using System;


namespace F10Y.L0039
{
    public class SolutionFileTokens : ISolutionFileTokens
    {
        #region Infrastructure

        public static ISolutionFileTokens Instance { get; } = new SolutionFileTokens();


        private SolutionFileTokens()
        {
        }

        #endregion
    }
}
