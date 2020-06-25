<%@ Page Title="" Language="C#" MasterPageFile="~/User/Welcome.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style = "margin:10px 0 0 50px;width:825px;">
<asp:Label ID="lblMsg" runat="server" Font-Size = "32px" Text="Help us in improving...Please provide a feedback..."></asp:Label>
    
    
    <asp:TextBox ID="txtFeedback" runat="server" TextMode = "MultiLine" Height = "350px" Width = "90%" style = "margin:40px 0 0 45px;border-radius:5px 5px 5px 5px;"></asp:TextBox>
    <div style = "float:right;margin:5px 220px 0 0"><asp:Button ID="btnSubmit" 
            runat="server" Text="Submit" Width = "350px" Height = "40px" 
            onclick="btnSubmit_Click"/></div>
            

    </div>

</asp:Content>

