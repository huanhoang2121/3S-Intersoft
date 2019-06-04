using System.Linq;
using System.Threading.Tasks;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;
using Tests.Common;
using Xunit;

namespace Tests.ServiceTest
{
    public class UserServiceTest
    {
        private readonly UserService _userService;

        public UserServiceTest()
        {
            var dataContext = TestHelpers.GetDataContext();
            AutoMapperConfig.Initialize();
            var mapper = AutoMapperConfig.GetMapper();

            _userService = new UserService(dataContext, mapper);
        }
        
        /// <summary>
        /// GetUsers Test
        /// Return List User
        /// </summary>
        [Fact]
        public void GetUsers_ReturnUsers()
        {
            var result = _userService.GetUsers();
            Assert.Equal(result.Count(), 2);
        }
        
        /// <summary>
        /// LoginAsync Test
        /// </summary>
        /// <returns>True</returns>
        [Fact]
        public async Task LoginAsync_ReturnTrue()
        {
            var loginViewModel = new LoginViewModel
            {
                Email = "huan.hv@3si.com.vn",
                Password = "Pass1234",
            };
            var result = await _userService.LoginAsync(loginViewModel);
            Assert.True(result);
        }
        
        /// <summary>
        /// LoginAsync Test
        /// Email Incorrect
        /// </summary>
        /// <returns>False</returns>
        [Fact]
        public async Task LoginAsync_EmailIncorrect_ReturnFalse()
        {
            var loginViewModel = new LoginViewModel
            {
                Email = "huanhv@32si.com.vn",
                Password = "Pass1234",
            };
            var result = await _userService.LoginAsync(loginViewModel);
            Assert.False(result);
        }
        
        /// <summary>
        /// LoginAsync Test
        /// Password Incorrect
        /// </summary>
        /// <returns>False</returns>
        [Fact]
        public async Task LoginAsync_PasswordIncorrect_ReturnFalse()
        {
            var loginViewModel = new LoginViewModel
            {
                Email = "huan.hv@3si.com.vn",
                Password = "Pass12345",
            };
            var result = await _userService.LoginAsync(loginViewModel);
            Assert.False(result);
        }
        
        /// <summary>
        /// GetUserByEmailAsync Test
        /// </summary>
        /// <returns>User</returns>
        [Fact]
        public async Task GetUserByEmailAsync_ReturnUser()
        {
            const string email = "huan.hv@3si.com.vn";
            var user = await _userService.GetUserByEmailAsync(email);
            Assert.NotNull(user);
        }
        
        /// <summary>
        /// GetUserByEmailAsync Test
        /// Email Incorrect
        /// </summary>
        /// <returns>Null</returns>
        [Fact]
        public async Task GetUserByEmailAsync_EmailIncorrect_ReturnNull()
        {
            const string email = "huanhv@32si.com.vn";
            var user = await _userService.GetUserByEmailAsync(email);
            Assert.Null(user);
        }
        
        /// <summary>
        /// CreateUserAsync Test
        /// </summary>
        /// <returns>True</returns>
        [Fact]
        public async Task CreateUserAsync_ReturnTrue()
        {
            var user = new UserViewModel
            {
                Email = "huan.hv@3si.com.vn",
                Password = "Pass1234",
                Fullname = "Hoàng Văn Huấn",
                Address = "Huế",
                ImagePath = "asdsad.jpg",
                StoreId = 1,
                Phone = "0964973404",
                RoleId = 1,
                IsActive = true,
            };
            var result = await _userService.CreateUserAsync(user);
            Assert.True(result);
        }
        
        /// <summary>
        /// CreateUserAsync Test
        /// UserNull
        /// </summary>
        /// <returns>False</returns>
        [Fact]
        public async Task CreateUserAsync_UserNull_ReturnFalse()
        {
            var user = new UserViewModel();
            var result = await _userService.CreateUserAsync(user);
            Assert.False(result);
        }
        
        /// <summary>
        /// GetUserEditAsync Test
        /// </summary>
        /// <returns>User</returns>
        [Fact]
        public async Task GetUserEditAsync_ReturnUser()
        {
            const int id = 1;
            var user = await _userService.GetUserEditAsync(id);
            Assert.NotNull(user);
        }
        
        /// <summary>
        /// GetUserEditAsync Test
        /// </summary>
        /// <returns>Null</returns>
        [Fact]
        public async Task GetUserEditAsync_ReturnNull()
        {
            const int id = 0;
            var user = await _userService.GetUserEditAsync(id);
            Assert.Null(user);
        }
        
