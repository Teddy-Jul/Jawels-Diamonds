<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Project.View.RegisterPage" %>
<%@ Register Src="~/View/Header.ascx" TagPrefix="uc" TagName="Header" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <uc:Header runat="server" ID="Header1" />

        <div>
            <h2>Register</h2>
            <br />

            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />

            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:"></asp:Label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />

            <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
            <asp:RadioButton ID="rbMale" runat="server" GroupName="Gender" Text="Male" />
            <asp:RadioButton ID="rbFemale" runat="server" GroupName="Gender" Text="Female" />
            <br />

            <asp:Label ID="lblDOB" runat="server" Text="Date of Birth:"></asp:Label>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" 
                        OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" CausesValidation="false"></asp:DropDownList>
                    <asp:Calendar ID="calDOB" runat="server" OnVisibleMonthChanged="calDOB_VisibleMonthChanged"></asp:Calendar>
                </ContentTemplate>
            </asp:UpdatePanel>
            


            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            <asp:Label ID="Validation" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
