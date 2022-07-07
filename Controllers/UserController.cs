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
    public IActionResult Login()
    {
        return View("Login");
    }

    [HttpGet("/register")]
    public IActionResult Register()
    {
        return View("Register");
    }

    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid == false)
        {
            return Register();
        }
        if (_context.Users.Any(User => User.Email == newUser.Email))
        {
            ModelState.AddModelError("Email", "is already in use");
            return Register();
        }
                if (_context.Users.Any(User => User.Username == newUser.Username))
        {
            ModelState.AddModelError("Username", "is already in use");
            return Register();
        }

        PasswordHasher<User> hashedPW = new PasswordHasher<User>();
        newUser.Password = hashedPW.HashPassword(newUser, newUser.Password);

        _context.Users.Add(newUser);
        _context.SaveChanges();


        return RedirectToAction("Dashboard", "Score");
    }

    [HttpPost("/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid == false)
        {
            ViewBag.AuthorizationError = "Your email or password is incorrect";
            return Login();
        }
        User? foundUser = _context.Users.FirstOrDefault(user => user.Email == loginUser.LoginEmail);

        if (foundUser == null)
        {
            ModelState.AddModelError("Email", "and/or password do not match");
            return Login();
        }

        PasswordHasher<LoginUser> hashedPW = new PasswordHasher<LoginUser>();
        PasswordVerificationResult PassCompare = hashedPW.VerifyHashedPassword(loginUser, foundUser.Password, loginUser.LoginPassword);

        if (PassCompare == 0)
        {
            ModelState.AddModelError("Password", "does not match up");
            return Login();
        }
        HttpContext.Session.SetInt32("UserId", foundUser.UserId);
        return RedirectToAction("Dashboard", "Score");
    }

        [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("LoginRegister");
    }
}