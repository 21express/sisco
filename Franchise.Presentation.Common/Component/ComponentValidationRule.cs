using System.Collections.Generic;

namespace Franchise.Presentation.Common.Component
{
    public class ComponentValidationRule
    {
        public EnumComponentValidationRule Rule { get; set; }
        public IList<object> Parameters { get; set; }
        public string ErrorMessage { get; set; }

        public ComponentValidationRule(EnumComponentValidationRule rule, string errorMessage = null, params object[] parameters)
        {
            Rule = rule;
            ErrorMessage = errorMessage;
            Parameters = parameters;
        }
    }
}