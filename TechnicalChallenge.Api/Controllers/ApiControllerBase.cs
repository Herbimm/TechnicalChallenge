using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace TechnicalChallenge.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public  class ApiControllerBase : ControllerBase
    {
        private ISender _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();

        protected List<string> CheckModelState()
        {

            var errors = ModelState.SelectMany(x => x.Value.Errors).Select(x=>x.ErrorMessage)
               .Where(y => y.Count() > 0)
               .ToList();
            return errors;

        }
    }
}
