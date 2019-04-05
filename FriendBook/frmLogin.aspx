<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="FriendBook.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.css" rel="stylesheet" />
    
    <title></title>
    <style>
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <h1>Friendbook Login</h1>
        <div class="row">
            <div class="col">
                <img src="Images/social.jpeg"/>
            </div>
            <div class="col">
                <asp:Panel ID="Panel1" runat="server" BackColor="#CCFF99" HorizontalAlign="Center">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Username : "></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server" Width="230px" CssClass="rounded"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password : "></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="230px" CssClass="rounded"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSignin" runat="server" Text="Sign In" Width="293px" OnClick="btnSignin_Click" CssClass="badge-success" />
        <br />
                    <asp:Label ID="lblLoginFail" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblSignin" runat="server" Text="Don't have an account?"></asp:Label>
        <br />
    </asp:Panel>
            </div>
        </div>
        
        
    </form>
   
    
    
    
    
    
    
    
</body>
</html>
