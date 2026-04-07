using System;


namespace F10Y.L0039.T000
{
    public class BuildConfigurationPlatforms : IBuildConfigurationPlatforms
    {
        #region Infrastructure

        public static IBuildConfigurationPlatforms Instance { get; } = new BuildConfigurationPlatforms();


        private BuildConfigurationPlatforms()
        {
        }

        #endregion
    }
}
