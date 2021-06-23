using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTrimestre3Asp.Models; 

namespace ProyectoTrimestre3Asp.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
                        
        {
            using (var db = new inventario2021Entities()) 
            {
                return View(db.clientes.ToList());
            }
                              
        }

        public ActionResult Create()

        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(cliente cliente)

        {

            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())

                {
                    db.clientes.Add(cliente);
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
                    cliente finduser = db.clientes.Where(a => a.id == id).FirstOrDefault();
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
                var cliente = db.clientes.Find(id);
                db.clientes.Remove(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(cliente clienteEdit)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    cliente user = db.clientes.Find(clienteEdit.id);

                    user.nombre = clienteEdit.nombre;
                    user.documento = clienteEdit.documento;
                    user.email = clienteEdit.email;
                    
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
                cliente user = db.clientes.Find(id);
                return View(user);
            }
        }

        public ActionResult uploadCLienteCSV()

        {
            return View();

        }

        [HttpPost]
        public ActionResult uploadClienteCSV(HttpPostedFileBase fileForm)

        {
            
            string filePath = string.Empty;

            
            if (fileForm != null)

            {
              
                string path = Server.MapPath("~/Uploads/");

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
                        var newCliente = new cliente
                        {
                            nombre = row.Split(';')[0],
                            documento = row.Split(';')[1],
                            email = row.Split(';')[2],
                                                    };

                        using (var db = new inventario2021Entities())

                        {
                            db.clientes.Add(newCliente);
                            db.SaveChanges();

                        }

                    }

                }

            }

            return View();

        }

    }

    }