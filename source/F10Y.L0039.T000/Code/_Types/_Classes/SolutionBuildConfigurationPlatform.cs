using System;

using F10Y.T0004;


namespace F10Y.L0039.T000
{
    /// <summary>
    /// {Source} = {Destination}
    /// Example: Debug|Any CPU = Debug|Any CPU
    /// </summary>
    [DataTypeMarker]
    public class SolutionBuildConfigurationPlatform
    {
        public BuildConfigurationPlatform Source { get; set; }
        public BuildConfigurationPlatform Destination { get; set; }
    }
}
