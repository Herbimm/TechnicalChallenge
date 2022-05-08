using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IOperacoesNumericasService _operacoesNumericasService;

        public DivisoresEPrimosQueryHandler(IOperacoesNumericasService operacoesNumericasService, IMapper mapper)
        {
            _mapper = mapper;
            _operacoesNumericasService = operacoesNumericasService;
        }
        public async Task<ServiceResult<NumeroOperacional>> Handle(DivisoresEPrimosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var numero = _mapper.Map<NumeroOperacional>(request);
                var divisores = _operacoesNumericasService.VerificarNumeroDivisores(numero);
                var primos = _operacoesNumericasService.VerificaNumerosPrimosExistentes(numero);                

                return ServiceResult.Success(numero);
            }
            catch (Exception)
            {
                return ServiceResult.Failed(new NumeroOperacional(),ServiceError.ValidationFormat);
            }
        }

    }
}
