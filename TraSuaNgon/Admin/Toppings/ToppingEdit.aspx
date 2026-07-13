<%@ Page Title="Sửa topping"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="ToppingEdit.aspx.cs"
    Inherits="TraSuaNgon.Admin.Toppings.ToppingEdit" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="container mt-4">

    <h2>Sửa topping</h2>

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

    <asp:Image
    ID="imgPreview"
    runat="server"
    Width="100"
    Height="100" />

<br /><br />

<asp:FileUpload
    ID="fuImage"
    runat="server"
    CssClass="form-control" />

    <div class="mb-3">
        <asp:CheckBox
            ID="chkStatus"
            runat="server"
            Text="Hoạt động" />
    </div>

    <asp:Button
        ID="btnSave"
        runat="server"
        Text="Cập nhật"
        CssClass="btn btn-primary"
        OnClick="btnSave_Click" />

</div>

</asp:Content>