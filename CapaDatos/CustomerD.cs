using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CustomerD
    {
        FTPDataBaseEntities entities;
        public CustomerD()
        {
            entities = new FTPDataBaseEntities();
        }

        public List<Customers> GetCustomers()
        {
            return entities.Customers.ToList<Customers>();
        }
        //*******************************************************
        private int CreateCustmers(Customers carrer)
        {
            try
            {
                entities.Customers.Add(carrer);
                return entities.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //*******************************************************************
        public string PostCustomer(int idCustomer, string NameCustomer, int phone, string email, string notes)
        {
            //try
            //{
            int resp = CreateCustmers(new CapaDatos.Customers()
            {
                IdCustomer = idCustomer,
                nameCustomer = NameCustomer,
                phone = phone,
                email = email,
                notes=notes,
            });
            if (resp == 1)
            {
                return "1";
            }
            else
            {
                return "0";
            }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        //***********************************************************
        public bool ExistsCustomers(int Idcustomer)
        {
            //validacion de datos 
            try
            {
                //consulta 
                var query = from c in entities.Customers
                            where c.IdCustomer == Idcustomer
                            select c;
                //verifica la lista a traves de la base de datos 
                List<Customers> carreer = query.ToList<Customers>();
                //si el calificador(el id) existe muestra retorna un verdadero 
                if (carreer.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //***********************************************************************
        //***********************************************************************
        public string DeleteCustomers(int idCustomers)
        {
            try
            {
                Customers cur = entities.Customers.First<Customers>(x => x.IdCustomer == idCustomers);
                entities.Customers.Remove(cur);
                return Convert.ToString(entities.SaveChanges());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
