using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTrimestre3Asp.Models;

namespace ProyectoTrimestre3Asp.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()

        {
            using (var db = new inventario2021Entities())

        {
                return View(db.compras.ToList());
        }

        }
        public static string NombreUsuario(int idUsuario)
        {
            using (var db = new inventario2021Entities())
            {
                return db.usuarios.Find(idUsuario).nombre;
            }
        }

        public ActionResult ListarUsuarios()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.usuarios.ToList());
            }
        }

        public static string NombreCliente(int idCliente)
        {
            using (var db = new inventario2021Entities())
            {
                return db.clientes.Find(db.clientes).nombre;
            }
        }

        public ActionResult ListarClientes()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.clientes.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(compra newCompra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.compras.Add(newCompra);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }


    }
}