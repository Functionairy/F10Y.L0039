using System;

using F10Y.T0003;


namespace F10Y.L0039.Strings
{
    /// <summary>
    /// Visual Studio solution file project type identity values.
    /// </summary>
    /// <remarks>
	/// Values from: <see href="https://cakebuild.net/api/Cake.Incubator.Project/ProjectTypes/"/>
    /// <para>
	/// Dead links:
    /// <list type="bullet">
    /// <item><see href="https://www.codeproject.com/Reference/720512/List-of-Visual-Studio-Project-Type-GUIDs"/></item>
    /// </list>
    /// </para>
    /// <inheritdoc cref="Documentation.Project_SelfDescription" path="/summary"/>
	/// </remarks>
    [ValuesMarker]
    public partial interface IProjectTypeIdentities
    {
        /// <summary>
        /// <para><value>9A19103F-16F7-4668-BE54-9A1E7A4F7556</value></para>
        /// </summary>
        const string CSharpProject_Constant = "9A19103F-16F7-4668-BE54-9A1E7A4F7556";

        /// <inheritdoc cref="CSharpProject_Constant"/>
        string CSharpProject => CSharpProject_Constant;

        /// <summary>
        /// <para><value>2150E333-8FDC-42A3-9474-1A3956D46DE8</value></para>
        /// </summary>
        const string SolutionFolder_Constant = "2150E333-8FDC-42A3-9474-1A3956D46DE8";

        /// <inheritdoc cref="SolutionFolder_Constant"/>
        string SolutionFolder => "2150E333-8FDC-42A3-9474-1A3956D46DE8";
    }
}
