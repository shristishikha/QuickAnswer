<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="qcato.aspx.cs" Inherits="qcato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style = "margin:0 0 0 50px;width:825px;">

<div style = "margin:0 0 10px 25px">
<table width="100%">
    <tr>
        <td>
             <asp:TextBox ID="txtCat" runat="server" TextMode="MultiLine" Width="725px" Placeholder="Type New Category Name" style = "text-decoration:none;border-radius:5px 5px 5px 5px;"
                 Height="30px"></asp:TextBox><br />        
        </td>
        <td align="right">
        <asp:Button ID="btnadd" runat="server" Text="Add" Width="50px" Height="30px" style = "margin:8px 0 10px 0;border-radius:5px 5px 5px 5px;" onclick="btnadd_Click"/>
    </td>    
    </tr>
    </table>
    </div>
    <hr style="width:95%"/>


<div runat = "server" style = "margin:0 0 0 0px;width:825px;background:white;">
                                                    
                                

    <%--Question Repeater--%>
        <asp:Repeater ID="rptQues" runat="server">
            
            <HeaderTemplate>
                <table class="table table-responsive">
            </HeaderTemplate>
        
            <ItemTemplate>
                <tr>
                    <tr>
                        <td> 
                            
                                <div style = "float:left;margin:0 0 0 0px;width:90%;">
                                <div style = "float:left;width:100%;margin:0px 0 0px 20px">
                                    <asp:Label ID="lblContactName" runat="server" Text='<%# Eval("Ques_type") %>' Font-Size = "24px"/>
                                    <asp:TextBox ID="txtCat" runat="server" Text = '<%# Eval("Ques_type") %>' Visible = "false" Width="625px" Font-Size = "Medium" style = "text-decoration:none;border-radius:5px 5px 5px 5px;margin:6px 0 0 0" Height="30px"></asp:TextBox>
                                </div>

                                <div><asp:Label ID="lbladate" runat="server" Font-Size = "Smaller" Text='<%# Eval("Date") %>'/></div>
                            </div>
                            <div style = "width:8%;float:right;padding: 5px 0 0 0">
                            <asp:HiddenField ID="hfCustomerId" runat="server" Value='<%# Eval("Q_id") %>' />
                            <asp:LinkButton ID="lbtnEdit" runat="server" onclick="lbtnEdit_Click">Edit</asp:LinkButton>
                            <asp:LinkButton ID="lbtnSave" runat="server" Visible = "false" onclick="lbtnSave_Click">Save</asp:LinkButton>
                            <asp:LinkButton ID="lbtnCancel" runat="server" Visible = "false" onclick="lbtnCancel_Click">Cancel</asp:LinkButton>
                            <asp:LinkButton ID="lbtnRem" runat="server" onclick="lbtnRem_Click" >Remove</asp:LinkButton>
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
            <asp:Label ID="lblNtng" runat="server" Font-Size = "24px" Text=".....Nothing added yet....."></asp:Label>
        </div>

</asp:Content>

