using System;


namespace F10Y.L0039
{
    public class ProjectNameOperator : IProjectNameOperator
    {
        #region Infrastructure

        public static IProjectNameOperator Instance { get; } = new ProjectNameOperator();


        private ProjectNameOperator()
        {
        }

        #endregion
    }
}
