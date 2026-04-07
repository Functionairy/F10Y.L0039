using System;

using F10Y.T0002;


namespace F10Y.L0039.T000
{
    [FunctionsMarker]
    public partial interface IProjectFileReferenceOperator
    {
        bool Equals_IdentityBased(
            ProjectFileReference x,
            ProjectFileReference y)
            => Instances.EqualityOperator.Are_Equal(
                x.ProjectIdentity,
                y.ProjectIdentity);

        /// <summary>
        /// Uses the <see cref="ProjectFileReference.ProjectIdentity"/> value.
        /// </summary>
        int Get_HashCode_IdentityBased(ProjectFileReference obj)
            => Instances.HashCodeOperator.Get_HashCode(obj.ProjectIdentity);

        string To_String(ProjectFileReference projectFileReference)
        {
            var representation = $"{projectFileReference.ProjectName}: {projectFileReference.ProjectRelativeFilePath}";
            return representation;
        }
    }
}
