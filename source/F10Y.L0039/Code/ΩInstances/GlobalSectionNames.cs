using System;


namespace F10Y.L0039
{
    public class GlobalSectionNames : IGlobalSectionNames
    {
        #region Infrastructure

        public static IGlobalSectionNames Instance { get; } = new GlobalSectionNames();


        private GlobalSectionNames()
        {
        }

        #endregion
    }
}
