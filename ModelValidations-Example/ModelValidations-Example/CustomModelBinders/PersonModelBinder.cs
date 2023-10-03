using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidations_Example.Models;

namespace ModelValidations_Example.CustomModelBinders
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Person person = new Person();
            if (bindingContext.ValueProvider.GetValue("FirstName").Length > 0)
            {
                person.PersonName = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;
                if(bindingContext.ValueProvider.GetValue("LastName").Length>0)
                {
                    person.PersonName += " " + bindingContext.ValueProvider.GetValue("LastName").FirstValue;
                }
            }
            bindingContext.Result=ModelBindingResult.Success(person);
            return Task.CompletedTask;
        }
    }
}
