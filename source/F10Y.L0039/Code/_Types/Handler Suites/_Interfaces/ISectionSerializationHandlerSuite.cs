using System;
using System.Collections.Generic;

using F10Y.T0004;


namespace F10Y.L0039
{
    [DataTypeMarker]
    public interface ISectionSerializationHandlerSuite
    {
        public Func<ISection, IEnumerable<string>> Serialize { get; set; }
    }
}
