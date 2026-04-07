using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using F10Y.T0002;

using F10Y.L0039.Extensions;


namespace F10Y.L0039
{
    [FunctionsMarker]
    public partial interface ISerializationOperator
    {
        SolutionFile Deserialize_FromLines(IEnumerable<string> lines)
        {
            var solutionFile = new SolutionFile();

            var enumerator = lines.GetEnumerator();

            // Start.
            enumerator.MoveNext();

            // Ignore the first blank line.
            enumerator.MoveNext();

            var formatInformation = this.Get_CurrentLine_Trimmed(enumerator);

            var versionDescription = this.Get_NextLine_Trimmed(enumerator);

            var version = this.Get_NextLine_Trimmed(enumerator);

            var minimumVersion = this.Get_NextLine_Trimmed(enumerator);

            solutionFile.VersionInformation = new VersionInformation
            {
                FormatInformation = formatInformation,
                VersionDescription = versionDescription,
                Version = version,
                MinimumVersion = minimumVersion,
            };

            // Advance to the next line.
            enumerator.MoveNext();

            // Handle projects (if any).
            var projectFileReferences = this.Deserialize_ProjectFileReferences(enumerator);

            solutionFile.ProjectFileReferences.AddRange(projectFileReferences);

            // We should now be at the globals section.
            // Verify the solution file has a globals section.
            var trimmedLine = this.Get_CurrentLine_Trimmed(enumerator);

            this.Verify_IsGlobalLine(trimmedLine);

            // Handle global sections.
            var globalSections = this.Deserialize_GlobalSections(enumerator);

            solutionFile.GlobalSections.AddRange(globalSections);

            // Ensure there are no more lines finished.
            do
            {
                trimmedLine = this.Get_CurrentLine_Trimmed(enumerator);

                if (Instances.StringOperator.Is_NotNullOrEmpty(trimmedLine))
                {
                    throw new Exception($"Null or empty lines at end of file expected. Found: {trimmedLine}");
                }
            }
            while (enumerator.MoveNext());

            return solutionFile;
        }

        IGlobalSection[] Deserialize_GlobalSections(IEnumerator<string> enumerator)
        {
            var trimmedLine = this.Get_CurrentLine_Trimmed(enumerator);

            this.Verify_IsGlobalLine(trimmedLine);

            trimmedLine = this.Get_NextLine_Trimmed(enumerator);

            var globalSections = new List<IGlobalSection>();

            var isGlobalSectionLine = this.Is_GlobalSectionLine(trimmedLine);

            // Handle global sections.
            while (isGlobalSectionLine)
            {
                var globalSection = this.Deserialize_GlobalSection(enumerator);

                globalSections.Add(globalSection);

                trimmedLine = this.Get_CurrentLine_Trimmed(enumerator);

                isGlobalSectionLine = this.Is_GlobalSectionLine(trimmedLine);
            }

            enumerator.MoveNext();

            return globalSections.ToArray();
        }

        IGlobalSection Deserialize_GlobalSection(IEnumerator<string> enumerator)
        {
            var trimmedLine = this.Get_CurrentLine_Trimmed(enumerator);

            this.Verify_IsGlobalSectionLine(trimmedLine);

            var lines = this.Deserialize_Section(
                enumerator,
                this.Is_EndGlobalSectionLine);

            var globalSection = this.Deserialize_GlobalSection(lines);
            return globalSection;
        }

        IGlobalSection Deserialize_GlobalSection(LinesBasedSection lines)
        {
            IGlobalSection output = lines.Name switch
            {
                IGlobalSectionNames.ExtensibilityGlobals_Constant => this.Deserialize_ExtensibilityGlobals(lines),
                IGlobalSectionNames.NestedProjects_Constant => this.Deserialize_NestedProjects(lines),
                IGlobalSectionNames.ProjectConfigurationPlatforms_Constant => this.Deserialize_ProjectConfigurationPlatforms(lines),
                IGlobalSectionNames.SolutionConfigurationPlatforms_Constant => this.Deserialize_SolutionConfigurationPlatforms(lines),
                // Otherwise, just return the lines-based global section.
                _ => this.Deserialize_LinesBasedGlobalSection(lines)
            };

            return output;
        }

