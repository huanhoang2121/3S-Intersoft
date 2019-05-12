using FluentValidation;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class StockValidator: AbstractValidator<StockViewModel>
    {
        public StockValidator(LocalizationService localizer)
        {
            RuleFor(x => x.Quantity).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"));
        }
        
    }
}