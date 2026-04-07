using System;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0039
{
    [FunctionsMarker]
    public partial interface IPathOperator :
        L0000.IPathOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        L0000.IPathOperator _L0000 => L0000.PathOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public string Get_ProjectFilePath_Absolute(
            string solutionFilePath,
            string projectFilePath_Relative)
        {
            var solutionDirectoryPath = this.Get_ParentDirectoryPath_ForFile(solutionFilePath);

            var projectFilePath = this.Combine(
                solutionDirectoryPath,
                projectFilePath_Relative);

            return projectFilePath;
        }

        string Get_ProjectFilePath_Relative(
            string solutionFilePath,
            string projectFilePath_Absolute)
        {
            var solutionDirectoryPath = this.Get_ParentDirectoryPath_ForFile(solutionFilePath);

            var output = this.Get_RelativePath(
                solutionDirectoryPath,
                projectFilePath_Absolute);

            return output;
        }
    }
}
