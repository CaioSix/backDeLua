using DeLua.Data.Entities;

namespace DeLua.Contracts
{
    public interface IClientRepository
    {
        public Task<IEnumerable<Client>> GetClientes();
    }
}
