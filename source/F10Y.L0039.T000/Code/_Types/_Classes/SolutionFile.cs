using System;
using System.Collections.Generic;

using F10Y.T0004;


namespace F10Y.L0039.T000
{
    [DataTypeMarker]
    public class SolutionFile
    {
        public VersionInformation VersionInformation { get; set; }

        public List<ProjectFileReference> ProjectFileReferences { get; } = new List<ProjectFileReference>();

        public List<IGlobalSection> GlobalSections { get; } = new List<IGlobalSection>();
    }
}
