<%@ Page Title="Thanh toán"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Checkout.aspx.cs"
    Inherits="TraSuaNgon.Checkout" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<div class="container mt-5 mb-5">


    <h2 class="text-center text-danger mb-4">

        <i class="fa-solid fa-credit-card"></i>

        Thanh toán

    </h2>



    <div class="row">


        <!-- Thông tin khách hàng -->

        <div class="col-md-6">


            <div class="card shadow-sm">


                <div class="card-header bg-danger text-white">

                    Thông tin nhận hàng

                </div>



                <div class="card-body">



                    <div class="mb-3">

                        <label>
                            Họ tên
                        </label>

                        <asp:TextBox ID="txtName"
                            runat="server"
                            CssClass="form-control">
                        </asp:TextBox>

                    </div>




                    <div class="mb-3">

                        <label>
                            Số điện thoại
                        </label>


                        <asp:TextBox ID="txtPhone"
                            runat="server"
                            CssClass="form-control">
                        </asp:TextBox>


                    </div>





                    <div class="mb-3">

                        <label>
                            Địa chỉ giao hàng
                        </label>


                        <asp:TextBox ID="txtAddress"
                            runat="server"
                            CssClass="form-control">
                        </asp:TextBox>


                    </div>





                    <div class="mb-3">

                        <label>
                            Ghi chú
                        </label>


                        <asp:TextBox ID="txtNote"
                            runat="server"
                            TextMode="MultiLine"
                            Rows="3"
                            CssClass="form-control">
                        </asp:TextBox>


                    </div>



                </div>


            </div>


        </div>







        <!-- Đơn hàng -->

        <div class="col-md-6">


            <div class="card shadow-sm">


                <div class="card-header bg-dark text-white">

                    Đơn hàng của bạn

                </div>



                <div class="card-body">


                    <asp:GridView ID="gvCheckout"
                        runat="server"
                        AutoGenerateColumns="False"
                        CssClass="table table-bordered">


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
                                DataField="TotalPrice"
                                DataFormatString="{0:N0} đ" />


                        </Columns>


                    </asp:GridView>



                    <h4 class="text-danger text-end">

                        Tổng:

                        <asp:Label ID="lblTotal"
                            runat="server">
                        </asp:Label>

                        đ

                    </h4>




                    <asp:Button ID="btnOrder"
                        runat="server"
                        Text="Đặt hàng"
                        CssClass="btn btn-danger w-100 mt-3"
                        OnClick="btnOrder_Click"/>



                </div>


            </div>


        </div>


    </div>



</div>



</asp:Content>