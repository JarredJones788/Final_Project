<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ChangePassword.aspx.cs" Inherits="FinalProject.ChangePassword" %>
<asp:Content ID="bodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Change Password</h3>
    <div class="form-group">
        <asp:Label ID="lblPassword" Text="Password: " AssociatedControlID="txtPassword" runat="server">
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
        </asp:Label>
        <asp:RequiredFieldValidator ID="rfvPassword" ControlToValidate="txtPassword" ErrorMessage="* Required Field" runat="server" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <asp:Label ID="lblConfirmPassword" Text="Confirm Password: " AssociatedControlID="txtConfirmPassword" runat="server">
            <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
        </asp:Label>
        <asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Password dont match" ControlToValidate="txtPassword" ControlToCompare="txtConfirmPassword" ForeColor="Red" Text="Password dont match!" Operator="Equal" Type="String"></asp:CompareValidator>
    </div>
    <asp:Button class="btn btn-success btn-med" ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
    <asp:Label ID="lblSubmit" runat="server"></asp:Label>
</asp:Content>
