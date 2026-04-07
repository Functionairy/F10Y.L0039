using System;
using System.Collections.Generic;


namespace F10Y.L0039.T000
{
    public interface ILinesBasedSection :
        ISection
    {
        public List<string> Lines { get; set; }
    }
}
