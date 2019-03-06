﻿using System.Collections.Generic;
using DevExpress.XtraPrinting.Native;
using SISCO.Presentation.Common.Component.Interfaces;

namespace SISCO.Presentation.Common.Component
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
                        if (component is dLookup && ((dLookup) component).Value == null)
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
                        var output = 0;
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