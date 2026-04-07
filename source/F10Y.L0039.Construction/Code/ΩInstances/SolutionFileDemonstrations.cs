using System;


namespace F10Y.L0039.Construction
{
    public class SolutionFileDemonstrations : ISolutionFileDemonstrations
    {
        #region Infrastructure

        public static ISolutionFileDemonstrations Instance { get; } = new SolutionFileDemonstrations();


        private SolutionFileDemonstrations()
        {
        }

        #endregion
    }
}
