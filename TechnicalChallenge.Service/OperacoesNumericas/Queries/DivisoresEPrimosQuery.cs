using System;
using System.Threading;
using System.Threading.Tasks;
using TechnicalChallenge.Application.Common;
using TechnicalChallenge.Application.Common.Models;
using TechnicalChallenge.Domain.Entity;
using TechnicalChallenge.Domain.Interface;

namespace TechnicalChallenge.Application.OperacoesNumericas.Queries
{
    public class DivisoresEPrimosQuery : IRequestWrapper<NumeroOperacional>
    {     
        /// <summary>
        /// Numero inserido pelo Usuário
        /// </summary>
        public decimal Numero { get; set; }
    }
    public class DivisoresEPrimosQueryHandler : IRequestHandlerWrapper<DivisoresEPrimosQuery, NumeroOperacional>
    {
        private readonly IOperacoesNumericasService _operacoesNumericasService;

        public DivisoresEPrimosQueryHandler(IOperacoesNumericasService operacoesNumericasService)
        {
            _operacoesNumericasService = operacoesNumericasService;
        }
        public async Task<ServiceResult<NumeroOperacional>> Handle(DivisoresEPrimosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                
            }
            catch (Exception e)
            {
                
            }
        }

    }
}
