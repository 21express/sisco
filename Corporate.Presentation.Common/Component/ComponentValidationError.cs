using Corporate.Presentation.Common.Component;
using Corporate.Presentation.Common.Component.Interfaces;

namespace Franchise.Presentation.Common.Component
{
    public class ComponentValidationError
    {
        public static string GetErrorMessage(IValidatableComponent component, ComponentValidationRule rule)
        {
            if (!string.IsNullOrEmpty(rule.ErrorMessage))
            {
                return string.Format(rule.ErrorMessage, component.FieldLabel);
            }

            switch (rule.Rule)
            {
                case EnumComponentValidationRule.Mandatory:
                    return string.Format("Please fill the {0} field", component.FieldLabel);
                case EnumComponentValidationRule.Number:
                    return string.Format("Please enter only number in the {0} field", component.FieldLabel);
                case EnumComponentValidationRule.Email:
                    return string.Format("Please enter a valid email for {0} field", component.FieldLabel);
                case EnumComponentValidationRule.Callback:
                    return "";
                default:
                    return "";
            }
        }

        public IValidatableComponent Component { get; set; }
        public ComponentValidationRule Rule { get; set; }

        public ComponentValidationError(IValidatableComponent component, ComponentValidationRule rule)
        {
            Component = component;
            Rule = rule;
        }

        public override string ToString()
        {
            return GetErrorMessage(Component, Rule);
        }
    }
}