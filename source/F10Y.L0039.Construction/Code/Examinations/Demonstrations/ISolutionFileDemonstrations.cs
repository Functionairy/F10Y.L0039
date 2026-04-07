using System;
using System.Linq;
using System.Threading.Tasks;

using F10Y.T0006;


namespace F10Y.L0039.Construction
{
    [DemonstrationsMarker]
    public partial interface ISolutionFileDemonstrations :
        IScriptTextOutputInfrastructure_Implementation
    {
        async Task Add_ProjectReference_ToSolutionFile()
        {
            /// Inputs.

            var projectFilePath = @"C:\Code\DEV\Git\GitHub\Functionairy\F10Y.L0000\source\F10Y.L0000\F10Y.L0000.csproj";

            var input_SolutionFilePath = @"C:\Code\DEV\Git\GitHub\davidcoats\D8S.S0015.Private\source\D8S.S0015.Private.sln";
            var solutionFilePath = Instances.FilePaths.Output_SolutionFilePath;


            /// Run.

            var solutionFile = await Instances.SolutionFileOperator.Deserialize(input_SolutionFilePath);

            Instances.SolutionFileOperator.Update_ProjectRelativeFilePaths(
                solutionFilePath,
                solutionFile,
                input_SolutionFilePath);

            var projectReference = Instances.SolutionFileOperator.Add_ProjectReference_Idempotent(
                solutionFile,
                solutionFilePath,
                projectFilePath);

            await Instances.SolutionFileOperator.Serialize(
                solutionFilePath,
                solutionFile);

            this.Open(
                input_SolutionFilePath,
                solutionFilePath);


            /// Write output.

            var lines_ForOutput = Instances.EnumerableOperator.From("Add Project Reference - Demonstration")
                .Append_BlankLine()
                .Append($"{projectReference.ProjectName}: added project reference ({projectReference.ProjectIdentity})")
                ;

            await this.Write_Lines_AndOpen(lines_ForOutput);
        }

        async Task RoundTrip_SolutionFile()
        {
            /// Inputs.

            var input_SolutionFilePath = @"C:\Code\DEV\Git\GitHub\davidcoats\D8S.S0015.Private\source\D8S.S0015.Private.sln";
            var output_SolutionFilePath = Instances.FilePaths.Output_SolutionFilePath;


            /// Run.

            var solutionFile = await Instances.SolutionFileOperator.Deserialize(input_SolutionFilePath);

            await Instances.SolutionFileOperator.Serialize(
                output_SolutionFilePath,
                solutionFile);

            this.Open(
                input_SolutionFilePath,
                output_SolutionFilePath);

            await Instances.FileEqualityVerifier.Verify_FileEquality_AtByteLevel(
                input_SolutionFilePath,
                output_SolutionFilePath);
        }

        async Task Generate_New_VisualStudio2022_SolutionFile()
        {
            /// Inputs.
            
            var output_SolutionFilePath = Instances.FilePaths.Output_SolutionFilePath;


            /// Run.

            var solutionFile = Instances.SolutionFiles.New_2022;

            await Instances.SolutionFileOperator.Serialize(
                output_SolutionFilePath,
                solutionFile);

            this.Open(output_SolutionFilePath);
        }
    }
}
