using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTrimestre3Asp.Models;

namespace ProyectoTrimestre3Asp.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        
        public ActionResult Index()

        {
            using (var db = new inventario2021Entities())
            {
                return View(db.proveedors.ToList());
            }

        }

        public ActionResult Create()

        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(proveedor proveedor)

        {

            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())

                {
                    db.proveedors.Add(proveedor);
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

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    proveedor finduser = db.proveedors.Where(a => a.id == id).FirstOrDefault();
                    return View(finduser);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }

        }

        public ActionResult Delete(int id)
        {
            using (var db = new inventario2021Entities())
            {
                var proveedor = db.proveedors.Find(id);
                db.proveedors.Remove(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(proveedor proveedorEdit)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    proveedor user = db.proveedors.Find(proveedorEdit.id);

                    user.nombre = proveedorEdit.nombre;
                    user.direccion = proveedorEdit.direccion;
                    user.telefono = proveedorEdit.telefono;
                    user.nombre_contacto = proveedorEdit.nombre_contacto;


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
                proveedor user = db.proveedors.Find(id);
                return View(user);
            }
        }

        public ActionResult uploadCSV() 
        
        {
            return View();

        }

        [HttpPost]
        public ActionResult uploadCSV(HttpPostedFileBase fileForm) 
        
        {
            //String para guardar la ruta
            string filePath = string.Empty;

            //Condicion para saber si llego el archivo
            if (fileForm != null) 
            
            {
                //Ruta de la carpeta que guardara el archivo
                string path = Server.MapPath("~/Uploads/");

                //Condicion para saber si la ruta de la carpeta existe

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path); 

                }

                //Obtener el nombre del archivo

                filePath = path + Path.GetFileName(fileForm.FileName);

                //Obterner la extension del archivo

                string extension = Path.GetExtension(fileForm.FileName);

                //Guardar el Archivo

                fileForm.SaveAs(filePath);

                string csvData = System.IO.File.ReadAllText(filePath);

                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        var newProveedor = new proveedor
                        {
                            nombre = row.Split(';')[0],
                            direccion = row.Split(';')[1],
                            telefono = row.Split(';')[2],
                            nombre_contacto = row.Split(';')[3],
                        };

                        using (var db = new inventario2021Entities())

                        {
                            db.proveedors.Add(newProveedor);
                            db.SaveChanges();

                        }

                    }

                }
                                         
            }

            return View();

        }

    }
}