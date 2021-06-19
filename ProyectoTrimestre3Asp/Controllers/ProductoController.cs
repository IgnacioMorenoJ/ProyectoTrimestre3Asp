using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTrimestre3Asp.Models;

namespace ProyectoTrimestre3Asp.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.productoes.ToList());
            }
        }

        public static string NombreProveedor(int idProveedor)
        {
            using (var db = new inventario2021Entities())
            {
                return db.proveedors.Find(idProveedor).nombre;
            }
        }

        public ActionResult ListarProveedores()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.proveedors.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(producto newProducto)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.productoes.Add(newProducto);
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
                producto productoDetalle = db.productoes.Where(a => a.id == id).FirstOrDefault();
                return View(productoDetalle);
            }

        }

        public ActionResult Delete(int id)
        {

            using (var db = new inventario2021Entities())
            {
                var productDelete = db.productoes.Find(id);
                db.productoes.Remove(productDelete);
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
                    producto producto = db.productoes.Where(a => a.id == id).FirstOrDefault();
                    return View(producto);
                }

            } catch (Exception ex)

            {
                ModelState.AddModelError("", "error" + ex);
                return View();

            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (producto productoEdit) 
        
        { 
            try 
            
            { 

             using ( var db = new inventario2021Entities())
                
             {
                    var producto = db.productoes.Find(productoEdit.id);
                    producto.nombre = productoEdit.nombre;
                    producto.percio_unitario = productoEdit.percio_unitario;
                    producto.cantidad = productoEdit.cantidad;
                    producto.descripcion = productoEdit.descripcion;
                    producto.id_proveedor = productoEdit.id_proveedor;
                    
                    db.SaveChanges();
                    return RedirectToAction("Index");
                     
             }

            } catch (Exception ex)
            
            { 
                ModelState.AddModelError ("", "error" + ex);
                return View();
            }

        }

        public ActionResult Reporte()
        {
            try
            {
                var db = new inventario2021Entities();
                var query = from tablaProveedor in db.proveedors
                            join tablaProducto in db.productoes on tablaProveedor.id equals tablaProducto.id_proveedor
                            select new Reporte
                            {

                                NombreProveedor = tablaProveedor.nombre,
                                DireccionProveedor = tablaProveedor.direccion,
                                TelefonoProveedor = tablaProveedor.telefono,
                                NombreProducto = tablaProducto.nombre,
                                PrecioProducto = tablaProducto.percio_unitario
                            };

                return View(query);

            }catch(Exception ex)
            {
                ModelState.AddModelError(" ", "Error " + ex);
                return View();
            }


        }


    }

    
}
