using System;
using System.Threading.Tasks;


namespace F10Y.L0039.Construction
{
    class Program
    {
        static async Task Main()
        {
            await Program

            #region Demonstrations

            .Demonstrations_SolutionFile()

            #endregion

            ;
        }

        static async Task Demonstrations_SolutionFile()
        {
            await SolutionFileDemonstrations.Instance
                .Add_ProjectReference_ToSolutionFile()
                //.RoundTrip_SolutionFile()
                //.Generate_New_VisualStudio2022_SolutionFile()
                ;
        }
    }
}