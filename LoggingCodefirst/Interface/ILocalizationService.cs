using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Interface
{
    public interface ILocalizationService<T>
    {
        
        #region Public Method
        
        /// <summary>
        /// Get Localized String
        /// </summary>
        /// <param name="key">Localized String</param>
        /// <returns></returns>
        LocalizedString GetLocalizedString(string key);

        #endregion
        
    }//end of interface
}