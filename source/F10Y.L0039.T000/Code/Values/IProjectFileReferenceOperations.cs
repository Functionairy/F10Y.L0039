using System;

using F10Y.T0003;


namespace F10Y.L0039.T000
{
    [ValuesMarker]
    public partial interface IProjectFileReferenceOperations
    {
        Func<ProjectFileReference, bool> Equals(
            Guid projectTypeIdentity,
            string projectName)
            => projectFileReference => Instances.ProjectFileReferenceOperator.Equals(
                projectFileReference,
                projectTypeIdentity,
                projectName);
    }
}
