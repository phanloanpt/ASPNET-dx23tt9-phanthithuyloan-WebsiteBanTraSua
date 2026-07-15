<%@ Page Title="Đặt hàng thành công"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="OrderSuccess.aspx.cs"
    Inherits="TraSuaNgon.OrderSuccess" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="container mt-5 mb-5">

    <div class="order-card shadow">

        <!-- HEADER -->
        <div class="text-center mb-4">

            <div class="success-icon">
                <i class="fa-solid fa-circle-check"></i>
            </div>

            <h2 class="store-name">
                TRÀ SỮA NGON
            </h2>

            <h3 class="success-title">
                Đặt hàng thành công 🎉
            </h3>

            <p class="text-muted">
                Cảm ơn quý khách đã đặt hàng.
                Đơn hàng của bạn đang được xử lý.
            </p>

        </div>


        <!-- THÔNG TIN ĐƠN -->
        <div class="section-box">

            <h5>
                <i class="fa-solid fa-receipt"></i>
                Thông tin đơn hàng
            </h5>

            <table class="info-table">

                <tr>
                    <td>Mã đơn hàng</td>
                    <td>
                        #<asp:Label 
                            ID="lblOrderID"
                            runat="server">
                        </asp:Label>
                    </td>
                </tr>


                <tr>
                    <td>Ngày đặt</td>
                    <td>
                        <asp:Label
                            ID="lblOrderDate"
                            runat="server">
                        </asp:Label>
                    </td>
                </tr>


                <tr>
                    <td>Thanh toán</td>
                    <td>
                        COD
                    </td>
                </tr>


                <tr>
                    <td>Trạng thái</td>
                    <td>
                        <span class="badge bg-warning text-dark">
                            Đang xử lý
                        </span>
                    </td>
                </tr>

            </table>

        </div>



        <!-- KHÁCH HÀNG -->
        <div class="section-box">

            <h5>
                <i class="fa-solid fa-user"></i>
                Thông tin khách hàng
            </h5>


            <table class="info-table">

                <tr>
                    <td>Họ tên</td>
                    <td>
                        <asp:Label
                            ID="lblCustomerName"
                            runat="server">
                        </asp:Label>
                    </td>
                </tr>


                <tr>
                    <td>Số điện thoại</td>
                    <td>
                        <asp:Label
                            ID="lblPhone"
                            runat="server">
                        </asp:Label>
                    </td>
                </tr>


            </table>

        </div>




        <!-- CHI TIẾT MÓN -->
        <div class="section-box">

            <h5>
                <i class="fa-solid fa-mug-hot"></i>
                Chi tiết món đã đặt
            </h5>


            <asp:GridView
                ID="gvOrderDetails"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="table order-table"
                GridLines="None">


                <Columns>


                    <asp:BoundField
                        HeaderText="Sản phẩm"
                        DataField="ProductName" />


                    <asp:BoundField
                        HeaderText="SL"
                        DataField="Quantity" />


                    <asp:BoundField
                        HeaderText="Đơn giá"
                        DataField="UnitPrice"
                        DataFormatString="{0:N0} đ" />


                    <asp:BoundField
                        HeaderText="Thành tiền"
                        DataField="SubTotal"
                        DataFormatString="{0:N0} đ" />


                </Columns>


            </asp:GridView>


        </div>




        <!-- TỔNG -->
        <div class="total-box">

            <span>
                Tổng thanh toán
            </span>


            <strong>

                <asp:Label
                    ID="lblTotal"
                    runat="server">
                </asp:Label>

                đ

            </strong>

        </div>



        <!-- FOOTER -->
        <div class="text-center mt-4">

            <p>
                ❤️ Trà Sữa NGON rất vui được phục vụ quý khách ❤️
            </p>


            <a href="Default.aspx"
               class="btn btn-danger">

                <i class="fa-solid fa-house"></i>
                Về trang chủ

            </a>


            <a href="Menu.aspx"
               class="btn btn-outline-danger ms-2">

                <i class="fa-solid fa-cart-shopping"></i>
                Mua thêm

            </a>

        </div>


    </div>


</div>



<style>

.order-card
{
    max-width:750px;
    margin:auto;
    background:white;
    padding:35px;
    border-radius:20px;
}


.success-icon
{
    font-size:55px;
    color:#28a745;
}


.store-name
{
    color:#e91e63;
    font-weight:bold;
}


.success-title
{
    font-weight:bold;
    margin-top:10px;
}



.section-box
{
    background:#fafafa;
    padding:20px;
    border-radius:15px;
    margin-bottom:20px;
}



.section-box h5
{
    color:#e91e63;
    font-weight:bold;
    margin-bottom:15px;
}



.info-table
{
    width:100%;
}


.info-table td
{
    padding:8px;
}


.info-table td:first-child
{
    font-weight:600;
    width:40%;
}



.order-table th
{
    background:#f8f9fa;
}


.order-table td,
.order-table th
{
    padding:12px !important;
}



.total-box
{
    display:flex;
    justify-content:space-between;
    background:#fff0f5;
    padding:20px;
    border-radius:15px;
    font-size:20px;
}


.total-box strong
{
    color:#e91e63;
}


</style>


</asp:Content>