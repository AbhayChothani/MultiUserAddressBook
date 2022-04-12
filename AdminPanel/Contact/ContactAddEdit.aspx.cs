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

public partial class AdminPanel_Contact_ContactAddEditt : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCBLContactCategoryID();
            FillCountry();
            FillState();
            FillCity();
            if (Page.RouteData.Values["ContactID"] != null)
            {
                lblMessage.Text = "<b>--- Edit Mode | ContactID = </b>" + EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactID"].ToString());
                FillContactControls(Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactID"].ToString().Trim())));

            }
            else
            {
                lblMessage.Text = "<b>--- Add Mode ---</b>";
                imgOldPhoto.Visible = false;
            }


            //ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
            //ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
            //FillContactCategory();

        }
    }
    #endregion Page_Load

    #region btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlString strUserID = SqlString.Null;
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlInt32 strStateID = SqlInt32.Null;
        SqlInt32 strCityID = SqlInt32.Null;
        SqlInt32 strContactCategoryID = SqlInt32.Null;
        SqlString strContactName = SqlString.Null;
        SqlString strContactPhotoPath = SqlString.Null;
        SqlString strContactNo = SqlString.Null;
        SqlString strWhatsAppNo = SqlString.Null;
        SqlDateTime strBirthDate = SqlDateTime.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strAge = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strBloodGroup = SqlString.Null;
        SqlString strFacebookID = SqlString.Null;
        SqlString strLinkedInID = SqlString.Null;
        SqlString strCreationDate = SqlString.Null;

        #region Server Side Validation
        String strErrorMessage = "";
        
        if (ddlCountryID.SelectedItem.Text == "Select Country")
            strErrorMessage += "- Select Country  ||  ";
        if (ddlStateID.SelectedItem.Text == "Select State")
            strErrorMessage += "- Select State<br/>";
        if (ddlCityID.SelectedItem.Text == "Select City")
            strErrorMessage += "- Select City  ||  ";
        //if (ddlContactCategoryID.SelectedItem.Text == "Select ContactCategory")
        //    strErrorMessage += "- Select Contact category<br/>";
        if (txtContactName.Text.Trim() == "")
            strErrorMessage += "- Enter Contact Name  ||  ";
        if (!fuContactPhotoPath.HasFile && imgOldPhoto.ImageUrl == "")
            strErrorMessage += "- Upload Photo <br/>";
        if (txtContactNo.Text.Trim() == "")
            strErrorMessage += "- Enter Contact No <br/>";
        if (txtWhatsAppNo.Text.Trim() == "")
            strErrorMessage += "- Enter WhatsAppNo  ||  ";
        if (txtBirthDate.Text.Trim() == "")
            strErrorMessage += "- Enter BirthDate <br/>";
        if (txtEmail.Text.Trim() == "")
            strErrorMessage += "- Enter Email  ||  ";
        if (txtAge.Text.Trim() == "")
            strErrorMessage += "- Enter Age<br/>";
        if (txtAddress.Text.Trim() == "")
            strErrorMessage += "- Enter Address  ||  ";
        if (txtBloodGroup.Text.Trim() == "")
            strErrorMessage += "- Enter BloodGroup <br/>";
        if (txtFacebookID.Text.Trim() == "")
            strErrorMessage += "- Enter FacebookID  ||  ";
        if (txtLinkedlnID.Text.Trim() == "")
            strErrorMessage += "- Enter LinkedlnID <br/>";

        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        String ContactPhotoPath = "";
        if (fuContactPhotoPath.HasFile)
        {
            ContactPhotoPath = "~/UserContent/" + fuContactPhotoPath.FileName.ToString().Trim();
            fuContactPhotoPath.SaveAs(Server.MapPath(ContactPhotoPath));
        }
        else
        {
            ContactPhotoPath = imgOldPhoto.ImageUrl;
        }

        #region Gather Information
        if (ddlCountryID.SelectedIndex > 0)
            strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
        if (ddlStateID.SelectedIndex > 0)
            strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
        if (ddlCityID.SelectedIndex > 0)
            strCityID = Convert.ToInt32(ddlCityID.SelectedItem.Value);
        //if (ddlContactCategoryID.SelectedIndex > 0)
        //    strContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedItem.Value);
        if (txtContactName.Text.Trim() != "")
            strContactName = txtContactName.Text.Trim();
        if (ContactPhotoPath != "")
        {
            strContactPhotoPath = ContactPhotoPath;
        }
        if (txtContactNo.Text.Trim() != "")
            strContactNo = txtContactNo.Text.Trim();
        if (txtWhatsAppNo.Text.Trim() != "")
            strWhatsAppNo = txtWhatsAppNo.Text.Trim();
        if (txtBirthDate.Text.Trim() != "")
            strBirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());
        if (txtEmail.Text.Trim() != "")
            strEmail = txtEmail.Text.Trim();
        if (txtAge.Text.Trim() != "")
            strAge = txtAge.Text.Trim();
        if (txtAddress.Text.Trim() != "")
            strAddress = txtAddress.Text.Trim();
        if (txtBloodGroup.Text.Trim() != "")
            strBloodGroup = txtBloodGroup.Text.Trim();
        if (txtFacebookID.Text.Trim() != "")
            strFacebookID = txtFacebookID.Text.Trim();
        if (txtLinkedlnID.Text.Trim() != "")
            strLinkedInID = txtLinkedlnID.Text.Trim();
        #endregion Gather Information


        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region set connection & command object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            strUserID = Session["UserID"].ToString().Trim();
            strContactName = txtContactName.Text.Trim();
            strContactNo = txtContactNo.Text.Trim();
            strWhatsAppNo = txtWhatsAppNo.Text.Trim();
            //strBirthDate = txtBirthDate.Text.Trim();
            strEmail = txtEmail.Text.Trim();
            strAge = txtAge.Text.Trim();
            strFacebookID = txtFacebookID.Text.Trim();
            strLinkedInID = txtLinkedlnID.Text.Trim();
            strAddress = txtAddress.Text.Trim();
            strBloodGroup = txtBloodGroup.Text.Trim();

            objCmd.Parameters.AddWithValue("@UserID", strUserID);
            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityID", strCityID);
            //objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);
            objCmd.Parameters.AddWithValue("@ContactName", strContactName);
            objCmd.Parameters.AddWithValue("@ContactPhotoPath", strContactPhotoPath);
            objCmd.Parameters.AddWithValue("@ContactNo", strContactNo);
            objCmd.Parameters.AddWithValue("@WhatsAppNo", strWhatsAppNo);
            objCmd.Parameters.AddWithValue("@BirthDate", strBirthDate);
            objCmd.Parameters.AddWithValue("@Email", strEmail);
            objCmd.Parameters.AddWithValue("@Age", strAge);
            objCmd.Parameters.AddWithValue("@Address", strAddress);
            objCmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);
            objCmd.Parameters.AddWithValue("@FacebookID", strFacebookID);
            objCmd.Parameters.AddWithValue("@LinkedInID", strLinkedInID);
            //we need ContactID(PK) after insertion of the record
            //It is needed to insert record in the table ContactWiseContactCategory

            //objCmd.Parameters["@ContactID"].Direction = ParameterDirection.Output;
            #endregion set connection & command object
            //SqlInt32 ContactID = EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactID"]);
            if (Page.RouteData.Values["ContactID"] != null)
            {
                
                #region Update Record
                //edit Mode
                objCmd.Parameters.AddWithValue("@ContactID", EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactID"].ToString().Trim()));
                objCmd.CommandText = "[dbo].[PR_Contact_UpdateByUserIDContactID]";
                objCmd.ExecuteNonQuery();
                
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                //Add Mode

                objCmd.CommandText = "[dbo].[PR_Contact_Insert]";

                objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                objCmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);

                objCmd.ExecuteNonQuery();
                //ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);
                //lblMessage.Text = "Data Inserted Successfully With ContactID = " + ContactID.ToString();

                ddlCountryID.SelectedIndex = 0;
                ddlStateID.Items.Clear();
                ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
                ddlStateID.SelectedValue = "-1";
                ddlCityID.Items.Clear();
                ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
                ddlCityID.SelectedValue = "-1";
                //ddlContactCategoryID.SelectedIndex = 0;
                txtContactName.Text = "";
                txtContactNo.Text = "";
                txtWhatsAppNo.Text = "";
                txtBirthDate.Text = "";
                txtEmail.Text = "";
                txtAge.Text = "";
                txtAddress.Text = "";
                txtBloodGroup.Text = "";
                txtFacebookID.Text = "";
                txtLinkedlnID.Text = "";

                ddlCountryID.Focus();
                #endregion Insert Record
            }
            try
            {
                SqlCommand objCmdContactCategory = objConn.CreateCommand();
                objCmdContactCategory.CommandType = CommandType.StoredProcedure;
                objCmdContactCategory.CommandText = "[dbo].[PR_ContactWiseContactCategory_DeleteByContactIDAndContactCategoryID]";
                objCmdContactCategory.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
                objCmdContactCategory.Parameters.AddWithValue("@ContactID", EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactID"].ToString().Trim()));
                objCmdContactCategory.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

            foreach (ListItem liContactCategoryID in cblContactCategoryID.Items)
            {
                if (liContactCategoryID.Selected)
                {
                    try
                    {
                        SqlCommand objCmdContactCategory = objConn.CreateCommand();
                        objCmdContactCategory.CommandType = CommandType.StoredProcedure;
                        objCmdContactCategory.CommandText = "[dbo].[PR_ContactWiseContactCategory_Insert]";
                        objCmdContactCategory.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
                        objCmdContactCategory.Parameters.AddWithValue("@ContactID", EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactID"].ToString().Trim()));
                        objCmdContactCategory.Parameters.AddWithValue("@ContactCategoryID", liContactCategoryID.Value.ToString());
                        objCmdContactCategory.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message;
                    }
                }
            }
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            Response.Redirect("/AdminPanel/Contact/List", true);
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
    #endregion btnSave_Click

    #region FillCBLContactCategoryID
    private void FillCBLContactCategoryID()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";

            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                cblContactCategoryID.DataTextField = "ContactCategoryName";
                cblContactCategoryID.DataValueField = "ContactCategoryID";
                cblContactCategoryID.DataSource = objSDR;
                cblContactCategoryID.DataBind();
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
    #endregion FillCBLContactCategoryID

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
        ddlCityID.Items.Clear();

        ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
        FillState();
    }
    #endregion ddlCountryID_SelectedIndexChanged

    #region FillState
    private void FillState()
    {
        CommonDropDownFillMethod.FillDropDownListState(ddlStateID, ddlCountryID, lblMessage);
    }
    #endregion FillState

    #region ddlStateID_SelectedIndexChanged
    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCityID.Items.Clear();
        FillCity();
    }
    #endregion ddlStateID_SelectedIndexChanged

    #region FillCity
    private void FillCity()
    {
        CommonDropDownFillMethod.FillDropDownListCirty(ddlStateID, ddlCountryID, ddlCityID, lblMessage);
    }
    #endregion FillCity

    //#region FillContactCategory
    //private void FillContactCategory()
    //{

    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
    //    try
    //    {
    //        objConn.Open();
    //        SqlCommand objCmd = objConn.CreateCommand();
    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";

    //        //objCmd.Parameters.AddWithValue("@ContactCategoryID", ddlContactCategoryID.SelectedValue.ToString());

    //        SqlDataReader objSDR = objCmd.ExecuteReader();

    //        if (objSDR.HasRows == true)
    //        {
    //            ddlContactCategoryID.DataSource = objSDR;
    //            ddlContactCategoryID.DataValueField = "ContactCategoryID";
    //            ddlContactCategoryID.DataTextField = "ContactCategoryName";
    //            ddlContactCategoryID.DataBind();
    //        }
    //        ddlContactCategoryID.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));

    //        objConn.Close();
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
    //#endregion FillContactCategory

    #region FillContactControls
    private void FillContactControls(SqlInt32 ContactID)
    {
        //string ContactID = EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactID"].ToString());

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_SelectByUserIDContactID";
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            objCmd.Parameters.AddWithValue("@ContactID", ContactID);

            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["CountryID"].Equals(DBNull.Value) != true)
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    FillState();
                    if (objSDR["StateID"].Equals(DBNull.Value) != true)
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    FillCity();
                    if (objSDR["CityID"].Equals(DBNull.Value) != true)
                    {
                        ddlCityID.SelectedValue = objSDR["CityID"].ToString().Trim();
                    }
                    if (objSDR["ContactPhotoPath"].Equals(DBNull.Value) != true)
                    {
                        imgOldPhoto.ImageUrl = objSDR["ContactPhotoPath"].ToString().Trim();
                    }
                    if (objSDR["ContactName"].Equals(DBNull.Value) != true)
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                    }
                    if (objSDR["ContactNo"].Equals(DBNull.Value) != true)
                    {
                        txtContactNo.Text = objSDR["ContactNo"].ToString().Trim();
                    }
                    if (objSDR["WhatsAppNo"].Equals(DBNull.Value) != true)
                    {
                        txtWhatsAppNo.Text = objSDR["WhatsAppNo"].ToString().Trim();
                    }
                    if (objSDR["BirthDate"].Equals(DBNull.Value) != true)
                    {
                        txtBirthDate.Text = Convert.ToDateTime(objSDR["BirthDate"]).ToString("yyyy-MM-dd");
                    }
                    if (objSDR["Email"].Equals(DBNull.Value) != true)
                    {
                        txtEmail.Text = objSDR["Email"].ToString().Trim();
                    }
                    if (objSDR["Age"].Equals(DBNull.Value) != true)
                    {
                        txtAge.Text = objSDR["Age"].ToString().Trim();
                    }
                    if (objSDR["Address"].Equals(DBNull.Value) != true)
                    {
                        txtAddress.Text = objSDR["Address"].ToString().Trim();
                    }
                    if (objSDR["BloodGroup"].Equals(DBNull.Value) != true)
                    {
                        txtBloodGroup.Text = objSDR["BloodGroup"].ToString().Trim();
                    }
                    if (objSDR["FacebookID"].Equals(DBNull.Value) != true)
                    {
                        txtFacebookID.Text = objSDR["FacebookID"].ToString().Trim();
                    }
                    if (objSDR["LinkedInID"].Equals(DBNull.Value) != true)
                    {
                        txtLinkedlnID.Text = objSDR["LinkedInID"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data Available For the ContactID = " + ContactID.ToString();
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

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmdContactCategory = objConn.CreateCommand();
            objCmdContactCategory.CommandType = CommandType.StoredProcedure;
            objCmdContactCategory.CommandText = "PR_ContactWiseContactCategory_SelectByContactID";

            objCmdContactCategory.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            objCmdContactCategory.Parameters.AddWithValue("@ContactID", ContactID);

            SqlDataReader objSDRContactCategory = objCmdContactCategory.ExecuteReader();

            
            if (objSDRContactCategory.HasRows)
            {
                while (objSDRContactCategory.Read())
                {
                    if (objSDRContactCategory["ContactCategoryID"].Equals(DBNull.Value) != true)
                    {

                        cblContactCategoryID.Items.FindByValue(objSDRContactCategory["ContactCategoryID"].ToString().Trim()).Selected = true;

                    }
                }
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
    #endregion FillContactControls

    #region btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/AdminPanel/Contact/List", true);
    }
    #endregion btnCancel_Click

    public object UserID { get; set; }
}
