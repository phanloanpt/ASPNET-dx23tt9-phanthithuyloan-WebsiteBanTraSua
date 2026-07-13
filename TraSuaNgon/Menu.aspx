<%@ Page Title="Menu Trà Sữa"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Menu.aspx.cs"
    Inherits="TraSuaNgon.Menu" %>


<asp:Content ID="BodyContent"
    ContentPlaceHolderID="MainContent"
    runat="server">


<section class="container mt-5">


    <!-- TIÊU ĐỀ -->

    <h2 class="text-center mb-4">

        <i class="fa-solid fa-mug-hot text-danger"></i>

        Menu Trà Sữa NGON

    </h2>



   <!-- ===========================
     TÌM KIẾM + LỌC DANH MỤC
=========================== -->

<!-- ===========================
     FILTER LEFT - SEARCH RIGHT
=========================== -->

<div class="row mb-4 align-items-center">


    <!-- Bên trái: Lọc danh mục -->
    <div class="col-lg-6 col-md-6 col-12 text-lg-start text-md-start text-center mb-3 mb-md-0">


        <a href="Menu.aspx"
            class="btn btn-outline-dark m-1">
            Tất cả
        </a>


        <a href="Menu.aspx?category=1"
            class="btn btn-outline-primary m-1">
            Trà sữa
        </a>


        <a href="Menu.aspx?category=2"
            class="btn btn-outline-success m-1">
            Trà trái cây
        </a>


    </div>




    <!-- Bên phải: Tìm kiếm -->
    <div class="col-lg-6 col-md-6 col-12">


        <div class="input-group justify-content-end">


            <asp:TextBox ID="txtSearch"
                runat="server"
                CssClass="form-control"
                placeholder="Tìm kiếm trà sữa...">
            </asp:TextBox>


            <asp:Button ID="btnSearch"
                runat="server"
                Text="Tìm kiếm"
                CssClass="btn btn-danger"
                OnClick="btnSearch_Click" />


        </div>


    </div>


</div>



    <!-- DANH SÁCH SẢN PHẨM -->

    <div class="row">


        <asp:Repeater ID="rptProducts"
            runat="server">


            <ItemTemplate>


                <div class="col-lg-3 col-md-4 col-sm-6 mb-4">


                    <div class="card product-card h-100 shadow-sm">



                        <!-- ẢNH -->

                        <div class="position-relative">


                            <img src='<%# ResolveUrl("~/Assets/images/products/" + Eval("ImageURL")) %>'
                                class="card-img-top product-img"
                                alt="<%# Eval("ProductName") %>" />



                            <%# Convert.ToBoolean(Eval("IsNew")) 
                                ?
                                "<span class='badge bg-success position-absolute top-0 start-0 m-2'>NEW</span>"
                                :
                                "" %>



                            <%# Convert.ToBoolean(Eval("IsBestSeller"))
                                ?
                                "<span class='badge bg-danger position-absolute top-0 end-0 m-2'>BEST SELLER</span>"
                                :
                                "" %>


                        </div>





                        <!-- THÔNG TIN -->

                        <div class="card-body text-center">



                            <h5 class="fw-bold">

                                <%# Eval("ProductName") %>

                            </h5>



                            <p class="text-danger fw-bold fs-5">

                                <%# Eval("PriceM","{0:N0}") %> đ

                            </p>



                            <p class="text-muted small">

                                <%# Eval("Description") %>

                            </p>





                            <div class="d-flex justify-content-center gap-2 mt-3">

    <a href='ProductDetail.aspx?id=<%# Eval("ProductID") %>'
        class="btn btn-outline-primary btn-sm">
        <i class="fa fa-info-circle"></i>
        Xem chi tiết
    </a>

    <a href='Cart.aspx?add=<%# Eval("ProductID") %>'
        class="btn btn-danger btn-sm">
        <i class="fa fa-shopping-cart"></i>
        Đặt ngay
    </a>

</div>



                        </div>



                    </div>


                </div>



            </ItemTemplate>


        </asp:Repeater>


    </div>







    <!-- ========================= -->
    <!-- DANH SÁCH TOPPING -->
    <!-- ========================= -->


    <hr class="my-5" />


    <h3 class="text-center mb-4">


        <i class="fa-solid fa-plus text-danger"></i>

        Topping thêm


    </h3>





    <div class="row">



        <asp:Repeater ID="rptToppingList"
            runat="server">


            <ItemTemplate>



                <div class="col-lg-2 col-md-3 col-sm-4 col-6 mb-4">



                    <div class="card shadow-sm h-100">





                        <img src='<%# ResolveUrl("~/Assets/images/toppings/" + Eval("ImageURL")) %>'
                             class="card-img-top"
                             style="height:120px;object-fit:cover;"
                             alt="<%# Eval("ToppingName") %>" />





                        <div class="card-body text-center p-2">



                            <h6 class="fw-bold">

                                <%# Eval("ToppingName") %>

                            </h6>




                            <p class="text-danger mb-0">


                                + <%# Eval("Price","{0:N0}") %> đ


                            </p>



                        </div>



                    </div>



                </div>



            </ItemTemplate>



        </asp:Repeater>



    </div>
    <!-- ===========================
     DANH SÁCH TOPPING
=========================== -->







<div class="row">


    <asp:Repeater ID="rptToppings"
        runat="server">


        <ItemTemplate>


            <div class="col-lg-2 col-md-3 col-sm-4 col-6 mb-4">


                <div class="card shadow-sm h-100 text-center">


                    <img src='<%# ResolveUrl("~/Assets/images/toppings/" + Eval("ImageURL")) %>'
                         class="card-img-top"
                         style="height:120px;object-fit:cover;"
                         alt="<%# Eval("ToppingName") %>" />



                    <div class="card-body">


                        <h6 class="card-title">
                            <%# Eval("ToppingName") %>
                        </h6>



                        <p class="text-danger fw-bold">

                            +
                            <%# Eval("Price","{0:N0}") %>
                            đ

                        </p>


                    </div>


                </div>


            </div>


        </ItemTemplate>


    </asp:Repeater>


</div>




</section>



</asp:Content>