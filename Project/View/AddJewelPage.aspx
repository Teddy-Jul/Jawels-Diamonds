<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddJewelPage.aspx.cs" Inherits="Project.View.AddJewelPage" %>
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
    <h2>Add Jewel</h2>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" />
    <table>
        <tr>
            <td>Jewel Name:</td>
            <td>
                <asp:TextBox ID="txtJewelName" runat="server" MaxLength="25" />
            </td>
        </tr>
        <tr>
            <td>Category:</td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Brand:</td>
            <td>
                <asp:DropDownList ID="ddlBrand" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Price ($):</td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Release Year:</td>
            <td>
                <asp:TextBox ID="txtReleaseYear" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnAddJewel" runat="server" Text="Add Jewel" OnClick="btnAddJewel_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" />
            </td>
        </tr>
    </table>
</div>
    </form>
</body>
</html>
