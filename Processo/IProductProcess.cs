using DeLua.Data.ValueObjects;

namespace DeLua.Processo
{
    public interface IProductProcess
    {
        Task<List<ProductVO>> PegarProdutos();
    }
}
