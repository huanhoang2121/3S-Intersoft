using System.Threading.Tasks;
using LoggingCodefirst.Models;

namespace LoggingCodefirst.Authentication
{
    /// <summary>
    /// Authentication service interface
    /// </summary>
    public interface IUserAuthenticationService
    {
        /// <summary>
        /// Sign in
        /// </summary>
        /// <param name="user">Customer</param>
        /// <param name="createPersistentCookie">A value indicating whether to create a persistent cookie</param>
        Task SignIn(User user, bool createPersistentCookie);

        /// <summary>
        /// Sign out
        /// </summary>
        Task SignOut();  
    }
}