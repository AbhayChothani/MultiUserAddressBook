<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressbook.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContnet" Runat="Server">

    <div class="row">
        <div class="col-md-12">
            <h2>City Add Edit Page</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false" ForeColor="Lime"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class ="col-md-4">
                    Country
                </div>
                <div class ="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlCountryID" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                </div>
            </div><br />
            <div class="row">
                <div class ="col-md-4">
                    State
                </div>
                <div class ="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlStateID" CssClass="form-control"></asp:DropDownList>
                </div>
            </div><br />
            <div class="row">
                <div class ="col-md-4">
                    City Name
                </div>
                <div class ="col-md-8">
                    <asp:TextBox runat="server" ID="txtCityName" CssClass="form-control"/>
                </div>
            </div><br />
            <div class="row">
                <div class ="col-md-4">
                    STD Code
                </div>
                <div class ="col-md-8">
                    <asp:TextBox runat="server" ID="txtSTDCode" CssClass="form-control"/>
                </div>
            </div><br />
            <div class="row">
                <div class ="col-md-4">
                   Pin Code
                </div>
                <div class ="col-md-8">
                    <asp:TextBox runat="server" ID="txtPinCode" CssClass="form-control"/>
                </div>
            </div><br />
            
            <div class="row">
                <div class ="col-md-4">
                    
                </div>
                <div class ="col-md-8">
                    <asp:Button runat="server" ID="btnSave" Text="Save" BackColor="Black" BorderColor="Black" ForeColor="White" style="border-radius:5px;height:30px;" OnClick="btnSave_Click"/>
                    <asp:Button runat="server" ID="btnCancel" Text="Cancel" style="border-radius:5px;" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click"/>
                </div>
            </div>
         </div>
    </div>

</asp:Content>

