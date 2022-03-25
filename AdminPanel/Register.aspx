<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="AdminPanel_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Form</title>
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
        .gradient-custom-3 {
            background: #84fab0;
            background: -webkit-linear-gradient(to right, rgba(132, 250, 176, 0.5), rgba(143, 211, 244, 0.5));
            background: linear-gradient(to right, rgba(132, 250, 176, 0.5), rgba(143, 211, 244, 0.5));
        }
        .gradient-custom-4 {
            background: #84fab0;
            background: -webkit-linear-gradient(to right, rgba(132, 250, 176, 1), rgba(143, 211, 244, 1));
            background: linear-gradient(to right, rgba(132, 250, 176, 1), rgba(143, 211, 244, 1));
        }
        .imgfortunerregister{
            background-position: center;
              background-repeat: no-repeat;
              background-size: cover;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <section class="imgfortunerregister" style=" background-image:url(https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTBE9GJbcB34msKZXl9BkqVbRfcnGjob-pARA&usqp=CAU)">
            <div class="mask d-flex align-items-center h-100 gradient-custom-3 p-5">
                <div class="container h-100">
                    <div class="row d-flex justify-content-center align-items-center h-100">
                        <div class="col-12 col-md-9 col-lg-7 col-xl-6">
                            <div class="card" style="border-radius: 15px;">
                                <div class="card-body p-5">
                                    <h2 class="text-uppercase text-center mb-5">Create an account</h2>

                                    <div class="form-outline mb-1">
                                        <label for="" class="form-label">User Name</label>
                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" CssClass="" ErrorMessage="Enter User name" ForeColor="red" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="form-outline mb-1">
                                        <label for="" class="form-label">Display Name</label>
                                        <asp:TextBox ID="txtDisplayName" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" CssClass="" ErrorMessage="Enter Display name" ForeColor="red" ControlToValidate="txtDisplayName"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="form-outline mb-1">
                                        <label for="" class="form-label">Password</label>
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                                        <asp:RequiredFieldValidator runat="server" CssClass="" ErrorMessage="Enter Password" ForeColor="red" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ErrorMessage="</br>Minimum 8 characters </br> Should have at least one number </br> Should have at least one upper case </br>Should have at least one lower case </br> Should have at least one special character </br> </br>"
                                            ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$" ControlToValidate="txtPassword" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>

                                    <div class="form-outline mb-1">
                                        <label for="" class="form-label">Confirm Password</label>
                                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" />
                                        <asp:RequiredFieldValidator runat="server" CssClass="" ErrorMessage="Enter Password" ForeColor="red" ControlToValidate="txtConfirmPassword"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator runat="server" ErrorMessage="Passwords do not match" ForeColor="Red" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"></asp:CompareValidator>
                                    </div>

                                    <div class="form-outline mb-1">
                                        <label for="" class="form-label">Contact Number</label>
                                        <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" CssClass="" ErrorMessage="Enter Contact Number" ForeColor="red" ControlToValidate="txtContactNo"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="form-outline mb-1">
                                        <label for="" class="form-label">Email</label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" CssClass="" ErrorMessage="Enter Email Address" ForeColor="red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                    </div>

                                    <%--<div class="form-outline mb-1">
                                        <label for="txtUserName" class="form-label">Upload Photo</label>
                                        <asp:FileUpload runat="server" ID="fuImage" /><br />
                                        <asp:RequiredFieldValidator runat="server" CssClass="" ErrorMessage="Select Image" ForeColor="red" ControlToValidate="fuImage"></asp:RequiredFieldValidator>
                                    </div>--%>

                                    <div class="d-flex justify-content-center">
                                        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-success btn-block btn-lg gradient-custom-4 text-body" OnClick="btnRegister_Click" />

                                    </div>

                                    <div class="d-flex justify-content-center m-3">
                                        <asp:Label runat="server" ID="lblMessage" ForeColor="Red"></asp:Label>
                                    </div>

                                    <p class="text-center text-muted mt-5 mb-0">
                                        Have already an account? <a href="#!" class=""><u>
                                            <asp:HyperLink ID="hlRegister" NavigateUrl="~/AdminPanel/Login.aspx" CssClass="fw-bold text-body" runat="server">Login Here</asp:HyperLink></u></a>
                                    </p>
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
