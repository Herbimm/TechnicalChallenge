using FluentValidation;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TechnicalChallenge.Application.OperacoesNumericas.Queries
{
    public class DivisoresEPrimosValidator : AbstractValidator<DivisoresEPrimosQuery>
    {
        public DivisoresEPrimosValidator()
        {
            RuleFor(x => x.Numero)
         .NotNull()
         .NotEmpty().WithMessage("O número esta vazio");

            RuleFor(v => v.Numero)
               .MustAsync((command, x, cancellation) => ValidarNumero(x)).WithMessage("Número invalido");
        }

        private async Task<bool> ValidarNumero(decimal numero)
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