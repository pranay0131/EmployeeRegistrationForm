using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;
using System.IO;

namespace RetirementCalculation
{
    public partial class EmpRegPage : System.Web.UI.Page
    {
        SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginName"] !=null)
            {
                lblUser.Text = Session["LoginName"].ToString();
            }
            if (!IsPostBack)
            {
                FillDepartment();
                FillId();
            }
        }

        protected void hpLogOut_DataBinding(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("LoginPage.aspx");
        }

        public void FillId()
        {
            string strProc = @"spEmp";
            SqlCommand SqlCmd = new SqlCommand(strProc, SqlConn);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@flag", "getId");
            SqlDataAdapter SqlAdp = new SqlDataAdapter(SqlCmd);
            DataSet ds = new DataSet();
            SqlAdp.Fill(ds, "dummyId");
            DataTable dt = ds.Tables["dummyId"];
            int rowCount = dt.Rows.Count;

            if (rowCount >0)
            {
                string strDate = System.DateTime.Now.ToString("dd").PadLeft(2, '0');
                string strMonth = System.DateTime.Now.ToString("MM").PadLeft(2, '0');
                string strEmpId = dt.Rows[0]["EmployeeId"].ToString();

                txtEmpId.Text = "NIC" + strDate + strMonth + strEmpId.PadLeft(4, '0');
            }
            else
            {
                txtEmpId.Text = "NIC00001";
            }
        }

        protected void btnGetId_Click(object sender, EventArgs e)
        {
            FillId();
        }

        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {
            DateTime birthdate = DateTime.ParseExact(txtDOB.Text, "dd-MM-yyyy", null);
            DateTime retirementDate = DateTime.ParseExact(birthdate.AddYears(60).ToString("dd-MM-yyyy"), "dd-MM-yyyy", null);
            txtDOR.Text = new DateTime(retirementDate.Year, retirementDate.Month, 1).AddMonths(1).AddDays(-1).ToString("dd-MM-yyyy");

            DateTime today = DateTime.Now;
            TimeSpan ts = today - birthdate;
            DateTime age = DateTime.MinValue + ts;
            int years = age.Year - 1;

            lblAge.Text = years.ToString();
        }

