
<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMenage/BackAdmin.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="prodAddEdit.aspx.cs" Inherits="web09052024.AdminMenage.prodAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="row">
    <div class="col-lg-12">
        <h1 class="page-header">ניהול מוצרים</h1>
    </div>
    <!-- /.col-lg-12 -->
</div>
<!-- /.row -->
<div class="row">
    <div class="col-lg-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                הוספה / עריכת מוצר
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-6">
                        <asp:HiddenField ID="hidPid" runat="server" Value="-1"/>
                            <div class="form-group">
                                <label>שם המוצר</label>
                                <asp:TextBox ID="TxtPname" CssClass="form-control" runat="server" placeholder="נא הזן שם מוצר"/>
                            </div>   
                            <div class="form-group">
                                <label>מחיר המוצר</label>
                                <asp:TextBox ID="TxtPrice" CssClass="form-control" runat="server" placeholder="נא הזן מחיר"/>
                            </div> 
                            <div class="form-group">
                                    <label>תיאור המוצר</label>
                                    <asp:TextBox ID="TxtDesc" CssClass="form-control" TextMode="MultiLine" Rows="10" Columns="40" runat="server" placeholder="נא הזן תיאור מוצר"/>
                                </div> 
                            <div class="form-group">
                                    <asp:Image ID="ImgPic" Width="350px" Height="250px" CssClass="form-control" runat="server"/>
                                </div> 
                            <div class="form-group">
                                <label>שם תמונה</label>
                                <asp:fileUpload ID="uploadPic" runat="server"/>
                            </div> 
 
   
                            <asp:button ID="btnSave" type="submit" class="btn btn-primary" runat="server" onclick="BtnSave_Click" Text="שמירה" />
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
    <script src="https://cdn.ckeditor.com/ckeditor5/41.4.2/classic/ckeditor.js"></script>
    <script>
    ClassicEditor
        .create(document.querySelector( '#MainCnt_TxtDesc' ) )
        .catch( error => {
            console.error( error );
        } );
    </script>

</asp:Content>
