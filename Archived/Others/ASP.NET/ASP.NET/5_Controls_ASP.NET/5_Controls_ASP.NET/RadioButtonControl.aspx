<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadioButtonControl.aspx.cs" Inherits="_5_Controls_ASP.NET.RadioButtonControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset style="width:300px">
                <legend><b>Gendef</b></legend>
                <asp:RadioButton ID="MaleRadioButton" Text="Male" runat="server" 
                    AutoPostBack="True" 
                    OnCheckedChanged="MaleRadioButton_CheckedChanged" GroupName="Geneder Group"/>

                <asp:RadioButton ID="FemaleRadioButton" Text="Female" runat="server" GroupName="Geneder Group"/>
                <asp:RadioButton ID="UnknownRadioButton" Text="Unknown" runat="server" GroupName="Geneder Group"/>
            </fieldset>

        <br /><br />

        <asp:Button ID="Buttonl" runat="server" Text="Button" onclick="Buttonl_Click" />

        </div>
    </form>
</body>
</html>
