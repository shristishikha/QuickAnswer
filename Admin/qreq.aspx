<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="qreq.aspx.cs" Inherits="qreq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div runat = "server" style = "margin:0 0 0 50px;width:825px;background:white;">
                            
                                

    <%--Question Repeater--%>
        <asp:Repeater ID="rptQues" runat="server">
            
            <HeaderTemplate>
                <table class="table table-responsive">
            </HeaderTemplate>
        
            <ItemTemplate>
                <tr>
                    <tr>
                        <td>
                            <h3>    
                                <div style = "float:left;margin:0 0 0 10px"><asp:ImageButton ID="imgbtnQuesPic" runat="server" ImageUrl = '<%# "../User/User_pics/" + Eval("Profile_pic") %>' Height = "70px" Width = "70px" CssClass = "ppic"/></div>
                                <div style = "float:left;width:79%;margin:20px 0 10px 20px"><asp:Label ID="lblContactName" runat="server" Text='<%# Eval("Question") %>' /></div>
                            </h3>
                            
                            <div style = "float:left;width:90%;margin:0 0 0 100px"><asp:Label ID="lblCity" runat="server" Text='<%# Eval("Ques_by") %>' /></div>
                            <div><asp:Label ID="lbladate" runat="server" Text='<%# Eval("Date") %>'/></div>
                        </td>
                    </tr>

                    <td>
                        
                        <asp:HiddenField ID="hfCustomerId" runat="server" Value='<%# Eval("Q_id") %>' />
                        <asp:LinkButton ID="lbtnApp" runat="server" onclick="lbtnApp_Click">Approve</asp:LinkButton>
                        <asp:LinkButton ID="lbtnRej" runat="server" onclick="lbtnRej_Click">Reject</asp:LinkButton>
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
            <asp:Label ID="lblNtng" runat="server" Font-Size = "24px" Text=".....Not question request....."></asp:Label>
        </div>

</asp:Content>

