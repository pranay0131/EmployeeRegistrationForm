<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="RetirementCalculation.LoginPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 40%;
            border: 5px solid #FFFFFF;
        }
        .auto-style2 {
            font-weight: bold;
            color: #CC3300;
        }
        .auto-style3 {
            color: #CC3300;
        }
        .auto-style4 {
            color: #0066FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <center>
                    <h2 class="auto-style4">Login Page</h2>
                    <table cellpadding="5" cellspacing="5" class="auto-style1">
                        <tr>
                            <td><strong>User Role :</strong></td>
                            <td>
                                <asp:TextBox ID="TxtRole" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td><strong>User Name :</strong></td>
                            <td>
                                <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td><strong>Password :</strong></td>
                            <td>
                                <asp:TextBox ID="TxtPwd" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td><strong>
                                <asp:Button ID="BtnLogin" runat="server" CssClass="auto-style2" Text="Login" OnClick="BtnLogin_Click" />
                                &nbsp;
                                <asp:Button ID="BtnReset" runat="server" CssClass="auto-style2" Text="Reset" OnClick="BtnReset_Click" />
                                </strong></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="LblMsg" runat="server" CssClass="auto-style3"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
