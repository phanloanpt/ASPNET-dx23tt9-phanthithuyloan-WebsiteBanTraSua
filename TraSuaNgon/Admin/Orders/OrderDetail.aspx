<%@ Page Title="Chi tiết đơn hàng"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="OrderDetail.aspx.cs"
    Inherits="TraSuaNgon.Admin.Orders.OrderDetail" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="container-fluid mt-4">

    <h2 class="text-danger mb-4">
        <i class="fa-solid fa-file-invoice"></i>
        Chi tiết đơn hàng
    </h2>

    <div class="card shadow">

        <div class="card-body">

            <!-- THÔNG TIN ĐƠN HÀNG -->
            <div class="row">

                <div class="col-md-6">

                    <p>
                        <b>Mã đơn:</b>
                        <asp:Label
                            ID="lblOrderID"
                            runat="server" />
                    </p>

                    <p>
                        <b>Ngày đặt:</b>
                        <asp:Label
                            ID="lblOrderDate"
                            runat="server" />
                    </p>

                    <p>
                        <b>Khách hàng:</b>
                        <asp:Label
                            ID="lblCustomer"
                            runat="server" />
                    </p>

                </div>

                <div class="col-md-6">

                    <p>
                        <b>Số điện thoại:</b>
                        <asp:Label
                            ID="lblPhone"
                            runat="server" />
                    </p>

                    <p>
                        <b>Địa chỉ:</b>
                        <asp:Label
                            ID="lblAddress"
                            runat="server" />
                    </p>

                    <p>
                        <b>Tổng tiền:</b>

                        <asp:Label
                            ID="lblTotal"
                            runat="server"
                            CssClass="text-danger fw-bold fs-5" />
                    </p>

                </div>

            </div>

            <hr />

            <!-- DANH SÁCH SẢN PHẨM -->
            <asp:GridView
                ID="gvDetail"
                runat="server"
                CssClass="table table-bordered table-hover"
                AutoGenerateColumns="false">

                <Columns>

                    <asp:BoundField
                        DataField="ProductName"
                        HeaderText="Sản phẩm" />

                    <asp:BoundField
                        DataField="Size"
                        HeaderText="Size" />

                    <asp:BoundField
                        DataField="ToppingName"
                        HeaderText="Topping" />

                    <asp:BoundField
                        DataField="Quantity"
                        HeaderText="Số lượng" />

                    <asp:BoundField
                        DataField="UnitPrice"
                        HeaderText="Đơn giá"
                        DataFormatString="{0:N0} đ" />

                    <asp:BoundField
                        DataField="SubTotal"
                        HeaderText="Thành tiền"
                        DataFormatString="{0:N0} đ" />

                </Columns>

            </asp:GridView>

            <hr />

            <!-- TRẠNG THÁI -->
            <div class="row">

                <div class="col-md-4">

                    <label class="fw-bold mb-2">
                        Trạng thái đơn hàng
                    </label>

                    <asp:DropDownList
                        ID="ddlStatus"
                        runat="server"
                        CssClass="form-control">

                        <asp:ListItem
                            Text="Chờ xác nhận"
                            Value="Chờ xác nhận" />

                        <asp:ListItem
                            Text="Đang pha chế"
                            Value="Đang pha chế" />

                        <asp:ListItem
                            Text="Đang giao"
                            Value="Đang giao" />

                        <asp:ListItem
                            Text="Hoàn thành"
                            Value="Hoàn thành" />

                        <asp:ListItem
                            Text="Đã hủy"
                            Value="Đã hủy" />

                    </asp:DropDownList>

                </div>

            </div>

            <!-- NÚT CHỨC NĂNG -->
            <div class="mt-4">

                <asp:Button
                    ID="btnUpdate"
                    runat="server"
                    Text="Cập nhật trạng thái"
                    CssClass="btn btn-danger"
                    OnClick="btnUpdate_Click" />

                <asp:HyperLink
                    ID="lnkPrint"
                    runat="server"
                    CssClass="btn btn-success ms-2"
                    Target="_blank">

                    <i class="fa-solid fa-print"></i>
                    In hóa đơn

                </asp:HyperLink>

                <asp:Button
                    ID="btnBack"
                    runat="server"
                    Text="← Quay lại danh sách"
                    CssClass="btn btn-secondary ms-2"
                    OnClick="btnBack_Click" />

            </div>

        </div>

    </div>

</div>

</asp:Content>