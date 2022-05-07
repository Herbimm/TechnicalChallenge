﻿using System.Collections.Generic;
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

        
    }
}
