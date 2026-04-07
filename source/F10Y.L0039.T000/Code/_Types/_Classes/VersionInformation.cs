using System;

using F10Y.T0004;


namespace F10Y.L0039.T000
{
    /// <summary>
    /// Represents the data from the top of a Visual Studio solution file
    /// </summary>
    [DataTypeMarker]
    public class VersionInformation
    {
        /// <summary>
        /// Example: <inheritdoc cref="Documentation.Example_FormatInformation" path="/summary"/>
        /// </summary>
        public string FormatInformation { get; set; }

        /// <summary>
        /// Example: <inheritdoc cref="Documentation.Example_VersionDescription" path="/summary"/>
        /// </summary>
        public string VersionDescription { get; set; }

        /// <summary>
        /// Example: <inheritdoc cref="Documentation.Example_Version" path="/summary"/>
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Example: <inheritdoc cref="Documentation.Example_Version" path="/summary"/>
        /// </summary>
        public string MinimumVersion { get; set; }
    }
}
