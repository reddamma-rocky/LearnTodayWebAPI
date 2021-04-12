using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearnTodayWebAPI.Models;

namespace LearnTodayWebAPI.Controllers
{
    public class TrainerController : ApiController
    {
        public HttpResponseMessage Post([FromBody] Trainer model)
        {
            try
            {
                using(LearnTodayWebAPIDbContext db = new LearnTodayWebAPIDbContext())
                {
                    db.Trainers.Add(model);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, model);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Put(int id, [FromBody] Trainer model)
        {
            try
            {
                using (LearnTodayWebAPIDbContext dbContext = new LearnTodayWebAPIDbContext())
                {
                    var entity = dbContext.Trainers.FirstOrDefault(s => s.TrainerId == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Searched Data not Found");
                    }
                    else
                    {
                        entity.TrainerId = model.TrainerId;
                        entity.Password = model.Password;
                        dbContext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Data updated successfully");
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
