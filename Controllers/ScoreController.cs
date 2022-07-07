using Microsoft.AspNetCore.Mvc;
using GolfScorePoster.Models;
using Microsoft.EntityFrameworkCore;

namespace GolfScorePoster.Controllers;

public class ScoreController : Controller
{
    private GolfContext _context;

    public ScoreController(GolfContext context)
        {
            _context = context;
        }


            private int? uid
    {
        get
        {
        return HttpContext.Session.GetInt32("UserId");
        }
    }
    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }
    
    [HttpGet("scores/home")]

    public IActionResult Dashboard()
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "Home");
        }

        List<GolfScore> AllScores = _context.Scores.Include(sc => sc.Player).ToList();
        return View("Dashboard", AllScores);
    }

}


