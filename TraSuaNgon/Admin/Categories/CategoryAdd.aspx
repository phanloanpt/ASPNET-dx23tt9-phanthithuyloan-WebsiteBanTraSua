<%@ Page Title="Thêm danh mục"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="CategoryAdd.aspx.cs"
    Inherits="TraSuaNgon.Admin.Categories.CategoryAdd" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<div class="container-fluid mt-4">


<h2 class="text-danger mb-4">
    <i class="fa-solid fa-plus"></i>
    Thêm danh mục
</h2>


<div class="card shadow">

<div class="card-body">


<div class="mb-3">

<label>
Tên danh mục
</label>

<asp:TextBox 
    ID="txtCategoryName"
    runat="server"
    CssClass="form-control">
</asp:TextBox>

</div>



<div class="mb-3">

<label>
Mô tả
</label>

<asp:TextBox
    ID="txtDescription"
    runat="server"
    TextMode="MultiLine"
    Rows="4"
    CssClass="form-control">
</asp:TextBox>


</div>



<div class="mb-3">

<label>
Trạng thái
</label>


<asp:DropDownList
    ID="ddlStatus"
    runat="server"
    CssClass="form-control">

    <asp:ListItem Value="true">
        Hiển thị
    </asp:ListItem>

    <asp:ListItem Value="false">
        Ẩn
    </asp:ListItem>

</asp:DropDownList>


</div>



<asp:Button
    ID="btnSave"
    runat="server"
    Text="Lưu"
    CssClass="btn btn-danger"
    OnClick="btnSave_Click"/>



<a href="CategoryList.aspx"
   class="btn btn-secondary">
   Quay lại
</a>



</div>

</div>


</div>


</asp:Content>