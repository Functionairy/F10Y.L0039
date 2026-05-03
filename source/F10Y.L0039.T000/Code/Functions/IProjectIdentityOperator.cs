using System;

using F10Y.T0002;


namespace F10Y.L0039.T000
{
    [FunctionsMarker]
    public partial interface IProjectIdentityOperator
    {
        Guid New()
            => Instances.GuidOperator.New();
    }
}
