<%@ Page Title="Chi tiết đơn hàng"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="OrderDetail.aspx.cs"
    Inherits="TraSuaNgon.Admin.Orders.OrderDetail" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<div class="container-fluid mt-4">


<h2 class="text-danger mb-4">

<i class="fa-solid fa-file-invoice"></i>

Chi tiết đơn hàng

</h2>



<div class="card shadow">


<div class="card-body">



<p>
<b>Mã đơn:</b>

<asp:Label 
ID="lblOrderID"
runat="server"/>

</p>



<p>
<b>Khách hàng:</b>

<asp:Label 
ID="lblCustomer"
runat="server"/>

</p>



<p>
<b>Số điện thoại:</b>

<asp:Label 
ID="lblPhone"
runat="server"/>

</p>



<p>
<b>Địa chỉ:</b>

<asp:Label 
ID="lblAddress"
runat="server"/>

</p>



<hr />



<asp:GridView 
ID="gvDetail"
runat="server"
CssClass="table table-bordered"
AutoGenerateColumns="false">


<Columns>


<asp:BoundField
DataField="ProductName"
HeaderText="Sản phẩm" />


<asp:BoundField
DataField="Size"
HeaderText="Size" />


<asp:BoundField
DataField="Quantity"
HeaderText="Số lượng" />


<asp:BoundField
DataField="Price"
HeaderText="Giá" />



</Columns>


</asp:GridView>




<hr />



<div class="row">


<div class="col-md-4">


<label>
Trạng thái
</label>


<asp:DropDownList
ID="ddlStatus"
runat="server"
CssClass="form-control">


<asp:ListItem>
Chờ xác nhận
</asp:ListItem>


<asp:ListItem>
Đang giao
</asp:ListItem>


<asp:ListItem>
Hoàn thành
</asp:ListItem>


<asp:ListItem>
Đã hủy
</asp:ListItem>


</asp:DropDownList>


</div>


</div>



<asp:Button

ID="btnUpdate"

runat="server"

Text="Cập nhật trạng thái"

CssClass="btn btn-danger mt-3"

OnClick="btnUpdate_Click"/>



</div>


</div>



</div>



</asp:Content>