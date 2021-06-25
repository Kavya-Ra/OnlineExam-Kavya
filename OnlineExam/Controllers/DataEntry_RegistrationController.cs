using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using OnlineExam.ViewModel;
using System.Web.Mvc;
using OnlineExam.DbContext;

namespace OnlineExam.Controllers
{
    public class DataEntry_RegistrationController : Controller
    {
        private Exam_DBEntities db = new Exam_DBEntities();

        // GET: DataEntry_Registration
        public ActionResult Index()
        {
            return View(db.DataEntry_Registration.Where(p => p.IsDeleted == 0).ToList());
        }

        // GET: DataEntry_Registration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataEntry_Registration dataEntry_Registration = db.DataEntry_Registration.Find(id);
            if (dataEntry_Registration == null)
            {
                return HttpNotFound();
            }
            return View(dataEntry_Registration);
        }

        // GET: DataEntry_Registration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataEntry_Registration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,FirmName,Mobile,WhatsApp,Email,Location,Place,IsDeleted,DeletedBy,CreatedDateTime,ModifiedDateTime,ModifiedBy,CreatedBy,DeletedDateTime")] DataEntry_Registration dataEntry_Registration)
        {
            if (ModelState.IsValid)
            {
                dataEntry_Registration.CreatedDateTime = DateTime.Now;
                dataEntry_Registration.ModifiedDateTime = DateTime.Now;
                dataEntry_Registration.DeletedDateTime = DateTime.Now;
                db.DataEntry_Registration.Add(dataEntry_Registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dataEntry_Registration);
        }

        // GET: DataEntry_Registration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataEntry_Registration dataEntry_Registration = db.DataEntry_Registration.Find(id);
            if (dataEntry_Registration == null)
            {
                return HttpNotFound();
            }
            return View(dataEntry_Registration);
        }

        // POST: DataEntry_Registration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FirmName,Mobile,WhatsApp,Email,Location,Place,IsDeleted,DeletedBy,CreatedDateTime,ModifiedDateTime,ModifiedBy,CreatedBy,DeletedDateTime")] DataEntry_Registration dataEntry_Registration)
        {
            if (ModelState.IsValid)
            {
                dataEntry_Registration.ModifiedDateTime = DateTime.Now;
                dataEntry_Registration.ModifiedBy = 1;
                db.Entry(dataEntry_Registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dataEntry_Registration);
        }

        // GET: DataEntry_Registration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataEntry_Registration dataEntry_Registration = db.DataEntry_Registration.Find(id);
            if (dataEntry_Registration == null)
            {
                return HttpNotFound();
            }
            return View(dataEntry_Registration);
        }

        // POST: DataEntry_Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DataEntry_Registration dataEntry_Registration = db.DataEntry_Registration.Find(id);
            db.DataEntry_Registration.Remove(dataEntry_Registration);
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

        public async Task<ActionResult> DataEntryRegistration(int? id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                var data = await db.DataEntry_Registration.Where(d => d.Id == id).FirstOrDefaultAsync();
                DtpViewModel dtpView = new DtpViewModel()
                {
                    Id = data.Id,
                    Name = data.Name,
                    FirmName = data.FirmName,
                    Mobile = data.Mobile,
                    WhatsApp = data.WhatsApp,
                    Email = data.Email,
                    Location = data.Location,
                    Place = data.Place    
                };

               return View(dtpView);

            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DataEntryRegistration(DtpViewModel dtpViewModel)
        {
            if (dtpViewModel.Id != null)
            {
                DataEntry_Registration data = db.DataEntry_Registration.Find(dtpViewModel.Id);
                if (data != null)
                {
                    if (ModelState.IsValid)
                    {
                        data.Name = dtpViewModel.Name;
                        data.FirmName = dtpViewModel.FirmName;
                        data.Email = dtpViewModel.Email;
                        data.Location = dtpViewModel.Location;
                        data.Place = dtpViewModel.Place;
                        data.WhatsApp = dtpViewModel.WhatsApp;
                        data.Mobile = dtpViewModel.Mobile;
                        data.ModifiedDateTime = DateTime.Now;
                        data.ModifiedBy = 1;
                        db.Entry(data).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }

                }
                return View(dtpViewModel);
            }
            else
            {
                DataEntry_Registration dataEntry_Registration = new DataEntry_Registration();
                dataEntry_Registration.Name = dtpViewModel.Name;
                dataEntry_Registration.FirmName = dtpViewModel.FirmName;
                dataEntry_Registration.Email = dtpViewModel.Email;
                dataEntry_Registration.Location = dtpViewModel.Location;
                dataEntry_Registration.Place = dtpViewModel.Place;
                dataEntry_Registration.WhatsApp = dtpViewModel.WhatsApp;
                dataEntry_Registration.Mobile = dtpViewModel.Mobile;
                dataEntry_Registration.CreatedDateTime = DateTime.Now;
                dataEntry_Registration.ModifiedDateTime = DateTime.Now;
                dataEntry_Registration.DeletedDateTime = DateTime.Now;
                db.DataEntry_Registration.Add(dataEntry_Registration);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
          
        }

     
        public ActionResult DeleteDataEntry(int? id)
        {
            if(id!=null)
            {
                DataEntry_Registration dataEntry_Registration = db.DataEntry_Registration.Find(id);
                dataEntry_Registration.IsDeleted = 1;
                dataEntry_Registration.DeletedDateTime = DateTime.Now;
                db.Entry(dataEntry_Registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
