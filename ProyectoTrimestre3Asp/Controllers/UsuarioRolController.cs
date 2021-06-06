﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTrimestre3Asp.Models;

namespace ProyectoTrimestre3Asp.Controllers
{
    public class UsuarioRolController : Controller
    {
        // GET: UsuarioRol
        public ActionResult Index()

        {
            using (var db = new inventario2021Entities())
            {
                return View(db.usuariorols.ToList());
            }

        }

        public static string UsuarioRol(int idUsuario)
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

        public static string RolUsuario(int idRole)
        {
            using (var db = new inventario2021Entities())
            {
                return db.roles.Find(idRole).descripcion;
            }
        }

        public ActionResult ListarRoles()
        {
            using (var db = new inventario2021Entities())

            {
                return PartialView(db.roles.ToList());

            }
        }

        public ActionResult Create()

        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(usuariorol usuarioRol)

        {

            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())

                {
                    db.usuariorols.Add(usuarioRol);
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

        public ActionResult Delete(int id)
        {
            using (var db = new inventario2021Entities())
            {
                var usuarioRol = db.usuariorols.Find(id);
                db.usuariorols.Remove(usuarioRol);
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
                    usuariorol finduser = db.usuariorols.Where(a => a.id == id).FirstOrDefault();
                    return View(finduser);
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
        public ActionResult Edit(usuariorol usuarioRolEdit)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    usuariorol usuarioRol = db.usuariorols.Find(usuarioRolEdit.id);

                    usuarioRol.idUsuario = usuarioRolEdit.idUsuario;
                    usuarioRol.idRol = usuarioRolEdit.idRol;


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
                usuariorol usuarioRol = db.usuariorols.Find(id);
                return View(usuarioRol);
            }
        }

    }
}