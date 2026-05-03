using System;


namespace F10Y.L0039.T000
{
    public class ProjectNestingOperator : IProjectNestingOperator
    {
        #region Infrastructure

        public static IProjectNestingOperator Instance { get; } = new ProjectNestingOperator();


        private ProjectNestingOperator()
        {
        }

        #endregion
    }
}
