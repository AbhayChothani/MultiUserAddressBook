    <%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressbook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <style>
        .gridview{
            overflow:scroll;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContnet" Runat="Server">
     <div class="row">
        <div class="col-md-12">
            <h2>Contact List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
           <asp:Label runat="server" ID="lblMessage" EnableViewState="False" />
        </div>
    </div>
    <div class="row">
        <div class="text-right">
                <asp:HyperLink runat="server" ID="hlAddContact" Text="Add New Contact" CssClass="btn btn-default mb-4" NavigateUrl="/AdminPanel/Contact/Add" BackColor="Black" Font-Size="Medium" ForeColor="White" />
            </div>
        <div class="col-md-12 gridview">
             
           <%-- <asp:GridView ID="gvContact" CssClass="table table-hover" runat="server" OnRowCommand="gvContact_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="btnEdit" Text="Edit" NavigateUrl='<%# "~/AdminPanel/Contact/ContactAddEdit.aspx?ContactID=" +Eval("ContactID").ToString().Trim() %>' CssClass=" btn btn-info"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>--%>
             <asp:GridView AutoGenerateColumns="False" ID="gvContact" runat="server" CssClass="table table-bordered table-hover" OnRowCommand="gvContact_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                 <AlternatingRowStyle BackColor="White" />
                <Columns>
                     <asp:TemplateField  HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-danger btn-sm" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this Contact?')" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-info" Text="Edit" NavigateUrl='<%# "/AdminPanel/Contact/Edit/"+ EncryptDecrypt.Base64Encode(Eval("ContactID").ToString()) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="ContactName" HeaderText="ContactName" />
                    <asp:TemplateField HeaderText="Photo">
                        <ItemTemplate>
                            <asp:Image runat="server" ID="imgPhoto" ImageUrl='<%# Eval("ContactPhotoPath") %>' Height="80" Width="70" />
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:BoundField DataField="ContactCategoryName" HeaderText="ContactCategoryName" />
                    <asp:BoundField DataField="ContactNo" HeaderText="ContactNo " />
                    <asp:BoundField DataField="StateName" HeaderText="State" />
                    <asp:BoundField DataField="WhatsAppNo" HeaderText="WhatsAppNo" />
                    <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="CityName" HeaderText="CityName" />
                    <asp:BoundField DataField="StateName" HeaderText="StateName" />
                    <asp:BoundField DataField="CountryName" HeaderText="CountryName" />
                    <asp:BoundField DataField="BloodGroup" HeaderText="BloodGroup" />
                    <asp:BoundField DataField="LinkedInID" HeaderText="LinkedlNID" />
                    <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" />
                </Columns>
                 <EditRowStyle BackColor="#2461BF" />
                 <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                 <RowStyle BackColor="#EFF3FB" />
                 <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                 <SortedAscendingCellStyle BackColor="#F5F7FB" />
                 <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                 <SortedDescendingCellStyle BackColor="#E9EBEF" />
                 <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

