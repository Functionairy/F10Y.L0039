using System;


namespace F10Y.L0039
{
    public class GlobalSectionGenerator : IGlobalSectionGenerator
    {
        #region Infrastructure

        public static IGlobalSectionGenerator Instance { get; } = new GlobalSectionGenerator();


        private GlobalSectionGenerator()
        {
        }

        #endregion
    }
}
