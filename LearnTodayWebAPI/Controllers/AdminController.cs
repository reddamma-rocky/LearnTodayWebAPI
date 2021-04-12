using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearnTodayWebAPI.Models;

namespace LearnTodayWebAPI.Controllers
{
    public class AdminController : ApiController
    {
        public IEnumerable<Course> GetAllCourses()
        {
            var db = new LearnTodayWebAPIDbContext();
            return db.Courses.ToList();
        }
        public HttpResponseMessage GetCourseById(int id)
        {
            var db = new LearnTodayWebAPIDbContext();
            var course = db.Courses.Find(id);
            if (course == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Searched Data not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, course);
        }
    }
}

