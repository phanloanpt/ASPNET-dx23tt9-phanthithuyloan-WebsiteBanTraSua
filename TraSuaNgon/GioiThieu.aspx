<%@ Page Title="Giới thiệu"
    Language="C#"
    MasterPageFile="~/Site.master"
    AutoEventWireup="true"
    CodeBehind="GioiThieu.aspx.cs"
    Inherits="TraSuaNgon.GioiThieu" %>


<asp:Content 
    ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<!-- Banner -->

<section class="py-5"
style="background:#FFF7EE;">


<div class="container">


<div class="row align-items-center">


<div class="col-lg-6">


<h1 class="fw-bold text-danger">

Trà Sữa NGON

</h1>


<h3 class="mb-4">

Hương vị thơm ngon - Chất lượng mỗi ngày

</h3>


<p class="fs-5">

Trà Sữa NGON mang đến những ly trà sữa
đậm vị trà, kết hợp cùng nguyên liệu
tươi ngon, an toàn và chất lượng.

</p>


<a href="Menu.aspx"
class="btn btn-danger">

Xem menu ngay

</a>


</div>




<div class="col-lg-6 text-center">


<img src="<%= ResolveUrl("~/Assets/images/logo/logo.png") %>"
     class="img-fluid"
     style="max-height:300px;" />


</div>


</div>


</div>


</section>





<!-- Câu chuyện -->


<section class="container mt-5">


<div class="row">


<div class="col-lg-6">


<img src="<%= ResolveUrl("~/Assets/images/banners/banner0.jpg") %>"
class="img-fluid rounded shadow"
style="height:350px;width:100%;object-fit:cover;" />


</div>




<div class="col-lg-6">


<h2 class="text-danger fw-bold">

Câu chuyện thương hiệu

</h2>



<p>

Được thành lập với mong muốn mang đến
những ly trà sữa chất lượng cao,
Trà Sữa NGON luôn chú trọng từng
chi tiết từ nguyên liệu đến cách pha chế.

</p>



<p>

Chúng tôi không ngừng sáng tạo những
hương vị mới, phù hợp với sở thích
của mọi khách hàng.

</p>


</div>


</div>


</section>





<!-- Điểm nổi bật -->


<section class="container mt-5 mb-5">


<h2 class="text-center text-danger fw-bold mb-4">

Vì sao chọn Trà Sữa NGON?

</h2>



<div class="row text-center">



<div class="col-md-4 mb-3">


<div class="card shadow border-0 h-100">


<div class="card-body">


<i class="fa-solid fa-leaf fa-3x text-danger"></i>


<h5 class="mt-3">

Nguyên liệu chất lượng

</h5>


<p>

Lựa chọn nguyên liệu an toàn,
tươi mới mỗi ngày.

</p>


</div>


</div>


</div>





<div class="col-md-4 mb-3">


<div class="card shadow border-0 h-100">


<div class="card-body">


<i class="fa-solid fa-mug-hot fa-3x text-danger"></i>


<h5 class="mt-3">

Hương vị đa dạng

</h5>


<p>

Nhiều loại trà sữa,
trà trái cây và topping hấp dẫn.

</p>


</div>


</div>


</div>





<div class="col-md-4 mb-3">


<div class="card shadow border-0 h-100">


<div class="card-body">


<i class="fa-solid fa-heart fa-3x text-danger"></i>


<h5 class="mt-3">

Phục vụ tận tâm

</h5>


<p>

Luôn đặt trải nghiệm khách hàng
làm ưu tiên.

</p>


</div>


</div>


</div>



</div>


</section>



</asp:Content>