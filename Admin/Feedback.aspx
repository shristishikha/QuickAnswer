<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div runat = "server" style = "margin:0 0 0 50px;width:825px;background:white;">                        
            
            
        <%--Question Repeater--%>
        <asp:Repeater ID="rptFeedback" runat="server">
            
            <HeaderTemplate>
                <table class="table table-responsive">
            </HeaderTemplate>
        
            <ItemTemplate>
                <tr>
                    <tr>
                        <td>
                            <h3>    
                                <div style = "float:left;margin:0 0 0 10px"><asp:ImageButton ID="imgbtnQuesPic" runat="server" ImageUrl = '<%# "../User/User_pics/" + Eval("Profile_pic") %>' Height = "70px" Width = "70px" CssClass = "ppic"/></div>
                                <div style = "float:left;width:79%;margin:20px 0 10px 20px"><asp:Label ID="lblContactName" CssClass = "textwrap" runat="server" Text='<%# Eval("Feedback") %>' /></div>
                            </h3>
                            
                            <div style = "float:left;width:90%;margin:0 0 0 100px"><asp:Label ID="lblCity" runat="server" Text='<%# Eval("F_name") +" " + Eval("L_name") %>' /></div>
                            <div><asp:Label ID="lbladate" runat="server" Text='<%# Eval("Date") %>'/></div>
                        </td>
                    </tr>

                    <td>

                        <asp:HiddenField ID="hfCustomerId" runat="server" Value='<%# Eval("F_id") %>' />
                        <asp:LinkButton ID="lbtnRemove" runat="server" onclick="lbtnRemove_Click">Remove</asp:LinkButton>

                    </td>

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
        <div id = "Nothing" runat = "server" style = "margin:250px 0 0 320px">
            <asp:Label ID="lblNtng" runat="server" Font-Size = "24px" Text=".....Nothing to show yet....."></asp:Label>
        </div>

</asp:Content>

