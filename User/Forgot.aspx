<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.master" AutoEventWireup="true" CodeFile="Forgot.aspx.cs" Inherits="User_Forgot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div style = "float:left;height:auto;background:rgb(212,219,229);margin:80px 50px 50px 120px;padding:0 0 0 0;">
        
        <table id = "tbl" runat = "server">
                    <tr>
                           <td>
                               <asp:Label ID="Label1" runat="server" Text="Enter UserId"></asp:Label>
                           </td>
                           <td>
                               <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
                               <asp:Label ID="lblID" runat="server" Visible = "false"></asp:Label>
                           </td>
                    </tr>
                    <tr>
                           <td>
                                <asp:Label ID="lblsqun" runat="server" Text="Security Question" Visible = "false"></asp:Label>
                           </td>
                           <td>
                               <asp:Label ID="lblSQues" runat="server" Visible = "false"></asp:Label>
                           </td>
                    </tr>
                    <tr>
                           <td>
                                <asp:Label ID="Label2" runat="server" Text="Answer" Visible = "false"></asp:Label>
                           </td>
                           <td>
                                <asp:TextBox ID="txtans" runat="server" Visible = "false"></asp:TextBox>
                               <asp:Label ID="lblSAns" runat="server" Visible = "false"></asp:Label>
                           </td>
                    </tr>
                    <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" />
                                <asp:Button ID="btnReset" runat="server" data-target="#test" Text="Reset" Visible = "false" onclick="btnReset_Click" />
                            </td>
                    </tr>
                
                </table> 
    </div>

    <div id = "pbox" visible = "false" runat="server">
         
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblnew" runat="server" Text="New Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNPswd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblre" runat="server" Text="Confirm Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCPswd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnPswd" runat="server" Text = "Reset" onclick="btnPswd_Click" />
                </td>
            </tr>
        </table>

    </div>

</asp:Content>

