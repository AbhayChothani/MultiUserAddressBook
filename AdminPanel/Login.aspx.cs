using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Login : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Load Event
    //protected void btnLogin_Click(object sender, EventArgs e)
    //{
    //    #region Local Variable
    //    SqlString strUserName = SqlString.Null;
    //    SqlString strPassword = SqlString.Null;
    //    #endregion Local Variable

    //    #region Server Side Validation
    //    string strErrorMessage = "";

    //    if (txtUserNameLogin.Text.Trim() == "")
    //    {
    //        strErrorMessage += "- Enter UserName <br/>";
    //    }
    //    if (txtPasswordLogin.Text.Trim() == "")
    //    {
    //        strErrorMessage += "- Enter Password <br/>";
    //    }

    //    if(strErrorMessage!="")
    //    {
    //        lblMessage.Text = "Kindly solve following Errors <br/>" + strErrorMessage;
    //        return;
    //    }
    //    #endregion Server Side Validation

    //    #region Asign Value

    //    if (txtUserNameLogin.Text.Trim() != "")
    //        strUserName = txtUserNameLogin.Text.Trim();
    //    if (txtPasswordLogin.Text.Trim() != "")
    //        strPassword = txtPasswordLogin.Text.Trim();
    //    #endregion Assign Value

    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

    //    try
    //    {
    //        if (objConn.State != ConnectionState.Open)
    //            objConn.Open();

    //        SqlCommand objCmd = objConn.CreateCommand();
    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        objCmd.CommandText = "PR_User_SelectByUserNamePassword";
    //        objCmd.Parameters.AddWithValue("@UserName", strUserName);
    //        objCmd.Parameters.AddWithValue("@Password", strPassword);
    //        SqlDataReader objSDR = objCmd.ExecuteReader();
    //        if (objSDR.HasRows)
    //        {
    //            //Valid User
    //            lblMessage.Text = "Valid User";

    //            while(objSDR.Read())
    //            {
    //                if (!objSDR["UserID"].Equals(DBNull.Value))
    //                {
    //                    Session["UserID"] = objSDR["UserID"].ToString().Trim();
    //                }
    //                if (!objSDR["DisplayName"].Equals(DBNull.Value))
    //                {
    //                    Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
    //                }
    //                break;
    //            }
    //            Response.Redirect("~/AdminPanel/Default.aspx", true);

    //        }
    //        else
    //        {
    //            lblMessage.Text = "Either UserName or Password is Not Valid, Try Again with different detail !";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message;
    //    }
    //    finally
    //    {
    //        objConn.Close();
    //    }
    //}

    #region btnLogin_Click
    protected void btnLogin_Click(object sender, EventArgs e)
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        conn.Open();

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = conn;

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.CommandText = "PR_User_SelectByUserNamePassword";

        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());

        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

        SqlDataReader read = cmd.ExecuteReader();

        DataTable dtUser = new DataTable();

        dtUser.Load(read);

        conn.Close();

        if (dtUser != null && dtUser.Rows.Count > 0)
        {
            foreach (DataRow drUser in dtUser.Rows)
            {
                if (!drUser["UserID"].Equals(DBNull.Value))
                {
                    Session["UserID"] = drUser["UserID"].ToString();
                }
                if (!drUser["DisplayName"].Equals(DBNull.Value))
                {
                    Session["DisplayName"] = drUser["DisplayName"].ToString();
                }
                //if (!drUser["PhotoPath"].Equals(DBNull.Value))
                //{
                //    Session["ImgProfile"] = drUser["PhotoPath"].ToString();
                //}

                break;
            }
            Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
        }
        else
        {
            lblMessage.Text = "Username or Password is not valid";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtUserName.Focus();
        }
    }
    #endregion btnLogin_Click

}