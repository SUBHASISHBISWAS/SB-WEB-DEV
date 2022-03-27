<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HyperLinkControl.aspx.cs" Inherits="_5_Controls_ASP.NET.HyperLinkControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" 
                NavigateUrl="~/RadioButtonControl.aspx"
                Text="Click Here"
                Target="_blank"></asp:HyperLink>
        </div>
    </form>
</body>
</html>
