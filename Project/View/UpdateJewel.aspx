<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateJewel.aspx.cs" Inherits="Project.View.UpdateJewel" %>
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
            <h2>Update Jewel</h2>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" />
            <table>
                <tr>
                    <td>Name:</td>
                    <td><asp:TextBox ID="txtName" runat="server" MaxLength="25" /></td>
                </tr>
                <tr>
                    <td>Category:</td>
                    <td><asp:DropDownList ID="ddlCategory" runat="server" /></td>
                </tr>
                <tr>
                    <td>Brand:</td>
                    <td><asp:DropDownList ID="ddlBrand" runat="server" /></td>
                </tr>
                <tr>
                    <td>Price:</td>
                    <td><asp:TextBox ID="txtPrice" runat="server" /></td>
                </tr>
                <tr>
                    <td>Release Year:</td>
                    <td><asp:TextBox ID="txtYear" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
