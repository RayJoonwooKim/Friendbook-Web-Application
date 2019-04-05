<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmRead.aspx.cs" Inherits="FriendBook.frmRead" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 300px;
            margin-left: 292px;
        }
        td{
            height:50px;
        }
        .auto-style2 {
            width: 115px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col">
                    <h1>Read Message</h1>
                </div>
            </div>
            <div class="row">

                <table class="auto-style1">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
                        </td>
                        <td class="auto-style2">
                            <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="From"></asp:Label>
                        </td>
                        <td class="auto-style2">
                            <asp:Label ID="lblFrom" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Date"></asp:Label>
                        </td>
                        <td class="auto-style2">
                            <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Message"></asp:Label>
                        </td>
                        <td class="auto-style2">
                            <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>

            </div>
            <asp:Label runat="server" ID="lblGoBack" Text="<a href='frmInbox.aspx'>Go Back To Inbox</a>"></asp:Label>
        </div>
    </form>
</body>
</html>
