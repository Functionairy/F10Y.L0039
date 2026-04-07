using System;
using System.Collections.Generic;

using F10Y.T0004;


namespace F10Y.L0039.T000
{
    /// <summary>
    /// A section with no structure other than a list of lines.
    /// </summary>
    [DataTypeMarker]
    public class LinesBasedSection : SectionBase
    {
        public List<string> Lines { get; set; }
    }
}
