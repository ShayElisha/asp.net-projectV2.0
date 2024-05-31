<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="web09052024.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div>
        שם משתמש: <asp:TextBox ID="UserName" runat="server" /><br />
        אימייל: <asp:TextBox ID="Email" runat="server" /><br />
        סיסמה : <asp:TextBox ID="UserPass" TextMode="Password" runat="server"/><br />
        אימות : <asp:TextBox ID="validPass" TextMode="Password" runat="server" /><br />
        עיר: <asp:DropDownList ID="DDlCity" runat="server">
             </asp:DropDownList><br />
        כתובת: <asp:TextBox ID="Address" runat="server" />
        טלפון: <asp:TextBox ID="Phone" runat="server" />
        <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" />
        <asp:Literal ID="Warning" runat="server" />
    </div>

</asp:Content>
