using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Rooster.Website.Infrastructure.Membership
{
    public class FormsAuthenticationService:IFormsAuthenticationService
    {
        public void SignIn(string emailAddress, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(emailAddress)) throw new ArgumentException("Value cannot be null or empty.", "emailAddress");

            FormsAuthentication.SetAuthCookie(emailAddress, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }

    public interface IFormsAuthenticationService
    {
        void SignIn(string emailAddress, bool createPersistentCookie);
        void SignOut();
    }
}