        ProjectConfigurationPlatformsGlobalSection Deserialize_ProjectConfigurationPlatforms(LinesBasedSection lines)
        {
            var output = new ProjectConfigurationPlatformsGlobalSection()
                .Fill_From(lines);

            foreach (var line in lines.Lines)
            {
                var projectBuildConfigurationMapping = this.Deserialize_ProjectBuildConfigurationMapping(line);

                output.ProjectBuildConfigurationMappings.Add(projectBuildConfigurationMapping);
            }

            return output;
        }

        ProjectBuildConfigurationMapping Deserialize_ProjectBuildConfigurationMapping(string projectBuildConfigurationMapping)
        {
            var equalsTokens = Instances.StringOperator.Split(
                Instances.Characters.Equals,
                projectBuildConfigurationMapping,
                StringSplitOptions.RemoveEmptyEntries)
                .Trim()
                .ToArray();

            var mapToken = equalsTokens[0];
            var mappedToken = equalsTokens[1];

            var mapTokens = Instances.StringOperator.Split(
                Instances.Characters.Period,
                mapToken,
                StringSplitOptions.RemoveEmptyEntries);

            var projectIdentityToken = mapTokens[0];
            var buildConfigurationPlatformToken = mapTokens[1];
            var projectConfigurationIndicatorToken = Instances.StringOperator.Join(Instances.Characters.Period, mapTokens[2..]); // Required for "Build.0".

            var projectIdentity = Instances.GuidOperator.Parse_ForSolutionFile(projectIdentityToken);
            var buildConfigurationPlatform = this.Deserialize_BuildConfigurationPlatform(buildConfigurationPlatformToken);
            var projectConfigurationIndicator = this.Deserialize_ProjectConfigurationIndicator(projectConfigurationIndicatorToken);

            var mappedSolutionBuildConfiguration = this.Deserialize_BuildConfigurationPlatform(mappedToken);

            var output = new ProjectBuildConfigurationMapping
            {
                ProjectIdentity = projectIdentity,
                BuildConfigurationPlatform = buildConfigurationPlatform,
                ProjectConfigurationIndicator = projectConfigurationIndicator,
                MappedBuildConfigurationPlatform = mappedSolutionBuildConfiguration,
            };

            return output;
        }

        ProjectConfigurationIndicator Deserialize_ProjectConfigurationIndicator(string projectConfigurationIndicator)
        {
            var output = projectConfigurationIndicator switch
            {
                "ActiveCfg" => ProjectConfigurationIndicator.ActiveCfg,
                "Build.0" => ProjectConfigurationIndicator.Build_0,
                _ => throw Instances.EnumerationOperator.Get_UnrecognizedEnumerationValueException<ProjectConfigurationIndicator>(projectConfigurationIndicator),
            };

            return output;
        }

        NestedProjectsGlobalSection Deserialize_NestedProjects(LinesBasedSection lines)
        {
            var output = new NestedProjectsGlobalSection()
                .Fill_From(lines);

            foreach (var line in lines.Lines)
            {
                var projectNesting = this.Deserialize_ProjectNesting(line);

                output.ProjectNestings.Add(projectNesting);
            }

            return output;
        }

