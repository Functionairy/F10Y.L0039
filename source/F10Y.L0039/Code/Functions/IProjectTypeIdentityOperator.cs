using System;

using F10Y.T0002;


namespace F10Y.L0039
{
    [FunctionsMarker]
    public partial interface IProjectTypeIdentityOperator
    {
        Guid Get_ProjectTypeIdentity(string projectFilePath)
        {
            // TODO: Just always return C# for now.
            var output = Instances.ProjectTypeIdentities.CSharpProject;
            return output;
        }
    }
}
