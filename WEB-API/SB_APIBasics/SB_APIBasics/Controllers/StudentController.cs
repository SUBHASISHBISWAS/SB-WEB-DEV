using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SB_APIBasics.Controllers
{
    public class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
    public class StudentController : ApiController
    {
        static List<Student> students = new List<Student>()
        {
            new Student() { Id = 1, Name = "Tom" },
            new Student() { Id = 2, Name = "Sam" },
            new Student() { Id = 3, Name = "John" }
        };

        /*
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(students);
        }
        */
        public IHttpActionResult Get()
        {
            return Ok(students);
        }

        /*
        public HttpResponseMessage Get(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "Student not found");
            }

            return Request.CreateResponse(student);
        }
        */
        public IHttpActionResult Get(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, "Student not found");
            }

            return Ok(student);
        }
    }
}
