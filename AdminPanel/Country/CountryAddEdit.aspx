<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressbook.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContnet" Runat="Server">
    <asp:Label runat="server" ID="lblMessage1" ForeColor="Lime" />
    <div class="row">
        <div class="col-md-12">
            <h2>Country Add / Edit Page</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="False" ForeColor="Lime"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            Country Name
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtCountryName" CssClass="form-control"/>
        </div>
    </div><br />
     <div class="row">
        <div class="col-md-4">
            Country Code
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtCountryCode" CssClass="form-control"/>
        </div>
    </div><br />
    
    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-8">
            <asp:Button runat="server" ID="btnSave" Text="Save" BackColor="Black" BorderColor="Black" ForeColor="White" OnClick="btnSave_Click" style="border-radius:5px;height:30px"  ToolTip="Insert Record" />
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" style="border-radius:5px;" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click"/>     
        </div>
    </div>
</asp:Content>

