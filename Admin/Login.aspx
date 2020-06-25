<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <link href="Adminp.css" rel="stylesheet" type="text/css" />
</head>
<body >
  
    <form id="form1" runat="server">
  
        <div id="admlog">
            <table cellpadding = "3px">
        
            <tr>
                    <td colspan="2" align="center">
                          <h2>Admin Panel Login</h2>
                    </td>        
            </tr>
            <tr>
                    <td colspan="2">
                          <center> 
                                <asp:Image ID="imgadm" runat="server" Width="100px" Height="100px" ImageUrl="Adm_pics/unknownbig.png" CssClass="ppic"/> 
                                <br />
                                <br />
                                <asp:FileUpload ID="upadm" runat="server" />
                          </center>
                    </td>        
            </tr>
            <tr>
                    <td >
                          <asp:Label ID="lblname" runat="server" Text="Name" width="150px"></asp:Label>                
                    </td>
                    <td>
                          <asp:TextBox ID="txtname" runat="server" Width="200px"></asp:TextBox>    
                    </td>                
        
            </tr>
            <tr>
                    <td>
                          <asp:Label ID="lbluname" runat="server" Text="Username"></asp:Label>
                        
                    </td>
                    <td>
                          <asp:TextBox ID="txtuname" runat="server" Width="200px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                    <td>
                          <asp:Label ID="lblpwd" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td>
                          <asp:TextBox ID="txtpwd" runat="server" Width="200px" TextMode="Password"></asp:TextBox>     
                    </td>        
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblsqun" runat="server" Text="Security Question"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtsqun" runat="server" Text="" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="lblsans" runat="server" Text="Answer"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtsans" runat="server" Text="" Width="200px" TextMode="SingleLine"></asp:TextBox>
                </td>
            </tr>
        
            <tr>
                <td colspan = "2"></td>
            </tr>  
            <tr>
                    <td align="center" colspan = "2">
                          <asp:Button ID="Btnsignup" runat="server" Text="SignUp" Width="60px" 
                              onclick="Btnsignup_Click" />        
                          <asp:Button ID="Btnlogin" runat="server" Text="Login" Width="60px" 
                              onclick="Btnlogin_Click" />
                    </td>        
            </tr>
            </table>        
        </div>
   
    </form>
  </body>
</html>
