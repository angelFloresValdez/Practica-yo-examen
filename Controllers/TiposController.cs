using ConexionEF.Entities;
using ConexionEF.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConexionEF.Controllers
{
    public class TiposController : Controller
    {
        public readonly ApplicationDbContext _context;

        public TiposController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult TipoAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TipoAdd(TipoModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            TipoProducto entity = new TipoProducto();
            entity.Id = new Guid();
            entity.Nombre = modelo.Nombre;
            entity.Descripcion = modelo.Descripcion;

            _context.TiposProductos.Add(entity);
            _context.SaveChanges();

            return RedirectToAction("TipoList", "Tipos");
        }

        public IActionResult TipoList()
        {
            List<TipoModel> list = 
            _context.TiposProductos
                .Select(m => new TipoModel()
                    {
                        Id = m.Id,
                        Nombre = m.Nombre,
                        Descripcion = m.Descripcion
                    })
                .ToList();

            return View(list);
        }

        public IActionResult TipoEdit(Guid Id)
        {
            TipoProducto entity = _context.TiposProductos
                .FirstOrDefault(m => m.Id == Id);

            if (entity == null)
            {
                return NotFound();
            }

            TipoModel modelo = new TipoModel();
            modelo.Nombre = entity.Nombre;
            modelo.Descripcion = entity.Descripcion;

            return View(modelo);
        }

        [HttpPost]  
        public IActionResult TipoEdit(TipoModel modelo)
        {
            TipoProducto entity = new TipoProducto();
            entity = _context.TiposProductos
                .FirstOrDefault(m => m.Id == modelo.Id);

            if (entity == null)
            {
                return NotFound();
            }
            
            entity.Nombre = modelo.Nombre;
            entity.Descripcion = modelo.Descripcion;

            _context.TiposProductos.Update(entity);
            _context.SaveChanges();

            return RedirectToAction("TipoList", "Tipos");
        }

        public IActionResult TipoDelete(Guid Id)
        {
            TipoProducto entity = _context.TiposProductos
                .FirstOrDefault(m => m.Id == Id);

            if (entity == null)
            {
                return NotFound();
            }

            TipoModel modelo = new TipoModel();
            modelo.Nombre = entity.Nombre;
            modelo.Descripcion = entity.Descripcion;

            return View(modelo);
        }

        
        [HttpPost]  
        public IActionResult TipoDelete(TipoModel modelo)
        {
            TipoProducto entity = new TipoProducto();
            entity = _context.TiposProductos
                .FirstOrDefault(m => m.Id == modelo.Id);

            if (entity == null)
            {
                return NotFound();
            }

            _context.TiposProductos.Remove(entity);
            _context.SaveChanges();

            return RedirectToAction("TipoList", "Tipos");
        }

    }
}