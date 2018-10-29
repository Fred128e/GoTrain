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
        public List<Trophies> Trophies2 { get; set; }

        private WelfareDenmarkContext _context = new WelfareDenmarkContext();

        public void OnGet()
        {
            userID = _userManager.GetUserId(User);
            var UsersID = _context.AspNetUsers.FirstOrDefault(c => c.Id == userID);
            Id2 = UsersID.Id;

            var trophies1 = _context.Trophies.Where(c => c.UserForeignKeyNavigation.Id == userID);
            List<Trophies> list = new List<Trophies>();

            foreach (var item in trophies1)
            {
                var TrophyLis = _context.TrophyLists.First(c => c.TrophylistId == item.Trophylistkey);

                TrophyList trophyL = new TrophyList()
                {
                    TrophyName = TrophyLis.TrophyName, TrophylistId = TrophyLis.TrophylistId, Description = item.trophyList.Description, Goal = item.trophyList.Goal


                };
                Trophies trophy = new Trophies
                {
                    Id = item.Id, Counter = item.Counter, UserForeignKey = item.UserForeignKey, trophyList = trophyL
                };

                list.Add(trophy);


            }

            Trophies2 = list;




        }

    }
}