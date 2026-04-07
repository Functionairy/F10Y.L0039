using System;


namespace F10Y.L0039.T000
{
    public class ProjectFileReferenceOperator : IProjectFileReferenceOperator
    {
        #region Infrastructure

        public static IProjectFileReferenceOperator Instance { get; } = new ProjectFileReferenceOperator();


        private ProjectFileReferenceOperator()
        {
        }

        #endregion
    }
}
