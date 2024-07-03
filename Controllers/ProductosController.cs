using ConexionEF.Entities;
using ConexionEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConexionEF.Controllers
{
    public class ProductosController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ProductoAdd()
        {
            var modelo  = new ProductoModel();

            var listaMarcas = 
            _context.MarcasProductos
                .Select(m => new SelectListItem()
                    {
                        Value = m.Id.ToString(),
                        Text = m.Nombre
                    })
                .ToList();

            modelo.ListadoMarcas = listaMarcas;

            return View(modelo);
        }

        [HttpPost]
        public IActionResult ProductoAdd(ProductoModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            Producto entity = new Producto();
            entity.Id = new Guid();
            entity.Nombre = modelo.Nombre;
            entity.Descripcion = modelo.Descripcion;

            _context.Productos.Add(entity);
            _context.SaveChanges();

            return RedirectToAction("ProductoList", "Productos");
        }

        public IActionResult ProductoList()
        {
            List<ProductoModel> list = 
            _context.Productos
                .Select(m => new ProductoModel()
                    {
                        Id = m.Id,
                        Nombre = m.Nombre,
                        Descripcion = m.Descripcion
                    })
                .ToList();

            return View(list);
        }

        public IActionResult ProductoEdit(Guid Id)
        {
            Producto entity = _context.Productos
                .FirstOrDefault(m => m.Id == Id);

            if (entity == null)
            {
                return NotFound();
            }

            ProductoModel modelo = new ProductoModel();
            modelo.Nombre = entity.Nombre;
            modelo.Descripcion = entity.Descripcion;

            return View(modelo);
        }

        [HttpPost]  
        public IActionResult ProductoEdit(ProductoModel modelo)
        {
            Producto entity = new Producto();
            entity = _context.Productos
                .FirstOrDefault(m => m.Id == modelo.Id);

            if (entity == null)
            {
                return NotFound();
            }
            
            entity.Nombre = modelo.Nombre;
            entity.Descripcion = modelo.Descripcion;

            _context.Productos.Update(entity);
            _context.SaveChanges();

            return RedirectToAction("ProductoList", "Productos");
        }

        public IActionResult ProductoDelete(Guid Id)
        {
            Producto entity = _context.Productos
                .FirstOrDefault(m => m.Id == Id);

            if (entity == null)
            {
                return NotFound();
            }

            ProductoModel modelo = new ProductoModel();
            modelo.Nombre = entity.Nombre;
            modelo.Descripcion = entity.Descripcion;

            return View(modelo);
        }

        
        [HttpPost]  
        public IActionResult ProductoDelete(ProductoModel modelo)
        {
            Producto entity = new Producto();
            entity = _context.Productos
                .FirstOrDefault(m => m.Id == modelo.Id);

            if (entity == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(entity);
            _context.SaveChanges();

            return RedirectToAction("ProductoList", "Productos");
        }

    }
}