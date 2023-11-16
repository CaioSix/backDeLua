using Dapper;
using DeLua.Context;
using DeLua.Contracts;
using DeLua.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DeLua.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;

        public ProductRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var query = "SELECT * FROM Produtos";
            using (var connection = _context.CreateConnection())
            {
                var produtos = await connection.QueryAsync<Product>(query);
                return produtos.ToList();
            }
        }

        public async Task<Product> GetProduct( int id)
        {
            var query = "SELECT * FROM Produtos WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var producto = await connection.QuerySingleOrDefaultAsync<Product>(query,new { id });
                return producto;
            }
        }

        public async Task<Product> CreateProduct(Product product)
        {
            var query =
                "INSERT INTO Produtos (NomeProduto, categoria, preco, imageUrl, possuiEstoque ) " +
                "VALUES (@nomeProduto, @categoria, @preco, @imageUrl, @possuiEstoque)";
            var parameters = new DynamicParameters();
            parameters.Add("NomeProduto", product.NomeProduto, DbType.String);
            parameters.Add("categoria", product.Categoria, DbType.String);
            parameters.Add("preco", product.Preco, DbType.Decimal);
            parameters.Add("imageUrl", product.ImageUrl, DbType.String);
            parameters.Add("possuiEstoque", product.PossuiEstoque, DbType.Decimal);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);
                var createdProduct = new Product
                {
                    //Id = id,
                    NomeProduto = product.NomeProduto,
                    Categoria = product.Categoria,
                    Preco = product.Preco,
                    ImageUrl = product.ImageUrl,
                    PossuiEstoque = product.PossuiEstoque
                };
                return createdProduct;
            }
        }

        public Task UpdateProduct(int id, Product product)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteProduct(int id)
        {


                    var queryDelete = "DELETE FROM Produtos WHERE Id = @Id";
                    using (var connection = _context.CreateConnection())
                    {
                        await connection.ExecuteAsync(queryDelete, new { id });
                        
                    }
                
            
        }

  
    }
}
