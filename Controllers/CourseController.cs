using Microsoft.AspNetCore.Mvc;
using GolfScorePoster.Models;
using Microsoft.EntityFrameworkCore;

namespace GolfScorePoster.Controllers;

public class CourseController : Controller
{
    private GolfContext _context;

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

    [HttpGet("/courses/new")]
    public IActionResult New()
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "Home");
        }
        return View("AddCourse");
    }

    [HttpPost("/courses/create")]
    public IActionResult Create(GolfCourse newCourse)
    {
        if(uid == null)
        {
            return RedirectToAction("Index", "Home");
        }

        if (ModelState.IsValid == false)
        {
            return New();
        }
        if (_context.Courses.Any(course => course.CourseName == newCourse.CourseName))
        {
            ModelState.AddModelError("Course Name", "has already been created");
            return New();
        }
        _context.Courses.Add(newCourse);
        _context.SaveChanges();

        return RedirectToAction("Dashboard", "Score");
    }
}