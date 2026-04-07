using System;

using F10Y.T0003;


namespace F10Y.L0039.T000
{
    [ValuesMarker]
    public partial interface IBuildConfigurationPlatforms
    {
        BuildConfigurationPlatform Debug_AnyCPU => new BuildConfigurationPlatform()
        {
            BuildConfiguration = BuildConfiguration.Debug,
            Platform = Platform.AnyCPU
        };

        BuildConfigurationPlatform Debug_X64 => new BuildConfigurationPlatform()
        {
            BuildConfiguration = BuildConfiguration.Debug,
            Platform = Platform.x64
        };

        BuildConfigurationPlatform Debug_X86 => new BuildConfigurationPlatform()
        {
            BuildConfiguration = BuildConfiguration.Debug,
            Platform = Platform.x86
        };

        BuildConfigurationPlatform Release_AnyCPU => new BuildConfigurationPlatform()
        {
            BuildConfiguration = BuildConfiguration.Release,
            Platform = Platform.AnyCPU
        };

        BuildConfigurationPlatform Release_X64 => new BuildConfigurationPlatform()
        {
            BuildConfiguration = BuildConfiguration.Release,
            Platform = Platform.x64
        };

        BuildConfigurationPlatform Release_X86 => new BuildConfigurationPlatform()
        {
            BuildConfiguration = BuildConfiguration.Release,
            Platform = Platform.x86
        };
    }
}
