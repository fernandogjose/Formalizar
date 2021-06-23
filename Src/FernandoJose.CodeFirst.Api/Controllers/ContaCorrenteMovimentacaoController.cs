using FernandoJose.CodeFirst.Application.ContaCorrenteMovimentacao.Interfaces;
using FernandoJose.CodeFirst.Application.ContaCorrenteMovimentacao.ViewModels;
using FernandoJose.CodeFirst.Application.Share.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace FernandoJose.CodeFirst.Api.Controllers
{
    [Route("api/conta-corrente-movimentacao")]
    [ApiController]
    public class ContaCorrenteMovimentacaoController : ControllerBase
    {
        private readonly IContaCorrenteMovimentacaoAppService _contaCorrenteMovimentacaoAppService;

        public ContaCorrenteMovimentacaoController(IContaCorrenteMovimentacaoAppService contaCorrenteMovimentacaoAppService)
        {
            _contaCorrenteMovimentacaoAppService = contaCorrenteMovimentacaoAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AdicionarAsync([FromBody] ContaCorrenteMovimentacaoAdicionarRequestViewModel request)
        {
            ResponseViewModel response = await _contaCorrenteMovimentacaoAppService.AdicionarAsync(request).ConfigureAwait(true);
            return Ok(response);
        }

        [HttpGet("obter-saldo-atualizado/{contaCorrenteId:int}")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult ObterSaldoAtualizado(int contaCorrenteId)
        {
            ResponseViewModel response = _contaCorrenteMovimentacaoAppService.ObterSaldoAtualizado(contaCorrenteId);
            return Ok(response);
        }
    }
}