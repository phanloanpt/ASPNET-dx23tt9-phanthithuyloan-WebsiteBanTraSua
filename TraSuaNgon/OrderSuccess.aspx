<%@ Page Title="Đặt hàng thành công"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="OrderSuccess.aspx.cs"
    Inherits="TraSuaNgon.OrderSuccess" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="container mt-4 mb-5">

    <div class="receipt shadow-sm" id="invoiceArea">

        <!-- HEADER -->
        <div class="text-center">

            <h2 class="store-name">
                TRÀ SỮA NGON
            </h2>

            <div class="receipt-title">
                PHIẾU THANH TOÁN
            </div>

            <div class="small-text">
                123 Đường ABC, TP.HCM
            </div>

            <div class="small-text">
                Hotline: 0909 999 999
            </div>

            <div class="small-text">
                08:00 - 22:00
            </div>

        </div>

        <hr />

        <!-- THÔNG TIN ĐƠN -->
        <table class="info-table">

            <tr>
                <td>Mã đơn</td>
                <td class="text-end">
                    #<asp:Label
                        ID="lblOrderID"
                        runat="server">
                    </asp:Label>
                </td>
            </tr>

            <tr>
                <td>Ngày</td>
                <td class="text-end">
                    <asp:Label
                        ID="lblOrderDate"
                        runat="server">
                    </asp:Label>
                </td>
            </tr>

            <tr>
                <td>Khách</td>
                <td class="text-end">
                    <asp:Label
                        ID="lblCustomerName"
                        runat="server">
                    </asp:Label>
                </td>
            </tr>

            <tr>
                <td>SĐT</td>
                <td class="text-end">
                    <asp:Label
                        ID="lblPhone"
                        runat="server">
                    </asp:Label>
                </td>
            </tr>

        </table>

        <hr />

        <!-- CHI TIẾT -->
        <asp:GridView
            ID="gvOrderDetails"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="table receipt-table"
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
                    DataFormatString="{0:N0}" />

                <asp:BoundField
                    HeaderText="TT"
                    DataField="SubTotal"
                    DataFormatString="{0:N0}" />

            </Columns>

        </asp:GridView>

        <hr />

        <!-- TỔNG TIỀN -->
        <table class="info-table">

            <tr>
                <td>
                    <strong>Tổng tiền</strong>
                </td>

                <td class="text-end">
                    <strong>
                        <asp:Label
                            ID="lblTotal"
                            runat="server">
                        </asp:Label> đ
                    </strong>
                </td>
            </tr>

            <tr>
                <td>Thanh toán</td>
                <td class="text-end">
                    COD
                </td>
            </tr>

        </table>

        <hr />

        <!-- FOOTER -->
        <div class="text-center">

            <p class="mb-1">
                ♥ Cảm ơn quý khách đã sử dụng dịch vụ ♥
            </p>

            <strong>
                TRÀ SỮA NGON
            </strong>

            <div class="small-text">
                Hotline: 0909 999 999
            </div>

        </div>

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


<style>

.receipt
{
    width:320px;
    margin:auto;
    padding:20px;
    background:white;
    border:1px dashed #999;
    font-family:Consolas, monospace;
    font-size:14px;
}

.store-name
{
    font-size:28px;
    font-weight:bold;
    margin-bottom:5px;
}

.receipt-title
{
    font-size:22px;
    font-weight:bold;
    margin-bottom:10px;
}

.small-text
{
    font-size:12px;
}

.info-table
{
    width:100%;
}

.info-table td
{
    padding:4px 0;
}

.receipt-table
{
    width:100%;
    font-size:13px;
}

.receipt-table th
{
    text-align:center;
    border-bottom:1px dashed #999 !important;
}

.receipt-table td
{
    border:none !important;
    padding:6px 2px !important;
}

hr
{
    border-top:1px dashed #999;
    margin:12px 0;
}

/* IN HÓA ĐƠN */
@media print
{
    body *
    {
        visibility:hidden;
    }

    #invoiceArea,
    #invoiceArea *
    {
        visibility:visible;
    }

    #invoiceArea
    {
        position:absolute;
        left:0;
        top:0;
        width:80mm;
        border:none;
        box-shadow:none;
        margin:0;
        padding:10px;
    }

    .no-print
    {
        display:none !important;
    }

    header,
    footer,
    .navbar
    {
        display:none !important;
    }
}

</style>

</asp:Content>