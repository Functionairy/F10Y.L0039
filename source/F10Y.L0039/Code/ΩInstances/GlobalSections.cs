using System;


namespace F10Y.L0039
{
    public class GlobalSections : IGlobalSections
    {
        #region Infrastructure

        public static IGlobalSections Instance { get; } = new GlobalSections();


        private GlobalSections()
        {
        }

        #endregion
    }
}
