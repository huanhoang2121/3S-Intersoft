using System.Threading.Tasks;
using LoggingCodefirst.Authentication;
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
    public class AccountControllerTest
    {
        private readonly AccountController _accountController;

        public AccountControllerTest()
        {
            var dataContext = TestHelpers.GetDataContext();
            AutoMapperConfig.Initialize();
            var mapper = AutoMapperConfig.GetMapper();
            
            var options = Options.Create(new LocalizationOptions());  // you should not need any params here if using a StringLocalizer<T>
            var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);

            var defaultHttpContext = new DefaultHttpContext();
//                TestHelpers.GetTestHttpContext();
            //Mock IHttpContextAccessor
            var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            mockHttpContextAccessor.Setup(m => m.HttpContext).Returns(defaultHttpContext);
            var httpContextAccessor =  mockHttpContextAccessor.Object;
            
            IUserService userService = new UserService(dataContext, mapper);
            ILocalizationService<UserResource> localizerService = new LocalizationService<UserResource>(factory);
            IUserAuthenticationService authenticationService = new UserAuthenticationService(httpContextAccessor);
            
//            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(defaultHttpContext, Mock.Of<ITempDataProvider>());
            
            _accountController = new AccountController(userService, localizerService, authenticationService)
            {
                TempData = tempData
            };
        }
        
        /// <summary>
        /// Index Test
        /// </summary>
        [Fact]
        public async Task Login_ReturnViewResult()
        {
            var user = new LoginViewModel
            {
                Email = "huan.hv@3si.com.vn",
                Password = "Pass1234"
            };
            var result = await _accountController.Login(user);
            Assert.IsType<RedirectResult>(result);
        }
    }
}