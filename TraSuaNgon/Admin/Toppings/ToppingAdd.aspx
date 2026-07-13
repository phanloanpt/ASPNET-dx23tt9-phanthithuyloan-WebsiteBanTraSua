<%@ Page Title="Thêm topping"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="ToppingAdd.aspx.cs"
    Inherits="TraSuaNgon.Admin.Toppings.ToppingAdd" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="container mt-4">

    <h2>Thêm topping</h2>

    <div class="mb-3">
        <label>Tên topping</label>
        <asp:TextBox ID="txtName"
            runat="server"
            CssClass="form-control" />
    </div>

    <div class="mb-3">
        <label>Giá</label>
        <asp:TextBox ID="txtPrice"
            runat="server"
            CssClass="form-control" />
    </div>

    <div class="mb-3">
    <label>Ảnh topping</label>

    <asp:FileUpload
        ID="fuImage"
        runat="server"
        CssClass="form-control" />
</div>

    <div class="mb-3">
        <asp:CheckBox
            ID="chkStatus"
            runat="server"
            Text="Hoạt động"
            Checked="true" />
    </div>

    <asp:Button
        ID="btnSave"
        runat="server"
        Text="Lưu"
        CssClass="btn btn-success"
        OnClick="btnSave_Click" />

</div>

</asp:Content>