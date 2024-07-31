<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="RetirementCalculation.AdminPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #669999;
        }
        .auto-style2 {
            color: #0066FF;
            text-decoration: underline;
        }
        .auto-style3 {
            width: 40%;
            border: 5px solid #FFFFFF;
        }
        .auto-style5 {
            color: #CC3300;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <center>
                    <h2 class="auto-style2">Admin Page</h2>
                    <p>
                        Welcome : <strong>
                        <asp:Label ID="lblUser" runat="server" CssClass="auto-style1"></asp:Label>
                        </strong>
                    </p>
                    <p>
                        <asp:HyperLink ID="hpLogOut" runat="server" OnDataBinding="hpLogOut_DataBinding">LogOut</asp:HyperLink>
                    </p>
                    <table cellpadding="5" cellspacing="5" class="auto-style3">
                        <tr>
                            <td>
                                <asp:GridView ID="gvEmployee" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="gvEmployee_PageIndexChanging" OnRowDeleting="gvEmployee_RowDeleting">
                                    <AlternatingRowStyle BackColor="White" />
                                    <FooterStyle BackColor="#CCCC99" />
                                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#F7F7DE" />
                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                    <SortedAscendingHeaderStyle BackColor="#848384" />
                                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                    <SortedDescendingHeaderStyle BackColor="#575357" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMsg" runat="server" CssClass="auto-style5"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
