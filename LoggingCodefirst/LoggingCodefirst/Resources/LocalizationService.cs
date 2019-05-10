using System.Reflection;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Resources
{
    public class LocalizationService
    {
        private readonly IStringLocalizer _localizer;
 
        public LocalizationService(IStringLocalizerFactory factory)
        {
            var type = typeof(PropertyResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("PropertyResource", assemblyName.Name);
            _localizer = factory.Create("ViewResource", assemblyName.Name);
        }
 
        public LocalizedString GetLocalizedString(string key)
        {
            return _localizer[key];
        }
    }
    // dummy class for grouping localizarion resources
    public class PropertyResource
    {
    }
}