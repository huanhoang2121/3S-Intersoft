using System;
using System.Collections.Generic;
using LoggingCodefirst.Models;
using LoggingCodefirst.Models.Data;
using Serilog;

namespace LoggingCodefirst.Interface
{
    public interface IRoleService
    {
        
        #region Public Methods
        
        /// <summary>
        /// Stores
        /// </summary>
        /// <returns>Stores</returns>
        IEnumerable<Role> GetRoles();        
        
        #endregion
        
    }//end of interface
}