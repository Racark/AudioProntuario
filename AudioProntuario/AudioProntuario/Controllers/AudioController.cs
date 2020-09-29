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

        [HttpGet]
        public JsonResult TocarAudio(int id)
        {
            Audio audio = new Audio();

            try
            {
                audio = db.AudioDB.Find(id);
            }

            catch
            {
                throw;
            }

            return Json(audio.AudioProntuario, JsonRequestBehavior.AllowGet);

        }

        // POST
        [HttpPost]
        public ActionResult SalvarAudio(string base64, string duracao, string hora)
        {
            Audio audio = new Audio();

            try
            {
                audio.duracao = duracao;
                audio.horario = hora;
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
