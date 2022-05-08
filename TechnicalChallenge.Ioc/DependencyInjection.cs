using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using TechnicalChallenge.Application.Common;
using TechnicalChallenge.Application.Services;
using TechnicalChallenge.Domain.Interface;

namespace TechnicalChallenge.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {

            #region AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            #endregion


            #region Service
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IOperacoesNumericasService, OperacoesNumericasService>();
            #endregion

            #region Repository
            
            #endregion

            var myhandlers = AppDomain.CurrentDomain.Load("TechnicalChallenge.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}

