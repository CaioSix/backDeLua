using AutoMapper;
using DeLua.Contracts;
using DeLua.Data.Entities;
using DeLua.Data.ValueObjects;

namespace DeLua.Service
{
    public class ProductsService : IProductsService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        public ProductsService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task <List<ProductVO>> PegarTodosOsProdutos() {
            var produtos = await _repository.GetProducts();
            return _mapper.Map<List<ProductVO>>(produtos);
        }


    }
}
