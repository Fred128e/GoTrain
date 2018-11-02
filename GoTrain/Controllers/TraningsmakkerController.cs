using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoTrain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GoTrain.Controllers
{
    public class TraningsmakkerController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public TraningsmakkerController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        private WelfareDenmarkContext _context = new WelfareDenmarkContext();

        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Post(int postnummer)
        {
          

            var user = _context.AspNetUsers.FirstOrDefault(c=>c.Id ==_userManager.GetUserId(User));
           
            user.Postnummer = postnummer;
            _context.SaveChanges();

            var Users = _context.AspNetUsers.Where(c=>c.Postnummer == postnummer).ToList();
            Users.Remove(user);
            return View(Users);

        }

       
    }
}