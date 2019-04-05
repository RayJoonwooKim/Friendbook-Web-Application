<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEditProfile.aspx.cs" Inherits="FriendBook.frmEditProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            margin-left: 233px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align: center">Edit Your Profile</h1>
        </div>
        <table class="auto-style1" runat="server">
            <tr>
                <td><asp:Label runat="server">Username : </asp:Label></td>
                <td><asp:TextBox runat="server" ID="txtUsername" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Password : </asp:Label></td>
                <td><asp:TextBox runat="server" ID="txtPassword"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Password (Re) : </asp:Label></td>
                <td><asp:TextBox runat="server" ID="txtPasswordRe"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">First Name : </asp:Label></td>
                <td><asp:TextBox runat="server" ID="txtFirstName" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Last Name : </asp:Label></td>
                <td><asp:TextBox runat="server" ID="txtLastName" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Gender : </asp:Label></td>
                <td><asp:TextBox runat="server" ID="txtGender" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Race : </asp:Label></td>
                <td><asp:TextBox runat="server" ID="txtRace" ReadOnly="True"></asp:TextBox></td>
            </tr>
             <tr>
                <td><asp:Label runat="server">Age : </asp:Label></td>
                <td><asp:TextBox runat="server" ID="txtAge"></asp:TextBox></td>
            </tr>
             <tr>
                <td><asp:Label runat="server">City : </asp:Label></td>
                <td><asp:DropDownList ID="cboCity" runat="server"></asp:DropDownList></td>
            </tr>
             <tr>
                <td><asp:Label runat="server">Language : </asp:Label></td>
                <td>
                    <asp:TextBox ID="txtLanguage" runat="server" ReadOnly="True"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </td>
                
            </tr>
        </table>
        <table class="auto-style1" runat="server">
            <tr>
                <td><asp:Button runat="server" ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click"/></td>
                <td><asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click"/></td>
            </tr>
        </table>
        
        <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
        
    </form>
</body>
</html>
