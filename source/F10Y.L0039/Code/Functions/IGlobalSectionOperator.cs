using System;
using System.Linq;

using F10Y.T0002;


namespace F10Y.L0039
{
    [FunctionsMarker]
    public partial interface IGlobalSectionOperator
    {
        void Add_ProjectConfigurations(
            SolutionFile solutionFile,
            Guid project_Identity)
        {
            var solutionConfigurationPlatforms = Instances.GlobalSectionOperator.Acquire_SolutionConfigurationPlatforms(solutionFile);

            var projectConfigurationPlatforms = Instances.GlobalSectionOperator.Acquire_ProjectConfigurationPlatforms(solutionFile);

            Instances.GlobalSectionOperator.Add_ProjectConfigurations(
                projectConfigurationPlatforms,
                project_Identity,
                solutionConfigurationPlatforms);
        }

        void Add_ProjectConfigurations(
            ProjectConfigurationPlatformsGlobalSection projectConfigurationPlatforms,
            Guid project_Identity,
            SolutionConfigurationPlatformsGlobalSection solutionConfigurationPlatforms)
        {
            var indicators = new[]
            {
                ProjectConfigurationIndicator.ActiveCfg,
                ProjectConfigurationIndicator.Build_0,
            };

            foreach (var solutionBuildConfigurationMapping in solutionConfigurationPlatforms.SolutionBuildConfigurationMappings)
            {
                var mappedSolutionBuildConfiguration = solutionBuildConfigurationMapping.Source.BuildConfiguration == BuildConfiguration.Debug
                    ? Instances.BuildConfigurationPlatforms.Debug_AnyCPU
                    : Instances.BuildConfigurationPlatforms.Release_AnyCPU;

                foreach (var indicator in indicators)
                {
                    projectConfigurationPlatforms.ProjectBuildConfigurationMappings.Add(new ProjectBuildConfigurationMapping
                    {
                        ProjectIdentity = project_Identity,
                        BuildConfigurationPlatform = solutionBuildConfigurationMapping.Source,
                        MappedBuildConfigurationPlatform = mappedSolutionBuildConfiguration,
                        ProjectConfigurationIndicator = indicator,
                    });
                }
            }
        }

        T Acquire_GlobalSection<T>(
            SolutionFile solutionFile,
            string globalSectionName,
            Func<T> constructor)
            where T : IGlobalSection
        {
            var hasGlobalSection = this.Has_GlobalSection<T>(solutionFile, globalSectionName);
            if (!hasGlobalSection)
            {
                var globalSection = constructor();

                this.Add_GlobalSection_NonIdempotent(solutionFile, globalSection);

                return globalSection;
            }

            return hasGlobalSection;
        }

        ProjectConfigurationPlatformsGlobalSection Acquire_ProjectConfigurationPlatforms(SolutionFile solutionFile)
        {
            var output = this.Acquire_GlobalSection(
                solutionFile,
                Instances.GlobalSectionNames.ProjectConfigurationPlatforms,
                this.New_ProjectConfigurationPlatforms);

            return output;
        }

        SolutionConfigurationPlatformsGlobalSection Acquire_SolutionConfigurationPlatforms(SolutionFile solutionFile)
        {
            var output = this.Acquire_GlobalSection(
                solutionFile,
                Instances.GlobalSectionNames.SolutionConfigurationPlatforms,
                this.New_SolutionConfigurationPlatforms_Default);

            return output;
        }

        For_Has.Has<T> Has_GlobalSection<T>(
            SolutionFile solutionFile,
            string globalSectionName)
            where T : ISection
        {
            var outputOrDefault = solutionFile.GlobalSections
                .Where(x => x.Name == globalSectionName)
                .Cast<T>()
                .FirstOrDefault(); // Use more robust first-or-default. There should only be one section, but why enforce it?

            var output = Instances.HasOperator.From(outputOrDefault);
            return output;
        }

        /// <summary>
        /// Creates a new <see cref="SolutionConfigurationPlatformsGlobalSection"/> with the <see cref="IGlobalSectionNames.SolutionConfigurationPlatforms"/> and <see cref="ISolutionFileTokens.PreSolution"/>.
        /// </summary>
        SolutionConfigurationPlatformsGlobalSection New_SolutionConfigurationPlatforms()
        {
            var output = new SolutionConfigurationPlatformsGlobalSection
            {
                Name = Instances.GlobalSectionNames.SolutionConfigurationPlatforms,
                PreOrPost = Instances.SolutionFileTokens.PreSolution,
            };
            return output;
        }

        SolutionConfigurationPlatformsGlobalSection New_SolutionConfigurationPlatforms_Default()
        {
            var output = this.New_SolutionConfigurationPlatforms();

            this.Add_SolutionBuildConfigurationPlatforms_Default(output);

            return output;
        }

        /// <summary>
        /// Creates a new <see cref="ProjectConfigurationPlatformsGlobalSection"/> with the <see cref="IGlobalSectionNames.ProjectConfigurationPlatforms"/> and <see cref="ISolutionFileTokens.PostSolution"/>.
        /// </summary>
        public ProjectConfigurationPlatformsGlobalSection New_ProjectConfigurationPlatforms()
        {
            var output = new ProjectConfigurationPlatformsGlobalSection
            {
                Name = Instances.GlobalSectionNames.ProjectConfigurationPlatforms,
                PreOrPost = Instances.SolutionFileTokens.PostSolution,
            };

            return output;
        }

        void Add_GlobalSection_NonIdempotent(
            SolutionFile solutionFile,
            IGlobalSection globalSection)
        {
            solutionFile.GlobalSections.Add(globalSection);
        }

        void Add_SolutionBuildConfigurationPlatforms_Default(SolutionConfigurationPlatformsGlobalSection solutionConfigurationPlatformsGlobalSection)
        {
            this.Add_SolutionBuildConfigurationPlatforms_AnyCpu(solutionConfigurationPlatformsGlobalSection);
        }

        void Add_SolutionBuildConfigurationPlatforms_AnyCpu(SolutionConfigurationPlatformsGlobalSection solutionConfigurationPlatformsGlobalSection)
        {
            solutionConfigurationPlatformsGlobalSection.SolutionBuildConfigurationMappings.AddRange(new[]
            {
                new SolutionBuildConfigurationPlatform { Source = Instances.BuildConfigurationPlatforms.Debug_AnyCPU, Destination = Instances.BuildConfigurationPlatforms.Debug_AnyCPU },
                new SolutionBuildConfigurationPlatform { Source = Instances.BuildConfigurationPlatforms.Release_AnyCPU, Destination = Instances.BuildConfigurationPlatforms.Release_AnyCPU },
            });
        }
    }
}
