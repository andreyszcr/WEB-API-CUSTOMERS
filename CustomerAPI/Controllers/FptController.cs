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
    public class fptController : ApiController
    {
        private FTPDataBaseEntities db = new FTPDataBaseEntities();
        private CustomerD customD = new CustomerD();
        [ResponseType(typeof(Customers))]
        public List<Customer> GetCustomers()
        {
            try
            {
                List<Models.Customer> c = new List<Models.Customer>();
                List<Customers> data = customD.GetCustomers();
                foreach (Customers cat in data)
                {
                   Models.Customer cm = new Models.Customer();
                   cm.IdCustomer = cat.IdCustomer;
                   cm.nameCustomer = cat.nameCustomer;
                   cm.phone = cat.phone;
                   cm.email = cat.email;
                   cm.notes = cat.notes;
                   c.Add(cm);
                }
                return c;
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