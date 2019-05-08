using System.ComponentModel;

namespace LoggingCodefirst.ViewModels.CategoryViewModels
{
    public class CategoryIndexViewModel
    {
        public int Id { get; set; }
        [DisplayName("CategoryName")] 
        public string CategoryName { get; set; }
    }
}