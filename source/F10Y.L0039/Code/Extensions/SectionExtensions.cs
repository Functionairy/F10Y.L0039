using System;


namespace F10Y.L0039.Extensions
{
    public static class SectionExtensions
    {
        public static TDestinationSection Fill_From<TDestinationSection, TSourceSection>(this TDestinationSection destination, TSourceSection source)
            where TDestinationSection : SectionBase
            where TSourceSection : ISection
        {
            Instances.SectionOperator.Fill_From(destination, source);

            return destination;
        }
    }
}
