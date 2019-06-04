using System.Threading.Tasks;
using LoggingCodefirst.Controllers;
using LoggingCodefirst.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using Tests.Common;
using Xunit;

namespace Tests.ControllerTest
{
    public class UserControllerTest
    {
        private readonly UserController _userController;

        public UserControllerTest()
        {
            var dataContext = TestHelpers.GetDataContext();
            AutoMapperConfig.Initialize();
            var mapper = AutoMapperConfig.GetMapper();
            
            var options = Options.Create(new LocalizationOptions());  // you should not need any params here if using a StringLocalizer<T>
            var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);
            
            IUserService userService = new UserService(dataContext, mapper);
            IStoreService storeService = new StoreService(dataContext, mapper);
            IRoleService roleService = new RoleService(dataContext);
            ILocalizationService<UserResource> localizer = new LocalizationService<UserResource>(factory);
            
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            _userController = new UserController(userService, storeService, roleService, localizer)
            {
                TempData = tempData
            };
        }
        
        /// <summary>
        /// Index Test
        /// </summary>
        [Fact]
        public void Index_ReturnViewResult()
        {
            var result = _userController.Index();
            Assert.IsType<ViewResult>(result);
        }
        
        /// <summary>
        /// Get Create Test
        /// </summary>
        [Fact]
        public void GetCreate_ReturnViewResult()
        {
            var result = _userController.Create();
            Assert.IsType<ViewResult>(result);
        }
        
        /// <summary>
        /// Post Create Test
        /// </summary>
        /// <returns>RedirectToActionResult</returns>
        [Fact]
        public async Task PostCreate_ReturnRedirectToActionResult()
        {
            var user = new UserViewModel
            {
                Email = "huanhv@3si.com.vn",
                Password = "Pass1234",
                Fullname = "Hoàng Văn Huấn",
                Address = "Huế",
                ImagePath = "asdsad.jpg",
                StoreId = 1,
                Phone = "0964973404",
                RoleId = 1,
                IsActive = true,
            };
            var result = await _userController.Create(user);
            Assert.IsType<RedirectToActionResult>(result);
        }
        
        /// <summary>
        /// Post Create Test
        /// </summary>
        /// <returns>ViewResult</returns>
        [Fact]
        public async Task PostCreate_ReturnViewResult()
        {
            var user = new UserViewModel();
            
            var result = await _userController.Create(user);
            Assert.IsType<ViewResult>(result);
        }
        
        /// <summary>
        /// Get Edit Test
        /// </summary>
        [Fact]
        public void GetEdit_ReturnBadRequestResult()
        {
            var result = _userController.Edit(0);
            Assert.IsType<BadRequestResult>(result.Result);
        }
        
        /// <summary>
        /// Get Edit Test
        /// </summary>
        [Fact]
        public void GetEdit_ReturnViewResult()
        {
            var result = _userController.Edit(1);
            Assert.IsType<ViewResult>(result.Result);
        }
        
        /// <summary>
        /// Post Edit Test
        /// </summary>
        /// <returns>ViewResult</returns>
        [Fact]
        public async Task PostEdit_ReturnViewResult()
        {
            var user = new UserEditViewModel();
            var result = await _userController.Edit(user);
            Assert.IsType<ViewResult>(result);
        }
        
        /// <summary>
        /// Post Edit Test
        /// </summary>
        /// <returns>RedirectToActionResult</returns>
        [Fact]
        public async Task PostEdit_ReturnRedirectToActionResult()
        {
            var user = new UserEditViewModel
            {
                Id = 1,
                Email = "huanhv@3si.com.vn",
                Fullname = "Hoàng Văn Huấn",
                Address = "Huế",
                ImagePath = "abc.jpg",
                StoreId = 1,
                Phone = "0964973404",
                RoleId = 1,
                IsActive = true,
            };
            var result = await _userController.Edit(user);
            Assert.IsType<RedirectToActionResult>(result);
        }
        
        /// <summary>
        /// Get ChangePassword Test
        /// </summary>
        [Fact]
        public void GetChangePassword_ReturnBadRequestResult()
        {
            var result = _userController.ChangePassword(0);
            Assert.IsType<BadRequestResult>(result.Result);
        }
        
        /// <summary>
        /// Get ChangePassword Test
        /// </summary>
        [Fact]
        public void GetChangePassword_ReturnViewResult()
        {
            var result = _userController.ChangePassword(1);
            Assert.IsType<PartialViewResult>(result.Result);
        }
        
        /// <summary>
        /// Post ChangePassword Test
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PostChangePassword_ReturnViewResult()
        {
            var user = new UserChangePasswordViewModel();
            var result = await _userController.ChangePassword(user);
            Assert.IsType<PartialViewResult>(result);
        }
        
        /// <summary>
        /// Post ChangePassword Test
        /// </summary>
        /// <returns>RedirectToActionResult</returns>
        [Fact]
        public async Task PostChangePassword_ReturnRedirectToActionResult()
        {
            var user = new UserChangePasswordViewModel()
            {
                Id = 1,
                Email = "huanhv@3si.com.vn",
                NewPassword = "Password1234"
            };
            var result = await _userController.ChangePassword(user);
            Assert.IsType<PartialViewResult>(result);
        }
        
        /// <summary>
        /// Get Delete Test
        /// </summary>
        [Fact]
        public void GetDelete_ReturnBadRequestResult()
        {
            var result = _userController.Delete(null);
            Assert.IsType<BadRequestResult>(result.Result);
        }
        
        /// <summary>
        /// Get Delete Test
        /// </summary>
        [Fact]
        public void GetDelete_ReturnViewResult()
        {
            var result = _userController.Delete(1);
            Assert.IsType<RedirectToActionResult>(result.Result);
        }
    }
}