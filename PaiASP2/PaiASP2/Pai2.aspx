<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pai2.aspx.cs" Inherits="PaiASP2.Pai2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server">start</asp:TextBox>
    
        <br />
    
        <asp:TextBox ID="TextBox2" runat="server">end</asp:TextBox>
    
        <br />
    
        <asp:TextBox ID="TextBox3" runat="server">points per thread</asp:TextBox>
    
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Run" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Errors:"></asp:Label>
        <br />
    
    </div>
    </form>
</body>
</html>
