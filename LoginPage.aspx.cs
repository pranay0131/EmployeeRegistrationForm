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
    public partial class LoginPage : System.Web.UI.Page
    {
        SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string strProc = @"spEmp";
            SqlCommand SqlCmd = new SqlCommand(strProc, SqlConn);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@flag", "Login");
            SqlCmd.Parameters.AddWithValue("@Role", TxtRole.Text);
            SqlCmd.Parameters.AddWithValue("@Name", TxtName.Text);
            SqlCmd.Parameters.AddWithValue("@Pwd", TxtPwd.Text);
            SqlDataAdapter SqlAdp = new SqlDataAdapter(SqlCmd);
            DataSet ds = new DataSet();
            SqlAdp.Fill(ds, "dummyLogin");
            DataTable dt = ds.Tables["dummyLogin"];
            int rowCount = dt.Rows.Count;

            if (rowCount > 0)
            {
                string strRole = dt.Rows[0]["Role"].ToString();
                string strName = dt.Rows[0]["Name"].ToString();
                string strPwd = dt.Rows[0]["Password"].ToString();

                Session["LoginRole"] = strRole;
                Session["LoginName"] = strName;
                Session["LoginPassword"] = strPwd;

                if(strRole == "Admin")
                {
                    Response.Redirect("AdminPage.aspx");
                }
                else
                {
                    Response.Redirect("EmpRegPage.aspx");
                }
            }
            else
            {
                LblMsg.Text = "*Invalid User Role/Name/Password";
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            TxtRole.Text = string.Empty;
            TxtName.Text = string.Empty;
            TxtPwd.Text = string.Empty;
            LblMsg.Text = string.Empty;
        }
    }
}