using System;
using System.Linq;
using System.Threading.Tasks;

using F10Y.T0002;

using F10Y.L0039.Extensions;


namespace F10Y.L0039
{
    [FunctionsMarker]
    public partial interface ISolutionFileOperator
    {
        void Add_GlobalSection(
            SolutionFile solutionFile,
            IGlobalSection globalSection)
        {
            solutionFile.GlobalSections.Add(globalSection);
        }

        void Add_GlobalSection(
            SolutionFile solutionFile,
            Func<IGlobalSection> globalSectionConstructor)
        {
            var globalSection = globalSectionConstructor();

            this.Add_GlobalSection(solutionFile, globalSection);
        }

        /// <summary>
        /// Adds the project as a reference, using the relative file path of the project as its identity.
        /// </summary>
        ProjectFileReference Add_ProjectReference_Idempotent(
            SolutionFile solutionFile,
            string solutionFilePath,
            string projectFilePath,
            Guid project_Identity)
        {
            var project_RelativeFilePath = Instances.PathOperator.Get_ProjectFilePath_Relative(
                solutionFilePath,
                projectFilePath);

            var has_ProjectAlready = this.Has_Project_ByRelativeProjectFilePath(
                solutionFile,
                project_RelativeFilePath);

            if(has_ProjectAlready)
            {
                return has_ProjectAlready.Value;
            }

            // Else, if the project does not exist, add it.

            var project_Name = Instances.ProjectNameOperator.Get_ProjectName_FromProjectFilePath(projectFilePath);

            var projectType_Identity = Instances.ProjectTypeIdentityOperator.Get_ProjectTypeIdentity(projectFilePath);

            var projectFileReference = Instances.ProjectFileReferenceOperator.From(
                project_Identity,
                project_Name,
                project_RelativeFilePath,
                projectType_Identity);

            this.Add_ProjectReference_NonIdempotent(
                solutionFile,
                projectFileReference);

            // Add values to global sections.
            Instances.GlobalSectionOperator.Add_ProjectConfigurations(
                solutionFile,
                project_Identity);

            return projectFileReference;
        }

        /// <inheritdoc cref="Add_ProjectReference_Idempotent(T000.SolutionFile, string, string, Guid)"/>
        ProjectFileReference Add_ProjectReference_Idempotent(
            SolutionFile solutionFile,
            string solutionFilePath,
            string projectFilePath)
        {
            var project_Identity = Instances.ProjectIdentityOperator.New();

            var output = this.Add_ProjectReference_Idempotent(
                solutionFile,
                solutionFilePath,
                projectFilePath,
                project_Identity);

            return output;
        }

