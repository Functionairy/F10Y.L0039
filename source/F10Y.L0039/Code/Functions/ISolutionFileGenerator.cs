using System;

using F10Y.T0002;

using F10Y.L0039.Extensions;


namespace F10Y.L0039
{
    [FunctionsMarker]
    public partial interface ISolutionFileGenerator
    {
        SolutionFile New_2022()
        {
            var solutionFile = new SolutionFile()
                .With_VersionInformation(Instances.VersionInformations.Default_2022)
                .Add_GlobalSection(Instances.GlobalSections.SolutionProperties_Default)
                .Add_GlobalSection(Instances.GlobalSections.ExtensibilityGlobals_Default)
                ;

            return solutionFile;
        }

        /// <summary>
        /// Chooses <see cref="New_2022()"/> as the default.
        /// </summary>
        SolutionFile New()
        {
            var solutionFile = this.New_2022();
            return solutionFile;
        }
    }
}
