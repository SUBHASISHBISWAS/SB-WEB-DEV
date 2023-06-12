<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ButtonControls.aspx.cs" Inherits="_5_Controls_ASP.NET.ButtonControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" 
                OnClientClick="return confirm('Are you sure you want to delete this record?')" 
                CommandName="Button1" OnCommand="Button1_Command"/>

            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
            <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" />
        </div>
    </form>
</body>
</html>
