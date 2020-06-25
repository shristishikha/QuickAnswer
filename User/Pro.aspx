 <%@ Page Title="" Language="C#" MasterPageFile="~/User/Welcome.master" AutoEventWireup="true" CodeFile="Pro.aspx.cs" Inherits="Pro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          
        <div runat = "server" style = "margin:0 0 0 50px;width:825px;background:white;">                        
            

        <%--Question Repeater--%>
        <asp:Repeater ID="rptCustomers" runat="server" OnItemDataBound="OnItemDataBound">
            
            <HeaderTemplate>
                <table class="table table-responsive">
            </HeaderTemplate>
        
            <ItemTemplate>
                <tr>
                    <tr>
                        <td>
                            <div style = "float:left">
                                <h3>    
                                    <div style = "float:left;margin:0 0 0 10px;"><asp:ImageButton ID="imgbtnQuesPic" runat="server" ImageUrl = '<%# "User_pics/" + Eval("Profile_pic") %>' Height = "70px" Width = "70px" CssClass = "ppic"/></div>
                                </h3>
                            </div>
                            <div style = "float:right;width:700px;">
                                <h3>
                                    <div style = "float:left;width:auto;margin:10px 0 10px 20px;width:650px"><asp:Label ID="lblContactName" runat="server" Text='<%# Eval("Question") %>' /></div>
                                </h3>
                                
                                <div style = "float:left;width:auto;margin:0 0 10px 20px">asked by&nbsp;<asp:Label ID="lblCity" runat="server" Text='<%# Eval("Ques_by") %>' /></div>
                                <div>&nbsp;on&nbsp;<asp:Label ID="lbladate" runat="server" Text='<%# Eval("Date") %>'/></div>
                            </div>
                        </td>
                    </tr>

                    <td colspan = "4">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <img alt="" style="cursor: pointer" src="../images/plus.png"  title="Click to Show Answer"/>

                        <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                        
                            <asp:Repeater ID="rptOrders" runat="server">
                                
                                <%--Answer Repeater--%>
                                <HeaderTemplate>
                                    <div style = "margin:-10px 18px -10px -695px;float:right">
                                    <table class="table table-responsive" style = "width:700px;background:rgb(212,219,229)">
                                </HeaderTemplate>
                                
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="imgbtnQuesPic" runat="server" ImageUrl = '<%# "User_pics/" + Eval("Profile_pic") %>' Height = "40px" Width = "40px" CssClass = "ppic"/>
                                            <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("Answer") %>' /><br />
                                            <asp:Label ID="lblCity" runat="server" Text='<%# Eval("Ansby") %>' />
                                            <asp:Label ID="lbladate" runat="server" Text='<%# Eval("Date") %>'/>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            
                                <FooterTemplate>
                                    </table>
                                    </div>
                                </FooterTemplate>
                            
                            </asp:Repeater>

                        </asp:Panel>

                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="HyperLink3" NavigateUrl='<%#Eval("Q_id","~/User/Answer.aspx?ID={0}") %>' runat="server"><b>Reply</b></asp:HyperLink>
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="imgbtnLike" runat="server" onclick="imgbtnLike_Click" ImageUrl = '<%#(Eval("FStatus").ToString() == "Like") ? "../images/Unlike.png" : "../images/Like.png"%>' Height = "20px" Width = "20px"/>
                        
                       

                        <asp:HiddenField ID="hfCustomerId" runat="server" Value='<%# Eval("Q_id") %>' />
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
            <asp:Label ID="lblNtng" runat="server" Font-Size = "24px" Text=".....Be the first to ask....."></asp:Label>
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

