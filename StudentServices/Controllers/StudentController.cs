using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DATA;

namespace StudentServices.Controllers
{
    public class StudentController : ApiController
    {
        public dynamic Get()
        {
            StudentDetailsEntities db = new StudentDetailsEntities();
            var students = db.Student.Select(x => new
            {
                ID = x.Id,
                Name = x.Name,
                Phone=x.Phone
            }).ToList();
            return students;
        }
        
        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            StudentDetailsEntities db = new StudentDetailsEntities();
            Student s = db.Student.SingleOrDefault(x => x.Id == id);
            if (s != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, s.Name);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound,"");
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

       [ Route("api/Student/{id}/{name}/{phone}")]
        public void Put(int id, string name,int phone)
        {
            StudentDetailsEntities db = new StudentDetailsEntities();
            Student s = db.Student.SingleOrDefault(x => x.Id == id);
            if (s != null)
            {
                s.Id = id;
                s.Name = name;
                s.Phone = phone;
                db.SaveChanges();

            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            StudentDetailsEntities db = new StudentDetailsEntities();
            Student s = db.Student.SingleOrDefault(x => x.Id == id);
            if (s != null)
            {
               
            }

        }
    }
}
