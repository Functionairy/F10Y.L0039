using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;


namespace F10Y.L0039
{
    [FunctionsMarker]
    public partial interface ISectionHandlers
    {
        IEnumerable<string> Serialize(ExtensibilityGlobalsGlobalSection section)
        {
            var body_Lines = Instances.EnumerableOperator.From($"{Instances.SolutionFileTokens.SolutionGuid} = {Instances.GuidOperator.ToString_ForSolutionFile(section.SolutionIdentity)}");

            var output = Instances.SerializationOperator.Serialize_GlobalSection(
                section,
                body_Lines);

            return output;
        }

        IEnumerable<string> Serialize(LinesBasedGlobalSection section)
        {
            var body_Lines = section.Lines;

            var output = Instances.SerializationOperator.Serialize_GlobalSection(
                section,
                body_Lines);

            return output;
        }

        IEnumerable<string> Serialize(LinesBasedProjectSection section)
        {
            var body_Lines = section.Lines;

            var output = Instances.SerializationOperator.Serialize_ProjectSection(
                section,
                body_Lines);

            return output;
        }

        IEnumerable<string> Serialize(NestedProjectsGlobalSection section)
        {
            var body_Lines = section.ProjectNestings
                .Select(Instances.SerializationOperator.Serialize_ProjectNesting)
                ;

            var output = Instances.SerializationOperator.Serialize_GlobalSection(
                section,
                body_Lines);

            return output;
        }

        IEnumerable<string> Serialize(ProjectConfigurationPlatformsGlobalSection section)
        {
            var body_Lines = section.ProjectBuildConfigurationMappings
                .Select(Instances.SerializationOperator.Serialize_ProjectBuildConfigurationMapping)
                ;

            var output = Instances.SerializationOperator.Serialize_GlobalSection(
                section,
                body_Lines);

            return output;
        }

        IEnumerable<string> Serialize(SolutionConfigurationPlatformsGlobalSection section)
        {
            var body_Lines = section.SolutionBuildConfigurationMappings
                .Select(Instances.SerializationOperator.Serialize_SolutionBuildConfigurationPlatform)
                ;

            var output = Instances.SerializationOperator.Serialize_GlobalSection(
                section,
                body_Lines);

            return output;
        }
    }
}
