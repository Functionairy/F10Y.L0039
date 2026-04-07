using System;


namespace F10Y.L0039
{
    public class SolutionFileFormatVersionStrings : ISolutionFileFormatVersionStrings
    {
        #region Infrastructure

        public static ISolutionFileFormatVersionStrings Instance { get; } = new SolutionFileFormatVersionStrings();


        private SolutionFileFormatVersionStrings()
        {
        }

        #endregion
    }
}
