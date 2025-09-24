<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Project.View.Header" %>
<asp:Panel ID="pnlNavBar" runat="server">
    <asp:Label ID="lblWelcome" runat="server" Font-Bold="true" />
    <asp:PlaceHolder ID="phNavLinks" runat="server" />
</asp:Panel>
<hr />