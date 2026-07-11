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


    <h2 class="text-center mb-4">
        <i class="fa-solid fa-mug-hot"></i>
        Menu Trà Sữa NGON
    </h2>



    <!-- Thanh tìm kiếm -->

    <div class="row mb-4">

        <div class="col-md-8 mx-auto">

            <div class="input-group">


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




    <!-- Danh sách sản phẩm -->


    <div class="row">


        <asp:Repeater ID="rptProducts"
            runat="server">


            <ItemTemplate>


                <div class="col-lg-3 col-md-4 col-sm-6 mb-4">


                    <div class="card product-card h-100 shadow-sm">



                        <div class="position-relative">


                            <img src='<%# ResolveUrl("~/Assets/images/products/" + Eval("ImageURL")) %>'
                                 class="card-img-top product-img"
                                 alt="<%# Eval("ProductName") %>" />



                            <%# Convert.ToBoolean(Eval("IsNew")) 
                                ? "<span class='badge bg-success position-absolute top-0 start-0 m-2'>NEW</span>" 
                                : "" %>



                            <%# Convert.ToBoolean(Eval("IsBestSeller")) 
                                ? "<span class='badge bg-danger position-absolute top-0 end-0 m-2'>BEST SELLER</span>" 
                                : "" %>


                        </div>




                        <div class="card-body text-center">


                            <h5 class="card-title">
                                <%# Eval("ProductName") %>
                            </h5>



                            <p class="text-danger fw-bold">

                                <%# Eval("PriceM","{0:N0}") %> đ

                            </p>



                            <p class="text-muted small">

                                <%# Eval("Description") %>

                            </p>





                            <a href='ProductDetail.aspx?id=<%# Eval("ProductID") %>'
                               class="btn btn-outline-primary">

                                Xem chi tiết

                            </a>



                            <button class="btn btn-danger">

                                <i class="fa fa-cart-plus"></i>

                                Thêm giỏ hàng

                            </button>



                        </div>


                    </div>


                </div>



            </ItemTemplate>


        </asp:Repeater>


    </div>



</section>


</asp:Content>