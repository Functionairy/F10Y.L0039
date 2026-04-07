using System;

using F10Y.T0003;


namespace F10Y.L0039
{
    [ValuesMarker]
    public partial interface ITypeSpecifiers
    {
        #region Sections

        For_TypeSpecifiers.TypeSpecifier<ISection> For_ISection =>
            For_TypeSpecifiers.TypeSpecifier<ISection>.Instance;

        For_TypeSpecifiers.TypeSpecifier<ISection, ExtensibilityGlobalsGlobalSection> For_ExtensibilityGlobalsGlobalSection =>
            For_TypeSpecifiers.TypeSpecifier<ISection, ExtensibilityGlobalsGlobalSection>.Instance;

        For_TypeSpecifiers.TypeSpecifier<ISection, LinesBasedSection> For_LinesBasedSection =>
            For_TypeSpecifiers.TypeSpecifier<ISection, LinesBasedSection>.Instance;

        For_TypeSpecifiers.TypeSpecifier<ISection, LinesBasedGlobalSection> For_LinesBasedGlobalSection =>
            For_TypeSpecifiers.TypeSpecifier<ISection, LinesBasedGlobalSection>.Instance;

        For_TypeSpecifiers.TypeSpecifier<ISection, LinesBasedProjectSection> For_LinesBasedProjectSection =>
            For_TypeSpecifiers.TypeSpecifier<ISection, LinesBasedProjectSection>.Instance;

        For_TypeSpecifiers.TypeSpecifier<ISection, NestedProjectsGlobalSection> For_NestedProjectsGlobalSection =>
            For_TypeSpecifiers.TypeSpecifier<ISection, NestedProjectsGlobalSection>.Instance;

        For_TypeSpecifiers.TypeSpecifier<ISection, ProjectConfigurationPlatformsGlobalSection> For_ProjectConfigurationPlatformsGlobalSection =>
            For_TypeSpecifiers.TypeSpecifier<ISection, ProjectConfigurationPlatformsGlobalSection>.Instance;

        For_TypeSpecifiers.TypeSpecifier<ISection, SolutionConfigurationPlatformsGlobalSection> For_SolutionConfigurationPlatformsGlobalSection =>
            For_TypeSpecifiers.TypeSpecifier<ISection, SolutionConfigurationPlatformsGlobalSection>.Instance;

        #endregion
    }
}
