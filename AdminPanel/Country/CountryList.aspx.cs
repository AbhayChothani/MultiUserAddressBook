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

public partial class AdminPanel_Country_CountryList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            FillCountryGridView();
        }
        
    }
    #endregion Load Event

    #region FillCountryGridview
    private void FillCountryGridView()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectByUserID";

            if (Session["UserID"]!=null)
                objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                gvCountry.DataSource = objSDR;
                gvCountry.DataBind();
            }
            objConn.Close();
        }
        catch(Exception ex) 
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }
    #endregion FillCountryGridview

    #region  gvCountry_RowCommand
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteCountry(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion  gvCountry_RowCommand

    #region DeleteCountry
    private void DeleteCountry(SqlInt32 CountryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_DeleteByUserIDCountryID";
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString());
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            objCmd.ExecuteNonQuery();

            objConn.Close();
            FillCountryGridView();
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
    #endregion DeleteCountry
}