using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AgendaContato.Models;

namespace AgendaContato.Controllers
{
    public class ContatosController : Controller
    {
        private ContatoContext db = new ContatoContext();

        // GET: Contatos
        public ActionResult Index()
        {
            return View(db.Contatos.ToList());
        }

        // GET: Contatos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = db.Contatos
                .Include(c => c.Emails).Include(c => c.Telefones)
                .FirstOrDefault( c => c.Id == id);

            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // GET: Contatos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contatos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Sobrenome,Telefones,Emails")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                db.Contatos.Add(contato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contato);
        }

        // GET: Contatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: Contatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Sobrenome,Telefones,Emails")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                if (contato.Telefones != null)
                {
                    foreach (var telefone in contato.Telefones)
                    {
                        if (telefone.Id > 0)
                            db.Entry(telefone).State = EntityState.Modified;
                        else
                            db.Entry(telefone).State = EntityState.Added;
                    }
                }

                if (contato.Emails != null)
                {
                    foreach (var email in contato.Emails)
                    {
                        if (email.Id > 0)
                            db.Entry(email).State = EntityState.Modified;
                        else
                            db.Entry(email).State = EntityState.Added;
                    }
                }

                db.Entry(contato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        // GET: Contatos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contato contato = db.Contatos.Find(id);
            db.Emails.RemoveRange(contato.Emails);
            db.Telefones.RemoveRange(contato.Telefones);
            db.Contatos.Remove(contato);
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

        [HttpPost]
        public void RemoverTelefone(int id)
        {
            var telefone = db.Telefones.Find(id);
            db.Entry(telefone).State = EntityState.Deleted;
            db.SaveChanges();
        }

        [HttpPost]
        public void RemoverEmail(int id)
        {
            var email = db.Emails.Find(id);
            db.Entry(email).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Teste prático: I4PRO - Insurance for Professionals.";

            return View();
        }
    }
}
