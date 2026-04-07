using System;

using F10Y.T0003;


namespace F10Y.L0039
{
    [ValuesMarker]
    public partial interface IVisualStudioVersions
    {
        Version MinimumVersion_Default => new(10, 0, 40219, 1);

        Version Version_16 => new(16, 0, 32002, 261);
        Version Version_17 => new(17, 2, 32630, 192);

        Version VisualStudio_2019 => this.Version_16;
        Version VisualStudio_2022 => this.Version_17;
    }
}
