<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="UserStyle.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <div style = "border:2px solid black;background:#a69eb0;margin:5% 15% 5% 17%;padding:2% 5% 2% 5%;height:auto;width:auto">
            <table cellpadding = "20px">
                
                <%--Heading--%>
                <tr>
                    <td colspan = "5" align = "center">
                        <h1>SignUp</h1>
                    </td>
                </tr>

                <tr>
                    <td colspan = "5">
                        
                    </td>
                </tr>
                
                <%--Form Details--%>
                
                <%--Name--%>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
                        
                    </td>
                    <td>
                    
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
                        
                    </td>
                </tr>

                <%--Gender--%>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Gender"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButton ID="radMale" runat="server" Text="Male" 
                            oncheckedchanged="radMale_CheckedChanged" />
                    </td>
                    <td colspan = "3">
                        <asp:RadioButton ID="radFemale" runat="server" Text="Female" 
                            oncheckedchanged="radFemale_CheckedChanged" />
                    </td>
                </tr>

                <%--Date of Birth--%>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Date of Birth"></asp:Label>
                    </td>
                    <td colspan = "4">
                        <asp:TextBox ID="txtDob" runat="server" type = "date"></asp:TextBox>
                        
                    </td>
                </tr>

                <tr>
                    
                    <%--Country List--%>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Country"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpCoun" runat="server">
                            <asp:ListItem>--select--</asp:ListItem>
                            <asp:ListItem>Afganistan</asp:ListItem>
                            <asp:ListItem>Bangladesh</asp:ListItem>
                            <asp:ListItem>Bhutan</asp:ListItem>
                            <asp:ListItem>China</asp:ListItem>
                            <asp:ListItem>Egypt</asp:ListItem>
                            <asp:ListItem>France</asp:ListItem>
                            <asp:ListItem>Germany</asp:ListItem>
                            <asp:ListItem>Hungry</asp:ListItem>
                            <asp:ListItem>India</asp:ListItem>
                            <asp:ListItem>Indonesia</asp:ListItem>
                            <asp:ListItem>Iraq</asp:ListItem>
                            <asp:ListItem>Japan</asp:ListItem>
                            <asp:ListItem>Korea</asp:ListItem>
                            <asp:ListItem>Pakistan</asp:ListItem>
                            <asp:ListItem>Turkey</asp:ListItem>
                            <asp:ListItem>UK</asp:ListItem>
                            <asp:ListItem>USA</asp:ListItem>
                            <asp:ListItem>Vetican City</asp:ListItem>
                        </asp:DropDownList>
                    </td>

                    <td>
                        
                    </td>
                    
                    <%--Mobile Number--%>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Mobile"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMob" runat="server"></asp:TextBox>
                        
                    </td>
                </tr>

                <%--Password--%>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td colspan = "4">
                        <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Confirm Password"></asp:Label>
                    </td>
                    <td colspan = "4">
                        <asp:TextBox ID="txtCpass" runat="server" TextMode="Password"></asp:TextBox>
                        
                    </td>
                </tr>

                <%--Email--%>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="E-mail"></asp:Label>
                    </td>
                    <td colspan = "4">
                        <asp:TextBox ID="txtMail" runat="server" Width="356px"></asp:TextBox>
                        
                    </td>
                </tr>
                
                <%--Security Question/Answer--%>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Security Question"></asp:Label>
                    </td>
                    <td colspan = "4">
                        <asp:TextBox ID="txtSques" runat="server" Width="373px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="Answer"></asp:Label>
                    </td>
                    <td colspan = "4">
                        <asp:TextBox ID="txtSans" runat="server" Width="376px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        
                    </td>
                </tr>

                <tr>
                    <td colspan = "5">
                        <%--Image Upload--%>
                        <asp:Image ID="Image1" runat="server" ImageUrl = "~/User/User_pics/unknownbig.png"/><br /><br />
                        <asp:FileUpload ID="fupUser" runat="server" /><br /><br /><br /><br />
                    </td>
                </tr>
                <tr>
                    <td colspan = "5">
                        <%--About--%>
                        <asp:Label ID="Label12" runat="server" Text="About : "></asp:Label> <br /><br />
                        <asp:TextBox ID="txtAbout" runat="server" TextMode="MultiLine" Height="85px" Width="491px"></asp:TextBox><br /><br /><br /><br />
                    </td>
                </tr>
                
                <%--Submit--%>
                <tr>
                    <td colspan = "5" align = "center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Register Now" Height="50px" Width="215px" onclick="btnSubmit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl = "~/User/Main.aspx">Not Now</asp:HyperLink>
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
