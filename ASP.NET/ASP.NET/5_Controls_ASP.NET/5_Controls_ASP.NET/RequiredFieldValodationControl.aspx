<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequiredFieldValodationControl.aspx.cs" Inherits="_5_Controls_ASP.NET.RequiredFieldValodationControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                    <table>
                        <tr>
                            <td>
                                <b>Name</b>
                            </td>
                            <td>
                                :<asp:TextBox ID="txtName" runat="server" Width="150px">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" 
                                ErrorMessage="Name is required" ForeColor="Red"
                                ControlToValidate="txtName" Display="Dynamic" >
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Gender</b>
                            </td>
                            <td>
                                :<asp:DropDownList ID="ddlGender" runat="server" Width="150px">
                                    <asp:ListItem Text="Select Gender" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" 
                                ErrorMessage="Gender is required" ForeColor="Red" InitialValue="-1"
                                ControlToValidate="ddlGender" Display="Dynamic" >
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSave" runat="server" Text="Save" Width="100px" 
                                    onclick="btnSave_Click"/>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblStatus" runat="server" Font-Bold="true">
                                </asp:Label>
                            </td>
                        </tr>
                </table>
        </div>
    </form>
</body>
</html>
