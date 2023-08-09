using CrudASP.Datos;
using CrudASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Diagnostics;

namespace CrudASP.Controllers
{
    public class InicioController : Controller
    {
        private readonly ApplicationDbContext _contexto;// se llama para poder acceder

        public InicioController(ApplicationDbContext contexto)
        {// aplicamos la inyeccion de dependencias y por medio de la variable contexto podemos aceder a cualquier propiedad
            // o modelo que contenga el programa.
            _contexto = contexto;  
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // utilizamos Entity Framework pora poder acceder a la entidad
            return View(await _contexto.Contactos.ToListAsync()); // retornara una lista 
        }

        [HttpGet]
        public async Task<IActionResult> Crear()// si no existe la vista clieck derecho, agregar vista >= vista reizor vacia, crear y nombre igual al metodo
        {
            // utilizamos Entity Framework pora poder acceder a la entidad
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]// Impide ataques Xcsc
        public async Task<IActionResult> Crear(Contacto contacto)
        {
            // cuando el modelo tiene datos osea que las validaciones se cumplen
            if (ModelState.IsValid)
            {
                // se envian los datos
                _contexto.Contactos.Add(contacto);
                contacto.FechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                await _contexto.SaveChangesAsync(); // se realiza el guardado 
                return RedirectToAction(nameof(Index));// y retorna la vista
            }
            // si no tiene datos retorna la vista
            return View();
        }

        // metodo para editar validamos que el id que buscamos no venga vacio
        [HttpGet]
        public IActionResult Editar(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _contexto.Contactos.Find(id);

            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]// Impide ataques Xcsc
        public async Task<IActionResult> Editar(Contacto contacto)
        {
            // cuando el modelo tiene datos osea que las validaciones se cumplen
            if (ModelState.IsValid)
            {
                // se envian los datos
                _contexto.Update(contacto);
                contacto.FechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                await _contexto.SaveChangesAsync(); // se realiza el guardado 
                return RedirectToAction(nameof(Index));// y retorna la vista
            }
            // si no tiene datos retorna la vista
            return View();
        }

        [HttpGet]
       public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contacto = _contexto.Contactos.Find(id);

            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }


        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contacto = _contexto.Contactos.Find(id);

            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]// Impide ataques Xcsc
        public async Task<IActionResult> EliminarContacto(int? id)
        {
            var contacto = await _contexto.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return View();
            }
            // borramos el contacto
            _contexto.Contactos.Remove(contacto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}