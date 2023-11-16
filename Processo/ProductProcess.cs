using DeLua.Data.ValueObjects;
using DeLua.Service;

namespace DeLua.Processo
{
    public class ProductProcess : IProductProcess
    {
        IProductsService _productsService;

        public ProductProcess(IProductsService productsService)
        {
            _productsService = productsService;
        }
        public Task<List<ProductVO>> PegarProdutos()
        {
            var produtos = _productsService.PegarTodosOsProdutos();
            return produtos;
        }
    }
}
