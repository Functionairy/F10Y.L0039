using System;


namespace F10Y.L0039
{
    public class SolutionFileOperator : ISolutionFileOperator
    {
        #region Infrastructure

        public static ISolutionFileOperator Instance { get; } = new SolutionFileOperator();


        private SolutionFileOperator()
        {
        }

        #endregion
    }
}
