using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Register : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Load Event

    
    #region btnRegister_Click
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            SqlString strUserName = SqlString.Null;
            SqlString strDisplayName = SqlString.Null;
            SqlString strPassword = SqlString.Null;
            SqlString strContact = SqlString.Null;
            SqlString strEmail = SqlString.Null;
      


            if (txtUserName.Text.Trim() != "")
                strUserName = txtUserName.Text;

            if (txtDisplayName.Text.Trim() != "")
                strDisplayName = txtDisplayName.Text;

            if (txtPassword.Text.Trim() != "")
                strPassword = txtPassword.Text;

            if (txtContactNo.Text.Trim() != "")
                strContact = txtContactNo.Text;

            if (txtEmail.Text.Trim() != "")
                strEmail = txtEmail.Text;

           // fuImage.SaveAs(Server.MapPath("~/Content/Image/" + fuImage.FileName));

            SqlConnection conn = new SqlConnection("data source=LAPTOP-U7E5M6G1;initial catalog=MultiUserAddressBook;Integrated Security=True;");

            conn.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "PR_User_Insert";

            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);

            cmd.Parameters.AddWithValue("@DisplayName", txtDisplayName.Text);

            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

            cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);

            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

            //cmd.Parameters.AddWithValue("@PhotoPath", "~/Content/Image/" + fuImage.FileName);

            cmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);

            SqlDataReader read = cmd.ExecuteReader();

            lblMessage.Text = "Registered";

            Response.Redirect("~/AdminPanel/Login.aspx");
        }

        catch (SqlException ex)
        {
            if (ex.Number == 2601)
                lblMessage.Text = "This Username is already exist";
        }
    }
    #endregion btnRegister_Click


}