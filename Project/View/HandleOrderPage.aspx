<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HandleOrderPage.aspx.cs" Inherits="Project.View.HandleOrderPage" %>
<%@ Register Src="~/View/Header.ascx" TagPrefix="uc" TagName="Header" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title>Handle Orders</title></head>
<body>
    <form id="form1" runat="server">
        <uc:Header runat="server" ID="Header1" />
        <h2>Handle Orders</h2>
        <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" OnRowCommand="gvOrders_RowCommand">
            <Columns>
                <asp:BoundField DataField="TransactionId" HeaderText="Transaction ID" />
                <asp:BoundField DataField="UserId" HeaderText="User ID" />
                <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
                <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="btnConfirmPayment" runat="server"
                        Text="Confirm Payment"
                        CommandName="ConfirmPayment"
                        CommandArgument='<%# Eval("TransactionId") %>'
                        Visible='<%# Eval("TransactionStatus").ToString() == "Payment Pending" %>' />
                    <asp:Button ID="btnShipPackage" runat="server"
                        Text="Ship Package"
                        CommandName="ShipPackage"
                        CommandArgument='<%# Eval("TransactionId") %>'
                        Visible='<%# Eval("TransactionStatus").ToString() == "Shipment Pending" %>' />
                    <asp:Label ID="lblWaiting" runat="server"
                        Text="Waiting for user confirmation..."
                        Visible='<%# Eval("TransactionStatus").ToString() == "Arrived" %>' />
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" />
    </form>
</body>
</html>
