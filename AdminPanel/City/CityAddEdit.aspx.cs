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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FillCountry();
            fillState();
            if (Page.RouteData.Values["CityID"] != null)
            {
                lblMessage.Text = "Edit Mode | CityID = " + EncryptDecrypt.Base64Decode(Page.RouteData.Values["CityID"].ToString().Trim());
                FillCityControls(Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["CityID"].ToString().Trim())));
            }
            else
            {
                lblMessage.Text = "Add Mode";
            }
           
           // ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region local Varialbles
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlString strUserID = SqlString.Null;
        SqlInt32 strStateID = SqlInt32.Null;
        SqlString strCityName = SqlString.Null;
        SqlString strSTDCode = SqlString.Null;
        SqlString strPinCode = SqlString.Null;
        SqlString strCreationDate = SqlString.Null;
        #endregion local Varialbles

        try
        {
            #region Server Side Validation
            String strErrorMessage = "";
            if (ddlCountryID.SelectedIndex == 0)
                strErrorMessage += "- Select Country <br/>";
            if (ddlStateID.Text.Trim() == "")
                strErrorMessage += "- Select State<br/>";
            if (txtCityName.Text.Trim() == "")
                strErrorMessage += "- Enter City Code<br/>";
            if (txtSTDCode.Text.Trim() == "")
                strErrorMessage += "- Enter STD Code <br/>";
            if (txtPinCode.Text.Trim() == "")
                strErrorMessage += "- Enter Pin Code <br/><hr/>";
            if (strErrorMessage != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Gather Information
            if (ddlStateID.SelectedIndex > 0)
                strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
            if (txtCityName.Text.Trim() != "")
                strCityName = txtCityName.Text.Trim();
            if (txtSTDCode.Text.Trim() != "")
                strSTDCode = txtSTDCode.Text.Trim();
            if (txtPinCode.Text.Trim() != "")
                strPinCode = txtPinCode.Text.Trim();
            #endregion Gather Information

            #region set connection & command object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            //SqlCommand objCmd = new SqlCommand();
            //objCmd.Connection = objConn;
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            strUserID = Session["UserID"].ToString().Trim();
            strCityName = txtCityName.Text.Trim();
            strSTDCode = txtSTDCode.Text.Trim();
            strPinCode = txtPinCode.Text.Trim();
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityName", strCityName);
            objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);
            objCmd.Parameters.AddWithValue("@PinCode", strPinCode);
            objCmd.Parameters.AddWithValue("@UserID", strUserID);
            #endregion set connection & command object

            if (Page.RouteData.Values["CityID"] != null)
            {
                #region Update Record
                //edit mode
                objCmd.Parameters.AddWithValue("@CityID", EncryptDecrypt.Base64Decode(Page.RouteData.Values["CityID"].ToString().Trim()));
                objCmd.CommandText = "[dbo].[PR_City_UpdateByUserIDCityID]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("/AdminPanel/City/List", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                objCmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                objCmd.CommandText = "[dbo].[PR_City_Insert]";
                objCmd.ExecuteNonQuery();

                objConn.Close();
                lblMessage.Text = "Data Inserted Successfully";
                ddlCountryID.SelectedIndex = 0;
                ddlStateID.SelectedIndex = 0;
                txtCityName.Text = "";
                txtSTDCode.Text = "";
                txtPinCode.Text = "";
                ddlCountryID.Focus();
                #endregion Insert Record
            }
            if (objConn.State == ConnectionState.Open)
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
    #endregion Button : Save

    #region FillCountry
    private void FillCountry()
    {
        CommonDropDownFillMethod.FillDropDownListCountry(ddlCountryID, lblMessage);

    }
    #endregion FillCountry

    #region ddlCountryID_SelectedIndexChanged
    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        ddlStateID.Items.Clear();
        fillState();
    }
    #endregion ddlCountryID_SelectedIndexChanged

    #region fillState
    private void fillState()
    {
        CommonDropDownFillMethod.FillDropDownListState(ddlStateID, ddlCountryID, lblMessage);
    }
    #endregion fillState

    #region FillCityControls
    private void FillCityControls(SqlInt32 CityID)
    {
        //CityID = EncryptDecrypt.Base64Decode(CityID);


        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectByUserIDCityID";
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString());

            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["CountryID"].Equals(DBNull.Value) != true)
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    fillState();
                    if (objSDR["StateID"].Equals(DBNull.Value) != true)
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    if (objSDR["CityName"].Equals(DBNull.Value) != true)
                    {
                        txtCityName.Text = objSDR["CityName"].ToString().Trim();
                    }
                    if (objSDR["STDCode"].Equals(DBNull.Value) != true)
                    {
                        txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                    }
                    if (objSDR["PinCode"].Equals(DBNull.Value) != true)
                    {
                        txtPinCode.Text = objSDR["PinCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data Available For the CityID = " + CityID.ToString();
            }
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
    #endregion FillCityControls

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/AdminPanel/City/List", true);
    }
    #endregion Button : Cancel
}