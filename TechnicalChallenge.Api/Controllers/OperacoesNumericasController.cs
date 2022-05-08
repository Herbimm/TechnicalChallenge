
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechnicalChallenge.Application.OperacoesNumericas.Queries;

namespace TechnicalChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacoesNumericasController : ApiControllerBase
    {    
        [HttpGet("primoedivisores{numero}")]
        public async Task<IActionResult> VerificaNumeroPrimoEDivisores(decimal numero)
        {
            DivisoresEPrimosQuery query = new DivisoresEPrimosQuery
            {
                Numero = numero
            };            
            return Ok(await Mediator.Send(query));
        }
    }
}
