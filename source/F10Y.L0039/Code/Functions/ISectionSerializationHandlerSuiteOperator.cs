using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0039
{
    [FunctionsMarker]
    public partial interface ISectionSerializationHandlerSuiteOperator :
        N001.ISectionSerializationHandlerSuiteOperator,
        For_HandlerSuites.TypeBased.IHandlerSuiteOperator<ISection, SectionHandlerSuite>
    {
        IEnumerable<string> Serialize(ISection section)
            => this.Serialize(
                section,
                this.HandlerSuites_ByHandledImplementationType);
    }
}


namespace F10Y.L0039.N001
{
    [FunctionsMarker]
    public partial interface ISectionSerializationHandlerSuiteOperator :
        For_HandlerSuites.TypeBased.IHandlerSuiteOperator
    {
        IEnumerable<string> Serialize(
            ISection section,
            IDictionary<Type, SectionHandlerSuite> handlerSuites_ByHandledImplementationType)
        {
            var handler = this.Verify_CanHandle(
                section,
                handlerSuites_ByHandledImplementationType);

            var output = handler.Serialize(section);
            return output;
        }
    }
}
