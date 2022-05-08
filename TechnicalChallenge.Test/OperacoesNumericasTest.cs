using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TechnicalChallenge.Test.Entity;
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

        [Theory]
        [InlineData(45)]
        public void DevePassarNumeroDecimalParaObjeto(decimal numeroDigitado)
        {
            NumeroOperacional numero = new NumeroOperacional();
            numero.Numero = numeroDigitado;
            Assert.Equal(numero.Numero, numeroDigitado);
        }

        [Theory]
        [InlineData(1)]
        public void NaoDeveRetornarDivisoresSeValorForUm(decimal numeroDigitado)
        {
            NumeroOperacional numero = new NumeroOperacional();
            numero.Numero = numeroDigitado;
            if (numero.Numero <= 1)
            {
                numero.Divisores = null;                
            }
            Assert.Equal(numero.Divisores, null);
        }

        [Theory]
        [InlineData(45)]
        public void DeveRetornarDivisoresEmLista(decimal numeroDigitado)
        {
            NumeroOperacional numero = new NumeroOperacional();
            numero.Numero = numeroDigitado;
            List<int> numerosInteirosDivididos = new List<int>();
            for (int i = 1; i < numero.Numero + 1; i++)
            {
                decimal divisaoResultado = numero.Numero / i;
                string result = divisaoResultado.ToString();
                if (!Convert.ToString(result).Contains(","))
                {
                    numerosInteirosDivididos.Add(i);
                }
            }
            numero.Divisores = numerosInteirosDivididos;
            Assert.Equal(numero.Divisores,new List<int> { 1, 3, 5, 9, 15, 45 });            
            Assert.Equal(numero.Divisores,numerosInteirosDivididos);            
        }


    }
}
