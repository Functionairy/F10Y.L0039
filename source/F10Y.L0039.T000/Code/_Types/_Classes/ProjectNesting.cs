using System;

using F10Y.T0004;


namespace F10Y.L0039.T000
{
    [DataTypeMarker]
    public class ProjectNesting
    {
        public Guid ChildProjectIdentity { get; set; }
        public Guid ParentProjectIdentity { get; set; }
    }
}
