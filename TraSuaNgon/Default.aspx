<%@ Page Title="Trang chủ" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="TraSuaNgon.Default" %>


<asp:Content ID="BodyContent" 
    ContentPlaceHolderID="MainContent" 
    runat="server">



<!-- ================= CAROUSEL ================= -->
   <style> #mainCarousel
{
    width:100vw;
    margin-left:calc(50% - 50vw);
    margin-top:-40px;
}

.banner-img
{
    height:650px;
    object-fit:cover;
}
       </style>

<div id="mainCarousel" 
     class="carousel slide" 
     data-bs-ride="carousel">


    <div class="carousel-inner">


        <div class="carousel-item active">

            <img src='<%= ResolveUrl("~/Assets/images/banners/banner4.jpg") %>'
     class="d-block w-100 banner-img"
     alt="Trà sữa NGON" />

        </div>


        <div class="carousel-item">

            <img src='<%= ResolveUrl("~/Assets/images/banners/banner5.jpg") %>'
                 class="d-block w-100 banner-img"
                 alt="Trà sữa">

        </div>


        <div class="carousel-item">

            <img src='<%= ResolveUrl("~/Assets/images/banners/banner6.jpg") %>'
                 class="d-block w-100 banner-img"
                 alt="Khuyến mãi">

        </div>


    </div>


    <button class="carousel-control-prev"
            type="button"
            data-bs-target="#mainCarousel"
            data-bs-slide="prev">

        <span class="carousel-control-prev-icon"></span>

    </button>


    <button class="carousel-control-next"
            type="button"
            data-bs-target="#mainCarousel"
            data-bs-slide="next">

        <span class="carousel-control-next-icon"></span>

    </button>


</div>

<!-- ================= TÌM KIẾM ================= -->

<section class="container mt-4 mb-5">

    <div class="search-box shadow-sm">

        <div class="row g-2">

            <div class="col-md-10">

                <asp:TextBox ID="txtSearch"
                    runat="server"
                    CssClass="form-control form-control-lg"
                    placeholder="Tìm kiếm trà sữa, topping..." />

            </div>

            <div class="col-md-2">

                <asp:Button ID="btnSearch"
                    runat="server"
                    Text="Tìm kiếm"
                    CssClass="btn btn-success w-100 btn-lg"
                    OnClick="btnSearch_Click" />

            </div>

        </div>

    </div>

</section>


<!-- ================= SẢN PHẨM NỔI BẬT ================= -->


<section class="container mt-5">


<h2 class="text-center mb-4 title-featured">
    <i class="fa-solid fa-star section-icon"></i>
    Sản phẩm nổi bật
</h2>



<div class="row">


<asp:Repeater ID="rptProducts" runat="server">


<ItemTemplate>


<div class="col-lg-3 col-md-4 col-sm-6 mb-4">


<div class="card product-card h-100">


<div class="position-relative">


<img src='<%# ResolveUrl("~/Assets/images/products/" + Eval("ImageURL")) %>'
     class="card-img-top product-img"
     alt="<%# Eval("ProductName") %>" />


</div>




<div class="card-body text-center">


<h5 class="card-title">

<%# Eval("ProductName") %>

</h5>



<p class="text-danger fw-bold">
    <%# Eval("PriceM","{0:N0}") %> đ
</p>




<div class="d-flex justify-content-center gap-2 mt-3">

    <a href='ProductDetail.aspx?id=<%# Eval("ProductID") %>'
       class="btn btn-outline-primary">

        <i class="fa-solid fa-circle-info"></i>
        Xem chi tiết

    </a>

    <a href='ProductDetail.aspx?id=<%# Eval("ProductID") %>'
       class="btn btn-danger">

        <i class="fa-solid fa-cart-shopping"></i>
        Đặt ngay

    </a>

</div>



</div>


</div>


</div>


</ItemTemplate>


</asp:Repeater>


</div>


</section>



    <hr class="section-divider" />



<!-- ================= SẢN PHẨM MỚI ================= -->


<section class="container mt-5">


<h2 class="text-center mb-4 title-new">
    <i class="fa-solid fa-mug-hot section-icon"></i>
    Sản phẩm mới
</h2>




<div class="row">


<asp:Repeater ID="rptNewProducts" runat="server">


<ItemTemplate>


<div class="col-lg-3 col-md-4 col-sm-6 mb-4">


<div class="card product-card h-100">


<div class="position-relative">



<span class="badge bg-success position-absolute top-0 start-0 m-2">

NEW

</span>



<img src='<%# ResolveUrl("~/Assets/images/products/" + Eval("ImageURL")) %>'
     class="card-img-top product-img"
     alt="<%# Eval("ProductName") %>" />



