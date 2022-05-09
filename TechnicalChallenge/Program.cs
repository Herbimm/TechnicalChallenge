using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.RegularExpressions;
using TechnicalChallenge.Application.Services;
using TechnicalChallenge.Domain.Entity;
using TechnicalChallenge.Domain.Interface;
using TechnicalChallenge.Infra.Data.Utis;

namespace TechnicalChallenge
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            #region Configurações

            var service = new ServiceCollection();
            ConfigureServices(service);
            var serviceProvider = service.BuildServiceProvider();
            var operacoesNumericasService = serviceProvider.GetService<IOperacoesNumericasService>();
            #endregion

            #region Execução
            Console.WriteLine("Sistema de Decomposição numérico");
            Console.WriteLine("Favor digitar um número para sua decomposição");
            var numeroDigitado = Console.ReadLine();
            var regex = new Regex("^[0-9]+$");
            while (true)
            {
                while (!regex.IsMatch(numeroDigitado))
                {
                    Console.Clear();
                    Console.WriteLine("Valor incorreto, Favor digitar um número inteiro.");
                    numeroDigitado = Console.ReadLine();
                }

                NumeroOperacional numeroOperacional = new NumeroOperacional { Numero = Convert.ToDecimal(numeroDigitado) };
                numeroOperacional.Divisores = operacoesNumericasService.VerificarNumeroDivisores(numeroOperacional);
                numeroOperacional.NumerosPrimos = operacoesNumericasService.VerificaNumerosPrimosExistentes(numeroOperacional);

                ConsoleListPrint.PrintConsoleNumerosDivisiveis(numeroOperacional.Divisores);
                ConsoleListPrint.PrintConsoleNumerosPrimos(numeroOperacional.NumerosPrimos);
                Console.WriteLine("Digite um novo Valor: ");
                numeroDigitado = Console.ReadLine();

            }
            #endregion
        }

        #region DependencyInjection
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IOperacoesNumericasService, OperacoesNumericasService>();
        }
        #endregion
    }
}
