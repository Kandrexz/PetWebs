using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetWebs.Models;

namespace PetWebs.Controllers
{
    public class MascotasController : Controller
    {
        private PETWEBSEntities db = new PETWEBSEntities();

        // GET: Mascotas
        public ActionResult MascList()
        {
            var mascota = db.Mascota.Include(m => m.Cliente).Include(m => m.Especie1).Include(m => m.Raza1);
            return View(mascota.ToList());
        }

        // GET: Mascotas/Details/5
        public ActionResult Details(string Rut)
        {
            if (Rut == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascota.Find(Rut);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // GET: Mascotas/Create
        public ActionResult Create()
        {
            ViewBag.Rut = new SelectList(db.Cliente, "Rut", "Nombre");
            ViewBag.Especie = new SelectList(db.Especie, "Id", "Tipo");
            ViewBag.Raza = new SelectList(db.Raza, "Id", "Nombre");
            return View();
        }

        // POST: Mascotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Microchip,Nombre,Sexo,Peso,Color,FechaNacimiento,Esterilizado,Defuncion,FechaDef,CausaDef,ObserDef,Rut,Especie,Raza")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.Mascota.Add(mascota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Rut = new SelectList(db.Cliente, "Rut", "Nombre", mascota.Rut);
            ViewBag.Especie = new SelectList(db.Especie, "Id", "Tipo", mascota.Especie);
            ViewBag.Raza = new SelectList(db.Raza, "Id", "Nombre", mascota.Raza);
            return View(mascota);
        }

        // GET: Mascotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascota.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            ViewBag.Rut = new SelectList(db.Cliente, "Rut", "Nombre", mascota.Rut);
            ViewBag.Especie = new SelectList(db.Especie, "Id", "Tipo", mascota.Especie);
            ViewBag.Raza = new SelectList(db.Raza, "Id", "Nombre", mascota.Raza);
            return View(mascota);
        }

        // POST: Mascotas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Microchip,Nombre,Sexo,Peso,Color,FechaNacimiento,Esterilizado,Defuncion,FechaDef,CausaDef,ObserDef,Rut,Especie,Raza")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Rut = new SelectList(db.Cliente, "Rut", "Nombre", mascota.Rut);
            ViewBag.Especie = new SelectList(db.Especie, "Id", "Tipo", mascota.Especie);
            ViewBag.Raza = new SelectList(db.Raza, "Id", "Nombre", mascota.Raza);
            return View(mascota);
        }

        // GET: Mascotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascota.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mascota mascota = db.Mascota.Find(id);
            db.Mascota.Remove(mascota);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
