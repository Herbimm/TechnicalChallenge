using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TechnicalChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacoesNumericasController : ControllerBase
    {
        [HttpGet("primoedivisores{numero}")]
        public IActionResult VerificaNumeroPrimoEDivisores(decimal numero)
        {
            
        }
    }
}
