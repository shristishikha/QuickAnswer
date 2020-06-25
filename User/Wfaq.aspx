<%@ Page Title="" Language="C#" MasterPageFile="~/User/Welcome.master" AutoEventWireup="true" CodeFile="Wfaq.aspx.cs" Inherits="Wfaq" %>

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
                                <div style = "float:left;margin:0 0 0 0px">
                                    <asp:Label ID="Label1" runat="server" Text="Q : "></asp:Label></div>
                                <div style = "float:left;width:87%;margin:0px 0 0px 20px">
                                    <asp:Label ID="lblContactName" runat="server" Text='<%# Eval("fqun") %>' />
                                    <asp:TextBox ID="txtEQun" runat="server" Text = '<%# Eval("fqun") %>' Visible = "false" TextMode="MultiLine" Width="725px" Font-Size = "Medium" style = "text-decoration:none;border-radius:5px 5px 5px 5px;" Height="30px"></asp:TextBox>
                                </div>
                            </h3>
                            
                            <div><asp:Label ID="lbladate" runat="server" Font-Size = "Smaller" Text='<%# Eval("Date") %>'/></div>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <h3>    
                                <div style = "float:left;margin:0 0 0 10px">
                                    <asp:Label ID="Label2" runat="server" Text="A : " Font-Size = "Medium"></asp:Label></div>
                                <div style = "float:left;width:87%;margin:0 0 10px 20px">
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("fans") %>' Font-Size = "Medium" />
                                    <asp:TextBox ID="txtEAns" runat="server" Text='<%# Eval("fans") %>' Visible = "false" TextMode="MultiLine" Width="725px" Font-Size = "Medium" Height="100px" style = "margin:2px 0 0 0; text-decoration:none;border-radius:5px 5px 5px 5px;"></asp:TextBox>
                                </div>
                            </h3>
                            
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

<div id = "Nothing" runat = "server" style = "margin:250px 0 0 320px">
            <asp:Label ID="lblNtng" runat="server" Font-Size = "24px" Text=".....Nothing to show yet....."></asp:Label>
        </div>

</asp:Content>

