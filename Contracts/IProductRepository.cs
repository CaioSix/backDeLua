using DeLua.Data.Entities;

namespace DeLua.Contracts
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts();

        public Task<Product> GetProduct(int id);

        public Task<Product> CreateProduct(Product product);

        public Task UpdateProduct(int id, Product product);
        public Task DeleteProduct(int id);
    }
}
