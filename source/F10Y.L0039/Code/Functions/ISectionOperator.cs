using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;


namespace F10Y.L0039
{
    [FunctionsMarker]
    public partial interface ISectionOperator : ISectionSerializationHandlerSuiteOperator
    {
        IDictionary<Type, SectionHandlerSuite> For_HandlerSuites.TypeBased.IHandlerSuiteOperator<ISection, SectionHandlerSuite>.HandlerSuites_ByHandledImplementationType
            => Instances.HandlerSuiteSets.For_Sections_ByType;


        void Fill_From<TDestinationSection, TSourceSection>(TDestinationSection destination, TSourceSection source)
            where TDestinationSection : SectionBase
            where TSourceSection : ISection
        {
            destination.Name = source.Name;
            destination.PreOrPost = source.PreOrPost;
        }
    }
}
