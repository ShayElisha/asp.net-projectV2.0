<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMenage/BackAdmin.Master" AutoEventWireup="true" CodeBehind="clientAddEdit.aspx.cs" Inherits="web09052024.AdminMenage.clientAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
            <div class="row">
    <div class="col-lg-12">
        <h1 class="page-header">ניהול משתמשים</h1>
    </div>
    <!-- /.col-lg-12 -->
</div>
<!-- /.row -->
<div class="row">
    <div class="col-lg-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                הוספה / עריכת משתמשים
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-6">
                        <asp:HiddenField ID="hidCus" runat="server" Value="-1"/>
                            <div class="form-group">
                                <label>שם מלא</label>
                                <asp:TextBox ID="cusFullName" CssClass="form-control" runat="server" placeholder="נא הזן שם קטגוריה"/>
                            </div>   
                            <div class="form-group">
                                <label>כתובת</label>
                                <asp:TextBox ID="CusAddress" CssClass="form-control" runat="server" placeholder="נא הזן תיאור מוצר"/>
                            </div> 
                        <div class="form-group">
                            <label>עיר</label>
                            <asp:TextBox ID="CusCityCode" CssClass="form-control" runat="server" placeholder="נא הזן שם קטגוריה"/>
                        </div>   
                        <div class="form-group">
                            <label>טלפון</label>
                            <asp:TextBox ID="CusPhone" CssClass="form-control" runat="server" placeholder="נא הזן תיאור מוצר"/>
                        </div> 
                        <div class="form-group">
                            <label>אימייל</label>
                            <asp:TextBox ID="CusMail" CssClass="form-control" runat="server" placeholder="נא הזן שם קטגוריה"/>
                        </div>   
                        <div class="form-group">
                            <label>סיסמה</label>
                            <asp:TextBox ID="CusPassword" CssClass="form-control" runat="server" placeholder="נא הזן תיאור מוצר"/>
                        </div> 
                           
 
   
                            <asp:button ID="btnSave" type="submit" class="btn btn-primary" runat="server" onclick="btnSave_Click" Text="שמירה" />
                    </div>
                </div>
                <!-- /.row (nested) -->
            </div>
            <!-- /.panel-body -->
        </div>
        <!-- /.panel -->
    </div>
    <!-- /.col-lg-12 -->
</div>
<!-- /.row -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooterCnt" runat="server">
</asp:Content>
