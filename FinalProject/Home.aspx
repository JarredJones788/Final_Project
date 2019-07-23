<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FinalProject._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="row">
            <asp:Label font-size="25px" ID="AccountStatus" runat="server"></asp:Label>
        </div>
        <div class="col-md-4">
            <h2>All</h2>
            <br />
            <asp:button id="ButtonLogout" runat="server" onclick="ButtonLogout_Click" text="Logout" />
            <br />
            <br />
             <asp:Button ID="ButtonUpdateInfo" runat="server" Text="Update Account" OnClick="ButtonUpdateInfo_Click"  />
            <br />
            <asp:fileupload id="FileUpload" runat="server" />
            <br />
            <asp:Image runat="server" ID="profilePic" />
            <br />
            <asp:button id="ButtonUpload" runat="server" onclick="ButtonUpload_Click" text="Upload Image" />
            <br />
            <br />
            <asp:button id="ButtonRegister" runat="server" onclick="ButtonRegister_Click" text="Register" />
            <br />
            <br />
            <asp:button id="ButtonGetMyProducts" runat="server" onclick="ButtonGetMyProducts_Click" text="Get My Products" />
            <br />
            <br /><br />
            <asp:button id="ButtonGetEnquiries" runat="server" onclick="ButtonGetEnquiries_Click" text="Get All Enquiries" />
        </div>
        <div class="col-md-4">
            <h2>Seller</h2>
            <br />
            <asp:button id="ButtonAddProduct" runat="server" onclick="ButtonAddProduct_Click" text="Add Product" />
            <br />
            <br />
            <asp:button id="ButtonDeleteProduct" runat="server" onclick="ButtonDeleteProduct_Click" text="Delete Product" />
            <br />
           <br />
            <asp:button id="ButtonEditProduct" runat="server" onclick="ButtonEditProduct_Click" text="Edit Product" />
            <br />
            <asp:button id="ButtonRespondEnquiry" runat="server" onclick="ButtonRespondEnquiry_Click" text="Respond to Enquiry" />
            <br />

            
        </div>
        <div class="col-md-4">
            <h2>Buyer</h2>
            <br />
            <asp:button id="ForSaleProducts" runat="server" onclick="ButtonForSaleProducts_Click" text="Get For Sale Products" />
            <br /><br />
            <asp:button id="ButtonBuyProduct" runat="server" onclick="ButtonBuyProduct_Click" text="Buy Product" />
             <br /><br />
            <asp:button id="ButtonCreateEnquiry" runat="server" onclick="ButtonCreateEnquiry_Click" text="Create Enquiry" />
         </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-6">
          <h5>Enquiry Test</h5>
          <asp:Table ID="myTable" class="table" runat="server" Width="100%"> 
            <asp:TableRow>
                <asp:TableCell>Subject</asp:TableCell>
                <asp:TableCell>Question</asp:TableCell>
                <asp:TableCell>Response</asp:TableCell>
            </asp:TableRow>
         </asp:Table>  
        </div>
        <div class="col-sm-6">
            <h5>Products Test</h5>
            <asp:Table ID="myTableProducts" class="table" runat="server" Width="100%"> 
              <asp:TableRow>
                <asp:TableCell>Name</asp:TableCell>
                <asp:TableCell>Category</asp:TableCell>
                <asp:TableCell>Price</asp:TableCell>
              </asp:TableRow>
            </asp:Table>  
        </div>

    </div>


</asp:Content>
