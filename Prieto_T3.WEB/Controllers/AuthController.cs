using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Prieto_T3.WEB.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            //Si el usuario existe en la base de datos generar la cookie, caso contrario mostrar mensaje
            //de usuario o password erroneo
            if (BD.DbEntities.Usuarios.Any(x => x.Username == username && x.Password == password))
            {
                //Que quiero guardar en la cookie
                var claims = new List<Claim>()
                {
                    new Claim (ClaimTypes.Name, username)
                };


                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(claimsPrincipal); //Crea la cookie

                return RedirectToAction("Index", "HistoriaClinica");
            }
            ModelState.AddModelError("AuthError", "Usuario y/o contraseña erronea");

            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}

