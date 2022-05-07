using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using TechnicalChallenge.Domain.Entity;
using TechnicalChallenge.Domain.Interface;
using TechnicalChallenge.Service.Implementation;

namespace TechnicalChallenge
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            #region Configurações
            
            var service = new ServiceCollection();
            ConfigureServices(service);
            var serviceProvider = service.BuildServiceProvider();
            var operacoesNumericasService = serviceProvider.GetService<IOperacoesNumericasService>();
            #endregion

            #region Inicialização
            Console.WriteLine("Sistema de Decomposição numérico");
            Console.WriteLine("Favor digitar um número para sua decomposição");

            var numeroDigitado = Console.ReadLine();
            var regex = new Regex("^[0-9]+$");
            while (!regex.IsMatch(numeroDigitado))
            {
                Console.Clear();
                Console.WriteLine("Valor incorreto, Favor digitar um número inteiro.");
                numeroDigitado = Console.ReadLine();
            }
            #endregion

            #region Regra Divisão
            NumeroOperacional numeroOperacional = new NumeroOperacional { Numero = Convert.ToInt32(numeroDigitado)};
            numeroOperacional.Divisores = operacoesNumericasService.VerificarNumeroDivisores(numeroOperacional);
            numeroOperacional.NumerosPrimos = operacoesNumericasService.VerificaNumerosPrimosExistentes(numeroOperacional);
            #endregion

            #region Print Resultado

            #endregion

        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IOperacoesNumericasService, OperacoesNumericasService>();
        }
    }
}
