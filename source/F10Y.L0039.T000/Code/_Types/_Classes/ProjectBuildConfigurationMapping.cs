using System;

using F10Y.T0004;


namespace F10Y.L0039.T000
{
    [DataTypeMarker]
    public class ProjectBuildConfigurationMapping
    {
        public Guid ProjectIdentity { get; set; }
        public BuildConfigurationPlatform BuildConfigurationPlatform { get; set; }
        public ProjectConfigurationIndicator ProjectConfigurationIndicator { get; set; }
        public BuildConfigurationPlatform MappedBuildConfigurationPlatform { get; set; }
    }
}
