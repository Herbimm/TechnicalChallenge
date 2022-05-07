using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TechnicalChallenge.Application.Services;
using TechnicalChallenge.Domain.Interface;

namespace TechnicalChallenge.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            #region Service
            services.AddScoped<IOperacoesNumericasService, OperacoesNumericasService>();
            #endregion

            #region Repository
            
            #endregion

            var myhandlers = AppDomain.CurrentDomain.Load("TechnicalChallenge.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}

