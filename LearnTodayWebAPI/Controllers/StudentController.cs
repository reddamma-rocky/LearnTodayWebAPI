using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearnTodayWebAPI.Models;

namespace LearnTodayWebAPI.Controllers
{
    public class StudentController : ApiController
    {
        public IEnumerable<Course> GetAllCourses()
        {
            var db = new LearnTodayWebAPIDbContext();
            return db.Courses.ToList().OrderBy(s => s.Start_Date);
        }
        public HttpResponseMessage Post([FromBody] Student model)

        {

            try

            {

                using (LearnTodayWebAPIDbContext db = new LearnTodayWebAPIDbContext())

                {
                    db.Students.Add(model);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, model);
                    return message;
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (LearnTodayWebAPIDbContext db = new LearnTodayWebAPIDbContext())
                {
                    var entity = db.Students.FirstOrDefault(s => s.StudentId == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No enrollement information found");
                    }
                    else
                    {
                        db.Students.Remove(entity);
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}