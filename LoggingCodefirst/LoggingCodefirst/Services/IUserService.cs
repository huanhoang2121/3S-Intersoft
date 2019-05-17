using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoggingCodefirst.Infrastructure;
using LoggingCodefirst.Models;
using LoggingCodefirst.Models.Data;
using LoggingCodefirst.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LoggingCodefirst.Services
{
    public interface IUserService
    {
        
        #region Public Methods

        /// <summary>
        /// Users
        /// </summary>
        /// <returns>Users</returns>
        IEnumerable<User> Users();   
        
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginViewModel">LoginViewModel</param>
        /// <returns>Could be Login?</returns>
        bool Login(LoginViewModel loginViewModel);
        
        /// <summary>
        /// GetUserAsync
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns>User</returns>
        Task<User> GetUserAsync(string email);
        
        /// <summary>
        /// GetListUserAsync
        /// </summary>
        /// <returns>ListUser</returns>
        Task<List<UserViewModel>> GetListUserAsync();
        
        /// <summary>
        /// CreateUserAsync
        /// </summary>
        /// <param name="createViewModel"></param>
        /// <returns>Could be Created?</returns>
        Task<bool> CreateUserAsync(UserViewModel createViewModel);
        
        /// <summary>
        /// GetUserEditAsync
        /// </summary>
        /// <param name="id">Userid</param>
        /// <returns>UserEditViewModel</returns>
        Task<UserEditViewModel> GetUserEditAsync(int id);
        
        /// <summary>
        /// EditUserAsync
        /// </summary>
        /// <param name="editViewModel"></param>
        /// <returns>Could be Edited?</returns>
        Task<bool> EditUserAsync(UserEditViewModel editViewModel);
        
        /// <summary>
        /// GetChangePasswordAsync
        /// </summary>
        /// <param name="id">Userid</param>
        /// <returns>UserChangePasswordViewModel</returns>
        Task<UserChangePasswordViewModel> GetChangePasswordAsync(int id);
        
        /// <summary>
        /// ChangePasswordAsync
        /// </summary>
        /// <param name="changePasswordViewModel">UserChangePasswordViewModel</param>
        /// <returns>Could be Changed?</returns>
        Task<bool> ChangePasswordAsync(UserChangePasswordViewModel changePasswordViewModel);
        
        /// <summary>
        /// DeleteUserAsync
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Could be Deleted?</returns>
        Task<bool> DeleteUserAsync(int id);
        
        /// <summary>
        /// IsExistedEmail
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="email">User email</param>
        /// <returns>ExistedEmail</returns>
        bool IsExistedEmail(int id, string email);
        
        #endregion
        
    }//end of interface
    
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

        #region Public Methods
        
        /// <inheritdoc />
        /// <summary>
        /// Users
        /// </summary>
        /// <returns>Users</returns>
        public IEnumerable<User> Users()
        {
            return _context.Users.Include(s => s.Store);
        }
        
        /// <inheritdoc />
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginViewModel">LoginViewModel</param>
        /// <returns>Could be Login?</returns>
        public bool Login(LoginViewModel loginViewModel)
        {  
            var user = _context.Users.FirstOrDefault(s => s.Email == loginViewModel.Email && SecurePasswordHasher.Verify(loginViewModel.Password, s.Password));
            return user != null;
        }

        /// <inheritdoc />
        /// <summary>
        /// GetUserAsync
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns>User</returns>
        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        
        /// <inheritdoc />
        /// <summary>
        /// GetListUserAsync
        /// </summary>
        /// <returns>ListUser</returns>
        public async Task<List<UserViewModel>> GetListUserAsync()
        {
            var users = await _context.Users
                .Include(u => u.Store)
                .ToListAsync();
            var viewModels = _mapper.Map<List<UserViewModel>>(users);
            return viewModels;
        }

        /// <inheritdoc />
        /// <summary>
        /// CreateUserAsync
        /// </summary>
        /// <param name="createViewModel"></param>
        /// <returns>Could be Created?</returns>
        public async Task<bool> CreateUserAsync(UserViewModel createViewModel)
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
                
                if (createViewModel.ImageFile != null)
                {
                    var imageSrc = DateTime.Now.ToString("MMddyyyyHHmmss") + createViewModel.ImageFile.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageSrc );

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await createViewModel.ImageFile.CopyToAsync(stream);
                    }
                    user.ImagePath = imageSrc;
                }
                
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
        
        /// <inheritdoc />
        /// <summary>
        /// GetUserEditAsync
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>UserEditViewModel</returns>
        public async Task<UserEditViewModel> GetUserEditAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            var editViewModel = _mapper.Map<UserEditViewModel>(user);
            return editViewModel;
        }
        
        /// <inheritdoc />
        /// <summary>
        /// EditUserAsync
        /// </summary>
        /// <param name="editViewModel"></param>
        /// <returns>Could be Edited?</returns>
        public async Task<bool> EditUserAsync(UserEditViewModel editViewModel)
        {
            try
            {
                var user = await _context.Users.FindAsync(editViewModel.Id);
            
                user.Fullname = editViewModel.Fullname;
                user.Address = editViewModel.Address;
                user.Phone = editViewModel.Phone;
                user.StoreId = editViewModel.StoreId;
                user.Email = editViewModel.Email;
                
                if (editViewModel.ImageFile != null)
                {
                    var imageSrc = DateTime.Now.ToString("MMddyyyyHHmmss") + editViewModel.ImageFile.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageSrc );

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await editViewModel.ImageFile.CopyToAsync(stream);
                    }
                    user.ImagePath = imageSrc;
                }
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

        /// <inheritdoc />
        /// <summary>
        /// GetChangePasswordAsync
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>UserChangePasswordViewModel</returns>
        public async Task<UserChangePasswordViewModel> GetChangePasswordAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            var changePasswordViewModel = _mapper.Map<UserChangePasswordViewModel>(user);
            return changePasswordViewModel;
        }
        
        /// <inheritdoc />
        /// <summary>
        /// ChangePasswordAsync
        /// </summary>
        /// <param name="changePasswordViewModel">UserChangePasswordViewModel</param>
        /// <returns>Could be Changed?</returns>
        public async Task<bool> ChangePasswordAsync(UserChangePasswordViewModel changePasswordViewModel)
        {
            try
            {
                var user = await _context.Users.FindAsync(changePasswordViewModel.Id);
                user.Password = SecurePasswordHasher.Hash(changePasswordViewModel.NewPassword);
                    
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
        
        /// <inheritdoc />
        /// <summary>
        /// DeleteUserAsync
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Could be Deleted?</returns>
        public async Task<bool> DeleteUserAsync(int id)
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
       
        /// <inheritdoc />
        /// <summary>
        /// IsExistedEmail
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="email">User email</param>
        /// <returns>ExistedEmail</returns>
        public bool IsExistedEmail(int id, string email)
        {
            return _context.Users.Any(b => b.Email == email && b.Id != id);
        }


        #endregion
        
    }//end of class
}