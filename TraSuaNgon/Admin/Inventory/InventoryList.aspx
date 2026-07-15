<%@ Page Title="Quản lý vật tư"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="InventoryList.aspx.cs"
    Inherits="TraSuaNgon.Admin.Inventory.InventoryList" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<div class="container-fluid mt-4">


<h2 class="text-danger mb-4">

<i class="fa-solid fa-boxes-stacked"></i>

Quản lý vật tư

</h2>



<div class="card shadow">


<div class="card-body">


<asp:GridView

ID="gvInventory"

runat="server"

AutoGenerateColumns="False"

CssClass="table table-bordered table-hover"

OnRowDataBound="gvInventory_RowDataBound">



<Columns>



<asp:BoundField
DataField="InventoryID"
HeaderText="Mã" />



<asp:BoundField
DataField="ItemName"
HeaderText="Tên vật tư" />



<asp:BoundField
DataField="Unit"
HeaderText="Đơn vị" />



<asp:BoundField
DataField="Quantity"
HeaderText="Số lượng" />



<asp:BoundField
DataField="MinimumQuantity"
HeaderText="Mức tối thiểu" />



<asp:TemplateField
HeaderText="Trạng thái">


<ItemTemplate>


<asp:Label
ID="lblStatus"
runat="server">
</asp:Label>


</ItemTemplate>


</asp:TemplateField>



<asp:BoundField
DataField="UpdatedDate"
HeaderText="Cập nhật"
DataFormatString="{0:dd/MM/yyyy HH:mm}" />


</Columns>


</asp:GridView>


</div>

</div>


</div>


</asp:Content>