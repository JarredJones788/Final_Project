<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FinalProject._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Button ID="ButtonUpdateInfo" runat="server" Text="Update Account" OnClick="ButtonUpdateInfo_Click"  />
    <br /><br />
    <asp:fileupload id="FileUpload" runat="server" />
    <br /><br />
    <asp:Image runat="server" ID="profilePic" />

    <asp:button id="ButtonUpload" runat="server" onclick="ButtonUpload_Click" text="Upload Image" />
    <br /><br />
     <asp:button id="ButtonRegister" runat="server" onclick="ButtonRegister_Click" text="Register" />

</asp:Content>
