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

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Page.RouteData.Values["ContactCategoryID"] != null)
            {
                lblMessage.Text = "Edit Mode | ContactCategoryID = " + EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactCategoryID"].ToString().Trim());
                FillContactCategoryControls(Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactCategoryID"].ToString().Trim())));
            }
            else
            {
                lblMessage.Text = "Add Mode";
            }
        }
    }
    #endregion Load Event

    #region btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlString strUserID = SqlString.Null;
        SqlString strContactCategoryName = SqlString.Null;
        SqlString strCreationDate = SqlString.Null;
        #region Server Side Validation
        String strErrorMessage = "";
        if (txtContactCategoryName.Text.Trim() == "")
            strErrorMessage += "- Enter Contact Category Name <br/><hr/>";
        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            //SqlCommand objCmd = new SqlCommand();
            //objCmd.Connection = objConn;
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            strUserID = Session["UserID"].ToString().Trim();
            objCmd.Parameters.AddWithValue("@UserID", strUserID);
            objCmd.Parameters.AddWithValue("@ContactCategoryName", txtContactCategoryName.Text.Trim());
            if (Page.RouteData.Values["ContactCategoryID"] != null)
            {
                #region Update Record
                //edit mode
                objCmd.Parameters.AddWithValue("@ContactCategoryID", EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactCategoryID"].ToString().Trim()));
                objCmd.CommandText = "[dbo].[PR_ContactCategory_UpdateByUserIDContactCategoryID]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("/AdminPanel/ContactCategory/List", true);
                #endregion Update Record
            }
            else
            { //Add mode
                objCmd.CommandText = "[dbo].[PR_ContactCategory_Insert]";

                strContactCategoryName = txtContactCategoryName.Text.Trim();

                objCmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                objCmd.ExecuteNonQuery();

                objConn.Close();
                lblMessage.Text = "Data Inserted Successfully";
                txtContactCategoryName.Text = "";
                txtContactCategoryName.Focus();
            }

           
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
#endregion btnSave_Click

    #region FillContactCategoryControls
    private void FillContactCategoryControls(SqlInt32 ContactCategoryID)
    {
       // string ContactCategoryID = EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactCategoryID"].ToString());

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectByUserIDContactCategoryID";
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID);
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["ContactCategoryName"].Equals(DBNull.Value) != true)
                    {
                        txtContactCategoryName.Text = objSDR["ContactCategoryName"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data Available For the ContactCategoryID = " + ContactCategoryID.ToString();
            }



        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally{
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion FillContactCategoryControls

    #region btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/AdminPanel/ContactCategory/List", true);
    }
    #endregion btnCancel_Click
}