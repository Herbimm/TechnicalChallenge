using System;
using System.Text.RegularExpressions;
using Xunit;

namespace TechnicalChallenge.Test
{
    public class OperacoesNumericasTest
    {
        [Theory]
        [InlineData("45")]
        public void VerificaValorDigitadoFoiNumerico(string numeroDigitado)
        {
            var regex = new Regex("^[0-9]+$");           
            Assert.True(regex.IsMatch(numeroDigitado));
        }
    }
}
