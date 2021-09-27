using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace PokedexApi.Service.Services.Pokemon.Validation {
    public class PokemonSearchQueryValidator : AbstractValidator<PokemonSearchQuery> {
        public PokemonSearchQueryValidator () {
            // RuleFor(x => x.Hp).Must(x => x > 0).When(x => x.Hp != null).WithMessage("HP must be greater than 0");
            // RuleFor(x => x.Attack).Must(x => x > 0).When(x => x.Attack != null).WithMessage("Attack must be greater than 0");
            // RuleFor(x => x.Defense).Must(x => x > 0).When(x => x.Defense != null).WithMessage("Defense must be greater than 0");
            // RuleFor(x => x.SpAttack).Must(x => x > 0).When(x => x.SpAttack != null).WithMessage("SpAttack must be greater than 0");
            // RuleFor(x => x.SpDefense).Must(x => x > 0).When(x => x.SpDefense != null).WithMessage("SpDefense must be greater than 0");
            // RuleFor(x => x.Speed).Must(x => x > 0).When(x => x.Speed != null).WithMessage("Speed must be greater than 0");
            // RuleFor(x => x.Generation).Must(x => x > 0).When(x => x.Generation != null).WithMessage("Generation must be greater than 0");
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<PokemonSearchQuery> context, CancellationToken cancellation = default) {
            await base.ValidateAsync(context);
            return new ValidationResult();
        }
    }
}