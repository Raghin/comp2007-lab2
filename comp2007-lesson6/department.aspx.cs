using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference models
using comp2007_lesson6.Models;
using System.Web.ModelBinding;

namespace comp2007_lesson6
{
    public partial class department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //fill the grid
            if (!IsPostBack)
            {
                if (Request.QueryString.Keys.Count > 0)
                {
                    //we have a url parameter if count is > 0 so populate the frm
                    GetDepartment();
                }
            }
        }

        protected void GetDepartment()
        {
            //connect
            using (DefaultConnection conn = new DefaultConnection())
            {
                //get id from url parameter and store in a variable
                Int32 DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
                var d = (from dep in conn.Departments where dep.DepartmentID == DepartmentID select dep).FirstOrDefault();

                //populate the form from our department object
                txtName.Text = d.Name;
                txtBudget.Text = d.Budget.ToString();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //connect
            using (DefaultConnection conn = new DefaultConnection())
            {
                //instantiate a new department object in memory
                Department d = new Department();

                if (Request.QueryString.Count > 0)
                {
                    Int32 DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
                    d = (from dep in conn.Departments where dep.DepartmentID == DepartmentID select dep).FirstOrDefault();
                }

                //fill the properties of our object from the form inputs
                d.Name = txtName.Text;
                d.Budget = Convert.ToDecimal(txtBudget.Text);

                //save
                if(Request.QueryString.Count == 0)
                    conn.Departments.Add(d);
                conn.SaveChanges();

                //redirect to updated departments page
                Response.Redirect("departments.aspx");
            }
        }
    }
}