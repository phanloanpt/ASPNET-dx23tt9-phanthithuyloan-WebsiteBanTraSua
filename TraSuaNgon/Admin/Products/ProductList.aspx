<%@ Page Title="Quản lý sản phẩm"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="ProductList.aspx.cs"
    Inherits="TraSuaNgon.Admin.Products.ProductList" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="d-flex justify-content-between align-items-center mb-4">

        <h2>
            <i class="fa-solid fa-mug-saucer"></i>
            Quản lý sản phẩm
        </h2>

        <a href="ProductAdd.aspx"
            class="btn btn-success">

            <i class="fa-solid fa-plus"></i>

            Thêm sản phẩm

        </a>

    </div>



    <asp:GridView ID="gvProducts"
        runat="server"
        AutoGenerateColumns="False"
        CssClass="table table-bordered table-hover align-middle"
        DataKeyNames="ProductID"
        OnRowDeleting="gvProducts_RowDeleting">

        <Columns>

            <asp:BoundField
                DataField="ProductID"
                HeaderText="ID" />



            <asp:TemplateField HeaderText="Ảnh">

    <ItemTemplate>

        <img src='<%# ResolveUrl("~/Assets/images/products/" + Eval("ImageURL")) %>'
            style="width:80px;height:80px;object-fit:cover;border-radius:10px;" />

    </ItemTemplate>

</asp:TemplateField>



            <asp:BoundField
                DataField="ProductName"
                HeaderText="Tên sản phẩm" />



            <asp:BoundField
                DataField="CategoryName"
                HeaderText="Danh mục" />



            <asp:BoundField
                DataField="PriceM"
                HeaderText="Giá M"
                DataFormatString="{0:N0}" />



            <asp:BoundField
                DataField="PriceL"
                HeaderText="Giá L"
                DataFormatString="{0:N0}" />



            <asp:CheckBoxField
                DataField="IsFeatured"
                HeaderText="Nổi bật" />



            <asp:CheckBoxField
                DataField="IsNew"
                HeaderText="Mới" />



            <asp:CheckBoxField
                DataField="IsBestSeller"
                HeaderText="Bán chạy" />



            <asp:CheckBoxField
                DataField="Status"
                HeaderText="Hiển thị" />



            <asp:TemplateField HeaderText="Sửa">

                <ItemTemplate>

                    <a href='ProductEdit.aspx?id=<%# Eval("ProductID") %>'
                        class="btn btn-warning btn-sm">

                        <i class="fa-solid fa-pen"></i>

                    </a>

                </ItemTemplate>

            </asp:TemplateField>



            <asp:CommandField
                ShowDeleteButton="True"
                DeleteText="Xóa"
                HeaderText="Xóa" />

        </Columns>

    </asp:GridView>

</asp:Content>