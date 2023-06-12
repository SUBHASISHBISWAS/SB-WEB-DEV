using APIDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SB_APIBasics.Controllers
{
    //[EnableCors("*","*","*")]
    //[RequireHTTPS]
    [BasicAuthentication]
    public class EmployeeController : ApiController
    {

        /*
        public IEnumerable<Employee> Get()
        {
            using (EmployeeDBEntities entity=new EmployeeDBEntities())
            {
                return entity.Employees.ToList();
            }
        }
        */
        /*
        [HttpGet]
        public IEnumerable<Employee> LoadEmployee()
        {
            using (EmployeeDBEntities entity = new EmployeeDBEntities())
            {
                return entity.Employees.ToList();
            }
        }
        */
        /*
        public HttpResponseMessage Get(int id)
        {
            using (EmployeeDBEntities entity = new EmployeeDBEntities())
            {
                var employee = entity.Employees.Where(e => e.ID == id);
                if (employee != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, employee);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
                }
            }
        }
        */
        /*
        [HttpGet]
        public HttpResponseMessage LoadEmployeeById(int id)
        {
            using (EmployeeDBEntities entity = new EmployeeDBEntities())
            {
                var employee = entity.Employees.Where(e => e.ID == id);
                if (employee != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, employee);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
                }
            }
        }
        */
        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            using (EmployeeDBEntities entity = new EmployeeDBEntities())
            {
                try
                {
                    entity.Employees.Add(employee);
                    entity.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);

                    message.Headers.Location = new Uri(Request.RequestUri
                        +"/"+ employee.ID.ToString());

                    return message;
                }
                catch (Exception e)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
                    throw;
                }
                
            }
        }
        public HttpResponseMessage Delete(int id) 
        {
            using (EmployeeDBEntities entity = new EmployeeDBEntities())
            {
                try
                {
                    var employee = entity.Employees.FirstOrDefault(e => e.ID == id);
                    if (employee != null)
                    {
                        entity.Employees.Remove(employee);
                        entity.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, employee);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
                    }

                }
                catch (Exception e)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
                    throw;
                }
                
            }
        }
        public HttpResponseMessage Put(int id,[FromBody] Employee employee)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                try
                {
                    var entity = entities.Employees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id " + id.ToString() + " not found to update");
                    }
                    else
                    {
                        entity.FirstName = employee.FirstName;
                        entity.LastName = employee.LastName;
                        entity.Gender = employee.Gender;
                        entity.Salary = employee.Salary;

                        entities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
                catch (Exception e)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
                    throw;
                }

            }
        }
        
        public HttpResponseMessage Get(string gender = "All")
        {
            string userName = Thread.CurrentPrincipal.Identity.Name;

            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                switch (userName.ToLower())
                {
                    //case "all":
                    //    return Request.CreateResponse(HttpStatusCode.OK,
                    //        entities.Employees.ToList());

                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Employees.Where(e => e.Gender.ToLower() == "male").
                            ToList());
                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Employees.Where(e => e.Gender.ToLower() == "female").
                            ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                            "Value for gender must be Male, Female or All. " + gender + 
                            " is invalid.");
                }
            }
        }
        

    }
}
