using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Infrastructure;
using LoggingCodefirst.Models;
using LoggingCodefirst.Models.Sales;
using LoggingCodefirst.ViewModels.AccountViewModels;
using LoggingCodefirst.ViewModels.UserViewModels;
using Microsoft.EntityFrameworkCore;

namespace LoggingCodefirst.DependencyInjection.Implementation
{
    public class UserService : IUserService
    { 
        #region Private Members
        
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        #endregion
        
        #region Constructors
        
        public UserService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        
        #endregion
        
        #region Public Properties
        
        public IEnumerable<User> Users => _context.Users.Include(s => s.Store);
        
        #endregion

        #region Public Methods
        
        public bool Login(AccountLoginViewModel model)
        {  
            var user = _context.Users.FirstOrDefault(s => s.Email == model.Email && SecurePasswordHasher.Verify(model.Password, s.Password));
            return user != null;
        }

        public async Task<User> GetUserNameAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        
        public async Task<List<UserIndexViewModel>> GetListUserAsync()
        {
            var users = await _context.Users
                .Include(u => u.Store)
                .ToListAsync();
            var viewModels = _mapper.Map<List<UserIndexViewModel>>(users);
            return viewModels;
        }

        public async Task<bool> CreateUserAsync(UserCreateViewModel createViewModel)
        {
            try
            {
                var user = new User
                {
                    Email = createViewModel.Email,
                    Password = SecurePasswordHasher.Hash(createViewModel.Password),
                    Fullname = createViewModel.Fullname,
                    Address = createViewModel.Address,
                    StoreId = createViewModel.StoreId,
                    Phone = createViewModel.Phone,
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        
        public async Task<UserEditViewModel> GetUserEditAsync(int? id)
        {
            var user = await _context.Users.FindAsync(id);
            var editViewModel = _mapper.Map<UserEditViewModel>(user);
            return editViewModel;
        }
        
        public async Task<bool> EditUserAsync(UserEditViewModel userEditViewModel)
        {
            try
            {
                var user = await _context.Users.FindAsync(userEditViewModel.Id);
            
                user.Fullname = userEditViewModel.Fullname;
                user.Email = userEditViewModel.Email;
                user.Address = userEditViewModel.Address;
                user.Phone = userEditViewModel.Phone;
                user.StoreId = userEditViewModel.StoreId;
            
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        
        public async Task<bool> DeleteUserAsync(int? id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<UserChangePasswordViewModel> GetChangePasswordAsync(int? id)
        {
            var user = await _context.Users.FindAsync(id);
            var changePasswordViewModel = _mapper.Map<UserChangePasswordViewModel>(user);
            return changePasswordViewModel;
        }
        
        public async Task<bool> ChangePasswordAsync(UserChangePasswordViewModel changePasswordModel)
        {
            try
            {
                var user = await _context.Users.FindAsync(changePasswordModel.Id);

                if (SecurePasswordHasher.Verify(changePasswordModel.OldPassword, user.Password))
                {
                    user.Email = changePasswordModel.Email;
                    user.Password = SecurePasswordHasher.Hash(changePasswordModel.NewPassword);
                    
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        
        #endregion
        
    }//end of class
}