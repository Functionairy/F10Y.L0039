using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0039
{
    [FunctionsMarker]
    public partial interface IOrderOperator :
        L0000.IOrderOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        L0000.IOrderOperator _L0000 => L0000.OrderOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        string[] Get_GlobalSectionNames_InOrder()
        {
            var output = new[]
            {
                Instances.GlobalSectionNames.SolutionConfigurationPlatforms,
                Instances.GlobalSectionNames.ProjectConfigurationPlatforms,
                Instances.GlobalSectionNames.SolutionProperties,
                Instances.GlobalSectionNames.ExtensibilityGlobals,
            };

            return output;
        }

        IEnumerable<ISection> Order_GlobalSections(IEnumerable<ISection> globalSections)
        {
            var orderedNames = this.Get_GlobalSectionNames_InOrder();

            var orderedNamesComparer = Instances.ComparerOperator.Get_OrderedValuesComparer(orderedNames);

            var output = globalSections.OrderBy(x => x.Name, orderedNamesComparer);
            return output;
        }
    }
}
