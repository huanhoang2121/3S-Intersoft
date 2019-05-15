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
    // dummy class for grouping localizarion resources
    public class BrandResource
    {  
    }// dummy class for grouping localizarion resources
    public class CommonResource
    {
        
    }// dummy class for grouping localizarion resources
    public class HomeResource
    {  
    }public class PropertyResource
    {  
    }// dummy class for grouping localizarion resources
    public class UserResource
    {  
    }// dummy class for grouping localizarion resources
    public class ViewResource
    {
        
    }
}