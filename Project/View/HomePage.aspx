<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Project.View.HomePage" %>
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
            <h2>Welcome to the Home Page</h2>
            <p>This is the home page of the application.</p>
           <asp:GridView ID="gvJewels" runat="server" AutoGenerateColumns="False" OnRowCommand="gvJewels_RowCommand">
            <Columns>
                <asp:BoundField DataField="JewelId" HeaderText="Jewel ID" />
                <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" />
                <asp:TemplateField HeaderText="Jewel Price">
                    <ItemTemplate>
                        $<%# Eval("JewelPrice", "{0:N0}") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnDetail" runat="server" Text="View Detail" CommandName="ViewDetail" CommandArgument='<%# Eval("JewelId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
    </form>
</body>
</html>
