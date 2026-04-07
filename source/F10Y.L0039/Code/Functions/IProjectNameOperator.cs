using System;

using F10Y.T0002;


namespace F10Y.L0039
{
    [FunctionsMarker]
    public partial interface IProjectNameOperator
    {
        string Get_ProjectName_FromProjectFilePath(string projectFilePath)
        {
            var project_FileNameStem = Instances.PathOperator.Get_FileNameStem(projectFilePath);

            var output = this.Get_ProjectName_FromProjectFileNameStem(project_FileNameStem);
            return output;
        }

        string Get_ProjectName_FromProjectFileNameStem(string project_FileNameStem)
            // The project name is just the file name stem of the project file.
            => project_FileNameStem;
    }
}
