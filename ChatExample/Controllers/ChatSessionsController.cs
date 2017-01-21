using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Codefirst_Models;

namespace ChatExample.Controllers
{
    public class ChatSessionsController : Controller
    {
        private Codefirst_Models.Models db = new Codefirst_Models.Models();

        // GET: ChatSessions
        public ActionResult Index()
        {
            return View(db.ChatSessions.ToList());
        }

        // GET: ChatSessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatSession chatSession = db.ChatSessions.Find(id);
            if (chatSession == null)
            {
                return HttpNotFound();
            }
            return View(chatSession);
        }

        // GET: ChatSessions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChatSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartedAt")] ChatSession chatSession)
        {
            if (ModelState.IsValid)
            {
                db.ChatSessions.Add(chatSession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chatSession);
        }

        // GET: ChatSessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatSession chatSession = db.ChatSessions.Find(id);
            if (chatSession == null)
            {
                return HttpNotFound();
            }
            return View(chatSession);
        }

        // POST: ChatSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartedAt")] ChatSession chatSession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chatSession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chatSession);
        }

        // GET: ChatSessions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatSession chatSession = db.ChatSessions.Find(id);
            if (chatSession == null)
            {
                return HttpNotFound();
            }
            return View(chatSession);
        }

        // POST: ChatSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChatSession chatSession = db.ChatSessions.Find(id);
            db.ChatSessions.Remove(chatSession);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult SessionList(int? SelectedEelement)
        {
            ViewBag.SelectedEelement = SelectedEelement;
            return PartialView("_SessionList", db.ChatSessions.ToList());
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
