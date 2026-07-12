<%@ Page Title="Quản lý đơn hàng"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="OrderList.aspx.cs"
    Inherits="TraSuaNgon.Admin.Orders.OrderList" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<div class="container-fluid mt-4">

    <h2 class="text-danger mb-4">
        <i class="fa-solid fa-cart-shopping"></i>
        Quản lý đơn hàng
    </h2>


    <div class="card shadow">

        <div class="card-body">

            <asp:GridView
                ID="gvOrders"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-bordered table-hover"
                OnRowCommand="gvOrders_RowCommand">

                <Columns>

                    <asp:BoundField
                        DataField="OrderID"
                        HeaderText="Mã đơn" />


                    <asp:BoundField
                        DataField="CustomerName"
                        HeaderText="Khách hàng" />


                    <asp:BoundField
                        DataField="Phone"
                        HeaderText="SĐT" />


                    <asp:BoundField
                        DataField="OrderDate"
                        HeaderText="Ngày đặt"
                        DataFormatString="{0:dd/MM/yyyy HH:mm}" />


                    <asp:BoundField
                        DataField="TotalAmount"
                        HeaderText="Tổng tiền"
                        DataFormatString="{0:N0} đ" />


                    <asp:BoundField
                        DataField="Status"
                        HeaderText="Trạng thái" />


                    <asp:TemplateField HeaderText="Xử lý">

                        <ItemTemplate>

                            <asp:Button
                                ID="btnDetail"
                                runat="server"
                                Text="Chi tiết"
                                CssClass="btn btn-danger btn-sm"
                                CommandName="Detail"
                                CommandArgument='<%# Eval("OrderID") %>' />

                        </ItemTemplate>

                    </asp:TemplateField>


                </Columns>


            </asp:GridView>


        </div>

    </div>

</div>


</asp:Content>