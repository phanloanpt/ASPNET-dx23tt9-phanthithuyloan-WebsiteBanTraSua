<%@ Page Title="Giỏ hàng"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Cart.aspx.cs"
    Inherits="TraSuaNgon.Cart" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="container mt-5 mb-5">

    <h2 class="text-center text-danger mb-4">
        <i class="fa-solid fa-cart-shopping"></i>
        Giỏ hàng của bạn
    </h2>

    
    <asp:Panel ID="pnlEmpty"
        runat="server"
        Visible="false"
        CssClass="text-center">

        <h4 class="text-muted">
            Giỏ hàng đang trống
        </h4>

        <a href="Menu.aspx"
           class="btn btn-danger mt-3">

            Chọn món ngay

        </a>

    </asp:Panel>

    
    <asp:Panel ID="pnlCart"
        runat="server">

        <div class="table-responsive">

            <asp:GridView ID="gvCart"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-bordered table-hover align-middle text-center"
                OnRowCommand="gvCart_RowCommand">

                <Columns>

                    
                    <asp:TemplateField HeaderText="Ảnh">
                        <ItemTemplate>

                            <img src='<%# ResolveUrl("~/Assets/images/products/" + Eval("ImageURL")) %>'
                                 width="90"
                                 class="rounded shadow-sm" />

                        </ItemTemplate>
                    </asp:TemplateField>

                    
                    <asp:TemplateField HeaderText="Sản phẩm">
                        <ItemTemplate>

                            <div class="fw-bold">
                                <%# Eval("ProductName") %>
                            </div>

                            <small class="text-muted">
                                Size: <%# Eval("Size") %>
                            </small>

                            <br />

                            <small class="text-danger">
                                <%# Eval("ToppingNames") %>
                            </small>

                        </ItemTemplate>
                    </asp:TemplateField>

                   
                    <asp:BoundField
                        HeaderText="Đơn giá"
                        DataField="UnitPrice"
                        DataFormatString="{0:N0} đ" />

                    <asp:TemplateField HeaderText="Số lượng">
                        <ItemTemplate>

                            <asp:LinkButton
                                runat="server"
                                CssClass="btn btn-sm btn-outline-secondary"
                                CommandName="Decrease"
                                CommandArgument="<%# Container.DataItemIndex %>"
                                CausesValidation="false">
                                -
                            </asp:LinkButton>

                            <span class="mx-3 fw-bold">
                                <%# Eval("Quantity") %>
                            </span>

                            <asp:LinkButton
                                runat="server"
                                CssClass="btn btn-sm btn-outline-danger"
                                CommandName="Increase"
                                CommandArgument="<%# Container.DataItemIndex %>"
                                CausesValidation="false">
                                +
                            </asp:LinkButton>

                        </ItemTemplate>
                    </asp:TemplateField>

                    
                    <asp:BoundField
                        HeaderText="Thành tiền"
                        DataField="TotalPrice"
                        DataFormatString="{0:N0} đ" />

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>

                            <asp:LinkButton
                                runat="server"
                                CssClass="btn btn-danger btn-sm"
                                CommandName="DeleteItem"
                                CommandArgument="<%# Container.DataItemIndex %>"
                                CausesValidation="false"
                                OnClientClick="return confirm('Xóa sản phẩm này khỏi giỏ hàng?');">

                                <i class="fa-solid fa-trash"></i>

                            </asp:LinkButton>

                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>

        </div>

       
        <div class="text-end mt-4">

            <h3 class="text-danger fw-bold">

                Tổng cộng:

                <asp:Label ID="lblGrandTotal"
                    runat="server">
                </asp:Label>

                đ

            </h3>

        </div>

        
        <div class="d-flex justify-content-between mt-4">

            <a href="Menu.aspx"
               class="btn btn-outline-secondary btn-lg">

                ← Tiếp tục chọn món

            </a>

            <asp:LinkButton
                ID="btnCheckout"
                runat="server"
                CssClass="btn btn-danger btn-lg"
                OnClick="btnCheckout_Click">

                Thanh toán

            </asp:LinkButton>

        </div>

    </asp:Panel>

</div>

</asp:Content>