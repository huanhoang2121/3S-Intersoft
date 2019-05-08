using System.ComponentModel;

namespace LoggingCodefirst.ViewModels.BrandViewModels
{
    public class BrandEditViewModel
    {
        public int Id { get; set; }
        [DisplayName("BrandName")] 
        public string BrandName { get; set; }
    }
}