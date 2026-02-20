using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Application.Validations.Generic;

public class GenericValidator : IGenericValidator
{
    private readonly IServiceProvider _serviceProvider;

    public GenericValidator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task ValidateAsync<T>(T entity)
    {
        var validator = _serviceProvider.GetService<IValidator<T>>();

        if (validator == null)
            throw new InvalidOperationException($"No validator found for type {typeof(T).Name}");

        var validationResult = await validator.ValidateAsync(entity);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors.ToList());
    }

}
