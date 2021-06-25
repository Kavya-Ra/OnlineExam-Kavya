using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineExam.DbContext;
using System.Threading.Tasks;
using OnlineExam.ViewModel;

namespace OnlineExam.Controllers
{
    public class Teachers_RegistrationController : Controller
    {
        private Exam_DBEntities db = new Exam_DBEntities();

        // GET: Teachers_Registration
        public ActionResult Index()
        {
            return View(db.Teachers_Registration.Where(p => p.IsDeleted == 0).ToList());
        }

        // GET: Teachers_Registration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers_Registration teachers_Registration = db.Teachers_Registration.Find(id);
            if (teachers_Registration == null)
            {
                return HttpNotFound();
            }
            return View(teachers_Registration);
        }

        // GET: Teachers_Registration/Create
        public ActionResult Create()
        {
            var sub = new SelectList(db.Subjects.Where(p => p.IsDeleted == 0), "Id", "Name");
            ViewBag.PrimarySubject = sub;
            ViewBag.SecondarySubject = sub;
            return View();
        }

        // POST: Teachers_Registration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,WhatsApp,PrimarySubject,SecondarySubject,Location,Street,Address,PO,District,State,IsActive,IsDeleted,DeletedDateTime")] Teachers_Registration teachers_Registration)
        {
            if (ModelState.IsValid)
            {
                teachers_Registration.DeletedDateTime = DateTime.Now;
                db.Teachers_Registration.Add(teachers_Registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var sub = new SelectList(db.Subjects.Where(p => p.IsDeleted == 0), "Id", "Name", teachers_Registration.Id);
            ViewBag.PrimarySubject = sub;
            ViewBag.SecondarySubject = sub;
            return View(teachers_Registration);
        }

        // GET: Teachers_Registration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers_Registration teachers_Registration = db.Teachers_Registration.Find(id);
            if (teachers_Registration == null)
            {
                return HttpNotFound();
            }
            var sub = new SelectList(db.Subjects.Where(p => p.IsDeleted == 0), "Id", "Name", teachers_Registration.PrimarySubject);
            ViewBag.PrimarySubject = sub;
            ViewBag.SecondarySubject = sub;
            return View(teachers_Registration);
        }

        // POST: Teachers_Registration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,WhatsApp,PrimarySubject,SecondarySubject,Location,Street,Address,PO,District,State,IsActive,IsDeleted,DeletedDateTime")] Teachers_Registration teachers_Registration)
        {
            if (ModelState.IsValid)
            {
                teachers_Registration.DeletedDateTime = DateTime.Now;
                db.Entry(teachers_Registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var sub = new SelectList(db.Subjects.Where(p => p.IsDeleted == 0), "Id", "Name", teachers_Registration.PrimarySubject);
            ViewBag.PrimarySubject = sub;
            ViewBag.SecondarySubject = sub;
            return View(teachers_Registration);
        }

        // GET: Teachers_Registration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers_Registration teachers_Registration = db.Teachers_Registration.Find(id);
            if (teachers_Registration == null)
            {
                return HttpNotFound();
            }
            return View(teachers_Registration);
        }

        // POST: Teachers_Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teachers_Registration teachers_Registration = db.Teachers_Registration.Find(id);
            teachers_Registration.IsDeleted = 1;
            teachers_Registration.DeletedDateTime = DateTime.Now;
            db.Entry(teachers_Registration).State = EntityState.Modified;
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

        public async Task<ActionResult> TeacherRegistration(int? id)
        {
            if (id == null)
            {
                var sub = new SelectList(db.Subjects.Where(p => p.IsDeleted == 0), "Id", "Name");
                ViewBag.PrimarySubject = sub;
                ViewBag.SecondarySubject = sub;
                return View();
            }
            else
            {
                var data = await db.Teachers_Registration.Where(d => d.Id == id).FirstOrDefaultAsync();
                TeacherRegViewModel teacher = new TeacherRegViewModel()
                {
                    Id = data.Id,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Address = data.Address,
                    WhatsApp = data.WhatsApp,
                    District = data.District,
                    Location = data.Location,
                    Street = data.Street,
                    PO = data.PO,
                    State = data.State
                };
                var sub = new SelectList(db.Subjects.Where(p => p.IsDeleted == 0), "Id", "Name", data.PrimarySubject);
                ViewBag.PrimarySubject = sub;
                ViewBag.SecondarySubject = sub;
                return View(teacher);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> TeacherRegistration(TeacherRegViewModel teacherRegView)
        {
            if (teacherRegView.Id != null)
            {
                Teachers_Registration data = db.Teachers_Registration.Find(teacherRegView.Id);
                if (data != null)
                {
                    if (ModelState.IsValid)
                    {
                        data.FirstName = teacherRegView.FirstName;
                        data.LastName = teacherRegView.LastName;
                        data.WhatsApp = teacherRegView.WhatsApp;
                        data.PrimarySubject = teacherRegView.PrimarySubject;
                        data.SecondarySubject = teacherRegView.SecondarySubject;
                        data.Location = teacherRegView.Location;
                        data.Street = teacherRegView.Street;
                        data.Address = teacherRegView.Address;
                        data.PO = teacherRegView.PO;
                        data.District = teacherRegView.District;
                        data.State = teacherRegView.State;
                        db.Entry(data).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }

                }
                return View(teacherRegView);
            }
            else
            {
                Teachers_Registration teachers_Registration = new Teachers_Registration();
                teachers_Registration.FirstName = teacherRegView.FirstName;
                teachers_Registration.LastName = teacherRegView.LastName;
                teachers_Registration.WhatsApp = teacherRegView.WhatsApp;
                teachers_Registration.PrimarySubject = teacherRegView.PrimarySubject;
                teachers_Registration.SecondarySubject = teacherRegView.SecondarySubject;
                teachers_Registration.Location = teacherRegView.Location;
                teachers_Registration.Street = teacherRegView.Street;
                teachers_Registration.Address = teacherRegView.Address;
                teachers_Registration.PO = teacherRegView.PO;
                teachers_Registration.District = teacherRegView.District;
                teachers_Registration.State = teacherRegView.State;
                teachers_Registration.DeletedDateTime = DateTime.Now;
                db.Teachers_Registration.Add(teachers_Registration);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }

        public ActionResult DeleteTeacherReg(int? id)
        {
            if (id != null)
            {
                Teachers_Registration teachers = db.Teachers_Registration.Find(id);
                teachers.IsDeleted = 1;
                teachers.DeletedDateTime = DateTime.Now;
                db.Entry(teachers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
