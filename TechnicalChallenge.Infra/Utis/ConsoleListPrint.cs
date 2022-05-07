using System;
using System.Collections.Generic;

namespace TechnicalChallenge.Infra.Utis
{
    public static class ConsoleListPrint
    {
        public static void PrintConsoleNumerosPrimos(List<int> numerosPrimos)
        {
            var numerosString = String.Join(", ", numerosPrimos);
            Console.WriteLine($"Os Números primos que se encontram no número digitado são : {numerosString}");
        }
        public static void PrintConsoleNumerosDivisiveis(List<int> numerosDivisiveis)
        {
            var numerosString = String.Join(", ", numerosDivisiveis);
            Console.WriteLine($"Os Números divisiveis que se encontram no número digitado são : {numerosString}");
        }
    }
}
