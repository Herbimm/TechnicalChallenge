using System;
using System.Collections.Generic;
using TechnicalChallenge.Domain.Entity;
using TechnicalChallenge.Domain.Interface;

namespace TechnicalChallenge.Application.Services
{
    public class OperacoesNumericasService : IOperacoesNumericasService
    {
        public List<int> VerificarNumeroDivisores(NumeroOperacional numeroOperacional)
        {
            if (numeroOperacional.Numero <= 1)
            {
                numeroOperacional.Divisores = null;
                return numeroOperacional.Divisores;
            }
            if(numeroOperacional.Numero == 2)
            {
                numeroOperacional.Divisores.Add(2);
                return numeroOperacional.Divisores;
            }
            var listNumerosDivisiveis = RetornaNumerosDivisiveis(numeroOperacional.Numero);
            foreach (var item in listNumerosDivisiveis)
            {                   
                numeroOperacional.Divisores.Add(item);
            }            
            return numeroOperacional.Divisores;
        }
        public List<int> VerificaNumerosPrimosExistentes(NumeroOperacional numeroOperacional)
        {
            if (numeroOperacional.Numero <= 1)
            {
                numeroOperacional.NumerosPrimos = null;
                return numeroOperacional.NumerosPrimos;
            }
            if (numeroOperacional.Numero == 2)
            {
                numeroOperacional.NumerosPrimos.Add(1);
                numeroOperacional.NumerosPrimos.Add(2);
                return numeroOperacional.NumerosPrimos;
            }
            var primos = RetornaNumerosPrimos(numeroOperacional.Numero);
            numeroOperacional.NumerosPrimos = primos;
            return numeroOperacional.NumerosPrimos;
        }

        private List<int> RetornaNumerosPrimos(decimal numero)
        {
            var listaNumerosDivisiveis = RetornaNumerosDivisiveis(numero);
            List<int> numerosPrimos = new List<int>();
            foreach (var item in listaNumerosDivisiveis)
            {
                List<int> contagemNumerosDivisiveis = new List<int>();

                for (int i = 1; i < item + 1; i++)
                {
                    decimal divisaoResultado = Convert.ToDecimal(item) / i;
                    string result = divisaoResultado.ToString();
                    if (!Convert.ToString(result).Contains(","))
                    {
                        contagemNumerosDivisiveis.Add(i);
                    }                   
                }   
                if (contagemNumerosDivisiveis.Count == 2)
                {
                    numerosPrimos.Add(item);
                }
            }            
            return numerosPrimos;
        }
        private List<int> RetornaNumerosDivisiveis(decimal numero)
        {
            List<int> numerosInteirosDivididos = new List<int>();
            for (int i = 1; i < numero + 1; i++)
            {
                decimal divisaoResultado = numero / i;
                string result = divisaoResultado.ToString();
                if (!Convert.ToString(result).Contains(","))
                {
                    numerosInteirosDivididos.Add(i);
                }
            }
            return numerosInteirosDivididos;
        }
       
    }
}
