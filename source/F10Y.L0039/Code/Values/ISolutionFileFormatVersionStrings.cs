using System;

using F10Y.T0003;


namespace F10Y.L0039
{
    [ValuesMarker]
    public partial interface ISolutionFileFormatVersionStrings
    {
        string Current => this.Version_12_00;

        string Version_12_00 => "12.00";
    }
}
