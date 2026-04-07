using System;


namespace F10Y.L0039
{
    public class VisualStudioVersionStrings : IVisualStudioVersionStrings
    {
        #region Infrastructure

        public static IVisualStudioVersionStrings Instance { get; } = new VisualStudioVersionStrings();


        private VisualStudioVersionStrings()
        {
        }

        #endregion
    }
}
