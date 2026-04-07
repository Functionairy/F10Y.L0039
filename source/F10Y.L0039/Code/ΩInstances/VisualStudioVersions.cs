using System;


namespace F10Y.L0039
{
    public class VisualStudioVersions : IVisualStudioVersions
    {
        #region Infrastructure

        public static IVisualStudioVersions Instance { get; } = new VisualStudioVersions();


        private VisualStudioVersions()
        {
        }

        #endregion
    }
}
