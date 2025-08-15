using Domain.Models.Customers;
using ReporitorySqlServer.Entities;

namespace ReporitorySqlServer.Mappers
{
    public static class CustomersMapper
    {
        public static CustomersModel ToDomain(this CustomersEntity entity) => new CustomersModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Email = entity.Email,
            CreatedAt = entity.CreatedAt,
        };

        public static CustomersEntity ToEntity(this CustomersModel domain) => new CustomersEntity
        {
            Id = domain.Id,
            Name = domain.Name,
            Email = domain.Email,
            CreatedAt = domain.CreatedAt,
        };
    }
}
