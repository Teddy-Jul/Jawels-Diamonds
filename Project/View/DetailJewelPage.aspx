<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailJewelPage.aspx.cs" Inherits="Project.View.DetailJewelPage" %>
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
            <asp:Panel ID="pnlDetails" runat="server" Visible="false">
            <h2>Jewel Details</h2>
            <table>
                <tr><td>Name:</td><td><asp:Label ID="lblName" runat="server" /></td></tr>
                <tr><td>Category:</td><td><asp:Label ID="lblCategory" runat="server" /></td></tr>
                <tr><td>Brand:</td><td><asp:Label ID="lblBrand" runat="server" /></td></tr>
                <tr><td>Country of Origin:</td><td><asp:Label ID="lblCountry" runat="server" /></td></tr>
                <tr><td>Class:</td><td><asp:Label ID="lblClass" runat="server" /></td></tr>
                <tr><td>Price:</td><td><asp:Label ID="lblPrice" runat="server" /></td></tr>
                <tr><td>Release Year:</td><td><asp:Label ID="lblYear" runat="server" /></td></tr>
            </table>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" />
            <br />
            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" OnClick="btnAddToCart_Click" Visible="false" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" Visible="false" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
