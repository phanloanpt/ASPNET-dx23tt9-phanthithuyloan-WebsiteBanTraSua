<%@ Page Title="Tin tức & Khuyến mãi"
    Language="C#"
    MasterPageFile="~/Site.master"
    AutoEventWireup="true"
    CodeBehind="TinTuc.aspx.cs"
    Inherits="TraSuaNgon.TinTuc" %>


<asp:Content 
    ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<div class="container mt-5 mb-5">


<h2 class="text-center mb-5">
    <i class="fa-solid fa-newspaper"></i>
    Tin tức & Khuyến mãi
</h2>



<div class="row">


<asp:Repeater 
    ID="rptNews"
    runat="server">


<ItemTemplate>


<div class="col-lg-4 col-md-6 mb-4">


<div class="card h-100 shadow-sm">


<img src='<%# ResolveUrl(Eval("ImageURL").ToString()) %>'
     class="card-img-top"
     style="height:220px;object-fit:cover;" />



<div class="card-body">


<h5 class="fw-bold">

<%# Eval("Title") %>

</h5>



<p class="text-muted">

<%# Eval("Summary") %>

</p>



<p class="small">

<i class="fa fa-calendar"></i>

<%# Convert.ToDateTime(Eval("CreatedDate")).ToString("dd/MM/yyyy") %>

</p>




<a href='NewsDetail.aspx?id=<%# Eval("NewsID") %>'
   class="btn btn-danger">

Xem chi tiết

</a>



</div>


</div>


</div>


</ItemTemplate>


</asp:Repeater>



</div>


</div>


</asp:Content>