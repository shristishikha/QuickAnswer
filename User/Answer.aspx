  <%@ Page Title="" Language="C#" MasterPageFile="~/User/Welcome.master" AutoEventWireup="true" CodeFile="~/User/Answer.aspx.cs" Inherits="User_Answer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <%--Question--%>
    <asp:Label ID="lblqun" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="lblqunby" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="lblqdate" runat="server" Text=""></asp:Label>
    <br />
    <br />

    <%--Answer Box--%>
    <asp:TextBox ID="txtans" runat="server" Width="850px" Height="50px" Placeholder="Type Answer Here" TextMode="MultiLine"></asp:TextBox>
    <br />
    <asp:Button ID="btnadd_Ans" runat="server" Text="Submit" onclick="add_Ans_Click" />
    <hr />

</asp:Content>

