using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MPTEditor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MPTEditor.Controllers
{
    public class AccountController : Controller
    {

        public ApplicationContext db;

        public AccountController(ApplicationContext content)
        {
            this.db = content;
        }
        public async Task<IActionResult> Autorise()
        {
            return await Task.Run(() => View());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Autorise(Users user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var users = await db.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);
                    if (users != null)
                    {
                        var UsersPositions = (from m in db.Users
                                              join t in db.Position on m.Position_id equals t.ID_Position
                                              select new DobleUsersPosition
                                              {
                                                  Id_User = m.Id_User,
                                                  Email = m.Email,
                                                  Name_position = t.Name_position
                                              }).ToList();

                        var AllUsers = UsersPositions.Where(p => p.Id_User == users.Id_User);

                        await Authenticate(AllUsers.First()); // аутентификация

                        return RedirectToAction("EditTableAttendance", "Editor");
                    }
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
                return await Task.Run(() => View(user));
            }
            catch
            {
                return await Task.Run(() => View(user));
            }
        }

        private async Task Authenticate(DobleUsersPosition users)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, users.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, users.Name_position)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet]
        public async Task<IActionResult> Registration()
        {
            return await Task.Run(() => View());
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    user = new Users { Email = model.Email, Password = model.Password, LastName = model.LastName, FirstName = model.FirstName, MiddleName = model.MiddleName };
                   
                    if (user != null)
                        user.Position_id = 2;

                    db.Users.Add(user);
                    await db.SaveChangesAsync();

                    var UsersPositions = (from m in db.Users
                                          join t in db.Position on m.Position_id equals t.ID_Position
                                          select new DobleUsersPosition
                                          {
                                              Id_User = m.Id_User,
                                              Email = m.Email,
                                              Name_position = t.Name_position
                                          }).ToList();

                    var AllUsers = UsersPositions.Where(p => p.Id_User == user.Id_User);

                    await Authenticate(AllUsers.First());

                    return RedirectToAction("MainMenu", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

    }
}
