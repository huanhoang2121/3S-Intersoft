using System.Threading.Tasks;
using LoggingCodefirst.Services;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;
using Tests.Common;
using Xunit;

namespace Tests.ServiceTest
{
    public class BrandServiceTest
    {
        private readonly BrandService _brandService;

        public BrandServiceTest()
        {
            var dataContext = TestHelpers.GetDataContext();
            AutoMapperConfig.Initialize();
            var mapper = AutoMapperConfig.GetMapper();
            
            _brandService = new BrandService(dataContext, mapper);
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
            const int id = 1;
            var result = await _brandService.GetBrandEditAsync(id);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task EditBrandTest()
        {
            var brand = new BrandViewModel { Id = 1, BrandName = "Google" };
            var result = await _brandService.EditBrandAsync(brand);
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteBrandTest()
        {
            const int id = 1;
            var result = await _brandService.DeleteBrandAsync(id);
            Assert.True(result);
        }
    }
}