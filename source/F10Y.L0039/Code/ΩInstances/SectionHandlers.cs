using System;


namespace F10Y.L0039
{
    public class SectionHandlers : ISectionHandlers
    {
        #region Infrastructure

        public static ISectionHandlers Instance { get; } = new SectionHandlers();


        private SectionHandlers()
        {
        }

        #endregion
    }
}
