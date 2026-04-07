using System;


namespace F10Y.L0039
{
    public class SectionOperator : ISectionOperator
    {
        #region Infrastructure

        public static ISectionOperator Instance { get; } = new SectionOperator();


        private SectionOperator()
        {
        }

        #endregion
    }
}
