using System.Collections.Generic;
using TechnicalChallenge.Domain.Entity;
using TechnicalChallenge.Domain.Interface;

namespace TechnicalChallenge.Service.Implementation
{
    public class OperacoesNumericasService : IOperacoesNumericasService
    {
        public List<int> VerificarNumeroDivisores(NumeroOperacional numeroOperacional)
        {
            if (numeroOperacional.Numero <= 1)
            {
                numeroOperacional.NumerosPrimos = null;
                return numeroOperacional.NumerosPrimos;
            }
            if(numeroOperacional.Numero == 2)
            {
                numeroOperacional.Divisores.Add(2);
                return numeroOperacional.NumerosPrimos;
            }
            return null;

        }
    }
}
