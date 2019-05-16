using System.Reflection;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Services
{
    public class LocalizationService<T>
    { 
        private readonly IStringLocalizer _localizer;
 
        public LocalizationService(IStringLocalizerFactory factory)
        {
            var type = typeof(T);
            var assemblyName = type.GetTypeInfo().Assembly.GetName().Name;
            var baseName = type.Name;
            _localizer = factory.Create(baseName, assemblyName);
        }
        
        public LocalizedString GetLocalizedString(string key)
        {
            return _localizer[key];
        }
    }
    /// <summary>
    /// dummy class for grouping localizarion Common Resource
    /// </summary> 
    public class CommonResource{ }
    
    /// <summary>
    /// dummy class for grouping localizarion Brand Resource
    /// </summary>
    public class HomeResource{ }
    
    /// <summary>
    /// dummy class for grouping localizarion Brand Resource
    /// </summary>
    public class UserResource{ }
    
    /// <summary>
    /// dummy class for grouping localizarion Brand Resource
    /// </summary>
    public class BrandResource{ }
    
    /// <summary>
    /// dummy class for grouping localizarion View Resource
    /// </summary>    public class UserResource{ }
    public class ViewResource{ }
}