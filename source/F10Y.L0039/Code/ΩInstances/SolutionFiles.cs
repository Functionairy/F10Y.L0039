using System;


namespace F10Y.L0039
{
    public class SolutionFiles : ISolutionFiles
    {
        #region Infrastructure

        public static ISolutionFiles Instance { get; } = new SolutionFiles();


        private SolutionFiles()
        {
        }

        #endregion
    }
}
