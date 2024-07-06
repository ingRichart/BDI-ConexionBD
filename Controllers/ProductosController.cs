using ConexionEF.Entities;
using ConexionEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

            var listaTipos =
                _context.TiposProductos
                .Select(m => new SelectListItem()
                    {
                        Value = m.Id.ToString(),
                        Text = m.Nombre
                    })
                .ToList();

            modelo.ListadoTipos = listaTipos;

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
            entity.TipoProductoId = modelo.TipoModelId;
            entity.MarcaProductoId = modelo.MarcaModelId;

            _context.Productos.Add(entity);
            _context.SaveChanges();

            return RedirectToAction("ProductoList", "Productos");
        }

        public IActionResult ProductoList()
        {
            List<ProductoModel> list = 
            _context.Productos
                .Include(t => t.TipoProducto)
                .Include(m => m.MarcaProducto)
                .Select(p => new ProductoModel()
                    {
                        Id = p.Id,
                        Nombre = p.Nombre,
                        Descripcion = p.Descripcion,
                        TipoModelNombre = p.TipoProducto.Nombre,
                        MarcaModelNombre = p.MarcaProducto.Nombre
                    })
                .ToList();

            return View(list);
        }

        public IActionResult ProductoEdit(Guid Id)
        {
             var listaMarcas = 
            _context.MarcasProductos
                .Select(m => new SelectListItem()
                    {
                        Value = m.Id.ToString(),
                        Text = m.Nombre
                    })
                .ToList();

            var listaTipos =
                _context.TiposProductos
                .Select(m => new SelectListItem()
                    {
                        Value = m.Id.ToString(),
                        Text = m.Nombre
                    })
                .ToList();

            var entity = _context.Productos
                .FirstOrDefault(m => m.Id == Id);
            if (entity == null)
            {
                return NotFound();
            }

            ProductoModel modelo = new ProductoModel();
            modelo.Nombre = entity.Nombre;
            modelo.Descripcion = entity.Descripcion;

            modelo.ListadoTipos = listaTipos;
            modelo.ListadoMarcas = listaMarcas;

            modelo.TipoModelId = entity.TipoProductoId;
            modelo.MarcaModelId = entity.MarcaProductoId;

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
            entity.TipoProductoId = modelo.TipoModelId;
            entity.MarcaProductoId = modelo.MarcaModelId;

            _context.Productos.Update(entity);
            _context.SaveChanges();

            return RedirectToAction("ProductoList", "Productos");
        }

        public IActionResult ProductoDelete(Guid Id)
        {
             var listaMarcas = 
            _context.MarcasProductos
                .Select(m => new SelectListItem()
                    {
                        Value = m.Id.ToString(),
                        Text = m.Nombre
                    })
                .ToList();

            var listaTipos =
                _context.TiposProductos
                .Select(m => new SelectListItem()
                    {
                        Value = m.Id.ToString(),
                        Text = m.Nombre
                    })
                .ToList();

            var entity = _context.Productos
                .FirstOrDefault(m => m.Id == Id);
            if (entity == null)
            {
                return NotFound();
            }

            ProductoModel modelo = new ProductoModel();
            modelo.Nombre = entity.Nombre;
            modelo.Descripcion = entity.Descripcion;

            modelo.ListadoTipos = listaTipos;
            modelo.ListadoMarcas = listaMarcas;

            modelo.TipoModelId = entity.TipoProductoId;
            modelo.MarcaModelId = entity.MarcaProductoId;
            
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