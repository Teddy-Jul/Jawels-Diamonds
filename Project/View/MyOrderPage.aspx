<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyOrderPage.aspx.cs" Inherits="Project.View.MyOrderPage" %>
<%@ Register Src="~/View/Header.ascx" TagPrefix="uc" TagName="Header" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:Header runat="server" ID="Header1" />
        <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" OnRowCommand="gvOrders_RowCommand" OnRowDataBound="gvOrders_RowDataBound">
            <Columns>
                <asp:BoundField DataField="TransactionId" HeaderText="Transaction ID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="PaymentMethod" HeaderText="Payment Method" />
                <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button runat="server" CommandName="ViewDetails" CommandArgument='<%# Eval("TransactionId") %>' Text="View Details" />
                        <asp:Button runat="server" ID="btnConfirm" CommandName="ConfirmPackage" CommandArgument='<%# Eval("TransactionId") %>' Text="Confirm Package" Visible="false" />
                        <asp:Button runat="server" ID="btnReject" CommandName="RejectPackage" CommandArgument='<%# Eval("TransactionId") %>' Text="Reject Package" Visible="false" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
</form>
</body>
</html>
