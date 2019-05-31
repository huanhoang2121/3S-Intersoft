using System.Linq;
using System.Threading.Tasks;
using LoggingCodefirst.Infrastructure;
using LoggingCodefirst.Models;
using LoggingCodefirst.Models.Data;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;
using Tests.Common;
using Xunit;

namespace Tests.ServiceTest
{
    public class UserServiceTest
    {
        public void Seed()
        {
            var user = new User
            {
                Email = "huan.hv@3si.com.vn",
                Password = SecurePasswordHasher.Hash("Pass1234"),
                Fullname = "Hoàng Văn Huấn",
                Address = "Huế",
                ImagePath = "asdsad.jpg",
                StoreId = 1,
                Phone = "0964973404",
                RoleId = 1,
                IsActive = true,
            };
            _dataContext.Users.Add(user);
            
            var role = new Role
            {
                RoleName = "Admin",
                Description = "All roles",
            };
            _dataContext.Roles.Add(role);
            
            var store = new Store
            {
                StoreName = "Hà Nội Store",
                Phone = "0216444665",
                Email = "hanoistore@3si.com.vn",
                Street = "Duy Tân",
                City = "Hà Nội",
                State = "Hà Nội",
                ZipCode = "000055"
            };
            _dataContext.Stores.Add(store);
            
            _dataContext.SaveChanges();
        }
        
        private readonly UserService _userService;
        private readonly DataContext _dataContext;

        public UserServiceTest()
        {
            _dataContext = TestHelpers.GetDataContext();
            AutoMapperConfig.Initialize();
            var mapper = AutoMapperConfig.GetMapper();

            _userService = new UserService(_dataContext, mapper);
        }

        [Fact]
        public void GetUser_ReturnNull()
        {
            var result = _userService.GetUsers();
            Assert.Equal(result.Count(), 0);
        }
        
        [Fact]
        public void GetUser_ReturnUsers()
        {
            Seed();
            var result = _userService.GetUsers();
            Assert.Equal(result.Count(), 1);
        }
        
        [Fact]
        public async Task LoginAsync_ReturnTrue()
        {
            Seed();
            var loginViewModel = new LoginViewModel
            {
                Email = "huan.hv@3si.com.vn",
                Password = "Pass1234",
            };
            var result = await _userService.LoginAsync(loginViewModel);
            Assert.True(result);
        }
        
        [Fact]
        public async Task LoginAsync_EmailIncorrect_ReturnFalse()
        {
            Seed();
            var loginViewModel = new LoginViewModel
            {
                Email = "huanhv@3si.com.vn",
                Password = "Pass1234",
            };
            var result = await _userService.LoginAsync(loginViewModel);
            Assert.False(result);
        }
        
        [Fact]
        public async Task LoginAsync_PasswordIncorrect_ReturnFalse()
        {
            Seed();
            var loginViewModel = new LoginViewModel
            {
                Email = "huan.hv@3si.com.vn",
                Password = "Pass12345",
            };
            var result = await _userService.LoginAsync(loginViewModel);
            Assert.False(result);
        }
        
        [Fact]
        public async Task GetUserByEmailAsync_ReturnUser()
        {
            Seed();
            const string email = "huan.hv@3si.com.vn";
            var result = await _userService.GetUserByEmailAsync(email);
            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task GetUserByEmailAsync_ReturnNull()
        {
            Seed();
            const string email = "huanhv@3si.com.vn";
            var result = await _userService.GetUserByEmailAsync(email);
            Assert.Null(result);
        }
        
        [Fact]
        public async Task CreateUserAsync_ReturnTrue()
        {
            Seed();
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
        
        [Fact]
        public async Task GetUserEditAsync_ReturnUserEditViewModel()
        {
            Seed();
            const int id = 1;
            var result = await _userService.GetUserEditAsync(id);
            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task GetUserEditAsync_ReturnNull()
        {
            Seed();
            const int id = 0;
            var result = await _userService.GetUserEditAsync(id);
            Assert.Null(result);
        }
        
        [Fact]
        public async Task EditUserAsync_ReturnTrue()
        {
            Seed();
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
        
        [Fact]
        public async Task GetChangePasswordAsync_ReturnUserChangePasswordViewModel()
        {
            
            Seed();
            const int id = 1;
            var result = await _userService.GetChangePasswordAsync(id);
            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task GetChangePasswordAsync_ReturnNull()
        {
            
            Seed();
            const int id = 0;
            var result = await _userService.GetChangePasswordAsync(id);
            Assert.Null(result);
        }
        
        [Fact]
        public async Task ChangePasswordAsync_ReturnTrue()
        {
            Seed();
            var user = new UserChangePasswordViewModel
            {
                Id = 1,
                NewPassword = "Pass12345",
            };
            var result = await _userService.ChangePasswordAsync(user);
            Assert.True(result);
        }
        
        [Fact]
        public async Task DeleteUserAsync_ReturnTrue()
        {
            Seed();
            const int id = 1;
            var result = await _userService.DeleteUserAsync(id);
            Assert.True(result);
        }
        
        [Fact]
        public async Task DeleteUserAsync_ReturnFalse()
        {
            Seed();
            const int id = 0;
            var result = await _userService.DeleteUserAsync(id);
            Assert.False(result);
        }
        
        [Fact]
        public void IsExistedEmail_ReturnTrue()
        {
            Seed();
            const int id = 0;
            const string email = "huan.hv@3si.com.vn";
            var result =  _userService.IsExistedEmail(id, email);
            Assert.True(result);
        }
        
        [Fact]
        public void IsExistedEmail_ReturnFalse()
        {
            Seed();
            const int id = 1;
            const string email = "huan.hv@3si.com.vn";
            var result =  _userService.IsExistedEmail(id, email);
            Assert.False(result);
        }
        
        [Fact]
        public void IsCurrentPassword_ReturnTrue()
        {
            Seed();
            const int id = 1;
            const string email = "Pass1234";
            var result =  _userService.IsCurrentPassword(id, email);
            Assert.True(result);
        }
        
        [Fact]
        public void IsCurrentPassword_ReturnFalse()
        {
            Seed();
            const int id = 0;
            const string email = "Pass12345";
            var result =  _userService.IsCurrentPassword(id, email);
            Assert.False(result);
        }
        
//        [Theory]
//        [MemberData("huan.hv" + "@3si.com.vn", "Pass1234", true)]
//        [MemberData("huan" + "@3si.com.vn", "Pass1234", false)]
//        [MemberData("huan.hv" + "@3si.com.vn", "Pass12345", false)]
//        public async Task LoginAsync_WhenCalled_ReturnFalse(string email, string password, bool expected)
//        {
//            Seed();
//            var loginViewModel = new LoginViewModel
//            {
//                Email = email,
//                Password = password,
//            };
//            var result = await _userService.LoginAsync(loginViewModel);
//            Assert.Equal(result, expected);
//        }
    }
}