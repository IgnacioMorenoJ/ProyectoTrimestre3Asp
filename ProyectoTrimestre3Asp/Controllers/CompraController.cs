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
                return db.clientes.Find(idCliente).nombre;
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

        public ActionResult Details(int id)

        {
            using (var db = new inventario2021Entities())

            {
                compra compraDetalle = db.compras.Where(a => a.id == id).FirstOrDefault();
                return View(compraDetalle);
            }

        }

        public ActionResult Delete(int id)
        {

            using (var db = new inventario2021Entities())
            {
                var compraDelete = db.compras.Find(id);
                db.compras.Remove(compraDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(int id)

        {

            try
            {
                using (var db = new inventario2021Entities())

                {
                    compra compra= db.compras.Where(a => a.id == id).FirstOrDefault();
                    return View(compra);
                }

            }
            catch (Exception ex)

            {
                ModelState.AddModelError("", "error" + ex);
                return View();

            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(compra compraEdit)

        {
            try

            {

                using (var db = new inventario2021Entities())

                {
                    var compra = db.compras.Find(compraEdit.id);
                    compra.fecha = compraEdit.fecha;
                    compra.total = compraEdit.total;
                    compra.id_usuario = compraEdit.id_usuario;
                    compra.id_cliente = compraEdit.id_cliente;
                    
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

            }
            catch (Exception ex)

            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }

        }


    }
}