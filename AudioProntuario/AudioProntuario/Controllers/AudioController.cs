using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using AudioProntuario.DAL;
using AudioProntuario.Models;

namespace AudioProntuario.Controllers
{
    public class AudioController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Audio
        public ActionResult Index()
        {
            return View(db.AudioDB.ToList());
        }

        // GET: Audio/Details/5
        [HttpPost]
        public ActionResult SalvarAudio(string base64)
        {
            Audio audio = new Audio();

            try
            {

                audio.AudioProntuario = base64;
                db.AudioDB.Add(audio);
            }
            catch
            {
                throw;
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Audio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Audio/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAudio,AudioProntuario")] Audio audio)
        {
            if (ModelState.IsValid)
            {
                db.AudioDB.Add(audio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(audio);
        }

        // GET: Audio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audio audio = db.AudioDB.Find(id);
            if (audio == null)
            {
                return HttpNotFound();
            }
            return View(audio);
        }

        // POST: Audio/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAudio,AudioProntuario")] Audio audio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(audio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(audio);
        }

        // GET: Audio/Delete/5
        public ActionResult Delete(int? id)
        {
            Audio guia = db.AudioDB.Find(id);
            db.AudioDB.Remove(guia);
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
