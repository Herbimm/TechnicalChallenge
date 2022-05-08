using AutoMapper;
using TechnicalChallenge.Application.OperacoesNumericas.Queries;
using TechnicalChallenge.Domain.Entity;

namespace TechnicalChallenge.Application.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DivisoresEPrimosQuery, NumeroOperacional>();            
        }
    }
}
