using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rooster.Service;
using Rooster.Website.Models.AccountViewModels;

namespace Rooster.Website.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        private readonly ISecurityService _securityService;

        public AccountController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool validCredentials = _securityService.ValidateMember(viewModel.EmailAddress, viewModel.Password);
                if (validCredentials)
                {
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
