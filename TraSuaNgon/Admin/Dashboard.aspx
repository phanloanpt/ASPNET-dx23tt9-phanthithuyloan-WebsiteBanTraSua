<%@ Page Title="Dashboard"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs"
    Inherits="TraSuaNgon.Admin.Dashboard" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<div class="container-fluid mt-4">


<h2 class="text-danger">
    Dashboard quản trị
</h2>


<div class="row mt-4">


<div class="col-md-3">

<div class="card shadow p-3">

<h5>Sản phẩm</h5>

<h2>
<asp:Label ID="lblProduct"
runat="server">
0
</asp:Label>
</h2>

</div>

</div>



<div class="col-md-3">

<div class="card shadow p-3">

<h5>Đơn hàng</h5>

<h2>
<asp:Label ID="lblOrder"
runat="server">
0
</asp:Label>
</h2>

</div>

</div>



<div class="col-md-3">

<div class="card shadow p-3">

<h5>Người dùng</h5>

<h2>
<asp:Label ID="lblUser"
runat="server">
0
</asp:Label>
</h2>

</div>

</div>


</div>


</div>


</asp:Content>