        /// <summary>
        /// EditUserAsync Test
        /// </summary>
        /// <returns>True</returns>
        [Fact]
        public async Task EditUserAsync_ReturnTrue()
        {
            var user = new UserEditViewModel
            {
                Id = 1,
                Email = "huan.hv@3si.com.vn",
                Fullname = "Hoàng Văn Huấn",
                Address = "Huế",
                ImagePath = "asdsad.jpg",
                StoreId = 1,
                Phone = "0964973404",
                RoleId = 1,
                IsActive = true,
            };
            var result = await _userService.EditUserAsync(user);
            Assert.True(result);
        }
        
        /// <summary>
        /// EditUserAsync Test
        /// UserNull
        /// </summary>
        /// <returns>False</returns>
        [Fact]
        public async Task EditUserAsync_UserNull_ReturnFalse()
        {
            var user = new UserEditViewModel();
            var result = await _userService.EditUserAsync(user);
            Assert.False(result);
        }
        
        /// <summary>
        /// GetChangePasswordAsync Test
        /// </summary>
        /// <returns>User</returns>
        [Fact]
        public async Task GetChangePasswordAsync_ReturnUser()
        {
            const int id = 1;
            var result = await _userService.GetChangePasswordAsync(id);
            Assert.NotNull(result);
        }
        
        
        /// <summary>
        /// GetChangePasswordAsync Test
        /// </summary>
        /// <returns>Null</returns>
        [Fact]
        public async Task GetChangePasswordAsync_ReturnNull()
        {
            const int id = 0;
            var result = await _userService.GetChangePasswordAsync(id);
            Assert.Null(result);
        }
        
        /// <summary>
        /// ChangePasswordAsync Test
        /// </summary>
        /// <returns>True</returns>
        [Fact]
        public async Task ChangePasswordAsync_ReturnTrue()
        {
            var user = new UserChangePasswordViewModel
            {
                Id = 1,
                NewPassword = "Pass12345",
            };
            var result = await _userService.ChangePasswordAsync(user);
            Assert.True(result);
        }
        
        /// <summary>
        /// ChangePasswordAsync Test
        /// UserNUll
        /// </summary>
        /// <returns>False</returns>
        [Fact]
        public async Task ChangePasswordAsync_UserNUll_ReturnFalse()
        {
            var user = new UserChangePasswordViewModel();
            var result = await _userService.ChangePasswordAsync(user);
            Assert.False(result);
        }
        
        /// <summary>
        /// DeleteUserAsync Test
        /// </summary>
        /// <returns>True</returns>
        [Fact]
        public async Task DeleteUserAsync_ReturnTrue()
        {
            const int id = 1;
            var result = await _userService.DeleteUserAsync(id);
            Assert.True(result);
        }
        
        /// <summary>
        /// DeleteUserAsync Test
        /// </summary>
        /// <returns>False</returns>
        [Fact]
        public async Task DeleteUserAsync_ReturnFalse()
        {
            const int id = 0;
            var result = await _userService.DeleteUserAsync(id);
            Assert.False(result);
        }
        
        /// <summary>
        /// IsExistedEmail Test
        /// </summary>
        /// <returns>True</returns>
        [Fact]
        public void IsExistedEmail_ReturnTrue()
        {
            const int id = 0;
            const string email = "huan.hv@3si.com.vn";
            var result =  _userService.IsExistedEmail(id, email);
            Assert.True(result);
        }
        
        /// <summary>
        /// IsExistedEmail Test
        /// </summary>
        /// <returns>False</returns>
        [Fact]
        public void IsExistedEmail_ReturnFalse()
        {
            const int id = 1;
            const string email = "huan.hv@3si.com.vn";
            var result =  _userService.IsExistedEmail(id, email);
            Assert.False(result);
        }
        
        /// <summary>
        /// IsCurrentPassword Test
        /// </summary>
        /// <returns>True</returns>
        [Fact]
        public void IsCurrentPassword_ReturnTrue()
        {
            const int id = 1;
            const string password = "Pass1234";
            var result =  _userService.IsCurrentPassword(id, password);
            Assert.True(result);
        }
        
        /// <summary>
        /// IsCurrentPassword Test
        /// </summary>
        /// <returns>False</returns>
        [Fact]
        public void IsCurrentPassword_ReturnFalse()
        {
            const int id = 1;
            const string password = "Pass12345";
            var result =  _userService.IsCurrentPassword(id, password);
            Assert.False(result);
        }
    }
}