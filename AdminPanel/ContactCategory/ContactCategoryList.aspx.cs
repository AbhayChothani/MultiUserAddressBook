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

public partial class AdminPanel_ContactCategory_ContactCategoryList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillContactCategoryGridView();
        }  
     
    }

    private void FillContactCategoryGridView()
    {

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectByUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                gvContactCategory.DataSource = objSDR;
                gvContactCategory.DataBind();
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

    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteContactCategory(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    private void DeleteContactCategory(SqlInt32 ContactCategoryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_DeleteByUserIDContactCategoryID";
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString());
            objCmd.ExecuteNonQuery();

            objConn.Close();
            FillContactCategoryGridView();
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