using System;

using F10Y.T0002;


namespace F10Y.L0039
{
    [FunctionsMarker]
    public partial interface IVersionInformationOperator
    {
        /// <inheritdoc cref="Get_MinimumVisualStudioVersion_Line(Version)" path="/summary"/>
        /// <remarks>
        /// Forward of <see cref="Get_MinimumVisualStudioVersion_Line(Version)"/>.
        /// </remarks>
        string Get_MinimumVersion(Version minimumVisualStudioVersion)
            => this.Get_MinimumVisualStudioVersion_Line(minimumVisualStudioVersion);

        string Get_MinimumVisualStudioVersion_Line(Version minimumVisualStudioVersion)
        {
            var output = $"MinimumVisualStudioVersion = {minimumVisualStudioVersion}";
            return output;
        }

        /// <inheritdoc cref="Get_SolutionFileFormatInformation_Line(string)" path="/summary"/>
        /// <remarks>
        /// Forward of <see cref="Get_SolutionFileFormatInformation_Line(string)"/>.
        /// </remarks>
        string Get_FormatInformation(string solutionFileFormatVersionString)
            => this.Get_SolutionFileFormatInformation_Line(solutionFileFormatVersionString);

        /// <summary>
        /// Example: <inheritdoc cref="T000.Documentation.Example_FormatInformation"/>
        /// </summary>
        string Get_SolutionFileFormatInformation_Line(string solutionFileFormatVersionString)
        {
            var formatInformation = $"Microsoft Visual Studio Solution File, Format Version {solutionFileFormatVersionString}";
            return formatInformation;
        }

        /// <inheritdoc cref="Get_VisualStudioVersionDescription_Line(string)" path="/summary"/>
        /// <remarks>
        /// Forward of <see cref="Get_VisualStudioVersionDescription_Line(string)"/>.
        /// </remarks>
        string Get_VersionDescription(string visualStudioVersionString)
            => this.Get_VisualStudioVersionDescription_Line(visualStudioVersionString);

        string Get_VisualStudioVersionDescription_Line(string visualStudioVersionString)
        {
            var output = $"# Visual Studio Version {visualStudioVersionString}";
            return output;
        }

        /// <inheritdoc cref="Get_VisualStudioVersion_Line(Version)" path="/summary"/>
        /// <remarks>
        /// Forward of <see cref="Get_VisualStudioVersion_Line(Version)"/>.
        /// </remarks>
        string Get_VisualStudioVersion(Version visualStudioVersion)
            => this.Get_VisualStudioVersion_Line(visualStudioVersion);

        string Get_VisualStudioVersion_Line(Version visualStudioVersion)
        {
            var output = $"VisualStudioVersion = {visualStudioVersion}";
            return output;
        }
    }
}
