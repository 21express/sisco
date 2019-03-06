using System.Collections.Generic;
using Corporate.Presentation.Common.Component;
using Corporate.Presentation.Common.Component.Interfaces;

namespace Franchise.Presentation.Common.Component
{
    public class ComponentValidationHelper
    {
        public static IList<ComponentValidationError> Validate(params IValidatableComponent[] components)
        {
            var errorList = new List<ComponentValidationError>();

            foreach (IValidatableComponent component in components)
            {
                errorList.AddRange(ValidateComponent(component));
            }

            return errorList;
        }

        public static IList<ComponentValidationError> ValidateComponent(IValidatableComponent component)
        {
            var errorList = new List<ComponentValidationError>();

            foreach (ComponentValidationRule rule in component.ValidationRules)
            {
                switch (rule.Rule)
                {
                    case EnumComponentValidationRule.Mandatory:
                        if (component is dLookupC && ((dLookupC) component).Value == null)
                        {
                            errorList.Add(new ComponentValidationError(component, rule));
                            return errorList;
                        }
                        
                        if (string.IsNullOrEmpty(component.Text))
                        {
                            errorList.Add(new ComponentValidationError(component, rule));
                            return errorList;
                        }
                        break;
                    case EnumComponentValidationRule.Number:
                        int output;
                        if (!int.TryParse(component.Text, out output))
                        {
                            errorList.Add(new ComponentValidationError(component, rule));
                            return errorList;
                        }
                        break;
                }
            }

            return errorList;
        }
    }
}