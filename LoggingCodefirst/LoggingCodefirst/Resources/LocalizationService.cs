using System.Reflection;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Resources
{
    public class LocalizationService
    {
        private readonly IStringLocalizer _localizer;
 
        public LocalizationService(IStringLocalizerFactory factory)
        {
            var type = typeof(ViewResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("ViewResource", assemblyName.Name);
        }
 
        public LocalizedString GetLocalizedString(string key)
        {
            return _localizer[key];
        }
    }
    // dummy class for grouping localizarion resources
    public class ViewResource
    {
    }
    // dummy class for grouping localizarion resources
    public class PropertyResource
    {
    }
}