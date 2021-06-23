using FernandoJose.CodeFirst.Application.ContaCorrente.Interfaces;
using FernandoJose.CodeFirst.Application.ContaCorrente.ViewModels;
using FernandoJose.CodeFirst.Application.Share.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace FernandoJose.CodeFirst.Api.Controllers
{
    [Route("api/conta-corrente")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IContaCorrenteAppService _contaCorrenteAppService;

        public ContaCorrenteController(IContaCorrenteAppService contaCorrenteAppService)
        {
            _contaCorrenteAppService = contaCorrenteAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AdicionarAsync([FromBody] ContaCorrenteAdicionarRequestViewModel request)
        {
            ResponseViewModel response = await _contaCorrenteAppService.AdicionarAsync(request).ConfigureAwait(true);
            return Ok(response);
        }

        [HttpGet("obter-por-id/{id:int}")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Obter(int id)
        {
            ResponseViewModel response = _contaCorrenteAppService.Obter(id);
            return Ok(response);
        }

        [HttpGet("listar")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Listar()
        {
            ResponseViewModel response = _contaCorrenteAppService.Listar();
            return Ok(response);
        }

        [HttpGet("obter-por-agencia-conta/{agencia}/{conta}")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult ObterPorAgenciaConta(string agencia, string conta)
        {
            ResponseViewModel response = _contaCorrenteAppService.ObterPorAgenciaConta(agencia, conta);
            return Ok(response);
        }
    }
}