using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace Physics.Api.Application
{
    public static class ModelStateHelper
    {
        public static IEnumerable<KeyValuePair<string, List<string>>> Errors(this ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                return modelState.ToDictionary(kvp => kvp.Key,
                    kvp => kvp.Value.Errors
                                    .Select(e => e.ErrorMessage).ToList())
                                    .Where(m => m.Value.Count > 0);
            }
            return new List<KeyValuePair<string, List<string>>>();
        }
    }
}