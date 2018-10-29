using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using GoTrain.Models;
using System.Collections;

namespace GoTrain.Areas.Identity.Pages.Account.Manage
{
    public class TrophiesModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public TrophiesModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string userID = "";
        public string Id2 { get; set; }
        private WelfareDenmarkContext _context = new WelfareDenmarkContext();

        public void OnGet()
        {
            userID = _userManager.GetUserId(User);
            var UsersID = _context.AspNetUsers.FirstOrDefault(c => c.Id == userID);
            Id2 = UsersID.Id;

        }

    }
}