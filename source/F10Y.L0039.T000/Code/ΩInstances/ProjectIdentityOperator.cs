using System;


namespace F10Y.L0039.T000
{
    public class ProjectIdentityOperator : IProjectIdentityOperator
    {
        #region Infrastructure

        public static IProjectIdentityOperator Instance { get; } = new ProjectIdentityOperator();


        private ProjectIdentityOperator()
        {
        }

        #endregion
    }
}
