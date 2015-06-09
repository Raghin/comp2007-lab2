using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2007_lesson6.Models;
using System.Web.ModelBinding;

namespace comp2007_lesson6
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStudents();
            }
        }

        protected void GetStudents()
        {
            //connect to database
            var conn = new DefaultConnection();

            //use link to query students
            var studs = from d in conn.Students select d;

            //bind the query
            grdStudents.DataSource = studs.ToList();
            grdStudents.DataBind();
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (DefaultConnection conn = new DefaultConnection())
            {
                //get StudentID
                Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[e.RowIndex].Values["StudentID"]);

                var d = (from studs in conn.Students where studs.StudentID == StudentID select studs).FirstOrDefault();

                conn.Students.Remove(d);
                conn.SaveChanges();

                //update grid
                GetStudents();
            }
        }
    }
}