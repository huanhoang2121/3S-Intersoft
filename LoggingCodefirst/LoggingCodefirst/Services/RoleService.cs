using System;
using System.Collections.Generic;
using LoggingCodefirst.Interface;
using LoggingCodefirst.Models;
using LoggingCodefirst.Models.Data;
using Serilog;

namespace LoggingCodefirst.Services
{
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
            try
            {
                return _context.Roles;
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw;
            }
        }

        #endregion
        
    }//end of class
}