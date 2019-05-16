using FluentValidation;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class StockValidator: AbstractValidator<StockViewModel>
    {
        public StockValidator(LocalizationService<StockResource> localizer)
        {
            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(1).WithMessage(localizer.GetLocalizedString("msg_GreaterThanOrEqualTo1"));
        }
        
    }
}