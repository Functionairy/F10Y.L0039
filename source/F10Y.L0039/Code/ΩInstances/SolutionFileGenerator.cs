using System;


namespace F10Y.L0039
{
    public class SolutionFileGenerator : ISolutionFileGenerator
    {
        #region Infrastructure

        public static ISolutionFileGenerator Instance { get; } = new SolutionFileGenerator();


        private SolutionFileGenerator()
        {
        }

        #endregion
    }
}