        void Add_ProjectReference_NonIdempotent(
            SolutionFile solutionFile,
            ProjectFileReference projectFileReference)
        {
            solutionFile.ProjectFileReferences.Add(projectFileReference);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Chooses <see cref="Has_Project_ByRelativeProjectFilePath(T000.SolutionFile, string)"/> as the default.
        /// </remarks>
        For_Has.Has<ProjectFileReference> Has_Project(
            SolutionFile solutionFile,
            string projectRelativeFilePath)
            => this.Has_Project_ByRelativeProjectFilePath(
                solutionFile,
                projectRelativeFilePath);

        For_Has.Has<ProjectFileReference> Has_Project_ByRelativeProjectFilePath(
            SolutionFile solutionFile,
            string projectRelativeFilePath)
        {
            var projectOrDefault = solutionFile.ProjectFileReferences
                .Where(x => x.ProjectRelativeFilePath == projectRelativeFilePath)
                // Use First() for robustness, even though there should not be multiple.
                .FirstOrDefault();

            var output = Instances.HasOperator.From(projectOrDefault);
            return output;
        }

        For_Has.Has<ProjectFileReference> Has_Project_ByProjectFilePath(
            SolutionFile solutionFile,
            string solutionFilePath,
            string projectFilePath)
        {
            var projectRelativeFilePath = Instances.PathOperator.Get_ProjectFilePath_Relative(
                solutionFilePath,
                projectFilePath);

            var output = this.Has_Project_ByRelativeProjectFilePath(
                solutionFile,
                projectRelativeFilePath);

            return output;
        }

        /// <inheritdoc cref="Get_ProjectReferenceFilePaths(SolutionFile, string)"/>
        async Task<string[]> Get_ProjectReferenceFilePaths(string solutionFilePath)
        {
            var projectReferenceFilePaths = await this.In_ReadContext(
                solutionFilePath,
                Instances.SolutionFileOperator.Get_ProjectReferenceFilePaths);

            return projectReferenceFilePaths;
        }

        /// <summary>
        /// Gets project file paths for all projects referenced by a solution file.
        /// </summary>
        string[] Get_ProjectReferenceFilePaths(
            SolutionFile solutionFile,
            string solutionFilePath)
        {
            var projectFileReferences = this.Get_ProjectFileReferences(solutionFile);

            var projectFileReferecePaths = projectFileReferences
                .Select(projectFileReference => Instances.PathOperator.Get_ProjectFilePath_Absolute(
                    solutionFilePath,
                    projectFileReference.ProjectRelativeFilePath))
                .ToArray();

            return projectFileReferecePaths;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_NonSolutionFolderProjectFileReferences(SolutionFile)"/>.
        /// <para><inheritdoc cref="Get_NonSolutionFolderProjectFileReferences(SolutionFile)" path="/summary"/></para>
        /// </summary>
        ProjectFileReference[] Get_ProjectFileReferences(SolutionFile solutionFile)
        {
            var output = this.Get_NonSolutionFolderProjectFileReferences(solutionFile);
            return output;
        }

        ProjectFileReference[] Get_NonSolutionFolderProjectFileReferences(SolutionFile solutionFile)
        {
            var output = solutionFile.ProjectFileReferences
                .Where_IsNotSolutionFolder()
                .ToArray();

            return output;
        }

        async Task<TOutput> In_ReadContext<TOutput>(string solutionFilePath,
            Func<SolutionFile, string, TOutput> solutionFileFunction)
        {
            var solutionFile = await this.Deserialize(solutionFilePath);

            var output = solutionFileFunction(solutionFile, solutionFilePath);
            return output;
        }

        /// <summary>
        /// Changes the project relative file paths
        /// </summary>
        void Update_ProjectRelativeFilePaths(
            string solutionFilePath_New,
            SolutionFile solutionFile,
            string solutionFilePath_Old)
        {
            foreach (var projectReference in solutionFile.ProjectFileReferences)
            {
                var projectFilePath = Instances.PathOperator.Get_ProjectFilePath_Absolute(
                    solutionFilePath_Old,
                    projectReference.ProjectRelativeFilePath);

                var projectFilePath_Relative_New = Instances.PathOperator.Get_ProjectFilePath_Relative(
                    solutionFilePath_New,
                    projectFilePath);

                projectReference.ProjectRelativeFilePath = projectFilePath_Relative_New;
            }
        }

        /// <summary>
        /// Changes the relative file paths in a solution file as required by a change to its file location.
        /// </summary>
        void Update_RelativeFilePaths(
            string solutionFilePath_New,
            SolutionFile solutionFile,
            string solutionFilePath_Old)
        {
            this.Update_ProjectRelativeFilePaths(
                solutionFilePath_New,
                solutionFile,
                solutionFilePath_Old);
        }

        void With_VersionInformation(
            SolutionFile solutionFile,
            VersionInformation versionInformation)
        {
            solutionFile.VersionInformation = versionInformation;
        }

        void With_VersionInformation(
            SolutionFile solutionFile,
            Func<VersionInformation> versionInformation_Provider)
        {
            var versionInformation = versionInformation_Provider();

            this.With_VersionInformation(
                solutionFile,
                versionInformation);
        }

        async Task<SolutionFile> Deserialize(string solutionFilePath)
        {
            var lines = await Instances.FileOperator.Read_AllLines(solutionFilePath);

            var solutionFile = Instances.SerializationOperator.Deserialize_FromLines(lines);
            return solutionFile;
        }

        Task Serialize(
            string solutionfilePath,
            SolutionFile solutionFile)
            => Instances.SerializationOperator.Serialize_ToFile(
                solutionfilePath,
                solutionFile);
    }
}
