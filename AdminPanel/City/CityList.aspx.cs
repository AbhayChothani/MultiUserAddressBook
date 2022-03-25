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

public partial class AdminPanel_City_CityList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCityGridView();
        }
    }
    #endregion Load Event

#region FillCityGridView
    private void FillCityGridView()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectByUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);

            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                gvCity.DataSource = objSDR;
                gvCity.DataBind();
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
#endregion FillCityGridView

    #region  gvCity_RowCommand
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteCity(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion gvCity_RowCommand
    #region DeleteCity
    private void DeleteCity(SqlInt32 CityID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_DeleteByUserIDCityID";
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString());
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            objCmd.ExecuteNonQuery();

            objConn.Close();
            FillCityGridView();
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
    #endregion DeleteCity
}   