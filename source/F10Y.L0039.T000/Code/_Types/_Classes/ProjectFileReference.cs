using System;
using System.Collections.Generic;

using F10Y.T0004;


namespace F10Y.L0039.T000
{
    [DataTypeMarker]
    public class ProjectFileReference
    {
        public Guid ProjectTypeIdentity { get; set; }
        public string ProjectName { get; set; }
        public string ProjectRelativeFilePath { get; set; }
        public Guid ProjectIdentity { get; set; }

        public List<IProjectSection> ProjectSections { get; } = new List<IProjectSection>();


        public override string ToString()
            => Instances.ProjectFileReferenceOperator.To_String(this);
    }
}
