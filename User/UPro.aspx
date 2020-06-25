<%@ Page Title="" Language="C#" MasterPageFile="~/User/Welcome.master" AutoEventWireup="true" CodeFile="UPro.aspx.cs" Inherits="User_UPro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <%--Heading--%>
        <div style = "background:white;width:1000px;margin:-33px 0 0 50px;">
            <table width = "100%">
                <tr>
                    <td align = "center" style = "width:150px;height:125px;">
                        
                        <div style = "margin:0 0 0 25px">
                            <asp:Image ID="imgUser" runat="server" Height = "130px" Width = "130px" CssClass="ppic"/> <br />
                            
                        </div>
                    </td>
                    <td>
                        <div style = "margin:20px 0 0 40px;width:100%">
                            <asp:Label ID="lblName" runat="server" Font-Bold = "true" Font-Size = "XX-Large" ForeColor = "Black"></asp:Label> <br />
                            
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            
                            <asp:Label ID="lblDofB" runat="server" Font-Italic = "true" style = "color:rgb(125,125,125)"></asp:Label>
                            <asp:Label ID="lblPlace" runat="server" Font-Italic = "true" style = "color:rgb(125,125,125)"></asp:Label>

                        </div>
                        
                        <div style = "margin:19px 0 0 450px;">
                            <asp:Button ID="btnQuesAsked" runat="server" CssClass = "wrap" Width = "60px"
                                onclick="btnQuesAsked_Click"/>
                            <asp:Button ID="btnAnswered" runat="server" CssClass = "wrap" 
                                onclick="btnAnswered_Click"/>
                            <asp:Button ID="btnFollowed" runat="server" CssClass = "wrap" 
                                onclick="btnFollowed_Click"/>
                        </div>
                    </td>
                    <td>
                        <div style = "margin:120px 30px 0 0px;">
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" Width = "100px" Height = "30px" onclick="btnEdit_Click"/>
                        </div>
                    </td>
                </tr>

                <tr id = "UserImg" runat = "server" visible = "false">
                    <td colspan = "3">
                        <asp:FileUpload ID="fupUser" runat="server"/>
                    </td>
                </tr>
                
                <tr>
                    <td colspan = "3">
                        <div style = "width:100%;height:30px;margin:0 0 0 0;background:rgb(212,219,229);"></div>
                    </td>
                </tr>
            </table>
        </div>
        
        

        <%--Information--%>
        <div id = "Info" runat = "server" style = "background:white;width:1000px;margin:0px 0 0 48px;">
            
            <%--General Information--%>
            <div style = "margin:30px 0 10px 10px;width:980px">
                <table width = "100%">
                    <tr>
                        <td colspan = "2">
                            <div style = "padding:5px 0 5px 20px;background:rgb(177,177,177);width:100%;color:White">
                                <asp:Label ID="Label4" runat="server" Text="General Information" Font-Bold = "true" Font-Size = "Medium"></asp:Label>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td style = "padding:10px 0 5px 50px">
                            <asp:Label ID="Label14" runat="server" Text="First Name : "></asp:Label>
                            <asp:Label ID="lblFName" runat="server"></asp:Label>
                            <asp:TextBox ID="txtFName" runat="server" Visible = "false" Enabled = "false"></asp:TextBox>
                        </td>
                        <td style = "padding:10px 0 5px 0">
                            <asp:Label ID="Label15" runat="server" Text="Last Name : "></asp:Label>
                            <asp:Label ID="lblLName" runat="server"></asp:Label>
                            <asp:TextBox ID="txtLName" runat="server" Visible = "false" Enabled = "false"></asp:TextBox>
                        </td>
                    </tr>
        
                    <tr>
                        <td colspan = "2">
                            <asp:Label ID="Label16" runat="server" Text="Gender : "></asp:Label>
                            <asp:Label ID="lblGender" runat="server"></asp:Label>
                            <asp:RadioButton ID="rdbtnMale" runat="server" Text = "Male" Visible = "false" Enabled = "false"/>
                            <asp:RadioButton ID="rdbtnFemale" runat="server" Text = "Female" Visible = "false" Enabled = "false"/>
                        </td>
                    </tr>

                    <tr>
                        <td colspan = "2">
                            <asp:Label ID="Label17" runat="server" Text="Date of Birth : "></asp:Label>
                            <asp:Label ID="lblDOB" runat="server"></asp:Label>
                            <asp:TextBox ID="txtDob" runat="server" Visible = "false" Enabled = "false"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td colspan = "2">
                            <asp:Label ID="Label18" runat="server" Text="From : "></asp:Label>
                            <asp:Label ID="lblFrom" runat="server"></asp:Label>
                            <asp:TextBox ID="txtFrom" runat="server" Visible = "false" Enabled = "false"></asp:TextBox>
                        </td>
                    </tr>
                
                    <tr>
                        <td colspan = "2">
                            <asp:Label ID="Label19" runat="server" Text="About : "></asp:Label>
                            <asp:Label ID="lblAbout" runat="server"></asp:Label>
                            <asp:TextBox ID="txtAbout" runat="server" Visible = "false" Enabled = "false"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>

            <%--Contact Information--%>
            <div style = "margin:30px 0 10px 10px;width:980px">
                <table width = "100%">
                    <tr>
                        <td  colspan = "2">
                            <div style = "padding:5px 0 5px 20px;background:rgb(177,177,177);width:100%;color:White">
                                <asp:Label ID="Label11" runat="server" Text="Contact Information" Font-Bold = "true" Font-Size = "Medium"></asp:Label>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan = "2">
                            <asp:Label ID="Label21" runat="server" Text="Mobile : "></asp:Label>
                            <asp:Label ID="lblMobile" runat="server"></asp:Label>
                            <asp:TextBox ID="txtMobile" runat="server" Visible = "false" Enabled = "false"></asp:TextBox>
                        </td>
                    </tr>
                
                    <tr>
                        <td colspan = "2">
                            <asp:Label ID="Label22" runat="server" Text="E-mail : "></asp:Label>
                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server" Visible = "false" Enabled = "false"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
                
            <%--Privacy--%>
            <div id = "Privacy" runat = "server" style = "margin:30px 0 10px 10px;width:980px">
                <table width = "100%">
                    <tr>
                        <td colspan = "2">
                            <div style = "padding:5px 0 5px 20px;background:rgb(177,177,177);width:100%;color:White">
                                <asp:Label ID="Label20" runat="server" Text="Privacy" Font-Bold = "true" Font-Size = "Medium"></asp:Label>
                            </div>
                        </td>
                    </tr>
                
                    <tr>
                        <td colspan = "2">
                            <asp:Label ID="Label23" runat="server" Text="Password : "></asp:Label>
                            <asp:LinkButton ID="lbtnPassword" runat="server" onclick="lbtnPassword_Click">Change Password</asp:LinkButton>
                        </td>
                    </tr>
                
                    <tr>
                        <td colspan = "2">
                            <asp:Label ID="Label24" runat="server" Text="Security Question : "></asp:Label>
                            <asp:LinkButton ID="lbtnSecurity" runat="server" onclick="lbtnSecurity_Click">Change Security Question</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>

            <div id = "Save" runat = "server" visible = "false" style = "float:right;margin:20px 320px 5px 0">
                <asp:Button ID="btnSave" runat="server" Width = "150px" Height = "30px" Text="Save" onclick="btnSave_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Width = "150px" Height = "30px" Text="Cancel" onclick="btnCancel_Click" />
            </div>

        </div>

        <%--Change Password--%>
        <div id = "Password" runat = "server" visible = "false" style = "background:white;width:1000px;margin:90px 0 0 48px;">
            <div style = "margin:30px 0 10px 10px;width:980px">
                <table width = "100%">
                    <tr>
                        <td>
                            <div style = "padding:5px 0 5px 20px;background:rgb(177,177,177);width:100%;color:White">
                                <asp:Label ID="Label1" runat="server" Text="Reset Password"></asp:Label>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Old Password : "></asp:Label>
                            <asp:TextBox ID="txtPPass" runat="server" Enabled = "false"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="New Password : "></asp:Label>
                            <asp:TextBox ID="txtNPass" runat="server" Enabled = "false"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Confirm Password : "></asp:Label>
                            <asp:TextBox ID="txtCPass" runat="server" Enabled = "false"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Button ID="btnPReset" runat="server" Text="Reset" onclick="btnPReset_Click" />
                            <asp:Button ID="btnPCancel" runat="server" Text="Cancel" onclick="btnPCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>

        <%--Change Security Question--%>
        <div id = "Security" visible = "false" runat = "server" style = "background:white;width:1000px;margin:90px 0 0 48px;">

            <%--Old Question--%>
            <div id = "OSQues" runat = "server" style = "margin:30px 0 10px 10px;width:980px">
                <table width = "100%">
                    <tr>
                        <td>
                            <div style = "padding:5px 0 5px 20px;background:rgb(177,177,177);width:100%;color:White">
                                <asp:Label ID="Label6" runat="server" Text="Reset Security Question"></asp:Label>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Security Question : "></asp:Label>
                            <asp:Label ID="lblSQun" runat="server"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Answer : "></asp:Label>
                            <asp:TextBox ID="txtSAns" runat="server" Enabled = "false"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click"/>
                            <asp:Button ID="btnSOCancel" runat="server" Text="Cancel" onclick="btnSOCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>

            <%--New Question--%>
            <div id = "NSQues" runat = "server" visible = "false" style = "margin:30px 0 10px 10px;width:980px">
                <table width = "100%">
                    <tr>
                        <td>
                            <div style = "padding:5px 0 5px 20px;background:rgb(177,177,177);width:100%;color:White">
                                <asp:Label ID="Label9" runat="server" Text="Reset Security Question"></asp:Label>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="Security Question : "></asp:Label>
                            <asp:TextBox ID="txtNSQues" runat="server" Enabled = "false"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label25" runat="server" Text="Answer : "></asp:Label>
                            <asp:TextBox ID="txtNSAns" runat="server" Enabled = "false"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Button ID="btnSReset" runat="server" Text="Reset" onclick="btnSReset_Click" />
                            <asp:Button ID="btnSNCancel" runat="server" Text="Cancel" onclick="btnSNCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            
        </div>
                <div style = "width:100%;height:30px;margin:0 0 0 0;background:rgb(212,219,229);"></div>

</asp:Content>

