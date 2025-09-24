<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="Project.View.ProfilePage" %>
<%@ Register Src="~/View/Header.ascx" TagPrefix="uc" TagName="Header" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:Header runat="server" ID="Header1" />
        <h2>Profile Information</h2>
         <asp:Label ID="lblError" runat="server" />
        <table>
            <tr><td>Username:</td><td><asp:Label ID="lblUsername" runat="server" /></td></tr>
            <tr><td>Email:</td><td><asp:Label ID="lblEmail" runat="server" /></td></tr>
            <tr><td>Gender:</td><td><asp:Label ID="lblGender" runat="server" /></td></tr>
            <tr><td>Date of Birth:</td><td><asp:Label ID="lblDOB" runat="server" /></td></tr>
        </table>
        <h3>Change Password</h3>
        <table>
            <tr>
                <td>Old Password:</td>
                <td><asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" /></td>
            </tr>
            <tr>
                <td>New Password:</td>
                <td><asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" /></td>
            </tr>
            <tr>
                <td>Confirm Password:</td>
                <td><asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblStatus" runat="server" />
    </form>
</body>
</html>
