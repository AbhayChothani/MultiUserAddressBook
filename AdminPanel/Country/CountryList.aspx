    <%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressbook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContnet" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>Country List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
           <asp:Label runat="server" ID="lblMessage" EnableViewState="False" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="text-right">
                <asp:HyperLink runat="server" ID="hlAddCountry" Text="Add New Country" CssClass="btn btn-default mb-4" NavigateUrl="/AdminPanel/Country/Add" BackColor="Black" Font-Size="Medium" ForeColor="White" />
            </div>
            <div>
                <asp:GridView ID="gvCountry" AutoGenerateColumns="false" CssClass="table table-hover" runat="server" OnRowCommand="gvCountry_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this Country?')" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("CountryID").ToString() %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="btnEdit" Text="Edit" NavigateUrl='<%# "/AdminPanel/Country/Edit/" +EncryptDecrypt.Base64Encode(Eval("CountryID").ToString().Trim()) %>' CssClass=" btn btn-info"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:BoundField DataField="CountryName" HeaderText="CountryName" />
                        <asp:BoundField DataField="CountryCode" HeaderText="CountryCode" />
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
    </div>
</asp:Content>

