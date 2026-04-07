using System;

using F10Y.T0004;


namespace F10Y.L0039.T000
{
    [DataTypeMarker]
    public abstract class SectionBase :
        ISection
    {
        public string Name { get; set; }
        public string PreOrPost { get; set; }


        public override string ToString()
        {
            var representation = this.Name;
            return representation;
        }
    }
}
