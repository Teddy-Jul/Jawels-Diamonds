<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="Project.View.TransactionDetailPage" %>
<%@ Register Src="~/View/Header.ascx" TagPrefix="uc" TagName="Header" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <uc:Header runat="server" ID="Header1" />
    <asp:Label ID="lblError" runat="server" ForeColor="Red" />
    <asp:Label ID="lblTransactionId" runat="server" Font-Bold="true" />
    <br />
    <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        </Columns>
    </asp:GridView>
</form>
</body>
</html>
