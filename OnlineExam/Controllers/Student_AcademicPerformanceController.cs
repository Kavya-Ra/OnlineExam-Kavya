using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OnlineExam.DbContext;

namespace OnlineExam.Controllers
{
    public class Student_AcademicPerformanceController : ApiController
    {
        private Exam_DBEntities db = new Exam_DBEntities();

        // GET: api/Student_AcademicPerformance
        public IQueryable<Student_AcademicPerformance> GetStudent_AcademicPerformance()
        {
            return db.Student_AcademicPerformance;
        }

        // GET: api/Student_AcademicPerformance/5
        [Route("api/Student_AcademicPerformance/GetStudent_AcademicPerformance/{id:int}")]
        [ResponseType(typeof(Student_AcademicPerformance))]
        public IHttpActionResult GetStudent_AcademicPerformance(int id)
        {
            Student_AcademicPerformance student_AcademicPerformance = db.Student_AcademicPerformance.Find(id);
            if (student_AcademicPerformance == null)
            {
                return NotFound();
            }

            return Ok(student_AcademicPerformance);
        }

        // PUT: api/Student_AcademicPerformance/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent_AcademicPerformance(int id, Student_AcademicPerformance student_AcademicPerformance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student_AcademicPerformance.Id)
            {
                return BadRequest();
            }

            db.Entry(student_AcademicPerformance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Student_AcademicPerformanceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Student_AcademicPerformance

        [Route("api/Student_AcademicPerformance/AcademicPerformance")]
        [ResponseType(typeof(Student_AcademicPerformance))]
        public IHttpActionResult AcademicPerformance(Student_AcademicPerformance student_AcademicPerformance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Student_AcademicPerformance.Add(student_AcademicPerformance);
            db.SaveChanges();


            return Ok(new { id = student_AcademicPerformance.Id });
        }



        // DELETE: api/Student_AcademicPerformance/5
        [Route("api/Student_AcademicPerformance/DeletePerformance/{id:int}")]
        [ResponseType(typeof(Student_AcademicPerformance))]
        public IHttpActionResult DeletePerformance(int id)
        {
            Student_AcademicPerformance student_AcademicPerformance = db.Student_AcademicPerformance.Find(id);
            if (student_AcademicPerformance == null)
            {
                return NotFound();
            }

            db.Student_AcademicPerformance.Remove(student_AcademicPerformance);
            db.SaveChanges();

            return Ok(student_AcademicPerformance);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Student_AcademicPerformanceExists(int id)
        {
            return db.Student_AcademicPerformance.Count(e => e.Id == id) > 0;
        }

        // POST: api/Student_PreviousEntrance

        [Route("api/Student_AcademicPerformance/PreviousEntrance")]
        [ResponseType(typeof(Student_PreviousEntrance))]
        public IHttpActionResult PreviousEntrance(Student_PreviousEntrance student_PreviousEntrance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Student_PreviousEntrance.Add(student_PreviousEntrance);
            db.SaveChanges();
            return Ok(new { id = student_PreviousEntrance.Id });
        }



        // DELETE: api/Student_PreviousEntrance/5
        [Route("api/Student_AcademicPerformance/DeletePreviousEntrance/{id:int}")]
        [ResponseType(typeof(Student_PreviousEntrance))]
        public IHttpActionResult DeletePreviousEntrance(int id)
        {
            Student_PreviousEntrance student_PreviousEntrance = db.Student_PreviousEntrance.Find(id);
            if (student_PreviousEntrance == null)
            {
                return NotFound();
            }

            db.Student_PreviousEntrance.Remove(student_PreviousEntrance);
            db.SaveChanges();

            return Ok(student_PreviousEntrance);
        }


        // GET: api/Student_PreviousEntrance/5
        [Route("api/Student_AcademicPerformance/GetStudent_PreviousEntrance/{id:int}")]
        [ResponseType(typeof(Student_PreviousEntrance))]
        public IHttpActionResult GetStudent_PreviousEntrance(int id)
        {
            Student_PreviousEntrance student_PreviousEntrance = db.Student_PreviousEntrance.Find(id);
            if (student_PreviousEntrance == null)
            {
                return NotFound();
            }

            return Ok(student_PreviousEntrance);
        }

      
        [Route("api/Student_AcademicPerformance/GetStudentAllDetails")]
        public IHttpActionResult GetStudentAllDetails()
        {
            var materializedUser = db.StudentAllDetailsByRegId();
            return Ok(materializedUser);
           
        }
    }
}