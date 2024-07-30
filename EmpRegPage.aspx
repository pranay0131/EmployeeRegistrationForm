<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpRegPage.aspx.cs" Inherits="RetirementCalculation.EmpRegPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #CC3300;
        }
        .auto-style2 {
            color: #0066FF;
        }
        .auto-style3 {
            width: 40%;
            border: 5px solid #FFFFFF;
        }
        .auto-style4 {
            font-weight: bold;
            color: #CC3300;
        }
        .auto-style5 {
            color: #CC0000;
        }
        .auto-style6 {
            color: #999966;
        }
        .auto-style7 {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <center>
                    <h2 class="auto-style2"><span class="auto-style7">Registration</span> <span class="auto-style7">Page</span></h2>
                    <p>
                        Welcome : <strong>
                        <asp:Label ID="lblUser" runat="server" CssClass="auto-style6"></asp:Label>
                        </strong>
                    </p>
                    <p>
                        <asp:HyperLink ID="hpLogOut" runat="server" NavigateUrl="~/LoginPage.aspx" CssClass="auto-style5" OnDataBinding="hpLogOut_DataBinding">LogOut</asp:HyperLink>
                    </p>
                    <table cellpadding="5" cellspacing="5" class="auto-style3">
                        <tr>
                            <td><strong>Employee Id :</strong></td>
                            <td>
                                <asp:TextBox ID="txtEmpId" runat="server"></asp:TextBox>
                            </td>
                            <td><strong>
                                <asp:Button ID="btnGetId" runat="server" CssClass="auto-style4" Text="Get Id" OnClick="btnGetId_Click" />
                                </strong></td>
                        </tr>
                        <tr>
                            <td><strong>Name :</strong></td>
                            <td colspan="2">
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td><strong>Gender :</strong></td>
                            <td colspan="2">
                                <strong>
                                <asp:RadioButtonList ID="rblGender" runat="server" CssClass="auto-style1" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="M">Male</asp:ListItem>
                                    <asp:ListItem Value="F">Female</asp:ListItem>
                                    <asp:ListItem Value="O">Other&#39;s</asp:ListItem>
                                </asp:RadioButtonList>
                                </strong>
                            </td>
                        </tr>
                        <tr>
                            <td><strong>Date of Birth :</strong></td>
                            <td colspan="2">
                                <asp:TextBox ID="txtDOB" runat="server" AutoPostBack="True" OnTextChanged="txtDOB_TextChanged"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton1" ImageUrl="~/CalendarImage/Calender.gif" runat="server" />
                                <asp:CalendarExtender TargetControlID="txtDOB" PopupButtonID="ImageButton1" Format="dd-MM-yyyy" runat="server"></asp:CalendarExtender>
                                <br />
                                <asp:Label ID="lblAge" runat="server" CssClass="auto-style1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td><strong>Date of Joining :</strong></td>
                            <td colspan="2">
                                <asp:TextBox ID="txtDOJ" runat="server" ReadOnly="True"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton2" ImageUrl="~/CalendarImage/Calender.gif" runat="server"></asp:ImageButton>
                                <asp:CalendarExtender TargetControlID="txtDOJ" PopupButtonID="ImageButton2" Format="dd-MM-yyyy" runat="server"></asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td><strong>Date of Retirement :</strong></td>
                            <td colspan="2">
                                <asp:TextBox ID="txtDOR" runat="server" ReadOnly="True"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton3" ImageUrl="~/CalendarImage/Calender.gif" runat="server"></asp:ImageButton>
                                <asp:CalendarExtender Format="dd-MM-yyyy" TargetControlID="txtDOR" PopupButtonID="ImageButton3" runat="server"></asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td><strong>Department :</strong></td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td><strong>Designation :</strong></td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlDesig" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td><strong>Basic Salary :</strong></td>
                            <td colspan="2">
                                <asp:TextBox ID="txtBasicSalary" runat="server" AutoPostBack="True" OnTextChanged="txtBasicSalary_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Ta :</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtTa" runat="server" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Da :</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtDa" runat="server" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Hra :</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtHra" runat="server" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Gross Salary :</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtGross" runat="server" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td><strong>Upload Doc. :</strong></td>
                            <td colspan="2">
                                <asp:FileUpload ID="fuDoc" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="2"><strong>
                                <asp:Button ID="btnRegister" runat="server" CssClass="auto-style4" Text="Register" OnClick="btnRegister_Click" />
                                <asp:Button ID="btnReset" runat="server" CssClass="auto-style4" Text="Reset" OnClick="btnReset_Click" />
                                </strong></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblMsg" runat="server" CssClass="auto-style1"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
