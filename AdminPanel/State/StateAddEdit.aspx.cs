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

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            if (Page.RouteData.Values["StateID"] != null)
            {
                lblMessage.Text = "Edit Mode | StateID = " + EncryptDecrypt.Base64Decode(Page.RouteData.Values["StateID"].ToString().Trim());
                FillStateControls(Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["StateID"].ToString().Trim())));
            }
            else
            {
                lblMessage.Text = "Add Mode";
            }      
     
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
        SqlString strStateName = SqlString.Null;
        SqlString strStateCode = SqlString.Null;
        SqlString strCreationDate = SqlString.Null;
        #endregion local Varialbles
        try {
            //ServerSide Validation
            #region Server Side Validation
            String strErrorMessage = "";
        if (ddlCountryID.SelectedIndex == 0)
            strErrorMessage += "- Select Country <br/>";
        if (txtStateName.Text.Trim() == "")
            strErrorMessage += "- Enter StateName <br/>";
        if (txtStateCode.Text.Trim() == "")
            strErrorMessage += "- Enter StateCode <br/><hr/>";
        if(strErrorMessage.Trim()!="")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
            #endregion Server Side Validation
        //gathering
        #region Gather Information
        if (ddlCountryID.SelectedIndex > 0)
            strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
        if (txtStateName.Text.Trim() != "")
            strStateName = txtStateName.Text.Trim();
        #endregion Gather Information
                
        #region set connection & command object
        if (objConn.State!=ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            strStateCode = txtStateCode.Text.Trim();
            strUserID = Session["UserID"].ToString().Trim();

            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@StateName", strStateName);
            objCmd.Parameters.AddWithValue("@StateCode", strStateCode);
            objCmd.Parameters.AddWithValue("@UserID", strUserID);


        #endregion set connection & command object

            if (Page.RouteData.Values["StateID"] != null)
            {
                #region Update Record
                //edit mode
                objCmd.Parameters.AddWithValue("@StateID", EncryptDecrypt.Base64Decode(Page.RouteData.Values["StateID"].ToString().Trim()));
                objCmd.CommandText = "[dbo].[PR_State_UpdateByUserIDStateID]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("/AdminPanel/State/List",true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                //Add mode
                objCmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);

                objCmd.CommandText = "[dbo].[PR_State_Insert]";

                objCmd.ExecuteNonQuery();
                 
                txtStateName.Text = "";
                txtStateCode.Text = "";

                ddlCountryID.SelectedIndex = 0;
                ddlCountryID.Focus();
                lblMessage.Text = "Data Inserted Successfully";
                #endregion Insert Record
            }
        
            if(objConn.State == ConnectionState.Open)
                objConn.Close();
          
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
                if(objConn.State == ConnectionState.Open)
                    objConn.Close();
        }
       
    }
    #endregion Button : Save

    #region Button : Cancel     
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/AdminPanel/State/List", true);
    }
    #endregion Button : Cancel

    #region Fill DropDownList
    private void FillDropDownList()
    {
        CommonDropDownFillMethod.FillDropDownListCountry(ddlCountryID, lblMessage);
    }
    #endregion Fill DropDownList

    #region Fill State Control
    private void FillStateControls(SqlInt32 StateID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectByUserIDStateID";
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            objCmd.Parameters.AddWithValue("@StateID",StateID.ToString());

            SqlDataReader objSDR = objCmd.ExecuteReader();
            if(objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["StateName"].Equals(DBNull.Value) != true)
                    {
                        txtStateName.Text = objSDR["StateName"].ToString().Trim(); 
                    }
                    if (objSDR["CountryID"].Equals(DBNull.Value) != true)
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    if (objSDR["StateCode"].Equals(DBNull.Value) != true)
                    {
                        txtStateCode.Text = objSDR["StateCode"].ToString().Trim(); 
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data Available For the StateID = " + StateID.ToString();
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
    #endregion Fill State Control

}