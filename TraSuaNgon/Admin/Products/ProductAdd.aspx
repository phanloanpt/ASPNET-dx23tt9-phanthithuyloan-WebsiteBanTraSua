<%@ Page Title="Thêm sản phẩm"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="ProductAdd.aspx.cs"
    Inherits="TraSuaNgon.Admin.Products.ProductAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Thêm sản phẩm</h2>

    <div class="mb-3">
        Danh mục
        <asp:DropDownList ID="ddlCategory" runat="server"
            CssClass="form-control"></asp:DropDownList>
    </div>

    <div class="mb-3">
        Tên sản phẩm
        <asp:TextBox ID="txtName" runat="server"
            CssClass="form-control"></asp:TextBox>
    </div>

    <div class="mb-3">
        Mô tả
        <asp:TextBox ID="txtDescription"
            runat="server"
            TextMode="MultiLine"
            CssClass="form-control"></asp:TextBox>
    </div>

   <div class="mb-3">
    <label class="form-label">Hình ảnh sản phẩm</label>

    <asp:FileUpload ID="fuImage"
        runat="server"
        CssClass="form-control" />
</div>

    <div class="mb-3">
        Giá M
        <asp:TextBox ID="txtPriceM"
            runat="server"
            CssClass="form-control"></asp:TextBox>
    </div>

    <div class="mb-3">
        Giá L
        <asp:TextBox ID="txtPriceL"
            runat="server"
            CssClass="form-control"></asp:TextBox>
    </div>

    <asp:CheckBox ID="chkFeatured" runat="server" Text="Nổi bật" />
    <br />
    <asp:CheckBox ID="chkNew" runat="server" Text="Sản phẩm mới" />
    <br />
    <asp:CheckBox ID="chkBestSeller" runat="server" Text="Bán chạy" />
    <br />
    <asp:CheckBox ID="chkStatus" runat="server" Text="Hiển thị" Checked="true" />

    <br /><br />

    <asp:Button ID="btnSave"
        runat="server"
        Text="Lưu"
        CssClass="btn btn-primary"
        OnClick="btnSave_Click" />

</asp:Content>