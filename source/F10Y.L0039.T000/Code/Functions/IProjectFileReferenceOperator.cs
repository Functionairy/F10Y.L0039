using System;

using F10Y.T0002;


namespace F10Y.L0039.T000
{
    [FunctionsMarker]
    public partial interface IProjectFileReferenceOperator
    {
        bool Equals(
            ProjectFileReference projectFileReference,
            Guid projectTypeIdentity,
            string projectName)
        {
            var output = true
                && projectFileReference.ProjectTypeIdentity == projectTypeIdentity
                && projectFileReference.ProjectName == projectName
                ;

            return output;
        }

        bool Equals_IdentityBased(
            ProjectFileReference x,
            ProjectFileReference y)
            => Instances.EqualityOperator.Are_Equal(
                x.ProjectIdentity,
                y.ProjectIdentity);

        ProjectFileReference From(
            string project_Name,
            string project_RelativeFilePath,
            Guid projectType_Identity)
        {
            var project_Identity = Instances.ProjectIdentityOperator.New();

            var output = this.From(
                project_Identity,
                project_Name,
                project_RelativeFilePath,
                projectType_Identity);

            return output;
        }

        ProjectFileReference From(
            Guid project_Identity,
            string project_Name,
            string project_RelativeFilePath,
            Guid projectType_Identity)
            => new ProjectFileReference()
            {
                ProjectIdentity = project_Identity,
                ProjectName = project_Name,
                ProjectRelativeFilePath = project_RelativeFilePath,
                ProjectTypeIdentity = projectType_Identity
            };

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
