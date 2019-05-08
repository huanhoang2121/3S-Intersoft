using System.ComponentModel;

namespace LoggingCodefirst.ViewModels.CategoryViewModels
{
    public class CategoryCreateViewModel
    {
        [DisplayName("CategoryName")] 
        public string CategoryName { get; set; }
    }
}