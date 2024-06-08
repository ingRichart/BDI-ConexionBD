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
            MarcaProducto entity = new MarcaProducto();
            entity.Id = new Guid();
            entity.Nombre = "Coca-Cola";
            entity.Descripcion = "Marca de grupo FAMSA";

            _context.MarcasProductos.Add(entity);
            _context.SaveChanges();

            return View();
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
                .Where(m => m.Id == Id)
                .FirstOrDefault();

            entity.Nombre = "Pepsi";
            entity.Descripcion = "Grupo PEPSICO";

            _context.MarcasProductos.Update(entity);
            _context.SaveChanges();

            return View();
        }

        public IActionResult MarcaDelete()
        {
            return View();
        }

    }
}