using System;
using System.Reflection;
using LoggingCodefirst.Interface;
using Microsoft.Extensions.Localization;
using Serilog;

namespace LoggingCodefirst.Services
{
    
    public class LocalizationService<T> :ILocalizationService
    { 
        
        #region Private Members

        private readonly IStringLocalizer _localizer;
 
        #endregion
        
        #region Constructors

        public LocalizationService(IStringLocalizerFactory factory)
        {
            var type = typeof(T);
            var assemblyName = type.GetTypeInfo().Assembly.GetName().Name;
            var baseName = type.Name;
            _localizer = factory.Create(baseName, assemblyName);
        }
        
        #endregion       
        
        #region Public Methods

        public LocalizedString GetLocalizedString(string key)
        {
            try
            {
                return _localizer[key];
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw;
            }
        }
        
        #endregion       

    }   
}