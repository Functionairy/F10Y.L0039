using System;


namespace F10Y.L0039
{
    public class ProjectTypeIdentityOperator : IProjectTypeIdentityOperator
    {
        #region Infrastructure

        public static IProjectTypeIdentityOperator Instance { get; } = new ProjectTypeIdentityOperator();


        private ProjectTypeIdentityOperator()
        {
        }

        #endregion
    }
}
