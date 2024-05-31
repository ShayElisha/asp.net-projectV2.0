<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="productList.aspx.cs" Inherits="web09052024.productList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="container">
                    <div class="row">
                        <asp:Repeater ID="rptProd" runat="server">
                            <ItemTemplate>
                                <div class="col-md-4">
                                    <div class="card" style="width: 18rem;">
                                      <img src="uploads/<%#Eval("picName") %>" class="card-img-top" style="width:285px" height="250px" alt="...">
                                      <div class="card-body">
                                        <h5 class="card-title"><%#Eval("pName") %></h5>
                                        <p class="card-text"><%# Eval("price") %></p>
                                        <h5 class="card-title"><%#Eval("picName") %></h5>
                                        <a href="#" class="btn btn-primary">Go somewhere</a>
                                      </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
</asp:Content>
