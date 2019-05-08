using FluentValidation;
using LoggingCodefirst.ViewModels.StockViewModels;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Validators.Stock
{
    public class StockEditValidator: AbstractValidator<StockEditViewModel>
    {
        public StockEditValidator(IStringLocalizer<StockEditValidator> localizer)
        {
            RuleFor(x => x.Quanlity).NotNull().WithMessage(localizer["Quanlity must not be empty."]);
        }
        
    }
}