        public void FillDepartment()
        {
            string strProc = @"spEmp";
            SqlCommand SqlCmd = new SqlCommand(strProc, SqlConn);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@flag", "getDepartment");
            SqlDataAdapter SqlAdp = new SqlDataAdapter(SqlCmd);
            DataSet ds = new DataSet();
            SqlAdp.Fill(ds, "dummyDepartment");
            DataTable dt = ds.Tables["dummyDepartment"];
            int rowCount = dt.Rows.Count;

            if (rowCount > 0)
            {
                ddlDept.DataSource = dt;
                ddlDept.DataTextField = "DepartmentName";
                ddlDept.DataValueField = "DepartmentId";
                ddlDept.DataBind();
            }
            else
            {
                ddlDept.DataSource = null;
                ddlDept.DataBind();
            }
            ddlDept.Items.Insert(0, "--Select Department--");
        }
        public void FillDesignation()
        {
            string strProc = @"spEmp";
            SqlCommand SqlCmd = new SqlCommand(strProc, SqlConn);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@flag", "getDesignation");
            SqlCmd.Parameters.AddWithValue("@DepartmentId", ddlDept.SelectedIndex.ToString());
            SqlDataAdapter SqlAdp = new SqlDataAdapter(SqlCmd);
            DataSet ds = new DataSet();
            SqlAdp.Fill(ds, "dummyDesignation");
            DataTable dt = ds.Tables["dummyDesignation"];
            int rowCount = dt.Rows.Count;

            if ( rowCount > 0)
            {
                ddlDesig.DataSource = dt;
                ddlDesig.DataTextField = "DesignationName";
                ddlDesig.DataValueField = "DesignationId";
                ddlDesig.DataBind();
            }
            else
            {
                ddlDesig.DataSource = null;
                ddlDesig.DataBind();
            }
            ddlDesig.Items.Insert(0, "--Select Designation--");
        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDept.SelectedIndex > 0)
            {
                FillDesignation();
            }
            else
            {
                lblMsg.Text = "*select any Department";
            }
        }

        protected void txtBasicSalary_TextChanged(object sender, EventArgs e)
        {
            double basicSalary = Convert.ToDouble(txtBasicSalary.Text);
            double Ta = basicSalary * 20 / 100;
            double Da = basicSalary * 30 / 100;
            double Hra = basicSalary * 10 / 100;
            double grossSalary = basicSalary + Ta + Da + Hra;

            txtTa.Text = Ta.ToString();
            txtDa.Text = Da.ToString();
            txtHra.Text = Hra.ToString();
            txtGross.Text = grossSalary.ToString();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if(ddlDept.SelectedIndex > 0)
            {
                if(ddlDesig.SelectedIndex > 0)
                {
                    if(fuDoc.HasFile)
                    {
                        if(fuDoc.FileBytes.Length > 102400)
                        {
                            string strFilePath = fuDoc.PostedFile.FileName;
                            string strFileName = Path.GetFileName(strFilePath);
                            string strExtension = Path.GetExtension(strFileName);

                            if(strExtension ==".jpeg"||strExtension==".png"||strExtension==".jpg")
                            {
                                string strDay = System.DateTime.Now.ToString("ddMMyyyyHHmmss");
                                string strLocation = Server.MapPath("~//UserDoc//Resume//") + strDay + fuDoc.FileName.ToString();
                                fuDoc.SaveAs(strLocation);
                                strLocation = "UserDoc/Resume/" + strDay + fuDoc.FileName.ToString();

                                string strProc = @"spEmp";
                                SqlCommand SqlCmd = new SqlCommand(strProc, SqlConn);
                                SqlCmd.CommandType = CommandType.StoredProcedure;
                                SqlCmd.Parameters.AddWithValue("@flag", "insertEmployee");
                                SqlCmd.Parameters.AddWithValue("@EmpId", txtEmpId.Text);
                                SqlCmd.Parameters.AddWithValue("@Name", txtName.Text);
                                SqlCmd.Parameters.AddWithValue("@Gender", rblGender.SelectedIndex.ToString());
                                SqlCmd.Parameters.AddWithValue("@DOB", txtDOB.Text);
                                SqlCmd.Parameters.AddWithValue("@DOJ", txtDOJ.Text);
                                SqlCmd.Parameters.AddWithValue("@DOR", txtDOR.Text);
                                SqlCmd.Parameters.AddWithValue("@DepartmentId", ddlDept.SelectedIndex.ToString());
                                SqlCmd.Parameters.AddWithValue("@DesignationId", ddlDesig.SelectedIndex.ToString());
                                SqlCmd.Parameters.AddWithValue("@BasicSalary", txtBasicSalary.Text);
                                SqlCmd.Parameters.AddWithValue("@Ta", txtTa.Text);
                                SqlCmd.Parameters.AddWithValue("@Da", txtDa.Text);
                                SqlCmd.Parameters.AddWithValue("@Hra", txtHra.Text);
                                SqlCmd.Parameters.AddWithValue("@GrossSalary", txtGross.Text);
                                SqlCmd.Parameters.AddWithValue("@UploadDoc", strLocation);

                                SqlConn.Open();
                                int rowCount = SqlCmd.ExecuteNonQuery();
                                SqlConn.Close();

                                if(rowCount > 0)
                                {
                                    lblMsg.Text = "*Records Saved Succesfully";
                                }
                                else
                                {
                                    lblMsg.Text = "*Please try again later";
                                }
                            }
                            else
                            {
                                lblMsg.Text = "*File extension must be .png/.jpeg/.jpg";
                            }
                        }
                        else
                        {
                            lblMsg.Text = "*File length must be less than 100kb";
                        }
                    }
                    else
                    {
                        lblMsg.Text = "*Please select a file to upload";
                    }
                }
                else
                {
                    lblMsg.Text = "*Please select any Designation";
                }
            }
            else
            {
                lblMsg.Text = "*Please select any Department";
            }
        }
        public void clearData()
        {
            txtEmpId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtDOJ.Text = string.Empty;
            txtDOR.Text = string.Empty;
            txtBasicSalary.Text = string.Empty;
            txtTa.Text = string.Empty;
            txtDa.Text = string.Empty;
            txtHra.Text = string.Empty;
            txtGross.Text = string.Empty;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            clearData();
            FillDepartment();
        }
    }
}