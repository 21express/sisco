namespace Corporate.Presentation.Common.Component.Interfaces
{
    public interface IValidatableComponent
    {
        string FieldLabel { get; set; }
        ComponentValidationRule[] ValidationRules { get; set; }
        string Text { get; set; }
    }
}