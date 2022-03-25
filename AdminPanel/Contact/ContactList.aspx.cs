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

public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillContactGridView();
        }  
    }

    private void FillContactGridView()
    {

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_SelectByUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                gvContact.DataSource = objSDR;
                gvContact.DataBind();
            }

            objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }

    }

    #region gvContact_RowCommand[Delete]
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteContact(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion gvContact_RowCommand[Delete]

    #region DeleteContact
    private void DeleteContact(SqlInt32 ContactID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_DeleteByUserIDContactID";
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString());
            objCmd.ExecuteNonQuery();

            objConn.Close();
            FillContactGridView();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }
    #endregion DeleteContact

    private void DeleteContactWiseContactCategory(SqlInt32 ContactID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();


            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactWiseContactCategory_DeleteByContactIDAndContactCategoryID";
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"].ToString());
            objCmd.Parameters.AddWithValue("@ContactID", ContactID);
            objCmd.ExecuteNonQuery();

            objConn.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }
}