using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GolfScorePoster.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GolfScorePoster.Controllers;

public class UserController : Controller
{
    private GolfContext _context;

    public UserController(GolfContext context)
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

    [HttpGet("")]
    public IActionResult LoginRegister()
    {
        return View("LoginRegistration");
    }

        [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid == false)
        {
            return LoginRegister();
        }
        if (_context.Users.Any(User => User.Email == newUser.Email))
        {
            ModelState.AddModelError("Email", "is already in use");
            return LoginRegister();
        }


        return RedirectToAction("AllHobbies", "Hobby");
    }

    [HttpPost("/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid == false)
        {
            ViewBag.AuthorizationError = "Your email or password is incorrect";
            return LoginRegister();
        }
        User? foundUser = _context.Users.FirstOrDefault(user => user.Email == loginUser.LoginEmail);

        if (foundUser == null)
        {
            ModelState.AddModelError("Email", "and/or password do not match");
            return LoginRegister();
        }

        PasswordHasher<LoginUser> hashedPW = new PasswordHasher<LoginUser>();
        PasswordVerificationResult PassCompare = hashedPW.VerifyHashedPassword(loginUser, foundUser.Password, loginUser.LoginPassword);

        if (PassCompare == 0)
        {
            ModelState.AddModelError("Password", "does not match up");
            return LoginRegister();
        }
        HttpContext.Session.SetInt32("UserId", foundUser.UserId);
        return RedirectToAction("AllHobbies", "Hobby");
    }

        [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("LoginRegister");
    }
}