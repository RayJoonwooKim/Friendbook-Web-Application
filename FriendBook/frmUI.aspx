<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmUI.aspx.cs" Inherits="FriendBook.frmUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".test input:checkbox").on('change', function () {
                $(".test input:checkbox").not(this).prop('checked', false);
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid" runat="server">

        
        <h1>
            <asp:Label ID="lblGreet" runat="server" Text="Label"></asp:Label>
        </h1>
        <div class="row">
            <div class="col-1">
                <asp:Label runat="server" ID="lblViewMessage" Text="Inbox"></asp:Label>
            </div>
            <div class="col-1">
                <asp:Label runat="server" ID="lblEditProfile" Text="Profile"></asp:Label>
            </div>
        </div>
        <div class="row">

        </div>
        <div class="row">
            <div class="col">
                <asp:Panel ID="panGender" runat="server" style="margin-bottom: 0px" GroupingText="Search By Gender">
            
                    <br />
                    <asp:RadioButtonList ID="radGender" runat="server">
                    </asp:RadioButtonList>
        </asp:Panel>
            </div>
            <div class="col">
                <asp:Panel ID="panCity" runat="server" style="margin-bottom: 0px" GroupingText="Search By City">
            
                    <br />
                    <asp:DropDownList ID="cboCity" runat="server">
                    </asp:DropDownList>
                    </asp:Panel>   
            </div>
            <div class="col">
                <asp:Panel ID="panAge" runat="server" style="margin-bottom: 0px" GroupingText="Search By Age">
            
                    <br />
                    <table>
                        <tr>
                            <td><asp:Label ID="Label5" runat="server" Text="From"></asp:Label></td>
                            <td><asp:TextBox ID="txtFrom" runat="server" Width="40px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label6" runat="server" Text="To"></asp:Label></td>
                            <td><asp:TextBox ID="txtTo" runat="server" Width="40px"></asp:TextBox></td>
                        </tr>
                    </table>
                    
                    
                    &nbsp;<br /> 
                    
                    </asp:Panel>
            </div>
            <div class="col">
                <asp:Panel ID="panLanguage" runat="server" style="margin-bottom: 0px" GroupingText="Search By Language">
            
                    <br />
                    <asp:CheckBoxList ID="chkLanguage" runat="server">
                    </asp:CheckBoxList>
                    </asp:Panel>
            </div>
            <div class="col">
                <asp:Panel ID="panRace" runat="server" style="margin-bottom: 0px" GroupingText="Search By Ethnicity">
            
                    <br />
                    <asp:DropDownList ID="cboRace" runat="server">
                    </asp:DropDownList>
                    <br />
                    
                    </asp:Panel>
            </div>
        </div>
        <div class="row">

        </div>
        <div class="row">
            <div class="col" >
                <asp:Button ID="btnTest" runat="server" OnClick="btnTest_Click" Text="Search" UseSubmitBehavior="false" Width="417px" CssClass="badge-success"/>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:Label ID="lblSearchResults" runat="server"></asp:Label>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <asp:GridView runat="server" ID="gridResults" CellPadding="4" ForeColor="#333333" GridLines="None">
             <AlternatingRowStyle BackColor="White" />
             <EditRowStyle BackColor="#2461BF" />
             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
             <RowStyle BackColor="#EFF3FB" />
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             <SortedAscendingCellStyle BackColor="#F5F7FB" />
             <SortedAscendingHeaderStyle BackColor="#6D95E1" />
             <SortedDescendingCellStyle BackColor="#E9EBEF" />
             <SortedDescendingHeaderStyle BackColor="#4870BE" />
             
                </asp:GridView>
            </div>
            <div class="col">
                <asp:Panel runat="server" ID="panSend" GroupingText="Send To :">
                    <asp:CheckBoxList ID="chkUserList" runat="server" Class="test">
        </asp:CheckBoxList>
                    <asp:Button runat="server" ID="btnSend" Text="Send Message" OnClick="btnSend_Click"/>
                </asp:Panel>
                
            </div>
        </div>
             
            
                
           
            
                
           
       
         
        
        
        
       
        
        
        
        
        
        
       
        
        
        <br />
        
        
        </div>
       
        
        
    </form>
</body>
</html>
