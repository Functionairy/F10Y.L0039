using System;


namespace F10Y.L0039.Construction
{
    public static class Instances
    {
        public static L0001.IEnumerableOperator EnumerableOperator => L0001.EnumerableOperator.Instance;
        public static L0001.L000.IFileEqualityVerifier FileEqualityVerifier => L0001.L000.FileEqualityVerifier.Instance;
        public static L0004.L000.IFilePaths FilePaths => L0004.L000.FilePaths.Instance;
        public static ISolutionFileOperator SolutionFileOperator => L0039.SolutionFileOperator.Instance;
        public static ISolutionFiles SolutionFiles => L0039.SolutionFiles.Instance;
    }
}