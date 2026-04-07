using System;

using F10Y.T0004;


namespace F10Y.L0039.T000
{
    /// <summary>
    /// Defines a common abstraction for Visual Studio solution file global sections.
    /// </summary>
    [DataTypeMarker]
    public interface ISection
    {
        string Name { get; }
        string PreOrPost { get; }
    }
}
