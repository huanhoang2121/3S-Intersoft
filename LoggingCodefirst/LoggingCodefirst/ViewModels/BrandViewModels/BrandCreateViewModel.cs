using System.ComponentModel;

namespace LoggingCodefirst.ViewModels.BrandViewModels
{
    public class BrandCreateViewModel
    {
        [DisplayName("BrandName")] 
        public string BrandName { get; set; }
    }
}