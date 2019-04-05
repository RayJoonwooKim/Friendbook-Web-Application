<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDelete.aspx.cs" Inherits="FriendBook.frmDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" ID="lblMsg" Text="Message(s) deleted!"></asp:Label>
            <asp:Label runat="server" Text="<a href='frmInbox.aspx'>Go Back</a>"></asp:Label>
        </div>
    </form>
</body>
</html>
