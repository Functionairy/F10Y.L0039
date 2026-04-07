using System;

using F10Y.T0003;


namespace F10Y.L0039
{
    [ValuesMarker]
    public partial interface IGlobalSectionNames
    {
        /// <summary>
        /// <para><value>ExtensibilityGlobals</value></para>
        /// </summary>
        const string ExtensibilityGlobals_Constant = "ExtensibilityGlobals";

        /// <inheritdoc cref="ExtensibilityGlobals_Constant"/>
        string ExtensibilityGlobals => ExtensibilityGlobals_Constant;

        /// <summary>
        /// <para><value>NestedProjects</value></para>
        /// </summary>
        const string NestedProjects_Constant = "NestedProjects";

        /// <inheritdoc cref="NestedProjects_Constant"/>
        string NestedProjects => NestedProjects_Constant;

        /// <summary>
        /// <para><value>ProjectConfigurationPlatforms</value></para>
        /// </summary>
        const string ProjectConfigurationPlatforms_Constant = "ProjectConfigurationPlatforms";

        /// <inheritdoc cref="ProjectConfigurationPlatforms_Constant"/>
        string ProjectConfigurationPlatforms => ProjectConfigurationPlatforms_Constant;

        /// <summary>
        /// <para><value>SolutionConfigurationPlatforms</value></para>
        /// </summary>
        const string SolutionConfigurationPlatforms_Constant = "SolutionConfigurationPlatforms";

        /// <inheritdoc cref="SolutionConfigurationPlatforms_Constant"/>
        string SolutionConfigurationPlatforms => SolutionConfigurationPlatforms_Constant;

        /// <summary>
        /// <para><value>SolutionProperties</value></para>
        /// </summary>
        const string SolutionProperties_Constant = "SolutionProperties";

        /// <inheritdoc cref="SolutionProperties_Constant"/>
        string SolutionProperties => SolutionProperties_Constant;
    }
}
