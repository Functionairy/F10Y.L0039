using System;

using F10Y.T0003;


namespace F10Y.L0039
{
    [ValuesMarker]
    public partial interface ISolutionFiles
    {
        /// <inheritdoc cref="ISolutionFileGenerator.New_2022"/>
        SolutionFile New_2022 => Instances.SolutionFileGenerator.New_2022();
    }
}
