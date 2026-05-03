using System;


namespace F10Y.L0039.T000
{
    public class ProjectFileReferenceOperations : IProjectFileReferenceOperations
    {
        #region Infrastructure

        public static IProjectFileReferenceOperations Instance { get; } = new ProjectFileReferenceOperations();


        private ProjectFileReferenceOperations()
        {
        }

        #endregion
    }
}
