<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="Project.View.CartPage" %>
<%@ Register Src="~/View/Header.ascx" TagPrefix="uc" TagName="Header" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:Header runat="server" ID="Header1" />
        <div>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" />
            <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" OnRowCommand="gvCart_RowCommand" DataKeyNames="JewelId">

                <Columns>
                    <asp:BoundField DataField="JewelId" HeaderText="Jewel ID" />
                    <asp:BoundField DataField="BrandName" HeaderText="Brand Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="${0:N0}" />
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>' Width="50px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="${0:N0}" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="UpdateItem" CommandArgument='<%# Eval("JewelId") %>' />
                            <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="RemoveItem" CommandArgument='<%# Eval("JewelId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <br />
            <asp:Label ID="lblTotal" runat="server" Font-Bold="true" />

            <br /><br />
            
            <asp:DropDownList ID="ddlPayment" runat="server">
                <asp:ListItem Text="-- Select Payment Method --" Value="" />
                <asp:ListItem Text="Credit Card" Value="Credit Card" />
                <asp:ListItem Text="Bank Transfer" Value="Bank Transfer" />
                <asp:ListItem Text="Cash" Value="Cash" />
            </asp:DropDownList>
            <br /><br />
            <asp:Button ID="btnClearCart" runat="server" Text="Clear Cart" OnClick="btnClearCart_Click" />
            <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />
        </div>
    </form>
</body>
</html>
