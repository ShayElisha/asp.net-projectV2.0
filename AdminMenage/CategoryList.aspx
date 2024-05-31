<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMenage/BackAdmin.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="web09052024.AdminMenage.CategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="css/plugins/dataTables.bootstrap.css" rel="stylesheet">
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
                מאגר מוצרים במערכת
            </div>
            <!-- /.panel-heading -->
            <div class="panel-body">
                <div class="table-responsive">
                    <table class="table table-striped table-bordered table-hover" id="mainTbl">
                        <thead>
                            <tr>
                                <th>קוד קטגוריה</th>
                                <th>שם קטגוריה</th>
                                <th>תיאור</th>
                                <th>תמונה</th>
                                <th>ניהול</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RptProd" runat="server">
                                <ItemTemplate>
                                    <tr class="odd gradeX">
                                        <td><%#Eval("Cid") %></td>
                                        <td><%#Eval("Cname") %></td>
                                        <td><%#Eval("Cdesc") %></td>
                                        <td class="center"><img src="/uploads/pic/PicCategory/<%#Eval("CPic")%>" width="50" /> </td>
                                        <td class="center"><a href="CatAddEdit.aspx?Cid=<%#Eval("Cid") %>">ערוך <spann class="fa fa-pencil"></spann></a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater> 
                        </tbody>
                    </table>
                </div>
                <!-- /.table-responsive -->
                <div class="well">
                    <h4>DataTables Usage Information</h4>
                    <p>DataTables is a very flexible, advanced tables plugin for jQuery. In SB Admin, we are using a specialized version of DataTables built for Bootstrap 3. We have also customized the table headings to use Font Awesome icons
                        in place of images. For complete documentation on DataTables, visit their website at <a target="_blank" href="https://datatables.net/">https://datatables.net/</a>.</p>
                    <a class="btn btn-default btn-lg btn-block" target="_blank" href="https://datatables.net/">View DataTables Documentation</a>
                </div>
            </div>
            <!-- /.panel-body -->
        </div>
        <!-- /.panel -->
    </div>
    <!-- /.col-lg-12 -->
</div>
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
