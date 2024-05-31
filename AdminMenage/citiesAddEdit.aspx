<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMenage/BackAdmin.Master" AutoEventWireup="true" CodeBehind="citiesAddEdit.aspx.cs" Inherits="web09052024.AdminMenage.citiesAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
            <div class="row">
    <div class="col-lg-12">
        <h1 class="page-header">ניהול ערים</h1>
    </div>
    <!-- /.col-lg-12 -->
</div>
<!-- /.row -->
<div class="row">
    <div class="col-lg-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                הוספה / עריכת ערים
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-6">
                        <asp:HiddenField ID="hidCid" runat="server" Value="-1"/>
                            <div class="form-group">
                                <label>שם עיר</label>
                                <asp:TextBox ID="TxtCname" CssClass="form-control" runat="server" placeholder="נא הזן שם קטגוריה"/>
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
        <script src="js/jquery/jquery.dataTables.min.js"></script>
<script src="js/bootstrap/dataTables.bootstrap.min.js"></script>
<script>
$(document).ready(function() {
    $('#mainTbl').dataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/2.0.7/i18n/he.json',
        }
    });
});
</script>
</asp:Content>
