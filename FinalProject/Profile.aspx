<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.cs" Inherits="FinalProject.Profile" %>

<asp:Content ID="bodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Profile Data</h2>
    <hr />
    <div class="form-group">
        <asp:Image ID="imgProfilePic" Height="100" Width="100" runat="server"/>
        <asp:FileUpload ID="uplProfilePic" runat="server" Visible="false"/>
    </div>

    <div class="form-group">
        <asp:Label ID="lblUsername" Text="Username: " AssociatedControlID="txtUsername" runat="server">
            <asp:TextBox ID="txtUsername" runat="server" ReadOnly="true"></asp:TextBox>
        </asp:Label>
        <asp:RequiredFieldValidator ID="rfvUsername" ControlToValidate="txtUsername" ErrorMessage="* Required Field" runat="server" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <asp:Label ID="lblName" Text="Name: " AssociatedControlID="txtName" runat="server">
            <asp:TextBox ID="txtName" runat="server" ReadOnly="true"></asp:TextBox>
        </asp:Label>
        <asp:RequiredFieldValidator ID="rfvName" ControlToValidate="txtName" ErrorMessage="* Required Field" runat="server" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <asp:Label ID="lblPhone" Text="Phone: " AssociatedControlID="txtPhone" runat="server">
            <asp:TextBox ID="txtPhone" runat="server" ReadOnly="true"></asp:TextBox>
        </asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPhone" ErrorMessage="* Required Field" runat="server" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <asp:Label ID="lblEmail" Text="Email: " AssociatedControlID="txtEmail" runat="server">
            <asp:TextBox ID="txtEmail" runat="server" ReadOnly="true"></asp:TextBox>
        </asp:Label>
        <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" ErrorMessage="* Required Field" runat="server" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revEmail" ControlToValidate="txtEmail" ErrorMessage="Not a valid email." Display="dynamic" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
    </div>

    <div class="form-group">
        <asp:Label ID="lblCompany" Text="Company: " AssociatedControlID="txtCompany" runat="server">
            <asp:TextBox ID="txtCompany" runat="server" ReadOnly="true"></asp:TextBox>
        </asp:Label>
     
    </div>

    <asp:Button class="btn btn-primary btn-med" ID="btnEdit" runat="server" Text="Edit Info" OnClick="btnEdit_Click" CausesValidation="false" />
    <asp:Button class="btn btn-success btn-med" ID="btnSubmit" runat="server" Text="Save Info" Visible="false" OnClick="btnSubmit_Click"/>
    <asp:Button class="btn btn-secondary btn-med" ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" CausesValidation="false" />
    <asp:Button class="btn btn-danger btn-med" ID="btnDelete" runat="server" Text="Delete User" OnClick="btnDelete_Click" />
    <br /><br />
    <asp:button id="ButtonLogout" class="btn btn-danger" runat="server" onclick="ButtonLogout_Click" text="Logout" />
    
    <div ID="divPurchaseHistory" runat="server">
        <hr />
        <h3>Purchase History</h3>
        <asp:Table ID="tblPurchaseHistory" class="table" runat="server" Width="100%"> 
              <asp:TableRow>
                <asp:TableCell>Name</asp:TableCell>
                <asp:TableCell>Description</asp:TableCell>
                <asp:TableCell>Price</asp:TableCell>
                <asp:TableCell>Category</asp:TableCell>
              </asp:TableRow>
            </asp:Table>  
    </div>
</asp:Content>

