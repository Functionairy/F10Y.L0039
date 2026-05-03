using System;

using F10Y.T0003;
using F10Y.T0011;


namespace F10Y.L0039
{
    [ValuesMarker]
    public partial interface IProjectTypeIdentities
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        Strings.IProjectTypeIdentities _Strings => Strings.ProjectTypeIdentities.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="Strings.IProjectTypeIdentities.CSharpProject"/>
        private static readonly Lazy<Guid> CSharpProject_Lazy = new(() => Instances.GuidOperator.Parse(
            Strings.IProjectTypeIdentities.CSharpProject_Constant));

        /// <inheritdoc cref="CSharpProject_Lazy"/>
        Guid CSharpProject => CSharpProject_Lazy.Value;

        /// <inheritdoc cref="Strings.IProjectTypeIdentities.SolutionFolder"/>
        private static readonly Lazy<Guid> SolutionFolder_Lazy = new(() => Instances.GuidOperator.Parse(
            Strings.IProjectTypeIdentities.SolutionFolder_Constant));

        /// <inheritdoc cref="SolutionFolder_Lazy"/>
        Guid SolutionFolder => SolutionFolder_Lazy.Value;
    }
}
