<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="udetail.aspx.cs" Inherits="udetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div style = "margin:0 0 0 50px;width:825px;">
<div runat = "server" style = "margin:0 0 0 0px;width:825px;background:white;">
<asp:Repeater ID="rptQues" runat="server">
            
            <HeaderTemplate>
                <table class="table table-responsive">
            </HeaderTemplate>
        
            <ItemTemplate>
                <tr>
                    <tr>
                        <td>

                            <div style = "width:20%;float:left;margin:-8px 0 -16px -8px;">
                                <asp:Image ID="imgUser" runat="server" Height = "110px" Width = "110px" ImageUrl = '<%# "../User/User_pics/" + Eval("Profile_pic") %>'/>
                            </div>

                            <div style = "width:60%;float:left;">
                                <asp:Label ID="lblName" runat="server" Font-Size = "24px" Text = '<%# Eval("F_Name") + " " + Eval("L_Name") %>' ></asp:Label><br />
                                <asp:Label ID="lblGender" runat="server" Text = '<%# Eval("Gender") %>' ></asp:Label>
                                <asp:Label ID="lblFrom" runat="server" Text = '<%# ". from " + Eval("Country") %>' ></asp:Label><br />
                                <asp:Label ID="lblMob" runat="server" Text = '<%# "Mobile - " + Eval("Mobile") %>' ></asp:Label><br />
                                <asp:Label ID="lblEmail" runat="server" Text = '<%# Eval("E_mail") %>' ></asp:Label>
                            </div>

                            <div style = "width:8%;float:right;margin-top:40px;">

                                <asp:HiddenField ID="hfCustomerId" runat="server" Value='<%# Eval("id") %>' />
                                <asp:LinkButton ID="lbtnRem" runat="server" onclick="lbtnRem_Click">Remove</asp:LinkButton>

                            </div>
        
                         </td>
                    </tr>
                    
                    
                    <tr>
                        <td colspan = "2"  style = "background:rgb(212,219,229);"></td>
                    </tr>

                </tr>
            </ItemTemplate>
            
            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:Repeater>

       <div style = "width:100%;height:30px;margin:-3% 0 0 0;background:rgb(212,219,229);"></div>
       </div>
</div>    

<div id = "Nothing" runat = "server" style = "margin:250px 0 0 320px">
            <asp:Label ID="lblNtng" runat="server" Font-Size = "24px" Text=".....No registered user....."></asp:Label>
        </div>

</asp:Content>

