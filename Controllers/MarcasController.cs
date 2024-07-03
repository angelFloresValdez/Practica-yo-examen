using ConexionEF.Entities;
using ConexionEF.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConexionEF.Controllers
{
    public class MarcasController : Controller
    {
        public readonly ApplicationDbContext _context;

        public MarcasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult MarcaAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MarcaAdd(MarcaModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            MarcaProducto entity = new MarcaProducto();
            entity.Id = new Guid();
            entity.Nombre = modelo.Nombre;
            entity.Descripcion = modelo.Descripcion;

            _context.MarcasProductos.Add(entity);
            _context.SaveChanges();

            return RedirectToAction("MarcaList", "Marcas");
        }

        public IActionResult MarcaList()
        {
            List<MarcaModel> list = 
            _context.MarcasProductos
                .Select(m => new MarcaModel()
                    {
                        Id = m.Id,
                        Nombre = m.Nombre,
                        Descripcion = m.Descripcion
                    })
                .ToList();

            return View(list);
        }

        public IActionResult MarcaEdit(Guid Id)
        {
            MarcaProducto entity = _context.MarcasProductos
                .FirstOrDefault(m => m.Id == Id);

            if (entity == null)
            {
                return NotFound();
            }

            MarcaModel modelo = new MarcaModel();
            modelo.Nombre = entity.Nombre;
            modelo.Descripcion = entity.Descripcion;

            return View(modelo);
        }

        [HttpPost]  
        public IActionResult MarcaEdit(MarcaModel modelo)
        {
            MarcaProducto entity = new MarcaProducto();
            entity = _context.MarcasProductos
                .FirstOrDefault(m => m.Id == modelo.Id);

            if (entity == null)
            {
                return NotFound();
            }
            
            entity.Nombre = modelo.Nombre;
            entity.Descripcion = modelo.Descripcion;

            _context.MarcasProductos.Update(entity);
            _context.SaveChanges();

            return RedirectToAction("MarcaList", "Marcas");
        }

        public IActionResult MarcaDelete(Guid Id)
        {
            MarcaProducto entity = _context.MarcasProductos
                .FirstOrDefault(m => m.Id == Id);

            if (entity == null)
            {
                return NotFound();
            }

            MarcaModel modelo = new MarcaModel();
            modelo.Nombre = entity.Nombre;
            modelo.Descripcion = entity.Descripcion;

            return View(modelo);
        }

        
        [HttpPost]  
        public IActionResult MarcaDelete(MarcaModel modelo)
        {
            MarcaProducto entity = new MarcaProducto();
            entity = _context.MarcasProductos
                .FirstOrDefault(m => m.Id == modelo.Id);

            if (entity == null)
            {
                return NotFound();
            }

            _context.MarcasProductos.Remove(entity);
            _context.SaveChanges();

            return RedirectToAction("MarcaList", "Marcas");
        }

    }
}