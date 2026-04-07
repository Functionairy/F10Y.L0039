using System;


namespace F10Y.L0039
{
    public class GuidOperator : IGuidOperator
    {
        #region Infrastructure

        public static IGuidOperator Instance { get; } = new GuidOperator();


        private GuidOperator()
        {
        }

        #endregion
    }
}
