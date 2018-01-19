using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PopEyeTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PopEyeTrip.Controllers
{
    [AllowAnonymous]
    public class BaseController : Controller
    {
        public PartialViewResult UserState()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            // Get the current logged in User and look up the user in ASP.NET Identity
            var currentUser = manager.FindById(User.Identity.GetUserId());

            if (currentUser != null)
            {
                // Recover the profile information about the logged in user
                ViewBag.ProfileImageUrl = currentUser.ProfileImageUrl;
            }

            return PartialView();
        }
    }
}