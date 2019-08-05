<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Register.aspx.cs" Inherits="FinalProject.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="row">
            <h2>Register New Account!</h2>
            <br />
            <asp:Label ID="status" runat="server"></asp:Label>
            <br />
            <div class="col-md-4">
                <div class="form-group">
                    <label for="fullName">Full Name</label>
                    <asp:TextBox ID="fullName" class="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="fullName" Display="Dynamic" Text="Required!"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="email">Email</label>
                    <asp:TextBox ID="email" class="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="email" Display="Dynamic" Text="Required!"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="phone">Phone</label>
                    <asp:TextBox ID="phone" class="form-control" runat="server" />
                </div>
                <div class="form-group">
                    <label for="company">Company</label>
                    <asp:TextBox ID="company" class="form-control" runat="server" />
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="username">Username</label>
                    <asp:TextBox ID="username" class="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="username" Display="Dynamic" Text="Required!"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="accountType">Account Type</label>
                    <asp:DropDownList ID="accountType"
                        runat="server">
                        <asp:ListItem Selected="true" Value="buyer"> Buyer </asp:ListItem>
                        <asp:ListItem Value="seller"> Seller </asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="password">Password</label>
                    <asp:TextBox ID="password" TextMode="password" class="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="password" Display="Dynamic" Text="Required!"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="confPassword">Confirm Password</label>
                    <asp:TextBox ID="confPassword" TextMode="password" class="form-control" runat="server" />
                    <asp:CompareValidator ID="comparevalidator" runat="server" ErrorMessage="Password dont match" ControlToValidate="password" ControlToCompare="confPassword" ForeColor="Red" Text="Password dont match!" Operator="Equal" Type="String"></asp:CompareValidator>
                </div>
                <asp:Button class="btn btn-primary btn-lg" ID="ButtonRegister" runat="server" Text="Create Account" OnClick="ButtonRegister_Click" />
            </div>
        </div>
    </div>

</asp:Content>
