using System;
using System.Collections.Generic;

using F10Y.T0004;


namespace F10Y.L0039
{
    [DataTypeMarker]
    public class SectionHandlerSuite :
        ISectionSerializationHandlerSuite
    {
        public Type Type { get; set; }

        public Func<ISection, IEnumerable<string>> Serialize { get; set; }
    }
}
