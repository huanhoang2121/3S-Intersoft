using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace LoggingCodefirst.Validators
{
    public class ValidateImageAttribute : ValidationAttribute
    {
        /// <inheritdoc />
        /// <summary>
        /// Valid Image
        /// </summary>
        /// <param name="value">file</param>
        /// <returns>Could be Valid?</returns>
        public override bool IsValid(object value)
        {
            const int maxContentLength = 1024 * 1024 * 2; //Max 2 MB file
            string[] allowedFileExtensions =  { ".jpg", ".gif", ".png" };

            if (!(value is IFormFile file))
                return false;
            if (!((IList) allowedFileExtensions).Contains(file.FileName.Substring(file.FileName.LastIndexOf('.')).ToLower()))
            {
                ErrorMessage = "Please upload Your Photo of type: " + 
                               string.Join(", ", allowedFileExtensions);
                return false;
            }
            if (file.Length <= maxContentLength) return true;
            ErrorMessage = "Your Photo is too large, maximum allowed size is : " 
                           + (maxContentLength / 1024) + "MB";
            return false;

        }        
    }
}