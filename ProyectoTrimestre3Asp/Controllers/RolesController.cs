using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTrimestre3Asp.Models;

namespace ProyectoTrimestre3Asp.Controllers
{
    public class RolesController : Controller
    {
    public ActionResult Index()

    {
        using (var db = new inventario2021Entities())
        {
            return View(db.roles.ToList());
        }

    }
        public ActionResult Create()

        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(role role)

        {

            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())

                {
                    db.roles.Add(role);
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
                var role = db.roles.Find(id);
                db.roles.Remove(role);
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
                    role finduser = db.roles.Where(a => a.id == id).FirstOrDefault();
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
        public ActionResult Edit(role roleEdit)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    role role = db.roles.Find(roleEdit.id);

                    role.descripcion = roleEdit.descripcion;
                   
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
                role role = db.roles.Find(id);
                return View(role);
            }
        }

    }


}
