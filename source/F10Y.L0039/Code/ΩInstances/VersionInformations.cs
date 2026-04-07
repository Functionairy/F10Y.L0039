using System;


namespace F10Y.L0039
{
    public class VersionInformations : IVersionInformations
    {
        #region Infrastructure

        public static IVersionInformations Instance { get; } = new VersionInformations();


        private VersionInformations()
        {
        }

        #endregion
    }
}
