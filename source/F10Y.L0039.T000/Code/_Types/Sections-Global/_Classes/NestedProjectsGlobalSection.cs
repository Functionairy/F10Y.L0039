using System;
using System.Collections.Generic;

using F10Y.T0004;


namespace F10Y.L0039.T000
{
    [DataTypeMarker]
    public class NestedProjectsGlobalSection : GlobalSectionBase
    {
        public List<ProjectNesting> ProjectNestings { get; } = new List<ProjectNesting>();
    }
}
