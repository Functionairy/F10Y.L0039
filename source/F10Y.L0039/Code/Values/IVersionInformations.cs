using System;

using F10Y.T0003;


namespace F10Y.L0039
{
    [ValuesMarker]
    public partial interface IVersionInformations
    {
        VersionInformation Default_2019 => new()
        {
            FormatInformation = Instances.VersionInformationOperator.Get_FormatInformation(
                Instances.SolutionFileFormatVersionStrings.Version_12_00),
            MinimumVersion = Instances.VersionInformationOperator.Get_MinimumVersion(
                Instances.VisualStudioVersions.MinimumVersion_Default),
            Version = Instances.VersionInformationOperator.Get_VisualStudioVersion(
                Instances.VisualStudioVersions.VisualStudio_2019),
            VersionDescription = Instances.VersionInformationOperator.Get_VersionDescription(
                Instances.VisualStudioVersionStrings.Version_16)
        };

        VersionInformation Default_2022 => new()
        {
            FormatInformation = Instances.VersionInformationOperator.Get_FormatInformation(
                Instances.SolutionFileFormatVersionStrings.Version_12_00),
            MinimumVersion = Instances.VersionInformationOperator.Get_MinimumVersion(
                Instances.VisualStudioVersions.MinimumVersion_Default),
            Version = Instances.VersionInformationOperator.Get_VisualStudioVersion(
                Instances.VisualStudioVersions.VisualStudio_2022),
            VersionDescription = Instances.VersionInformationOperator.Get_VersionDescription(
                Instances.VisualStudioVersionStrings.Version_17)
        };
    }
}