        ProjectNesting Deserialize_ProjectNesting(string projectNesting)
        {
            var tokens = projectNesting.Split(Instances.Characters.Equals, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            var childProjectIdentityToken = tokens[0];
            var parentProjectIdentityToken = tokens[1];

            var childProjectIdentity = Instances.GuidOperator.Parse_ForSolutionFile(childProjectIdentityToken);
            var parentProjectIdentity = Instances.GuidOperator.Parse_ForSolutionFile(parentProjectIdentityToken);

            var output = new ProjectNesting
            {
                ChildProjectIdentity = childProjectIdentity,
                ParentProjectIdentity = parentProjectIdentity,
            };

            return output;
        }

        ExtensibilityGlobalsGlobalSection Deserialize_ExtensibilityGlobals(LinesBasedSection lines)
        {
            var output = new ExtensibilityGlobalsGlobalSection()
                .Fill_From(lines);

            foreach (var line in lines.Lines)
            {
                var tokens = line.Split(
                    Instances.Characters.Equals,
                    StringSplitOptions.RemoveEmptyEntries)
                    .Trim()
                    .ToArray();

                var key = tokens[0];
                var valueToken = tokens[1];

                switch (key)
                {
                    case "SolutionGuid":
                        var solutionIdentity = Instances.GuidOperator.Parse_ForSolutionFile(valueToken);
                        output.SolutionIdentity = solutionIdentity;
                        break;

                    default:
                        throw new Exception($"Unknown extensibility global key: '{key}'");
                }
            }

            return output;
        }

        SolutionConfigurationPlatformsGlobalSection Deserialize_SolutionConfigurationPlatforms(LinesBasedSection lines)
        {
            var output = new SolutionConfigurationPlatformsGlobalSection()
                .Fill_From(lines);

            foreach (var line in lines.Lines)
            {
                var solutionBuildConfigurationPlatform = this.Deserialize_SolutionBuildConfigurationPlatform(line);

                output.SolutionBuildConfigurationMappings.Add(solutionBuildConfigurationPlatform);
            }

            return output;
        }

        SolutionBuildConfigurationPlatform Deserialize_SolutionBuildConfigurationPlatform(string solutionBuildConfigurationPlatform)
        {
            var tokens = solutionBuildConfigurationPlatform.Split(Instances.Characters.Equals, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            var sourceToken = tokens[0];
            var destinationToken = tokens[1];

            var source = this.Deserialize_BuildConfigurationPlatform(sourceToken);
            var destination = this.Deserialize_BuildConfigurationPlatform(destinationToken);

            var output = new SolutionBuildConfigurationPlatform
            {
                Destination = destination,
                Source = source,
            };

            return output;
        }

        BuildConfigurationPlatform Deserialize_BuildConfigurationPlatform(string buildConfigurationPlatform)
        {
            var tokens = buildConfigurationPlatform.Split(
                Instances.Characters.Pipe,
                StringSplitOptions.RemoveEmptyEntries);

            var buildConfigurationToken = tokens[0];
            var platformToken = tokens[1];

            var buildConfiguration = this.Deserialize_BuildConfiguration(buildConfigurationToken);
            var platform = this.Deserialize_Platform(platformToken);

            var output = new BuildConfigurationPlatform
            {
                BuildConfiguration = buildConfiguration,
                Platform = platform,
            };

            return output;
        }

        BuildConfiguration Deserialize_BuildConfiguration(string buildConfiguration)
        {
            var output = buildConfiguration switch
            {
                "Debug" => BuildConfiguration.Debug,
                "Release" => BuildConfiguration.Release,
                _ => throw Instances.EnumerationOperator.Get_UnrecognizedEnumerationValueException<BuildConfiguration>(buildConfiguration),
            };

            return output;
        }

        Platform Deserialize_Platform(string platform)
        {
            var output = platform switch
            {
                "Any CPU" => Platform.AnyCPU,
                "x64" => Platform.x64,
                "x86" => Platform.x86,
                _ => throw Instances.EnumerationOperator.Get_UnrecognizedEnumerationValueException<Platform>(platform),
            };

            return output;
        }

        LinesBasedGlobalSection Deserialize_LinesBasedGlobalSection(LinesBasedSection lines)
        {
            var linesBasedGlobalSection = new LinesBasedGlobalSection
            {
                Lines = lines.Lines,
            }
            .Fill_From(lines);

            return linesBasedGlobalSection;
        }

        void Verify_IsGlobalSectionLine(string trimmedLine)
        {
            var isGlobalSectionLine = this.Is_GlobalSectionLine(trimmedLine);
            if (!isGlobalSectionLine)
            {
                throw new Exception($"Global section line expected. Found:\n{trimmedLine}");
            }
        }

        bool Is_EndGlobalSectionLine(string line)
        {
            var output = line.TrimStart().StartsWith(
                Instances.SolutionFileTokens.EndGlobalSection);

            return output;
        }

        bool Is_GlobalSectionLine(string line)
        {
            var output = line.TrimStart().StartsWith(
                Instances.SolutionFileTokens.GlobalSection);

            return output;
        }

        ProjectFileReference[] Deserialize_ProjectFileReferences(
            IEnumerator<string> enumerator)
        {
            var projectFileReferences = new List<ProjectFileReference>();

            var trimmedLine = this.Get_CurrentLine_Trimmed(enumerator);

            var isProjectLine = this.Is_ProjectLine(trimmedLine);

            // Handle projects.
            while (isProjectLine)
            {
                var projectFileReference = this.Deserialize_ProjectFileReference(enumerator);

                projectFileReferences.Add(projectFileReference);

                trimmedLine = this.Get_CurrentLine_Trimmed(enumerator);

                isProjectLine = this.Is_ProjectLine(trimmedLine);
            }

            // No move-next because project file reference has already done it.

            return projectFileReferences.ToArray();
        }

        ProjectFileReference Deserialize_ProjectFileReference(
            IEnumerator<string> enumerator)
        {
            var trimmedLine = this.Get_CurrentLine_Trimmed(enumerator);

            this.Verify_IsProjectLine(trimmedLine);

            var projectFileReference = this.Deserialize_ProjectFileReference(trimmedLine);

            trimmedLine = this.Get_NextLine_Trimmed(enumerator);

            var isProjectSectionLine = this.Is_ProjectSectionLine(trimmedLine);
            if (isProjectSectionLine)
            {
                var projectSections = this.Deserialize_ProjectSections(enumerator);

                projectFileReference.ProjectSections.AddRange(projectSections);
            }

            trimmedLine = this.Get_CurrentLine_Trimmed(enumerator);

            var isEndProjectLine = this.Is_EndProjectLine(trimmedLine);
            if (isEndProjectLine)
            {
                enumerator.MoveNext();

                return projectFileReference;
            }

            // Else, unknown.
            throw new Exception($"Expected end project line. Found:\n{trimmedLine}");
        }

        bool Is_EndProjectLine(string line)
        {
            var output = line.StartsWith(
                Instances.SolutionFileTokens.EndProject);

            return output;
        }

        IProjectSection[] Deserialize_ProjectSections(IEnumerator<string> enumerator)
        {
            var trimmedLine = this.Get_CurrentLine_Trimmed(enumerator);

            this.Verify_IsProjectSectionLine(trimmedLine);

            var projectSections = new List<IProjectSection>();

            var isProjectSectionLine = this.Is_ProjectSectionLine(trimmedLine);

            // Handle projects.
            while (isProjectSectionLine)
            {
                var projectSection = this.Deserialize_ProjectSection(enumerator);

                projectSections.Add(projectSection);

                trimmedLine = this.Get_CurrentLine_Trimmed(enumerator);

                isProjectSectionLine = this.Is_ProjectSectionLine(trimmedLine);
            }

            // No move-next, since project section has handled that.

            return projectSections.ToArray();
        }

        IProjectSection Deserialize_ProjectSection(IEnumerator<string> enumerator)
        {
            var trimmedLine = this.Get_CurrentLine_Trimmed(enumerator);

            this.Verify_IsProjectSectionLine(trimmedLine);

            var lines = this.Deserialize_Section(
                enumerator,
                this.Is_EndProjectSectionLine);

            var projectSection = this.Deserialize_ProjectSection(lines);
            return projectSection;
        }

        IProjectSection Deserialize_ProjectSection(LinesBasedSection lines)
        {
            IProjectSection output = lines.Name switch
            {
                // Everything is a lines-based project section for now.

                // Otherwise, just return the lines-based project section.
                _ => this.Deserialize_LinesBasedProjectSection(lines)
            };

            return output;
        }

        LinesBasedProjectSection Deserialize_LinesBasedProjectSection(LinesBasedSection lines)
        {
            var linesBasedGlobalSection = new LinesBasedProjectSection
            {
                Lines = lines.Lines,
            }
            .Fill_From(lines);

            return linesBasedGlobalSection;
        }

        LinesBasedSection Deserialize_Section(
            IEnumerator<string> enumerator,
            Func<string, bool> isEndSectionLine)
        {
            var trimmedLine = this.Get_CurrentLine_Trimmed(enumerator);

            // Parse the global section.
            var tokens = trimmedLine.Split('(', ')', '=');

            var sectionName = tokens[1];
            var preOrPostSolutionToken = tokens.Last()
                // Trim.
                .Trim();

            trimmedLine = this.Get_NextLine_Trimmed(enumerator);

            var isSectionEndLine = isEndSectionLine(trimmedLine);

            // First, deserialize to a lines-based global section. Then, convert to a specific global section type (if possible).
            var sectionLines = new List<string>();

            while (!isSectionEndLine)
            {
                // Trim the line.
                sectionLines.Add(trimmedLine);

                trimmedLine = this.Get_NextLine_Trimmed(enumerator);

                isSectionEndLine = isEndSectionLine(trimmedLine);
            }

            enumerator.MoveNext();

            var linesSection = new LinesBasedSection
            {
                Name = sectionName,
                PreOrPost = preOrPostSolutionToken,
                Lines = sectionLines,
            };

            return linesSection;
        }

        public bool Is_EndProjectSectionLine(string line)
        {
            var output = line.StartsWith(
                Instances.SolutionFileTokens.EndProjectSection);

            return output;
        }

        bool Is_ProjectSectionLine(string line)
        {
            var output = line.TrimStart().StartsWith(
                Instances.SolutionFileTokens.ProjectSection);

            return output;
        }

        void Verify_IsProjectSectionLine(string trimmedLine)
        {
            var isProjectSectionLine = this.Is_ProjectSectionLine(trimmedLine);
            if (!isProjectSectionLine)
            {
                throw new Exception($"Project section line expected. Found:\n{trimmedLine}");
            }
        }

        ProjectFileReference Deserialize_ProjectFileReference(string projectLine)
        {
            // Example project line:
            // Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "R5T.F0024.Construction", "R5T.F0024.Construction\R5T.F0024.Construction.csproj", "{388EFF42-1731-4882-9034-63D9D7427904}"

            // Split on quotes, and take tokens of interest.
            var tokens = projectLine.Split('"',
                // Keep empty entries.
                StringSplitOptions.None);

            var projectTypeGuidToken = tokens[1];
            var projectName = tokens[3];
            var projectRelativeFilePath = tokens[5];
            var projectGuidToken = tokens[7];

            var projectTypeIdentity = Instances.GuidOperator.Parse_ForSolutionFile(projectTypeGuidToken);
            var projectIdentity = Instances.GuidOperator.Parse_ForSolutionFile(projectGuidToken);

            var output = new ProjectFileReference
            {
                ProjectIdentity = projectIdentity,
                ProjectName = projectName,
                ProjectRelativeFilePath = projectRelativeFilePath,
                ProjectTypeIdentity = projectTypeIdentity,
            };

            return output;
        }

        void Verify_IsProjectLine(string trimmedLine)
        {
            var isProjectLine = this.Is_ProjectLine(trimmedLine);
            if (!isProjectLine)
            {
                throw new Exception($"Project line expected. Found:\n{trimmedLine}");
            }
        }

        bool Is_ProjectLine(string line)
        {
            var output = line.StartsWith(
                Instances.SolutionFileTokens.Project);

            return output;
        }

        void Verify_IsGlobalLine(string trimmedLine)
        {
            var isGlobalLine = this.Is_GlobalLine(trimmedLine);
            if (!isGlobalLine)
            {
                throw new Exception($"Global line expected. Found:\n{trimmedLine}");
            }
        }

        bool Is_GlobalLine(string line)
        {
            var output = line.StartsWith(
                Instances.SolutionFileTokens.Global);

            return output;
        }

        string Get_CurrentLine_Trimmed(IEnumerator<string> enumerator)
        {
            var trimmedLine = enumerator.Current.Trim();
            return trimmedLine;
        }

        string Get_NextLine_Trimmed(IEnumerator<string> enumerator)
        {
            enumerator.MoveNext();

            var trimmedLine = this.Get_CurrentLine_Trimmed(enumerator);
            return trimmedLine;
        }

        string Serialize_SolutionBuildConfigurationPlatform(SolutionBuildConfigurationPlatform solutionBuildConfigurationPlatform)
        {
            var output = $"{this.Serialize_BuildConfigurationPlatform(solutionBuildConfigurationPlatform.Source)} = {this.Serialize_BuildConfigurationPlatform(solutionBuildConfigurationPlatform.Destination)}";
            return output;
        }

        string Serialize_BuildConfiguration(BuildConfiguration buildConfiguration)
        {
            var output = buildConfiguration.ToString();
            return output;
        }

        string Serialize_BuildConfigurationPlatform(BuildConfigurationPlatform buildConfigurationPlatform)
        {
            var buildConfiguration = this.Serialize_BuildConfiguration(buildConfigurationPlatform.BuildConfiguration);
            var platform = this.Serialize_Platform(buildConfigurationPlatform.Platform);

            var output = $"{buildConfiguration}|{platform}";
            return output;
        }

        IEnumerable<string> Serialize_Section(
            ISection section,
            IEnumerable<string> body_Lines,
            string sectionStart,
            string sectionEnd)
        {
            var output = Instances.EnumerableOperator.From(
                $"{sectionStart}({section.Name}) = {section.PreOrPost}")
                .Append(body_Lines
                    // Prepend tab to each body line.
                    .Select(x => $"\t{x}"))
                .Append(sectionEnd)
                // Prepend tab to each line of the whole section.
                .Select(x => $"\t{x}")
                .ToArray();

            return output;
        }

        IEnumerable<string> Serialize_GlobalSection(IGlobalSection globalSection, IEnumerable<string> body_Lines)
            => this.Serialize_Section(
                globalSection,
                body_Lines,
                Instances.SolutionFileTokens.GlobalSection,
                Instances.SolutionFileTokens.EndGlobalSection);

        IEnumerable<string> Serialize_ProjectSection(IProjectSection projectSection, IEnumerable<string> body_Lines)
            => this.Serialize_Section(
                projectSection,
                body_Lines,
                Instances.SolutionFileTokens.ProjectSection,
                Instances.SolutionFileTokens.EndProjectSection);

        string Serialize_Platform(Platform platform)
        {
            var output = platform switch
            {
                Platform.AnyCPU => Instances.SolutionFileTokens.AnyCpu,
                Platform.x64 => Instances.SolutionFileTokens.x64,
                Platform.x86 => Instances.SolutionFileTokens.x86,
                _ => throw Instances.SwitchOperator.Get_DefaultCaseException(platform),
            };

            return output;
        }

        string Serialize_ProjectBuildConfigurationMapping(ProjectBuildConfigurationMapping mapping)
        {
            var projectIdentity = Instances.GuidOperator.ToString_ForSolutionFile(mapping.ProjectIdentity);
            var solutionBuildConfiguration = this.Serialize_BuildConfigurationPlatform(mapping.BuildConfigurationPlatform);
            var projectConfigurationIndicator = this.Serialize_ProjectConfigurationIndicator(mapping.ProjectConfigurationIndicator);
            var mappedSolutionBuildConfiguration = this.Serialize_BuildConfigurationPlatform(mapping.MappedBuildConfigurationPlatform);

            var output = $"{projectIdentity}.{solutionBuildConfiguration}.{projectConfigurationIndicator} = {mappedSolutionBuildConfiguration}";
            return output;
        }

        string Serialize_ProjectConfigurationIndicator(ProjectConfigurationIndicator indicator)
        {
            var output = indicator switch
            {
                ProjectConfigurationIndicator.ActiveCfg => Instances.SolutionFileTokens.ActiveCfg,
                ProjectConfigurationIndicator.Build_0 => Instances.SolutionFileTokens.Build_0,
                _ => throw Instances.SwitchOperator.Get_DefaultCaseException(indicator),
            };

            return output;
        }

        string Serialize_ProjectNesting(ProjectNesting projectNesting)
        {
            var output = $"{Instances.GuidOperator.ToString_ForSolutionFile(projectNesting.ChildProjectIdentity)} = {Instances.GuidOperator.ToString_ForSolutionFile(projectNesting.ParentProjectIdentity)}";
            return output;
        }

        string Serialize_ProjectFileReference_ToLine(ProjectFileReference projectFileReference)
        {
            var output = $"{Instances.SolutionFileTokens.Project}(\"{Instances.GuidOperator.ToString_ForSolutionFile(projectFileReference.ProjectTypeIdentity)}\") = \"{projectFileReference.ProjectName}\", \"{projectFileReference.ProjectRelativeFilePath}\", \"{Instances.GuidOperator.ToString_ForSolutionFile(projectFileReference.ProjectIdentity)}\"";
            return output;
        }

        IEnumerable<string> Serialize_ProjectSection(IProjectSection projectSection)
        {
            var output = Instances.SectionOperator.Serialize(projectSection);
            return output;
        }

        IEnumerable<string> Serialize_ProjectFileReference(ProjectFileReference projectFileReference)
        {
            var output = Instances.EnumerableOperator.From(this.Serialize_ProjectFileReference_ToLine(projectFileReference))
                .Append(projectFileReference.ProjectSections
                    .SelectMany(projectSection => this.Serialize_ProjectSection(projectSection)))
                .Append(Instances.SolutionFileTokens.EndProject)
                ;

            return output;
        }

        List<string> Serialize_ToLines(SolutionFile solutionFile)
        {
            var lines = Instances.ListOperator.From(
				// Add an initial blank line.
				"",
                solutionFile.VersionInformation.FormatInformation,
                solutionFile.VersionInformation.VersionDescription,
                solutionFile.VersionInformation.Version,
                solutionFile.VersionInformation.MinimumVersion
            );

            lines.AddRange(solutionFile.ProjectFileReferences
                .SelectMany(projectFileReference => this.Serialize_ProjectFileReference(projectFileReference)));

            lines.Add(Instances.SolutionFileTokens.Global);

            var orderedGlobalSections = Instances.OrderOperator.Order_GlobalSections(solutionFile.GlobalSections);

            foreach (var globalSection in orderedGlobalSections)
            {
                var sectionLines = Instances.SectionOperator.Serialize(globalSection);

                lines.AddRange(sectionLines);
            }

            lines.Add(Instances.SolutionFileTokens.EndGlobal);

            // Add an empty line?
            lines.Add(Instances.Strings.Empty);

            return lines;
        }

        async Task Serialize_ToFile(
            string solutionfilePath,
            SolutionFile solutionFile)
        {
            var lines = this.Serialize_ToLines(solutionFile);

            await Instances.FileOperator.Write_Lines_WithByteOrderMark(
                solutionfilePath,
                lines,
                Instances.Strings.NewLine_ForEnvironment);
        }
    }
}
