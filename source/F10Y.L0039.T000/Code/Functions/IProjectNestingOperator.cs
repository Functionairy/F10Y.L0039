using System;

using F10Y.T0002;


namespace F10Y.L0039.T000
{
    [FunctionsMarker]
    public partial interface IProjectNestingOperator
    {
        ProjectNesting New(
            Guid childProject_Identity,
            Guid parentProject_Identity)
            => new ProjectNesting()
            {
                ChildProjectIdentity = childProject_Identity,
                ParentProjectIdentity = parentProject_Identity,
            };
    }
}
