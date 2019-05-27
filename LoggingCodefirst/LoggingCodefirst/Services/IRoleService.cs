using System.Collections.Generic;
using LoggingCodefirst.Models;
using LoggingCodefirst.Models.Data;

namespace LoggingCodefirst.Services
{
    public interface IRoleService
    {
        
        #region Public Methods
        
        /// <summary>
        /// Stores
        /// </summary>
        /// <returns>Stores</returns>
        IEnumerable<Role> Roles();        
        
        #endregion
        
    }//end of interface
    
    public class RoleService : IRoleService
    {
        
        #region Private Members
        
        private readonly DataContext _context;
        
        #endregion
        
        #region Constructors
        
        public RoleService(DataContext context)
        {
            _context = context;
        }
        
        #endregion

        #region Public Methods
        
        /// <inheritdoc />
        /// <summary>
        /// Stores
        /// </summary>
        /// <returns>Stores</returns>
        public IEnumerable<Role> Roles()
        {
            return _context.Roles;
        }

        #endregion
        
    }//end of class
}