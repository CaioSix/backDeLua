using DeLua.Contracts;
using DeLua.Data.Entities;
using DeLua.Processo;
using Microsoft.AspNetCore.Mvc;

namespace DeLua.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productsRepo;
        private readonly IProductProcess _productProcess;

        public ProductController(IProductRepository productsRepo, IProductProcess process)
        {
            _productsRepo = productsRepo;
            _productProcess = process;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productProcess.PegarProdutos();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneProduct(int id)
        {
            try
            {
                var product = await _productsRepo.GetProduct(id);
                if (product == null) return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            try
            {
                var createdProduct = await _productsRepo.CreateProduct(product);
                return Ok(createdProduct);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutc(int id)
        {
            try
            {
                var dbProduct = await _productsRepo.GetProduct(id);
                if (dbProduct == null) return NotFound();

                await _productsRepo.DeleteProduct(id);
                return Ok(dbProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }


        //[HttpGet]
        //public async Task<IActionResult> Teste()
        //{
        //    try
        //    {
        //        var products = await _productProcess.PegarProdutos();
        //        return Ok(products);
        //    }
        //    catch (Exception ex)
        //    {
                
        //        return StatusCode(500, "Ocorreu um erro interno. Consulte os logs para obter mais informações.");
        //    }
        //}




    }
}