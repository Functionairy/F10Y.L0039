using System;

using F10Y.T0002;


namespace F10Y.L0039
{
    [FunctionsMarker]
    public partial interface IGlobalSectionGenerator
    {
        NestedProjectsGlobalSection NestedProjects_Constructor()
            => new()
            {
                Name = Instances.GlobalSectionNames.NestedProjects,
                PreOrPost = Instances.SolutionFileTokens.PreSolution
            };

        ExtensibilityGlobalsGlobalSection Get_ExtensibilityGlobals_Default(Guid solutionIdentity)
        {
            var extensibilityGlobalsSection = new ExtensibilityGlobalsGlobalSection()
            {
                Name = Instances.GlobalSectionNames.ExtensibilityGlobals,
                PreOrPost = Instances.SolutionFileTokens.PostSolution,
                SolutionIdentity = solutionIdentity,
            };

            return extensibilityGlobalsSection;
        }

        ExtensibilityGlobalsGlobalSection Get_ExtensibilityGlobals_Default()
        {
            var solutionIdentity = Instances.GuidOperator.New();

            var extensibilityGlobalsSection = this.Get_ExtensibilityGlobals_Default(solutionIdentity);
            return extensibilityGlobalsSection;
        }

        /// <summary>
        /// Gets the default <see cref="IGlobalSectionNames.SolutionProperties"/> global section.
        /// </summary>s
        LinesBasedGlobalSection Get_SolutionProperties_Default()
        {
            var solutionPropertiesGloblaSection = new LinesBasedGlobalSection()
            {
                Name = Instances.GlobalSectionNames.SolutionProperties,
                PreOrPost = Instances.SolutionFileTokens.PreSolution,
                Lines = Instances.ListOperator.From(
                    Instances.SolutionFileStrings.HideSolutionNode_FALSE
                )
            };

            return solutionPropertiesGloblaSection;
        }
    }
}
