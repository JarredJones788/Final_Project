<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="FinalProject.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="row">
            <div class="col-md-4">
                <h2>Login In</h2>
                <asp:Label ID="status" runat="server"></asp:Label>
                <div class="form-group">
                    <label for="username">Username</label>
                    <asp:TextBox ID="username" class="form-control" placeholder="Username" runat="server" />
                </div>
                <div class="form-group">
                    <label for="password">Password</label>
                    <asp:TextBox ID="password" TextMode="password" class="form-control" placeholder="Password" runat="server" />
                </div>
                <asp:Button ID="ButtonLogin" runat="server" Text="Submit" OnClick="ButtonLogin_Click" />
            </div>
        </div>
    </div>

</asp:Content>
