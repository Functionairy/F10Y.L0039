using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0003;


namespace F10Y.L0039
{
    [ValuesMarker]
    public partial interface IHandlerSuiteSets
    {
#pragma warning disable IDE1006 // Naming Styles

        private static IHandlerSuites _HandlerSuites => Instances.HandlerSuites;

#pragma warning restore IDE1006 // Naming Styles


        #region Sections

        SectionHandlerSuite[] For_Sections =>
        [
            _HandlerSuites.For_ExtensibilityGlobalsGlobalSection,
            //_HandlerSuites.For_LinesBasedSection,
            _HandlerSuites.For_LinesBasedGlobalSection,
            _HandlerSuites.For_LinesBasedProjectSection,
            _HandlerSuites.For_NestedProjectsGlobalSection,
            _HandlerSuites.For_ProjectConfigurationPlatformsGlobalSection,
            _HandlerSuites.For_SolutionConfigurationPlatformsGlobalSection,
        ];

        private static readonly Lazy<Dictionary<Type, SectionHandlerSuite>> For_Sections_ByType_Lazy = new(() =>
            HandlerSuiteSets.Instance.For_Sections
                .ToDictionary(x => x.Type)
        );

        Dictionary<Type, SectionHandlerSuite> For_Sections_ByType => For_Sections_ByType_Lazy.Value;

        #endregion
    }
}
