using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonDropDownFillMethod
/// </summary>
public static class CommonDropDownFillMethod
{
    #region FillDropDownListCountry
    public static void FillDropDownListCountry(DropDownList ddlCountryID, Label lblMessage)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlCountryID.DataSource = objSDR;
                ddlCountryID.DataValueField = "CountryID";
                ddlCountryID.DataTextField = "CountryName";
                ddlCountryID.DataBind();
            }
            ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));
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
    #endregion FillDropDownListCountry

    #region FillDropDownListState
    public static void FillDropDownListState(DropDownList ddlStateID, DropDownList ddlCountryID, Label lblMessage)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectForDropDownList";

            objCmd.Parameters.AddWithValue("@CountryID", ddlCountryID.SelectedValue.ToString());
            if (HttpContext.Current.Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);
            }

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlStateID.DataSource = objSDR;
                ddlStateID.DataValueField = "StateID";
                ddlStateID.DataTextField = "StateName";
                ddlStateID.DataBind();
            }
            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
            objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion FillDropDownListState

    public static void FillDropDownListCirty(DropDownList ddlStateID, DropDownList ddlCountryID, DropDownList ddlCityID, Label lblMessage)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectForDropDownList";

            //objCmd.Parameters.AddWithValue("@CountryID", ddlCountryID.SelectedValue.ToString());
            objCmd.Parameters.AddWithValue("@StateID", ddlStateID.SelectedValue.ToString());

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlCityID.DataSource = objSDR;
                ddlCityID.DataValueField = "CityID";
                ddlCityID.DataTextField = "CityName";
                ddlCityID.DataBind();
            }
            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
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