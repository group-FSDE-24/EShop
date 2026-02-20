namespace EShop.Application.Validations.Generic;

public interface IGenericValidator
{
    Task ValidateAsync<T>(T entity);
}
