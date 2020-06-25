<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <%--<div class="Title">DASHBOARD</div>--%>
    <div style = "height:auto;width:auto;padding-left:3%">
    <div class="option">
        <table>
        <tr>
            <td><h1>
                <asp:Label ID="lblQunAsked" runat="server" Text=""></asp:Label></h1></td>
        </tr>
        <tr>
            <td><p>QUESTION ASKED</p></td>
        </tr>
        </table>
    </div>
        
    <div class="option">
        <table>
        <tr>
            <td><h1>
                <asp:Label ID="lblQunans" runat="server" Text=""></asp:Label></h1></td>
        </tr>
        <tr>
            <td><p>QUESTION ANSWERED</p></td>
        </tr>
        </table>
        
    </div>
    
    <div class="option">
        <table>
        <tr>
            <td><h1><asp:Label ID="lblQRej" runat="server" Text=""></asp:Label></h1></td>
        </tr>
        <tr>
            <td><p>QUESTION REJECTED</p></td>
        </tr>
        </table>
    </div>
    
    <div class="option">
        <table>
        <tr>
            <td><h1><asp:Label ID="lbluserd" runat="server" Text=""></asp:Label></h1></td>
        </tr>
        <tr>
            <td><p>ACTIVE USER</p></td>
        </tr>
        </table>
    </div>
    </div>
</asp:Content>

