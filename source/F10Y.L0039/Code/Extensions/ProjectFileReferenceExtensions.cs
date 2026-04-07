using System;
using System.Collections.Generic;


namespace F10Y.L0039.Extensions
{
    public static class ProjectFileReferenceExtensions
    {
        public static IEnumerable<ProjectFileReference> Where_IsNotSolutionFolder(this IEnumerable<ProjectFileReference> projectFileReferences)
            => Instances.ProjectFileReferenceOperator.Where_IsNotSolutionFolder(projectFileReferences);

        public static IEnumerable<ProjectFileReference> Where_IsSolutionFolder(this IEnumerable<ProjectFileReference> projectFileReferences)
            => Instances.ProjectFileReferenceOperator.Where_IsSolutionFolder(projectFileReferences);
    }
}
