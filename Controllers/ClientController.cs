using DeLua.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DeLua.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientesRepository;
        public ClientController(IClientRepository clientesRepository)
        {
            _clientesRepository =   clientesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            try
            {
                var produtos = await _clientesRepository.GetClientes();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
