using System;

using F10Y.T0003;


namespace F10Y.L0039
{
    [ValuesMarker]
    public partial interface ISolutionFileTokens
    {
#pragma warning disable IDE1006 // Naming Styles

        string ActiveCfg => "ActiveCfg";
        string Build_0 => "Build.0";

        string AnyCpu => "Any CPU";
        string x64 => "x64";
        string x86 => "x86";

        string SolutionGuid => "SolutionGuid";

        string Global => "Global";
        string EndGlobal => "EndGlobal";

        string GlobalSection => "GlobalSection";
        string EndGlobalSection => "EndGlobalSection";

        string Project => "Project";
        string EndProject => "EndProject";

        string ProjectSection => "ProjectSection";
        string EndProjectSection => "EndProjectSection";

        string PreSolution => "preSolution";
        string PostSolution => "postSolution";
        string PreProject => "preProject";
        string PostProject => "postProject";

#pragma warning restore IDE1006 // Naming Styles
    }
}
