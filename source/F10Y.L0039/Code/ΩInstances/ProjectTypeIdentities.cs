using System;


namespace F10Y.L0039
{
    public class ProjectTypeIdentities : IProjectTypeIdentities
    {
        #region Infrastructure

        public static IProjectTypeIdentities Instance { get; } = new ProjectTypeIdentities();


        private ProjectTypeIdentities()
        {
        }

        #endregion
    }
}


namespace F10Y.L0039.Strings
{
    public class ProjectTypeIdentities : IProjectTypeIdentities
    {
        #region Infrastructure

        public static IProjectTypeIdentities Instance { get; } = new ProjectTypeIdentities();


        private ProjectTypeIdentities()
        {
        }

        #endregion
    }
}