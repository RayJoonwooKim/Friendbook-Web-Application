<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSignupVerify.aspx.cs" Inherits="FriendBook.frmSignupVerify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" ID="lblMsg" Text="Congratulations! You are now a member!  "></asp:Label>
            <asp:Label runat="server" ID="lblVerify" Text="<a href='frmLogin.aspx'>Please click here to sign in!</a>"></asp:Label>
        </div>
    </form>
</body>
</html>
