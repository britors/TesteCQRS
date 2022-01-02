using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace TesteCQRS.Utils
{
    public static class ValidatorErrorsUtil
    {
        public static Dictionary<string, IEnumerable<string>> GetErrorsFromException(ValidationException ex)
        {
            return ex.Errors
                    .GroupBy(failure => failure.PropertyName)
                    .ToDictionary(failures => failures.Key,
                                        failures => failures
                                        .Select(failure => failure.ErrorMessage));
        }
    }
}
