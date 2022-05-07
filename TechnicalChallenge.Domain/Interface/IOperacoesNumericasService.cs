using System;
using System.Collections.Generic;
using System.Text;
using TechnicalChallenge.Domain.Entity;

namespace TechnicalChallenge.Domain.Interface
{
    public interface IOperacoesNumericasService
    {
        /// <summary>
        /// Obtem os divisores do número digitado
        /// </summary>
        /// <param name="numeroOperacional"></param>
        /// <returns>Retorna em lista os numeros divisores</returns>
        List<int> VerificarNumeroDivisores(NumeroOperacional numeroOperacional);

        /// <summary>
        /// Obtem os numeros primos do numero
        /// </summary>
        /// <param name="numeroOperacional"></param>
        /// <returns>Lista com os números primos</returns>
        List<int> VerificaNumerosPrimosExistentes(NumeroOperacional numeroOperacional);

        /// <summary>
        /// Printa os numeros divisores
        /// </summary>
        /// <param name="numeroOperacional"></param>
        /// <returns>Console Write com os numeros divisores</returns>        
        string PrintNumerosDivisores(List<int> numeroOperacional);

        /// <summary>
        /// Printa os numeros primos
        /// </summary>
        /// <param name="numeroOperacional"></param>
        /// <returns>Console Write com os numeros primos</returns>
        string PrintNumerosPrimos(List<int> numeroOperacional);
    }
}
