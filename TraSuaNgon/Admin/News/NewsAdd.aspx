<%@ Page Title="Thêm tin tức"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="NewsAdd.aspx.cs"
    Inherits="TraSuaNgon.Admin.News.NewsAdd" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="container mt-4">

    <h2 class="text-danger mb-4">
        Thêm tin tức
    </h2>

    <div class="mb-3">
        <label>Tiêu đề</label>
        <asp:TextBox ID="txtTitle"
            runat="server"
            CssClass="form-control" />
    </div>

    <div class="mb-3">
        <label>Mô tả ngắn</label>
        <asp:TextBox ID="txtSummary"
            runat="server"
            CssClass="form-control"
            TextMode="MultiLine"
            Rows="3" />
    </div>

    <div class="mb-3">
        <label>Nội dung</label>
        <asp:TextBox ID="txtContent"
            runat="server"
            CssClass="form-control"
            TextMode="MultiLine"
            Rows="10" />
    </div>

    <div class="mb-3">
        <label>Ảnh URL</label>
        <asp:TextBox ID="txtImage"
            runat="server"
            CssClass="form-control" />
    </div>

    <div class="mb-3">
        <label>Tác giả</label>
        <asp:TextBox ID="txtAuthor"
            runat="server"
            CssClass="form-control" />
    </div>

    <div class="form-check">
        <asp:CheckBox
            ID="chkFeatured"
            runat="server" />
        Tin nổi bật
    </div>

    <div class="form-check mb-3">
        <asp:CheckBox
            ID="chkStatus"
            runat="server"
            Checked="true" />
        Hiển thị
    </div>

    <asp:Button
        ID="btnSave"
        runat="server"
        Text="Lưu"
        CssClass="btn btn-danger"
        OnClick="btnSave_Click" />
    <div class="mb-3">
    <label class="form-label">Chọn ảnh</label>

    <asp:FileUpload
        ID="fuImage"
        runat="server"
        CssClass="form-control" />
</div>

<div class="mb-3">
    <label class="form-label">Ảnh hiện tại</label>

    <asp:TextBox
        ID="TextBox1"
        runat="server"
        CssClass="form-control"
        ReadOnly="true">
    </asp:TextBox>
</div>

</div>

</asp:Content>