<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSignUp.aspx.cs" Inherits="FriendBook.frmSignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <style>
        td{
            height:50px;
        }
    </style>
</head>
<body>
    <h1 style="text-align: center">Sign Up For Friendbook!</h1>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col">
                    <table runat="server">
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Username : "></asp:Label></td>
                <td><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" runat="server" Text="Password : "></asp:Label></td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label3" runat="server" Text="First Name : "></asp:Label></td>
                <td><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label4" runat="server" Text="Last Name : "></asp:Label></td>
                <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label5" runat="server" Text="Gender : "></asp:Label></td>
                <td><asp:RadioButtonList ID="radGroupGender" runat="server">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList></td>
                
            </tr>
            </table>
                </div>
                <div class="col">
                    <table>
            <tr>
                <td><asp:Label ID="lblRace" runat="server" Text="Ethinicity : "></asp:Label></td>
                <td><asp:DropDownList ID="cboRace" runat="server">
        </asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label6" runat="server" Text="Age : "></asp:Label></td>
                <td><asp:TextBox ID="txtAge" runat="server" Width="49px"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label7" runat="server" Text="City : "></asp:Label></td>
                <td><asp:DropDownList ID="cboCity" runat="server">
        </asp:DropDownList></td>
            </tr>
                        </table>
                </div>
                <div class="col">
                     <table runat="server">
            <tr>
                <td>
                    <asp:Panel runat="server" GroupingText="Language">
                    <asp:CheckBoxList ID="chkLang" runat="server">
        </asp:CheckBoxList>
                </asp:Panel>
                </td>
                
                
            </tr>
            </table>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <table runat="server">
                        <tr>
                <td colspan="2"><asp:Label ID="lblMsg" runat="server" Text=""></asp:Label></td>
                
            </tr>
                        </table>
            
                </div>
            </div>
            <asp:Button ID="btnSignup" runat="server" Text="Sign Up!" OnClick="btnSignup_Click" Width="417px" CssClass="btn-primary" />
        </div>
        
        
       
            
        
     
    </form>
</body>
</html>
