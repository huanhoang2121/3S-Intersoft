using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using LoggingCodefirst.Models.Data;
using LoggingCodefirst.Services;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests.ServiceTest
{
    public class BrandServiceTest
    {
        private readonly BrandService _brandService;
        private readonly IMapper _mapper;

        public BrandServiceTest()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.CreateMap<Brand, BrandViewModel>();
            });
            _mapper = config.CreateMapper();
            
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "Database")
                .Options;
            
            using (var context = new DataContext(options))
            {  
                _brandService = new BrandService(context, _mapper);
            }
            
            var brand = new BrandViewModel {Id = 1, BrandName = "Adidas"};
            var result = _brandService.CreateBrandAsync(brand);  
        }
        
        [Fact]  
        public void GetBrandsTest()  
        {  
            var result =  _brandService.GetBrands();  
            
            Assert.NotNull(result);
        } 
        
        [Fact]  
        public async Task CreateBrandTest()
        {
            
            var brand = new BrandViewModel {Id = 1, BrandName = "Adidas"};
            var result = await _brandService.CreateBrandAsync(brand);  
            
            Assert.NotNull(result);
        } 
    }
}