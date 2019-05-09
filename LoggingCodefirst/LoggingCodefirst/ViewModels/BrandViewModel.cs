using System.ComponentModel;

namespace LoggingCodefirst.ViewModels
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        [DisplayName("Brand Name")] 
        public string BrandName { get; set; }
    }
}