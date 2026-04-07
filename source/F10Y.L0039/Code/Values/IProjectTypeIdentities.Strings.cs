using System;

using F10Y.T0003;


namespace F10Y.L0039.Strings
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
	/// Values from:
	/// * https://www.codeproject.com/Reference/720512/List-of-Visual-Studio-Project-Type-GUIDs
	/// * https://cakebuild.net/api/Cake.Incubator.Project/ProjectTypes/
	/// </remarks>
    [ValuesMarker]
    public partial interface IProjectTypeIdentities
    {
        /// <summary>
        /// <para><value>9A19103F-16F7-4668-BE54-9A1E7A4F7556</value></para>
        /// </summary>
        string CSharpProject => "9A19103F-16F7-4668-BE54-9A1E7A4F7556";

        /// <summary>
        /// <para><value>2150E333-8FDC-42A3-9474-1A3956D46DE8</value></para>
        /// </summary>
        string SolutionFolder => "2150E333-8FDC-42A3-9474-1A3956D46DE8";
    }
}
