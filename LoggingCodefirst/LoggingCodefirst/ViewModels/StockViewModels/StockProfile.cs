using AutoMapper;
using LoggingCodefirst.Models.Production;

namespace LoggingCodefirst.ViewModels.StockViewModels
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<Stock, StockIndexViewModel>();
            CreateMap<Stock, StockEditViewModel>();
        }
    }
}