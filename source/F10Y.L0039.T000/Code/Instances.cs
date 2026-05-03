using System;


namespace F10Y.L0039.T000
{
    public static class Instances
    {
        public static L0000.IEqualityOperator EqualityOperator => L0000.EqualityOperator.Instance;
        public static L0000.IGuidOperator GuidOperator => L0000.GuidOperator.Instance;
        public static L0000.IHashCodeOperator HashCodeOperator => L0000.HashCodeOperator.Instance;
        public static IProjectFileReferenceOperator ProjectFileReferenceOperator => T000.ProjectFileReferenceOperator.Instance;
        public static IProjectIdentityOperator ProjectIdentityOperator => T000.ProjectIdentityOperator.Instance;
    }
}