using FluentValidation;
using LoggingCodefirst.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class StockValidator: AbstractValidator<StockViewModel>
    {
        public StockValidator(ILocalizationService<StockResource> localizer)
        {
            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(1).WithMessage(localizer.GetLocalizedString("msg_GreaterThanOrEqualTo1"));
        }
        
    }
}