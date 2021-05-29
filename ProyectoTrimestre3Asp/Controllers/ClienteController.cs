﻿using System;
using System.Collections.Generic;
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

    }

    }