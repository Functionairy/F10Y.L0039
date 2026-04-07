using System;


namespace F10Y.L0039
{
    public class VersionInformationOperator : IVersionInformationOperator
    {
        #region Infrastructure

        public static IVersionInformationOperator Instance { get; } = new VersionInformationOperator();


        private VersionInformationOperator()
        {
        }

        #endregion
    }
}
