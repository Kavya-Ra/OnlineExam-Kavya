using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using OnlineExam.DbContext;
using OnlineExam.ViewModel;

namespace OnlineExam.Controllers
{
    public class GroupsController : Controller
    {
        private Exam_DBEntities db = new Exam_DBEntities();

        // GET: Groups
        public ActionResult Index()
        {
            return View(db.Groups.Where(p => p.IsDeleted == 0).ToList());
        
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Groups, "Id", "GroupName");
            ViewBag.Id = new SelectList(db.Groups, "Id", "GroupName");
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GroupName,PgmId,CourseId,SubPgmId,SubjectId,CreatedBy,CreatedDateTime,ModifiedBy,ModifiedDateTime,DeletedBy,DeletedDateTime,IsDeleted,ClassId")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Groups, "Id", "GroupName", group.Id);
            ViewBag.Id = new SelectList(db.Groups, "Id", "GroupName", group.Id);
            return View(group);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Groups, "Id", "GroupName", group.Id);
            ViewBag.Id = new SelectList(db.Groups, "Id", "GroupName", group.Id);
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GroupName,PgmId,CourseId,SubPgmId,SubjectId,CreatedBy,CreatedDateTime,ModifiedBy,ModifiedDateTime,DeletedBy,DeletedDateTime,IsDeleted,ClassId")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Groups, "Id", "GroupName", group.Id);
            ViewBag.Id = new SelectList(db.Groups, "Id", "GroupName", group.Id);
            return View(group);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.Groups.Find(id);
            db.Groups.Remove(group);
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

        public async Task<ActionResult> Group(int? id)
        {
            if (id == null)
            {
                var pro = new SelectList(db.Programmes.Where(p => p.IsDeleted == 0), "Id", "Name");
                ViewBag.PgmId = pro;
                var cou = new SelectList(db.Classes.Where(c => c.IsDeleted == 0), "Id", "Name");
                ViewBag.ClassId = cou;
                var subj = new SelectList(db.Subjects.Where(s => s.IsDeleted == 0), "Id", "Name");
                ViewBag.SubjectId = subj;

                var sub = new SelectList(Enumerable.Empty<SelectListItem>());
                ViewBag.SubPgmId = sub;
                ViewBag.CourseId = sub;
            }
            else
            {
                var data = await db.Groups.Where(d => d.Id == id).FirstOrDefaultAsync();
                GroupViewModel groupView = new GroupViewModel()
                {
                    Id = data.Id,
                    GroupName = data.GroupName,
                    PgmId = data.PgmId,
                    SubPgmId = data.SubPgmId,
                    ClassId = data.ClassId,
                    CourseId = data.CourseId,
                    SubjectId = data.SubjectId,
                };
                var pro = new SelectList(db.Programmes.Where(p => p.IsDeleted == 0), "Id", "Name", data.PgmId);
                ViewBag.PgmId = pro;
                var sub = new SelectList(db.SubPrograms.Where(p => p.IsDeleted == 0), "Id", "Name", data.SubPgmId);
                ViewBag.SubPgmId = sub;
                var cou = new SelectList(db.Courses.Where(c => c.IsDeleted == 0), "Id", "Name", data.CourseId);
                ViewBag.CourseId = cou;
                var subj = new SelectList(db.Subjects.Where(s => s.IsDeleted == 0), "Id", "Name", data.SubjectId);
                ViewBag.SubjectId = subj;
                var chap = new SelectList(db.Classes.Where(p => p.IsDeleted == 0), "Id", "Name", data.ClassId);
                ViewBag.ClassId = chap;

                return View(groupView);

            }
            return View();
        }

        [HttpGet]
        public JsonResult SubProgram(int ID)
        {
            var sub = new SelectList(db.SubPrograms.Where(s => s.PgmId == ID), "Id", "Name");
            return Json(sub, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Course(int ID)
        {
            var chap = new SelectList(db.Courses.Where(c => c.ClassId == ID), "Id", "Name");
            return Json(chap, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Group(GroupViewModel groupView)
        {

            if (groupView.Id != null)
            {
                Group data = db.Groups.Find(groupView.Id);
                if (data != null)
                {
                    if (ModelState.IsValid)
                    {
                        data.GroupName = groupView.GroupName;
                        data.PgmId = groupView.PgmId;
                        data.SubPgmId = groupView.SubPgmId;
                        data.ClassId = groupView.ClassId;
                        data.CourseId = groupView.CourseId;
                        data.SubjectId = groupView.SubjectId;
                        data.ModifiedDateTime = DateTime.Now;
                        data.ModifiedBy = 1;
                        db.Entry(data).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }

                }
                return View(groupView);

            }
            else
            {
                Group group = new Group();
                group.GroupName = groupView.GroupName;
                group.PgmId = groupView.PgmId;
                group.SubPgmId = groupView.SubPgmId;
                group.ClassId = groupView.ClassId;
                group.CourseId = groupView.CourseId;
                group.SubjectId = groupView.SubjectId;
                group.CreatedDateTime = DateTime.Now;
                group.ModifiedDateTime = DateTime.Now;
                group.DeletedDateTime = DateTime.Now;
                db.Groups.Add(group);
                await db.SaveChangesAsync();
                int id = group.Id;
                return RedirectToAction("Index");
            }
          
        }
        public ActionResult DeleteGroup(int? id)
        {
            if (id != null)
            {
                Group group = db.Groups.Find(id);
                group.IsDeleted = 1;
                group.DeletedDateTime = DateTime.Now;
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