</div>





<div class="card-body text-center">


<h5>

<%# Eval("ProductName") %>

</h5>



<p class="text-danger fw-bold">
    <%# Eval("PriceM","{0:N0}") %> đ
</p>




<div class="d-flex justify-content-center gap-2 mt-3">

    <a href='ProductDetail.aspx?id=<%# Eval("ProductID") %>'
       class="btn btn-outline-primary">

        <i class="fa-solid fa-circle-info"></i>
        Xem chi tiết

    </a>

    <a href='ProductDetail.aspx?id=<%# Eval("ProductID") %>'
       class="btn btn-danger">

        <i class="fa-solid fa-cart-shopping"></i>
        Đặt ngay

    </a>

</div>



</div>


</div>


</div>


</ItemTemplate>


</asp:Repeater>


</div>


</section>




<hr class="section-divider" />




<!-- ================= BEST SELLER ================= -->


<section class="container mt-5">


<h2 class="text-center mb-4 title-best">
    <i class="fa-solid fa-fire section-icon"></i>
    Best Seller
</h2>





<div class="row">


<asp:Repeater ID="rptBestSeller" runat="server">


<ItemTemplate>


<div class="col-lg-3 col-md-4 col-sm-6 mb-4">


<div class="card product-card h-100">


<div class="position-relative">



<span class="badge bg-danger position-absolute top-0 start-0 m-2">

BEST SELLER

</span>





<img src='<%# ResolveUrl("~/Assets/images/products/" + Eval("ImageURL")) %>'
     class="card-img-top product-img"
     alt="<%# Eval("ProductName") %>" />



</div>





<div class="card-body text-center">


<h5>

<%# Eval("ProductName") %>

</h5>



<p class="text-danger fw-bold">
    <%# Eval("PriceM","{0:N0}") %> đ
</p>



<div class="d-flex justify-content-center gap-2 mt-3">

    <a href='ProductDetail.aspx?id=<%# Eval("ProductID") %>'
       class="btn btn-outline-primary">

        <i class="fa-solid fa-circle-info"></i>
        Xem chi tiết

    </a>

    <a href='ProductDetail.aspx?id=<%# Eval("ProductID") %>'
       class="btn btn-danger">

        <i class="fa-solid fa-cart-shopping"></i>
        Đặt ngay

    </a>

</div>



</div>


</div>


</div>


</ItemTemplate>


</asp:Repeater>


</div>


</section>





<hr class="section-divider" />



<!-- ================= NEWS ================= -->






<section class="container mt-5 mb-5">

    <h2 class="text-center mb-4 title-news">
        <i class="fa-solid fa-newspaper"></i>
        Tin tức & Khuyến mãi
    </h2>

    <div class="row">

        <!-- Tin chính -->
        <div class="col-lg-8">

            <asp:Repeater ID="rptMainNews" runat="server">
                <ItemTemplate>

                    <div class="card shadow">

                        <img src='<%# Eval("ImageURL") %>'
     class="img-fluid main-news-img" />
                            

                        <div class="card-body">

                            <h3>
                                <%# Eval("Title") %>
                            </h3>

                            <p>
                                <%# Eval("Summary") %>
                            </p>

                            <a href='NewsDetail.aspx?id=<%# Eval("NewsID") %>'
                               class="btn btn-success">
                                Xem thêm
                            </a>

                        </div>

                    </div>

                </ItemTemplate>
            </asp:Repeater>

        </div>

        <!-- 3 tin nhỏ -->
        <div class="col-lg-4">

            <asp:Repeater ID="rptSubNews" runat="server">
    <ItemTemplate>

        <div class="card mb-3 shadow-sm border-0 sub-news-card">

            <div class="row g-0 h-100">

                <!-- Ảnh -->
                <div class="col-4">
                    <img src='<%# Eval("ImageURL") %>'
     class="img-fluid h-100 w-100 sub-news-img"
     alt="<%# Eval("Title") %>" />
                </div>

                <!-- Nội dung -->
                <div class="col-8">

                    <div class="card-body d-flex flex-column h-100">

                        <h6 class="fw-bold mb-2">
                            <%# Eval("Title") %>
                        </h6>

                        <p class="text-muted small flex-grow-1">
                            <%# Eval("Summary") %>
                        </p>

                        <a href='NewsDetail.aspx?id=<%# Eval("NewsID") %>'
                           class="text-success fw-bold text-decoration-none">
                            Xem thêm →
                        </a>

                    </div>

                </div>

            </div>

        </div>

    </ItemTemplate>
</asp:Repeater>

        </div>

    </div>

</section>







</asp:Content>