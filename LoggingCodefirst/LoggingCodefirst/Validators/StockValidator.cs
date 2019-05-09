using FluentValidation;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class StockValidator: AbstractValidator<StockViewModel>
    {
        public StockValidator(LocalizationService localizer)
        {
            RuleFor(x => x.Quanlity).NotNull().WithMessage(localizer.GetLocalizedString("{PropertyName} must not be empty."));
        }
        
    }
}