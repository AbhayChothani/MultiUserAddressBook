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

public partial class AdminPanel_State_StateList : System.Web.UI.Page
{   
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
        
    }
    #endregion Load Event

    #region FillGridView
    private void FillGridView()
    {

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectByUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);

            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                gvState.DataSource = objSDR;
                gvState.DataBind();
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
    #endregion FillGridView

    #region gvState_RowCommand
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteState(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion gvState_RowCommand

    #region DeleteState
    private void DeleteState(SqlInt32 StateID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_DeleteByUserIDStateID";
            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString());
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            objCmd.ExecuteNonQuery();

            objConn.Close();
            FillGridView();
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
    #endregion DeleteState
}