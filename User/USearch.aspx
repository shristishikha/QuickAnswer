<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.master" AutoEventWireup="true" CodeFile="USearch.aspx.cs" Inherits="User_USearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<br />
        <div id = "Qun" style = "margin:0 2% 0 5%;width:1000px;background:white;">
        
        <%--Question Repeater--%>
        <asp:Repeater ID="rptCustomers" runat="server" OnItemDataBound="OnItemDataBound">
            
            <HeaderTemplate>
                <table  class="table table-responsive">
            </HeaderTemplate>
        
            <ItemTemplate>
                <tr>
                    <tr>
                        <td>
                            <h3>    
                                <div style = "float:left;margin:0 0 0 10px"><asp:ImageButton ID="imgbtnQuesPic" runat="server" ImageUrl = '<%# "User_pics/" + Eval("Profile_pic") %>' Height = "70px" Width = "70px" CssClass = "ppic"/></div>
                                <div style = "float:left;width:87%;margin:20px 0 10px 20px"><asp:Label ID="lblContactName" runat="server" Text='<%# Eval("Question") %>' /></div>
                            </h3>
                            
                            <div style = "float:left;width:90%;margin:0 0 0 100px"><asp:Label ID="lblCity" runat="server" Text='<%# Eval("Ques_by") %>' /></div>
                        </td>
                    </tr>

                    <td colspan = "4">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <img alt="" style="cursor: pointer" src="../images/plus.png"  title="Click to Show Answer"/>

                        <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                        
                            <asp:Repeater ID="rptOrders" runat="server">
                                
                                <%--Answer Repeater--%>
                                <HeaderTemplate>
                                    <div style = "margin:-10px 0 0 -900px;padding:0 0 0 30px">
                                    <table class="table table-responsive" style = "width:875px;background:rgb(212,219,229)">
                                </HeaderTemplate>
                                
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="imgbtnQuesPic" runat="server" ImageUrl = '<%# "User_pics/" + Eval("Profile_pic") %>' Height = "40px" Width = "40px" CssClass = "ppic"/>
                                            <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("Answer") %>' /><br />
                                            <asp:Label ID="lblCity" runat="server" Text='<%# Eval("Ansby") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            
                                <FooterTemplate>
                                    </table>
                                    </div>
                                </FooterTemplate>
                            
                            </asp:Repeater>

                        </asp:Panel>

                        <asp:HiddenField ID="hfCustomerId" runat="server" Value='<%# Eval("Q_id") %>'/>
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

        <div style = "width:100%;height:20px;margin:-2% 0 0 0;background:rgb(212,219,229);"></div>

        </div>

        <div id = "Nothing" runat = "server" style = "margin:250px 0 0 320px">
            <asp:Label ID="lblNtng" runat="server" Font-Size = "24px" Text=".....Not found....."></asp:Label>
        </div>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

        <script type="text/javascript">
            $("body").on("click", "[src*=plus]", function () {
                $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
                $(this).attr("src", "../images/minus.png");
            });
            $("body").on("click", "[src*=minus]", function () {
                $(this).attr("src", "../images/plus.png");
                $(this).closest("tr").next().remove();
            });
        </script>

</asp:Content>

