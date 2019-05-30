using System;
using Microsoft.AspNetCore.Http;

namespace LoggingCodefirst.Authentication
{
    public static class UserCookieAuthenticationDefaults
    {
        /// <summary>
        /// The default value used for authentication scheme
        /// </summary>
        public const string AuthenticationScheme = "Authentication";
        
        /// <summary>
        /// The default value for the login path
        /// </summary>
        public static readonly PathString LoginPath = new PathString("/Account/Login");

        /// <summary>
        /// The default value used for the logout path
        /// </summary>
        public static readonly PathString LogoutPath = new PathString("/Account/Logout");

        /// <summary>
        /// The default value for the access denied path
        /// </summary>
        public static readonly PathString AccessDeniedPath = new PathString("/Error/401");

        /// <summary>
        /// The default value of the return url parameter
        /// </summary>
        public static readonly string ReturnUrlParameter = "RequestPath";
        /// <summary>
        /// The default value of the return url parameter
        /// </summary>
        public static readonly TimeSpan ExpireTimeSpan = TimeSpan.FromMinutes(30);
    }
}