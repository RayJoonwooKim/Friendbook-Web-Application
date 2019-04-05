<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInbox.aspx.cs" Inherits="FriendBook.frmInbox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 300px;
        }
        .auto-style3 {
            margin-left: 17px;
        }
        .auto-style4 {
            width: 180px;
        }
        .auto-style5 {
            width: 228px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col">
                    <h1>Inbox</h1>
                </div>
            </div>
            <div class="row">
            <div class="col">
                <asp:Literal ID="litInbox" runat="server"></asp:Literal>
            </div>
                <div class="col">
                    <asp:Panel runat="server" GroupingText="Delete Multiple Messages" ID="panDelete">
                        <asp:CheckBoxList ID="chkDeleteMsg" runat="server"></asp:CheckBoxList>
                        <br />
                        <asp:Button runat="server" ID="btnDelete" Text="Delete" OnClick="btnDelete_Click"/>
                    </asp:Panel>
                </div>
        </div>
            
                </div>
        <asp:Label runat="server" Text="<a href='frmUI.aspx'>Go Back to Main Menu</a>"></asp:Label>
        
    </form>
</body>
</html>
