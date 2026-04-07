using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;


namespace F10Y.L0039
{
    [FunctionsMarker]
    public partial interface IProjectFileReferenceOperator
    {
        ProjectFileReference From(
            Guid project_Identity,
            string project_Name,
            string project_RelativeFilePath,
            Guid projectType_Identity)
            => new()
            {
                ProjectIdentity = project_Identity,
                ProjectName = project_Name,
                ProjectRelativeFilePath = project_RelativeFilePath,
                ProjectTypeIdentity = projectType_Identity
            };

        bool IsNot_SolutionFolder(ProjectFileReference projectFileReference)
        {
            var output = projectFileReference.ProjectTypeIdentity != Instances.ProjectTypeIdentities.SolutionFolder;
            return output;
        }

        bool Is_SolutionFolder(ProjectFileReference projectFileReference)
        {
            var output = projectFileReference.ProjectTypeIdentity == Instances.ProjectTypeIdentities.SolutionFolder;
            return output;
        }

        IEnumerable<ProjectFileReference> Where_IsNotSolutionFolder(IEnumerable<ProjectFileReference> projectFileReferences)
        {
            var output = projectFileReferences
                .Where(this.IsNot_SolutionFolder)
                ;

            return output;
        }

        IEnumerable<ProjectFileReference> Where_IsSolutionFolder(IEnumerable<ProjectFileReference> projectFileReferences)
        {
            var output = projectFileReferences
                .Where(this.Is_SolutionFolder)
                ;

            return output;
        }
    }
}
