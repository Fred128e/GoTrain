using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoTrain.Models;
using Microsoft.AspNetCore.Identity;

namespace GoTrain.Controllers
{
    public class TrainingsSessionsController : Controller
    {
        private WelfareDenmarkContext _context = new WelfareDenmarkContext();

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public TrainingsSessionsController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: TrainingsSessions
        public async Task<IActionResult> Index()
        {
            var traningsPartnerSessions = _context.TraningsPartnerSession.Where(u => u.UserId == _userManager.GetUserId(User)).Select(c => c.TraningsSession);



            //await _context.TrainingsSessions.ToListAsync()
            return View(traningsPartnerSessions);
        }

        // GET: TrainingsSessions/Details/5
        //Inset træningsmakkere på
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingsSessions = await _context.TrainingsSessions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingsSessions == null)
            {
                return NotFound();
            }

            return View(trainingsSessions);
        }

        // GET: TrainingsSessions/Create
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingsSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TrainingsDescription")] TrainingsSessions trainingsSessions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingsSessions);

                TraningsPartnerSession traningsPartnerSession = new TraningsPartnerSession { UserId = _userManager.GetUserId(User), TraningsSessionId = trainingsSessions.Id };
                _context.TraningsPartnerSession.Add(traningsPartnerSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(trainingsSessions);
        }
    }
}
