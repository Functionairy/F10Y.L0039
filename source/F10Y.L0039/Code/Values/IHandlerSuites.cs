using System;

using F10Y.T0003;


namespace F10Y.L0039
{
    [ValuesMarker]
    public partial interface IHandlerSuites
    {
        #region Sections

        SectionHandlerSuite For_ExtensibilityGlobalsGlobalSection => new()
        {
            Type = Instances.TypeOperator.Get_Type<ExtensibilityGlobalsGlobalSection>(),
            Serialize = Instances.TypeOperator.Get_Operator_WithInputTypeVerified(
                Instances.SectionHandlers.Serialize,
                Instances.TypeSpecifiers.For_ExtensibilityGlobalsGlobalSection),
        };

        //SectionHandlerSuite For_LinesBasedSection => new()
        //{
        //    Type = Instances.TypeOperator.Get_Type<LinesBasedSection>(),
        //    Serialize = Instances.TypeOperator.Get_Operator_WithInputTypeVerified(
        //        Instances.SectionHandlers.Serialize,
        //        Instances.TypeSpecifiers.For_LinesBasedSection),
        //};

        SectionHandlerSuite For_LinesBasedGlobalSection => new()
        {
            Type = Instances.TypeOperator.Get_Type<LinesBasedGlobalSection>(),
            Serialize = Instances.TypeOperator.Get_Operator_WithInputTypeVerified(
                Instances.SectionHandlers.Serialize,
                Instances.TypeSpecifiers.For_LinesBasedGlobalSection),
        };

        SectionHandlerSuite For_LinesBasedProjectSection => new()
        {
            Type = Instances.TypeOperator.Get_Type<LinesBasedProjectSection>(),
            Serialize = Instances.TypeOperator.Get_Operator_WithInputTypeVerified(
                Instances.SectionHandlers.Serialize,
                Instances.TypeSpecifiers.For_LinesBasedProjectSection),
        };

        SectionHandlerSuite For_NestedProjectsGlobalSection => new()
        {
            Type = Instances.TypeOperator.Get_Type<NestedProjectsGlobalSection>(),
            Serialize = Instances.TypeOperator.Get_Operator_WithInputTypeVerified(
                Instances.SectionHandlers.Serialize,
                Instances.TypeSpecifiers.For_NestedProjectsGlobalSection),
        };

        SectionHandlerSuite For_ProjectConfigurationPlatformsGlobalSection => new()
        {
            Type = Instances.TypeOperator.Get_Type<ProjectConfigurationPlatformsGlobalSection>(),
            Serialize = Instances.TypeOperator.Get_Operator_WithInputTypeVerified(
                Instances.SectionHandlers.Serialize,
                Instances.TypeSpecifiers.For_ProjectConfigurationPlatformsGlobalSection),
        };

        SectionHandlerSuite For_SolutionConfigurationPlatformsGlobalSection => new()
        {
            Type = Instances.TypeOperator.Get_Type<SolutionConfigurationPlatformsGlobalSection>(),
            Serialize = Instances.TypeOperator.Get_Operator_WithInputTypeVerified(
                Instances.SectionHandlers.Serialize,
                Instances.TypeSpecifiers.For_SolutionConfigurationPlatformsGlobalSection),
        };

        #endregion
    }
}
