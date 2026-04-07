using System;

using F10Y.T0002;


namespace F10Y.L0039
{
    [FunctionsMarker]
    public partial interface IProjectIdentityOperator
    {
        Guid New_ProjectIdentity()
            => Instances.GuidOperator.New();
    }
}
