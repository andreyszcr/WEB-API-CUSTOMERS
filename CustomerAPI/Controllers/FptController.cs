using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CapaDatos;
using CustomerAPI.Models;
namespace CustomerAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private FTPDataBaseEntities db = new FTPDataBaseEntities();
        private CustomerD customD = new CustomerD();
        [ResponseType(typeof(Customers))]
        public IHttpActionResult GetCustomers()
        {
            try
            {
                List<Customer> c = new List<Customer>();
                List<Customers> data = customD.GetCustomers();
                if (data.Count > 0)
                {
                    foreach (Customers customers in data)
                    {
                        Customer temp = new Customer();
                        temp.IdCustomer = customers.IdCustomer;
                        temp.nameCustomer = customers.nameCustomer;
                        temp.phone = customers.phone;
                        temp.email = customers.email;
                        temp.notes = customers.notes;
                        c.Add(temp);
                    }
                    return Ok(c);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // POST: api/Customers
        [ResponseType(typeof(Customers))]
        public IHttpActionResult PostCustomers(Customers customers)
        {
            if (customD.ExistsCustomers(customers.IdCustomer) == false)
            {
                string request = customD.PostCustomer(customers.IdCustomer, customers.nameCustomer,customers.phone,customers.email,customers.notes);
                if (request == "1")
                {
                    Ok(customers);
                    return CreatedAtRoute("DefaultApi", new { id = customers.IdCustomer }, customers);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return Conflict();
            }
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customers))]
        public IHttpActionResult DeleteCustomers(int id)
        {
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return NotFound();
            }
            db.Customers.Remove(customers);
            db.SaveChanges();
            return Ok(customers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private bool CustomersExists(int id)
        {
            return db.Customers.Count(e => e.IdCustomer == id) > 0;
        }
    }
}