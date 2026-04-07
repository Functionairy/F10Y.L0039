using System;
using System.Collections.Generic;

using F10Y.T0004;


namespace F10Y.L0039.T000
{
    [DataTypeMarker]
    public class SolutionConfigurationPlatformsGlobalSection : GlobalSectionBase
    {
        public List<SolutionBuildConfigurationPlatform> SolutionBuildConfigurationMappings { get; } = new List<SolutionBuildConfigurationPlatform>();
    }
}
