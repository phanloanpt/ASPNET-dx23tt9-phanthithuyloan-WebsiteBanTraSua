<%@ Page Title="Đặt hàng thành công"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="OrderSuccess.aspx.cs"
    Inherits="TraSuaNgon.OrderSuccess" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">
    <hr />



<div class="container mt-5 mb-5">

    <div class="card shadow">

       <div class="card-body p-4" id="invoiceArea">

    <!-- CỬA HÀNG -->
    <div class="text-center mb-3">

        <h2 class="fw-bold text-danger mb-1">
            TRÀ SỮA NGON
        </h2>

        <small>
            123 Đường ABC, TP.HCM |
            Hotline: 0909 999 999
        </small>

        <br />

        <small>
            Mở cửa: 08:00 - 22:00
        </small>

    </div>

    <hr />

    <!-- THÀNH CÔNG -->
    <div class="text-center mb-3">

        <h3 class="text-success">
            <i class="fa-solid fa-circle-check"></i>
            Đặt hàng thành công
        </h3>

        <p class="mb-0">
            Cảm ơn bạn đã mua hàng tại
            <strong>Trà Sữa NGON</strong>
        </p>

    </div>

    <!-- THÔNG TIN ĐƠN -->
    <div class="row mt-4 mb-3">

        <div class="col-md-6">

            <p class="mb-1">
                <strong>Mã đơn:</strong>
                #<asp:Label ID="lblOrderID"
                    runat="server"></asp:Label>
            </p>

            <p class="mb-1">
                <strong>Khách hàng:</strong>
                <asp:Label ID="lblCustomerName"
                    runat="server"></asp:Label>
            </p>

        </div>

        <div class="col-md-6">

            <p class="mb-1">
                <strong>SĐT:</strong>
                <asp:Label ID="lblPhone"
                    runat="server"></asp:Label>
            </p>

            <p class="mb-1">
                <strong>Ngày đặt:</strong>
                <asp:Label ID="lblOrderDate"
                    runat="server"></asp:Label>
            </p>

        </div>

    </div>

    <!-- CHI TIẾT -->
    <h5 class="text-danger mb-3">
        Chi tiết đơn hàng
    </h5>

    <asp:GridView
        ID="gvOrderDetails"
        runat="server"
        AutoGenerateColumns="False"
        CssClass="table table-bordered text-center">

        <Columns>

            <asp:BoundField
                HeaderText="Sản phẩm"
                DataField="ProductName" />

            <asp:BoundField
                HeaderText="Size"
                DataField="Size" />

            <asp:BoundField
                HeaderText="SL"
                DataField="Quantity" />

            <asp:BoundField
                HeaderText="Thành tiền"
                DataField="SubTotal"
                DataFormatString="{0:N0} đ" />

        </Columns>

    </asp:GridView>

    <!-- TỔNG -->
    <div class="text-end">

        <h4 class="text-danger fw-bold">

            Tổng cộng:

            <asp:Label
                ID="lblTotal"
                runat="server">
            </asp:Label>

            đ

        </h4>

    </div>

    <div class="text-center mt-3">

        <small class="text-muted">
            Chúng tôi sẽ liên hệ xác nhận đơn hàng sớm nhất.
        </small>

    </div>

    <!-- BUTTON -->
    <div class="text-center mt-4 no-print">

        <button type="button"
            class="btn btn-dark me-2"
            onclick="window.print()">

            <i class="fa-solid fa-print"></i>
            In hóa đơn

        </button>

        <a href="Default.aspx"
            class="btn btn-danger">

            <i class="fa-solid fa-house"></i>
            Về trang chủ

        </a>

    </div>

</div>

    </div>

</div>

<style>

@media print
{
    header,
    footer,
    .navbar,
    .no-print
    {
        display:none !important;
    }

    body
    {
        background:#fff !important;
    }

    .card
    {
        border:none !important;
        box-shadow:none !important;
    }

    #invoiceArea
    {
        width:100%;
        margin:0;
        padding:0;
    }

    table
    {
        font-size:12px;
    }

    h2,h3,h4,h5
    {
        margin-bottom:10px;
    }
}

</style>

</asp:Content>