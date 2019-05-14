using FluentValidation;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class StockValidator: AbstractValidator<StockViewModel>
    {
        public StockValidator(LocalizationService localizer)
        {
            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(1).WithMessage(localizer.GetLocalizedString("msg_vld_GreaterThanOrEqualTo1"));
        }
        
    }
}