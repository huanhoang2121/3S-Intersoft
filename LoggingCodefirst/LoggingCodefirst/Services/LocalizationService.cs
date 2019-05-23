using System.Reflection;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Services
{
    public class LocalizationService<T>
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
            return _localizer[key];
        }
        
        #endregion       

    }   
}