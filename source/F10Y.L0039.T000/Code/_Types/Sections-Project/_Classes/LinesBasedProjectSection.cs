using System;
using System.Collections.Generic;


namespace F10Y.L0039.T000
{
    /// <summary>
    /// A project section with no structure other than a list of lines.
    /// </summary>
    public class LinesBasedProjectSection : ProjectSectionBase,
        ILinesBasedSection
    {
        public List<string> Lines { get; set; }
    }
}
