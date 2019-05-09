using System.ComponentModel;

namespace LoggingCodefirst.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [DisplayName("CategoryName")] 
        public string CategoryName { get; set; }
    }
}