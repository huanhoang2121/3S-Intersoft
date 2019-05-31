using System.Threading.Tasks;
using LoggingCodefirst.Services;
using LoggingCodefirst.Models;
using LoggingCodefirst.Models.Data;
using LoggingCodefirst.ViewModels;
using Tests.Common;
using Xunit;

namespace Tests.ServiceTest
{
    public class BrandServiceTest
    {
        private readonly BrandService _brandService;
        private readonly DataContext _dataContext;

        public BrandServiceTest()
        {
            _dataContext = TestHelpers.GetDataContext();
            AutoMapperConfig.Initialize();
            var mapper = AutoMapperConfig.GetMapper();

            var brand = new Brand { BrandName = "Adidas" };
            _dataContext.Brands.Add(brand);
            _dataContext.SaveChanges();

            _brandService = new BrandService(_dataContext, mapper);
        }

        [Fact]
        public void GetBrandsTest()
        {
            var result = _brandService.GetBrands();
            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task CreateBrandTest()
        {
            var brand = new BrandViewModel { BrandName = "Microsoft" };
            var result = await _brandService.CreateBrandAsync(brand);
            Assert.True(result);
        }

        [Fact]
        public async Task GetBrandEditTest()
        {
            const int id = 4;
            var result = await _brandService.GetBrandEditAsync(id);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task EditBrandTest()
        {
            var brand = new BrandViewModel { Id = 5, BrandName = "Google" };
            var result = await _brandService.EditBrandAsync(brand);
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteBrandTest()
        {
            const int id = 6;
            var result = await _brandService.DeleteBrandAsync(id);
            Assert.True(result);
        }
    }
}