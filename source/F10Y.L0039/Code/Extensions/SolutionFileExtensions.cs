using System;


namespace F10Y.L0039.Extensions
{
    public static class SolutionFileExtensions
    {
        public static SolutionFile Add_GlobalSection(this SolutionFile solutionFile,
            IGlobalSection globalSection)
        {
            Instances.SolutionFileOperator.Add_GlobalSection(solutionFile, globalSection);

            return solutionFile;
        }

        public static SolutionFile Add_GlobalSection(this SolutionFile solutionFile,
            Func<IGlobalSection> globalSectionConstructor)
        {
            Instances.SolutionFileOperator.Add_GlobalSection(solutionFile, globalSectionConstructor);

            return solutionFile;
        }

        public static SolutionFile With_VersionInformation(this SolutionFile solutionFile,
            VersionInformation versionInformation)
        {
            Instances.SolutionFileOperator.With_VersionInformation(solutionFile, versionInformation);

            return solutionFile;
        }

        public static SolutionFile With_VersionInformation(this SolutionFile solutionFile,
            Func<VersionInformation> versionInformationConstructor)
        {
            Instances.SolutionFileOperator.With_VersionInformation(solutionFile, versionInformationConstructor);

            return solutionFile;
        }
    }
}
