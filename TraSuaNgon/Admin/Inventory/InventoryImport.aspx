<%@ Page Title="Nhập kho"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="InventoryImport.aspx.cs"
    Inherits="TraSuaNgon.Admin.Inventory.InventoryImport" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<div class="container mt-4">


<h2 class="text-danger">
<i class="fa-solid fa-box"></i>
Nhập kho
</h2>



<div class="card shadow mt-3">

<div class="card-body">



<div class="mb-3">

<label>
Chọn vật tư
</label>


<asp:DropDownList
ID="ddlInventory"
runat="server"
CssClass="form-control">

</asp:DropDownList>


</div>



<div class="mb-3">

<label>
Số lượng nhập
</label>


<asp:TextBox
ID="txtQuantity"
runat="server"
CssClass="form-control">
</asp:TextBox>


</div>



<div class="mb-3">

<label>
Ghi chú
</label>


<asp:TextBox
ID="txtNote"
runat="server"
CssClass="form-control">
</asp:TextBox>


</div>




<asp:Button
ID="btnImport"
runat="server"
Text="Nhập kho"
CssClass="btn btn-danger"
OnClick="btnImport_Click"/>



<asp:Label
ID="lblMessage"
runat="server"
CssClass="d-block mt-3"/>



</div>

</div>


</div>


</asp:Content>