<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressbook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEditt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContnet" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>Contact Add / Edit Page</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false" ForeColor="Lime"/>
        </div>
    </div>

    <div class="row">
        <div class="col-md-8">
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-4">
                            <span style="color: red">*</span> Country
                        </div>
                        <div class="col-md-8">
                            <asp:DropDownList runat="server" ID="ddlCountryID" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>

                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <span style="color: red">*</span> State
                        </div>
                        <div class="col-md-8">
                            <asp:DropDownList runat="server" ID="ddlStateID" OnSelectedIndexChanged="ddlStateID_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>

                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <span style="color: red">*</span> City
                        </div>
                        <div class="col-md-8">
                            <asp:DropDownList runat="server" ID="ddlCityID" CssClass="form-control"></asp:DropDownList>

                        </div>
                    </div>
                    <br />
                    <%--<div class="row">
                <div class="col-md-4">
                    ContactCategory
                </div>
                <div class="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlContactCategoryID" CssClass="form-control"></asp:DropDownList>

                </div>
            </div>
            <br />--%>
                    <div class="row">
                        <div class="col-md-4">
                            <span style="color: red">*</span> Contact Name
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtContactName" CssClass="form-control" />
                            <%--                   <asp:RequiredFieldValidator runat="server" CssClass="" ErrorMessage="Enter ContactName" ForeColor="red" ControlToValidate="txtContactName"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <br />
                    
                    <div class="row">
                        <div class="col-md-4">
                            <span style="color: red">*</span> Upload Photo
                        </div>
                        <div class="col-md-4">
                            <asp:FileUpload runat="server" ID="fuContactPhotoPath" />
                        </div>
                        <div class="col-md-4 text-center ">
                            <asp:Image runat="server" ID="imgOldPhoto" EnableViewState="false" Height="70px" Width="70px" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <span style="color: red">*</span>  ContactNo.
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtContactNo" CssClass="form-control" TextMode="Phone" />
                            <%--                    <asp:RequiredFieldValidator runat="server" CssClass="" ErrorMessage="Enter ContactNo" ForeColor="red" ControlToValidate="txtContactNo"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <span style="color: red">*</span> WhatsAppNo
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtWhatsAppNo" CssClass="form-control" TextMode="Phone" />
                            <%--                    <asp:RequiredFieldValidator runat="server" CssClass="" ErrorMessage="Enter WhatsAppNo" ForeColor="red" ControlToValidate="txtWhatsAppNo"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <span style="color: red">*</span> BirthDate
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtBirthDate" CssClass="form-control" TextMode="Date" />
                            <%--                    <asp:RequiredFieldValidator runat="server" CssClass="" ErrorMessage="Enter BirthDate" ForeColor="red" ControlToValidate="txtBirthDate"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <span style="color: red">*</span> Email
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
                            <%--                    <asp:RequiredFieldValidator runat="server" CssClass="" ErrorMessage="Enter Email" ForeColor="red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <span style="color: red">*</span> Age
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtAge" CssClass="form-control" TextMode="Number" />
                            <%--                    <asp:RequiredFieldValidator runat="server" CssClass="" ErrorMessage="Enter Age" ForeColor="red" ControlToValidate="txtAge"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <span style="color: red">*</span>  Address
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" />
                            <%--                    <asp:RequiredFieldValidator runat="server" CssClass="" ErrorMessage="Enter Address" ForeColor="red" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <span style="color: red">*</span>  BloodGroup
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtBloodGroup" CssClass="form-control" />
                            <%--                    <asp:RequiredFieldValidator runat="server" CssClass="" ErrorMessage="Enter BloodGroup" ForeColor="red" ControlToValidate="txtBloodGroup"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <span style="color: red">*</span>  FaceBookID
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtFacebookID" CssClass="form-control" />
                            <%--                    <asp:RequiredFieldValidator runat="server" CssClass="" ErrorMessage="Enter FacebookID" ForeColor="red" ControlToValidate="txtFacebookID"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <span style="color: red">*</span>  LinkedlnID
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtLinkedlnID" CssClass="form-control" />
                            <%--                    <asp:RequiredFieldValidator runat="server" CssClass="" ErrorMessage="Enter LinkedlnID" ForeColor="red" ControlToValidate="txtLinkedlnID"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-4">
                        </div>
                        <div class="col-md-8">
                            <asp:Button runat="server" ID="btnSave" Text="Save" BackColor="Black" BorderColor="Black" ForeColor="White" Style="border-radius: 5px; height: 30px" OnClick="btnSave_Click" />
                            <asp:Button runat="server" ID="btnCancel" Text="Cancel" Style="border-radius: 5px;" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <h5>Contact Category</h5>
            <asp:CheckBoxList runat="server" ID="cblContactCategoryID" />
        </div>
    </div>


</asp:Content>

