using Dapper;
using DeLua.Context;
using DeLua.Contracts;
using DeLua.Data.Entities;

namespace DeLua.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DapperContext _context;

        public ClientRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetClientes()
        {
            var query = "SELECT * FROM Clientes";
            using (var connection = _context.CreateConnection())
            {
                var produtos = await connection.QueryAsync<Client>(query);
                return produtos.ToList();
            }
        }

    }
}
