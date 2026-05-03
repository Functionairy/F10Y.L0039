using System;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0039
{
    [FunctionsMarker]
    public partial interface IProjectIdentityOperator :
        T000.IProjectIdentityOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        T000.IProjectIdentityOperator _T000 => T000.ProjectIdentityOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
