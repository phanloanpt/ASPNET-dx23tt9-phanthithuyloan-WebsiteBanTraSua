<%@ Page Title="Dashboard"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs"
    Inherits="TraSuaNgon.Admin.Dashboard" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="container-fluid mt-4">

    <h2 class="text-danger mb-4">
        <i class="fa-solid fa-gauge-high"></i>
        Dashboard quản trị
    </h2>


    <div class="row g-4">

        <!-- Sản phẩm -->
        <div class="col-lg-3 col-md-6">
            <div class="card shadow border-0 h-100">
                <div class="card-body text-center">

                    <i class="fa-solid fa-mug-hot fa-3x text-danger mb-3"></i>

                    <h5>Sản phẩm</h5>

                    <p class="text-muted">
                        Quản lý danh sách sản phẩm
                    </p>

                    <a href="../Admin/Products/ProductList.aspx"
                        class="btn btn-danger">
                        Quản lý
                    </a>

                </div>
            </div>
        </div>


        <!-- Đơn hàng -->
        <div class="col-lg-3 col-md-6">
            <div class="card shadow border-0 h-100">
                <div class="card-body text-center">

                    <i class="fa-solid fa-cart-shopping fa-3x text-primary mb-3"></i>

                    <h5>Đơn hàng</h5>

                    <p class="text-muted">
                        Theo dõi đơn hàng khách đặt
                    </p>

                    <a href="../Admin/Orders/OrderList.aspx"
                        class="btn btn-primary">
                        Quản lý
                    </a>

                </div>
            </div>
        </div>


        <!-- Kho -->
        <div class="col-lg-3 col-md-6">
            <div class="card shadow border-0 h-100">
                <div class="card-body text-center">

                    <i class="fa-solid fa-boxes-stacked fa-3x text-success mb-3"></i>

                    <h5>Kho vật tư</h5>

                    <p class="text-muted">
                        Nhập kho và quản lý tồn kho
                    </p>

                    <a href="../Admin/Inventory/InventoryList.aspx"
                        class="btn btn-success">
                        Quản lý
                    </a>

                </div>
            </div>
        </div>


        <!-- Báo cáo -->
        <div class="col-lg-3 col-md-6">
            <div class="card shadow border-0 h-100">
                <div class="card-body text-center">

                    <i class="fa-solid fa-chart-line fa-3x text-warning mb-3"></i>

                    <h5>Thống kê</h5>

                    <p class="text-muted">
                        Xem doanh thu và báo cáo
                    </p>

                    <a href="../Admin/Reports/ReportDashboard.aspx"
                        class="btn btn-warning text-white">
                        Xem báo cáo
                    </a>

                </div>
            </div>
        </div>

    </div>


    <div class="card shadow mt-5">

        <div class="card-header bg-danger text-white">
            Truy cập nhanh
        </div>

        <div class="card-body">

            <div class="row text-center">

                <div class="col-md-3 mb-3">
                    <a href="../Admin/Products/ProductAdd.aspx"
                        class="btn btn-outline-danger w-100">
                        + Thêm sản phẩm
                    </a>
                </div>

                <div class="col-md-3 mb-3">
                    <a href="../Admin/Inventory/InventoryImport.aspx"
                        class="btn btn-outline-success w-100">
                        + Nhập kho
                    </a>
                </div>

                <div class="col-md-3 mb-3">
                    <a href="../Admin/Orders/OrderList.aspx"
                        class="btn btn-outline-primary w-100">
                        Xem đơn hàng
                    </a>
                </div>

                <div class="col-md-3 mb-3">
                    <a href="../Admin/Reports/ReportDashboard.aspx"
                        class="btn btn-outline-warning w-100">
                        Xem thống kê
                    </a>
                </div>

            </div>

        </div>

    </div>

</div>

</asp:Content>