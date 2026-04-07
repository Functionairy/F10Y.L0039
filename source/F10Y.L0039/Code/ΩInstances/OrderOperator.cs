using System;


namespace F10Y.L0039
{
    public class OrderOperator : IOrderOperator
    {
        #region Infrastructure

        public static IOrderOperator Instance { get; } = new OrderOperator();


        private OrderOperator()
        {
        }

        #endregion
    }
}
