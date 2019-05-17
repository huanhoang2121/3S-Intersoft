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
    
    #region Public Dummy Class

    /// <summary>
    /// Dummy class for grouping localizarion Common Resource
    /// </summary> 
    public class CommonResource{ }
    
    /// <summary>
    /// Dummy class for grouping localizarion Brand Resource
    /// </summary>
    public class HomeResource{ }
    
    /// <summary>
    /// Dummy class for grouping localizarion Error Resource
    /// </summary>
    public class ErrorResource{ }
    
    /// <summary>
    /// Dummy class for grouping localizarion Brand Resource
    /// </summary>
    public class UserResource{ }
    
    /// <summary>
    /// Dummy class for grouping localizarion Brand Resource
    /// </summary>
    public class BrandResource{ }
    
    /// <summary>
    /// Dummy class for grouping localizarion Category Resource
    /// </summary>
    public class CategoryResource{ }
    
    /// <summary>
    /// Dummy class for grouping localizarion Product Resource
    /// </summary>
    public class ProductResource{ }
    
    /// <summary>
    /// Dummy class for grouping localizarion Product Resource
    /// </summary>
    public class StockResource{ }
    
    /// <summary>
    /// Dummy class for grouping localizarion Product Resource
    /// </summary>
    public class StoreResource{ }
    
    #endregion 
    
}