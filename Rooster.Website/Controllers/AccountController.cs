using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rooster.Service;
using Rooster.Website.Infrastructure.Membership;
using Rooster.Website.Models.AccountViewModels;

namespace Rooster.Website.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        private readonly ISecurityService _securityService;
        private readonly IFormsAuthenticationService _formsAuthenticationService;

        public AccountController(ISecurityService securityService, IFormsAuthenticationService formsAuthenticationService)
        {
            _securityService = securityService;
            _formsAuthenticationService = formsAuthenticationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool validCredentials = _securityService.ValidateMember(viewModel.EmailAddress, viewModel.Password);
                if (validCredentials)
                {
                    _formsAuthenticationService.SignIn(viewModel.EmailAddress, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(viewModel); 
                }
            }
            else
            {
                return View();
            }
        }
        
        public ActionResult Logoff()
        {
            if (User.Identity.IsAuthenticated)
            {
                _formsAuthenticationService.SignOut();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                
            }

            return Index();
        }

    }
}
