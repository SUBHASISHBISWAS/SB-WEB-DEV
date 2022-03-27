<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomValidatorControl.aspx.cs" Inherits="_5_Controls_ASP.NET.CustomValidatorControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        // Client side validation function to check if the number is even. 
        function IsEven(source, args) 
        {
            if (args.Value == "") 
            {
                args.IsValid = false;
            }
            else 
            {
                if (args.Value % 2 == 0) 
                {
                    args.IsValid = true;
                }
                else 
                {
                    args.IsValid = false;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <table>
                <tr>
                    <td>
                        <b>Please enter a positive even number</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEvenNumber" runat="server"></asp:TextBox>
                        
                        <asp:CustomValidator ID="CustomValidatorEvenNumber" runat="server"
                            ForeColor="Red" 
                            ErrorMessage="Custom Validator : Not an even number"
                            OnServerValidate="CustomValidatorEvenNumber_ServerValidate"
                            ControlToValidate="txtEvenNumber"
                            ClientValidationFunction="IsEven"
                            ValidateEmptyText="true">
                        </asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" 
                            onclick="btnSubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblStatus" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
        </table>
        </div>
    </form>
</body>
</html>
