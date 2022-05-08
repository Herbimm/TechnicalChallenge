using FluentValidation;
using System.Text.RegularExpressions;

namespace TechnicalChallenge.Application.OperacoesNumericas.Queries
{
    public class DivisoresEPrimosValidator : AbstractValidator<DivisoresEPrimosQuery>
    {
        public DivisoresEPrimosValidator()
        {
            RuleFor(x => x.Numero)
         .NotNull()
         .NotEmpty().WithMessage("O número esta vazio");

            RuleFor(x => x.Numero).Must((query, x) => ValidarNumero(x)).WithMessage("Numero invalido");
        }

        private bool ValidarNumero(decimal numero)
        {
            var regex = new Regex("^[0-9]+$");
            if (!regex.IsMatch(numero.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}