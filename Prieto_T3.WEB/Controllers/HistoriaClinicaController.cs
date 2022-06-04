using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prieto_T3.WEB.BD;
using Prieto_T3.WEB.Models;
using System.Security.Claims;

namespace Prieto_T3.WEB.Controllers
{
    [Authorize]
    public class HistoriaClinicaController : Controller
    {
        private DbEntities _dbEntities;
        public HistoriaClinicaController(DbEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var historias = _dbEntities.Historias;
            return View(historias);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HistoriaClinica historia)
        {
            historia.Usuarioid = GetLoggedUser().Id;


            if (historia.NombreMascota == null || historia.NombreMascota == "")
            {
                ModelState.AddModelError("NombreMas", "El nombre es obligatorio");
            }
            if (historia.NombreDueño == null || historia.NombreDueño == "")
            {
                ModelState.AddModelError("NombreDue", "El nombre es obligatorio");
            }
            if (historia.Direccion == null || historia.Direccion == "")
            {
                ModelState.AddModelError("Direccion", "Direccion obligatoria");
            }
            if (historia.Telefono == null || historia.Telefono == "")
            {
                ModelState.AddModelError("Telefono", "Telefono obligatorio");
            }


            if (ModelState.IsValid)
            {
                _dbEntities.Historias.Add(historia);
                _dbEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", historia);
        }

        private Models.Usuario GetLoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
            var username = claim.Value;
            return BD.DbEntities.Usuarios.First(o => o.Username == username);
        }
    }
}
