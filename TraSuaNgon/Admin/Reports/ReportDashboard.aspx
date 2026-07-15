<%@ Page Title="Báo cáo thống kê"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="ReportDashboard.aspx.cs"
    Inherits="TraSuaNgon.Admin.Reports.ReportDashboard" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<style>

.report-card{
    background:#fff5f8;
    border:1px solid #f3d1dd;
    border-radius:15px;
}

.report-card .card-header{
    background:#e91e63;
    color:white;
}

.report-table th{
    background:#fff0f5;
    color:#ad1457;
}

.report-table td{
    border-color:#f3d1dd;
}

.card{
    border-radius:15px;
}

</style>


<div class="container-fluid mt-4">

    <h2 class="text-danger mb-4">
        <i class="fa-solid fa-chart-line"></i>
        Báo cáo & thống kê
    </h2>


    <!-- CARD THỐNG KÊ -->
    <div class="row g-3">

        <div class="col-lg-3 col-md-6">
            <div class="card shadow report-card h-100 text-center">
                <div class="card-body">

                    <h6 class="text-muted">
                        Tổng đơn hàng
                    </h6>

                    <h2 class="text-danger fw-bold">
                        <asp:Label
                            ID="lblTotalOrders"
                            runat="server"
                            Text="0" />
                    </h2>

                </div>
            </div>
        </div>


        <div class="col-lg-3 col-md-6">
            <div class="card shadow report-card h-100 text-center">
                <div class="card-body">

                    <h6 class="text-muted">
                        Tổng doanh thu
                    </h6>

                    <h2 class="text-success fw-bold">
                        <asp:Label
                            ID="lblRevenue"
                            runat="server"
                            Text="0 đ" />
                    </h2>

                </div>
            </div>
        </div>


        <div class="col-lg-3 col-md-6">
            <div class="card shadow report-card h-100 text-center">
                <div class="card-body">

                    <h6 class="text-muted">
                        Đơn hoàn thành
                    </h6>

                    <h2 class="text-primary fw-bold">
                        <asp:Label
                            ID="lblCompleted"
                            runat="server"
                            Text="0" />
                    </h2>

                </div>
            </div>
        </div>


        <div class="col-lg-3 col-md-6">
            <div class="card shadow report-card h-100 text-center">
                <div class="card-body">

                    <h6 class="text-muted">
                        Đơn đã hủy
                    </h6>

                    <h2 class="text-danger fw-bold">
                        <asp:Label
                            ID="lblCancelled"
                            runat="server"
                            Text="0" />
                    </h2>

                </div>
            </div>
        </div>

    </div>


    <!-- TRẠNG THÁI ĐƠN HÀNG -->
    <div class="card shadow report-card mt-4">

        <div class="card-header">
            Trạng thái đơn hàng
        </div>

        <div class="card-body">

            <table class="table table-bordered table-hover report-table">

                <tr>
                    <th width="40%">
                        Chờ xác nhận
                    </th>

                    <td>
                        <asp:Label
                            ID="lblPending"
                            runat="server"
                            Text="0" />
                    </td>
                </tr>

                <tr>
                    <th>
                        Đang pha chế
                    </th>

                    <td>
                        <asp:Label
                            ID="lblProcessing"
                            runat="server"
                            Text="0" />
                    </td>
                </tr>

                <tr>
                    <th>
                        Đang giao
                    </th>

                    <td>
                        <asp:Label
                            ID="lblShipping"
                            runat="server"
                            Text="0" />
                    </td>
                </tr>

            </table>

        </div>

    </div>


    <hr class="my-5" />


    <div class="row">

        <!-- TOP BÁN CHẠY -->
        <div class="col-lg-6">

            <div class="card shadow report-card h-100">

                <div class="card-header" style="background:#A52A2A;color:white">
                    Top 5 sản phẩm bán chạy
                </div>

                <div class="card-body">

                    <asp:GridView
                        ID="gvBestSeller"
                        runat="server"
                        CssClass="table table-hover report-table"
                        AutoGenerateColumns="false"
                        EmptyDataText="Chưa có dữ liệu">

                        <Columns>

                            <asp:BoundField
                                DataField="ProductName"
                                HeaderText="Sản phẩm" />

                            <asp:BoundField
                                DataField="QuantitySold"
                                HeaderText="Đã bán" />

                        </Columns>

                    </asp:GridView>

                </div>

            </div>

        </div>


        <!-- KHO THẤP -->
        <div class="col-lg-6">

            <div class="card shadow report-card h-100">

                <div class="card-header"
    style="background:#3D2314;color:white;">
    Cảnh báo tồn kho thấp
</div>

                <div class="card-body">

                    <asp:GridView
                        ID="gvLowStock"
                        runat="server"
                        CssClass="table table-hover report-table"
                        AutoGenerateColumns="false"
                        EmptyDataText="Không có vật tư sắp hết">

                        <Columns>

                            <asp:BoundField
                                DataField="ItemName"
                                HeaderText="Vật tư" />

                            <asp:BoundField
                                DataField="Quantity"
                                HeaderText="Còn lại" />

                            <asp:BoundField
                                DataField="MinimumQuantity"
                                HeaderText="Tối thiểu" />

                        </Columns>

                    </asp:GridView>

                </div>

            </div>

        </div>

    </div>

</div>

</asp:Content>