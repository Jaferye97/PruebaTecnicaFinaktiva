using Application.Ports;
using Domain.Models.Customers;
using ReporitorySqlServer.Context;
using ReporitorySqlServer.Entities;
using ReporitorySqlServer.Mappers;

namespace ReporitorySqlServer.Repositories
{
    public class CustomersRepository : BaseRepository<CustomersEntity, CustomersModel, int>, ICustomersRepositorySqlServerPort
    {
        public CustomersRepository(EntityDbContext context) : base(context, entity => entity.ToDomain(), entity => entity.ToEntity())
        {
        }

        public async Task<CustomersModel> GetAsync(int id) => await base.GetAsync(id);

        public async Task<IEnumerable<CustomersModel>> GetAsync() => await base.GetAsync();

        public async Task<CustomersModel> AddAsync(CustomersModel model) => CustomersMapper.ToDomain(await base.AddAsync(model));

        public async Task<CustomersModel> UpdateAsync(CustomersModel model) => CustomersMapper.ToDomain(await base.UpdateAsync(model));
    }
}
