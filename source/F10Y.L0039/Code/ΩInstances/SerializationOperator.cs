using System;


namespace F10Y.L0039
{
    public class SerializationOperator : ISerializationOperator
    {
        #region Infrastructure

        public static ISerializationOperator Instance { get; } = new SerializationOperator();


        private SerializationOperator()
        {
        }

        #endregion
    }
}
