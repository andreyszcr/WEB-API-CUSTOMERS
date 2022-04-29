using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerAPI.Controllers;
using CapaDatos;
namespace CustomerAPI
{
    public partial class Index : System.Web.UI.Page
    {
        //instancia para conectar los metodos
        
        fptController fpt = new fptController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CapaDatos.Customers customer = new CapaDatos.Customers();
            string idCustomer = txtID.Text;
            customer.nameCustomer = txtname.Text;
            string phone = txtphone.Text;
            customer.notes = txtnotes.Text;

            if(string.IsNullOrEmpty(idCustomer) || string.IsNullOrEmpty(txtname.Text)
            || (string.IsNullOrEmpty(phone)||string.IsNullOrEmpty(txtnotes.Text)))
            {
                lblmsj.Text = "Completa todos los campos";
            }
            else
            {
                customer.IdCustomer = Convert.ToInt32(idCustomer);
                customer.phone= Convert.ToInt32(phone);
                lblmsj.Visible = false;
                fpt.PostCustomers(customer);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            gvcustomers.DataSource = fpt.GetCustomers();
            gvcustomers.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CapaDatos.Customers customer = new CapaDatos.Customers();
            if (string.IsNullOrEmpty(txtID.Text))
            {
                lblmsj.Text = "Completa los datos para eliminar";
            }
            else
            {
                lblmsj.Visible = false;
                customer.IdCustomer = Convert.ToInt32(txtID.Text);
                fpt.DeleteCustomers(customer.IdCustomer);
            }
        }
    }
}