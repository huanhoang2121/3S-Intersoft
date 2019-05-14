using FluentValidation;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels.Store;

namespace LoggingCodefirst.Validators.Store
{
    public class EditValidator: AbstractValidator<StoreEditViewModel>
    {
        public EditValidator(LocalizationService localizer)
        {
            RuleFor(x => x.StoreName).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"));
            
            RuleFor(x => x.Phone).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"));
        }
        
    }
}