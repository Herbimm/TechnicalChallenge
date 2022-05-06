﻿using System;
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
    }
}
