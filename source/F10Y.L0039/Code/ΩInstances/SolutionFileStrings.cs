using System;


namespace F10Y.L0039
{
    public class SolutionFileStrings : ISolutionFileStrings
    {
        #region Infrastructure

        public static ISolutionFileStrings Instance { get; } = new SolutionFileStrings();


        private SolutionFileStrings()
        {
        }

        #endregion
    }
}
