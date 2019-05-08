using FluentValidation;
using LoggingCodefirst.ViewModels.StockViewModels;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Validators.Stock
{
    public class StockCreateValidator: AbstractValidator<StockCreateViewModel>
    {
        public StockCreateValidator(IStringLocalizer<StockCreateValidator> localizer)
        {
            RuleFor(x => x.Quanlity).NotNull().WithMessage(localizer["Quanlity must not be empty."]);
        }
        
    }
}