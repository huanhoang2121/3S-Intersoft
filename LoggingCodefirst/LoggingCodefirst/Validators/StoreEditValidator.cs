using FluentValidation;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;
using LoggingCodefirst.ViewModels.Store;

namespace LoggingCodefirst.Validators
{
    public class StoreEditValidator: AbstractValidator<StoreEditViewModel>
    {
        public StoreEditValidator(LocalizationService localizer)
        {
            RuleFor(x => x.StoreName).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"));
            
            RuleFor(x => x.Phone).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"));
        }
        
    }
}