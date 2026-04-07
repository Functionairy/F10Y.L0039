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
        public Guid CSharpProject => Instances.GuidOperator.Parse(_Strings.CSharpProject);

        /// <inheritdoc cref="Strings.IProjectTypeIdentities.SolutionFolder"/>
        public Guid SolutionFolder => Instances.GuidOperator.Parse(_Strings.SolutionFolder);
    }
}
