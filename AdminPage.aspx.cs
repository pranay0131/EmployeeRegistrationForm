using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RetirementCalculation
{
    public partial class AdminPage : System.Web.UI.Page
    {
        SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ToString()); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginName"]!=null)
            {
                lblUser.Text = Session["LoginName"].ToString();
            }
            if(!IsPostBack)
            {
                FillEmpDetails();
            }
        }

        protected void hpLogOut_DataBinding(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("LoginPage.aspx");
        }

        public void FillEmpDetails()
        {
            string strProc = @"spEmp";
            SqlCommand SqlCmd = new SqlCommand(strProc, SqlConn);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@flag", "EmpDetails");
            SqlDataAdapter SqlAdp = new SqlDataAdapter(SqlCmd);
            DataSet ds = new DataSet();
            SqlAdp.Fill(ds, "dummyEmpDetails");
            DataTable dt = ds.Tables["dummyEmpDetails"];
            int rowCount = dt.Rows.Count;

            if (rowCount >0)
            {
                gvEmployee.DataSource = dt;
                gvEmployee.DataBind();
            }
            else
            {
                gvEmployee.DataSource = null;
                gvEmployee.DataBind();
            }
        }

        protected void gvEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployee.PageIndex = e.NewPageIndex;
            FillEmpDetails();
        }

        protected void gvEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string EmpId = gvEmployee.DataKeys[e.RowIndex].Value.ToString();

            string strProc = @"spEmp";
            SqlCommand SqlCmd = new SqlCommand(strProc, SqlConn);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@flag", "removeEmployee");
            SqlCmd.Parameters.AddWithValue("@EmpId", EmpId);

            SqlConn.Open();
            int rowCount = SqlCmd.ExecuteNonQuery();
            SqlConn.Close();

            if (rowCount > 0)
            {
                lblMsg.Text = "*Record deleted succesfully";
            }
            else
            {
                lblMsg.Text = "*Please try again later";
            }
        }

        
    }
}