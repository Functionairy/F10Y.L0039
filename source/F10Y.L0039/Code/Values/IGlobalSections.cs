using System;

using F10Y.T0003;


namespace F10Y.L0039
{
    [ValuesMarker]
    public partial interface IGlobalSections
    {
        /// <inheritdoc cref="IGlobalSectionGenerator.Get_ExtensibilityGlobals_Default()"/>
        ExtensibilityGlobalsGlobalSection ExtensibilityGlobals_Default => Instances.GlobalSectionGenerator.Get_ExtensibilityGlobals_Default();

        /// <inheritdoc cref="IGlobalSectionGenerator.Get_SolutionProperties_Default"/>
        LinesBasedGlobalSection SolutionProperties_Default => Instances.GlobalSectionGenerator.Get_SolutionProperties_Default();
    }
}
