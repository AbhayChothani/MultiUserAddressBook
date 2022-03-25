<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminPanel_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <link href="~/Content/css/bootstrap-theme.min.css" rel="stylesheet" />
    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
   <%-- <link href="~/Content/css/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="~/Content/css/Style.css" rel="stylesheet" />
    <%--<script src="~/Content/js/bootstrap.bundle.min.js"></script>--%>
    <script src="~/Content/js/bootstrap.min.js"></script>

    <style>
        .myContainer {
            padding: 50px;
            margin: 20px;
            border: 2px solid black;
            border-radius: 15px;
            width: 100%;
            height: 100%;
        }
        .gradient-custom-3 {
            background: #84fab0;
            background: -webkit-linear-gradient(to right, rgba(120, 250, 176, 0.5), rgba(143, 211, 244, 0.5));
            background: linear-gradient(to right, rgba(132, 250, 176, 0.5), rgba(143, 211, 244, 0.5));
        }
        .gradient-custom-4 {
            background: #84fab0;
            background: -webkit-linear-gradient(to right, rgba(132, 250, 15, 1), rgba(143, 211, 244, 1));
            background: linear-gradient(to right, rgba(132, 250, 176, 1), rgba(143, 211, 244, 1));
        }
        .imgfortuner{
              background-position: center;
              background-repeat: no-repeat;
              background-size: cover;
        }
    </style>

</head>
<body>
    <%--<form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <h1>Existing User Login to Address Book</h1>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblMessage" EnableViewState="false" />
                </div>
            </div>
             <div class="row">
                <div class="col-md-2">
                    User Name
                </div>
                 <div class="col-md-6">
                    <asp:TextBox runat="server" ID="txtUserNameLogin" CssClass="form-control" />
                </div>
            </div><br />
            <div class="row">
                <div class="col-md-2">
                    Password
                </div>
                 <div class="col-md-6">
                    <asp:TextBox runat="server" ID="txtPasswordLogin" CssClass="form-control"/>
                </div>
            </div><br />
            <div class="row">
                <div class="col-md-2">
                    
                </div>
                 <div class="col-md-6">
                    <asp:Button runat="server" ID="btnLogin" Text="Login" OnClick="btnLogin_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    
                </div>
                <p class="text-center text-muted mt-5 mb-0">Didn't Register ? <a href="#!" class="fw-bold text-body"><u><asp:HyperLink ID="hlRegister" NavigateUrl="~/AddressBook/AdminPanel/Register.aspx" CssClass="fw-bold text-body" runat="server">Register Here</asp:HyperLink></u></a></p>              
            </div>
        </div>
    </form>--%>

     <form id="form1" runat="server">
        <section class="vh-100 bg-image img-fluid imgfortuner" 
            style="background-image:url(https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTBE9GJbcB34msKZXl9BkqVbRfcnGjob-pARA&usqp=CAU)">
            <div class="mask d-flex align-items-center h-100 gradient-custom-3">
                <div class="container h-100">
                    <div class="row d-flex justify-content-center align-items-center h-100">
                        <div class="col-12 col-md-9 col-lg-7 col-xl-6">
                            <div class="card" style="border-radius: 15px;">
                                <div class="card-body p-5">
                                    <h2 class="text-uppercase text-center mb-5">Login</h2>

                                    <div class="form-outline mb-4">
                                        <label class="form-label" for="form3Example1cg">Username</label>
                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="rfUsername" runat="server" CssClass="" ErrorMessage="Enter Username" ForeColor="red" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="form-outline mb-4">
                                        <label class="form-label" for="form3Example4cg">Password</label>
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"/>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Password" ForeColor="red" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="d-flex justify-content-center">
                                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-success btn-lg gradient-custom-4 text-body" OnClick="btnLogin_Click" />
                                        <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                    </div>

                                    <p class="text-center text-muted mt-5 mb-0">Didn't Register ? <a href="#!" class="fw-bold text-body"><u><asp:HyperLink ID="hlRegister" NavigateUrl="~/AdminPanel/Register.aspx" CssClass="fw-bold text-body" runat="server">Register Here</asp:HyperLink></u></a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>
