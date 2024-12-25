using Microsoft.Extensions.Localization;
using System.Reflection;

namespace GeneMap.WebUI.Services
{
    public class SharedResource
    {

    }
    public class LanguageService
    {
        private readonly IStringLocalizer _localizer;
        public LanguageService(IStringLocalizerFactory stringLocalizerFactory)
        {
            var type = typeof(SharedResource);
            var assemblyType = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = stringLocalizerFactory.Create(nameof(SharedResource), assemblyType.Name);
        }

        public LocalizedString GetKey(string key)
        {
            return _localizer[key];
        }
    }
}
