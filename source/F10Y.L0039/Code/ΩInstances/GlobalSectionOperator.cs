using System;


namespace F10Y.L0039
{
    public class GlobalSectionOperator : IGlobalSectionOperator
    {
        #region Infrastructure

        public static IGlobalSectionOperator Instance { get; } = new GlobalSectionOperator();


        private GlobalSectionOperator()
        {
        }

        #endregion
    }
}
