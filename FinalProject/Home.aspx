<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FinalProject._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="modal fade" id="addProductsModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="addProductUpdate" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">
                                    <asp:Label ID="Label1" runat="server" Text="">Add Product</asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label for="company">Name</label>
                                    <asp:TextBox ID="addProductName" class="form-control" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="company">Category</label>
                                    <asp:TextBox ID="addProductCategory" class="form-control" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="company">Description</label>
                                    <asp:TextBox ID="addProductDescription" class="form-control" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="company">Price</label>
                                    <asp:TextBox ID="addProductPrice" class="form-control" runat="server" />
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="Button1" class="btn btn-primary" runat="server" OnClick="ButtonAddProduct_Click" Text="Create Product" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="modal fade" id="respondModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="respondUpdate" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <asp:TextBox ID="respondId" class="form-control" runat="server" Visible="false" />
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">
                                    <asp:Label ID="Label2" runat="server" Text="">Respond to enquiry</asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label for="company">Subject</label>
                                    <asp:TextBox ID="respondSubject" class="form-control" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="company">Question</label>
                                    <asp:TextBox ID="respondQuestion" class="form-control" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="company">Response</label>
                                    <asp:TextBox ID="responseText" class="form-control" runat="server" />
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="Button2" class="btn btn-primary" runat="server" OnClick="ButtonRespondEnquiry_Click" Text="Respond" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="modal fade" id="myProductsModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="productModalUpdate" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <asp:TextBox ID="editProductId" class="form-control" runat="server" Visible="false" />
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">
                                    <asp:Label ID="lblModalTitle" runat="server" Text="">Edit Product</asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label for="company">Name</label>
                                    <asp:TextBox ID="editProductName" class="form-control" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="company">Category</label>
                                    <asp:TextBox ID="editProductCategory" class="form-control" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="company">Description</label>
                                    <asp:TextBox ID="editProductDescription" class="form-control" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="company">Price</label>
                                    <asp:TextBox ID="editProductPrice" class="form-control" runat="server" />
                                </div>

                            </div>
                            <div class="modal-footer">
                                <asp:button id="editProductBtn" class="btn btn-primary" runat="server" onclick="ButtonEditProduct_Click" text="Save Product" />
                                <asp:button id="deleteProductBtn" class="btn btn-danger" runat="server" onclick="ButtonDeleteProduct_Click" text="Delete Product" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="modal fade" id="enquireModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="enquireUpdate" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                             <asp:TextBox ID="enquireSellerId" class="form-control" runat="server" Visible="false" />
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">
                                    <asp:Label ID="Label3" runat="server" Text="">Ask the seller</asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label for="company">Subject</label>
                                    <asp:TextBox ID="addSubject" class="form-control" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="company">Question</label>
                                    <asp:TextBox ID="addQuestion" class="form-control" runat="server" />
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="Button3" class="btn btn-primary" runat="server" OnClick="ButtonCreateEnquiry_Click" Text="Send Question" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="row">
            <asp:Panel ID="sellerPanel" runat="server" Visible="false">
                <div class="col-sm-12">
                    <h3 class="text-center">Your Enquiries</h3>
                    <asp:Table ID="yourEnquiries" class="table" runat="server" Width="100%">
                        <asp:TableRow>
                            <asp:TableCell>Subject</asp:TableCell>
                            <asp:TableCell>Question</asp:TableCell>
                            <asp:TableCell>Response</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <div class="col-sm-12">
                    <h3 class="text-center">Your Products</h3>
                    <asp:Button ID="addNewProduct" class="btn btn-primary float-right" runat="server" OnClick="AddProductModal_Click" Text="New Product" />
                    <br /><br />
                    <asp:Table ID="yourProducts" class="table" runat="server" Width="100%">
                        <asp:TableRow>
                            <asp:TableCell>Name</asp:TableCell>
                            <asp:TableCell>Category</asp:TableCell>
                            <asp:TableCell>Price</asp:TableCell>
                            <asp:TableCell>Description</asp:TableCell>
                            <asp:TableCell>Action</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </asp:Panel>
             <asp:Panel ID="buyerPanel" runat="server" Visible="false">
                 <div class="col-sm-12">
                     <h3 class="text-center">Your Enquiries</h3>
                     <asp:Table ID="buyerEnquiries" class="table" runat="server" Width="100%">
                         <asp:TableRow>
                             <asp:TableCell>Subject</asp:TableCell>
                             <asp:TableCell>Question</asp:TableCell>
                             <asp:TableCell>Response</asp:TableCell>
                         </asp:TableRow>
                     </asp:Table>
                 </div>
                 <div class="col-sm-12">
                     <h3 class="text-center">Products for sale</h3>
                     <div class="row">
                         <div class="col-sm-3">
                             <asp:TextBox ID="productSearchBar" class="form-control" placeholder="Search.." runat="server"></asp:TextBox>
                         </div>
                         <div class="col-sm-2">
                             <asp:DropDownList ID="searchFilter" Width="100%" runat="server">
                                 <asp:ListItem Selected="true" Value="product">Product Name</asp:ListItem>
                                 <asp:ListItem Value="company">Company</asp:ListItem>
                                 <asp:ListItem Value="seller">Seller's Name</asp:ListItem>
                                 <asp:ListItem Value="category">Category</asp:ListItem>
                             </asp:DropDownList>
                         </div>
                         <div class="col-sm-2">
                             <asp:Button ID="searchBtn" class="btn btn-primary" runat="server" Text="Search" AutoPostBack="false" />
                         </div>

                     </div>
                     <br />
                     <asp:Table ID="productsForSale" class="table" runat="server" Width="100%">
                         <asp:TableRow>
                             <asp:TableCell>Name</asp:TableCell>
                             <asp:TableCell>Category</asp:TableCell>
                             <asp:TableCell>Price</asp:TableCell>
                             <asp:TableCell>Description</asp:TableCell>
                             <asp:TableCell>Actions</asp:TableCell>
                         </asp:TableRow>
                     </asp:Table>
                 </div>
             </asp:Panel>
        </div>


    </div>


</asp:Content>
