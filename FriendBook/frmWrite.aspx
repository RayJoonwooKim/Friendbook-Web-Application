<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmWrite.aspx.cs" Inherits="FriendBook.frmWrite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Title : "></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" Width="361px"></asp:TextBox>
        </div>
        <asp:Label ID="Label2" runat="server" Text="To : "></asp:Label>
        <asp:TextBox ID="txtTo" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Message"></asp:Label>
        <br />
        <asp:TextBox ID="txtMessage" runat="server" Height="261px" TextMode="MultiLine" Width="408px"></asp:TextBox>
        <br />
        <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" Width="130px" />
    </form>
</body>
</html>
