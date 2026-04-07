using System;

using F10Y.T0002;
using F10Y.T0011;

using GuidDocumentation = F10Y.Y0000.Documentation.For_Guid;


namespace F10Y.L0039
{
    [FunctionsMarker]
    public partial interface IGuidOperator :
        L0000.IGuidOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        L0000.IGuidOperator _L0000 => L0000.GuidOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        Guid Parse_ForSolutionFile(string guidString)
        {
            var output = this.Parse(guidString);
            return output;
        }

        /// <summary>
        /// Uses the braced (B) uppercase Guid format.
        /// <inheritdoc cref="GuidDocumentation.B_Uppercase_Format"/>
        /// </summary>
        string ToString_ForSolutionFile(Guid guid)
        {
            var output = this.To_String_B_Uppercase_Format(guid);
            return output;
        }
    }
}
