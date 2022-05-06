using System;
using System.Collections.Generic;

namespace TechnicalChallenge.Domain.Entity
{
    public class NumeroOperacional
    {
        /// <summary>
        /// Número digitado
        /// </summary>
        public int Numero { get; set; }
        /// <summary>
        /// Lista com os numeros primos do Numero digitado
        /// </summary>
        public List<int> NumerosPrimos { get; set; }   

        /// <summary>
        /// Lista com os divisores do Numero digitado
        /// </summary>
        public List<int> Divisores { get; set; }              
       
    }    
}
