<%@ Page Title="Chi tiết sản phẩm"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ProductDetail.aspx.cs"
    Inherits="TraSuaNgon.ProductDetail" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<asp:UpdatePanel ID="upProductDetail"
    runat="server"
    UpdateMode="Conditional">


<ContentTemplate>


<div class="container mt-5 mb-5">


<div class="row">


<!-- ẢNH SẢN PHẨM -->

<div class="col-lg-5 text-center mb-4">


<asp:Image ID="imgProduct"
    runat="server"
    CssClass="img-fluid rounded shadow product-detail-img" />


</div>





<!-- THÔNG TIN -->

<div class="col-lg-7">


<h2 class="fw-bold text-danger mb-3">


<asp:Label ID="lblProductName"
    runat="server">
</asp:Label>


</h2>





<p class="text-muted">


<asp:Label ID="lblDescription"
    runat="server">
</asp:Label>


</p>







<!-- SIZE -->

<div class="card shadow-sm mb-4">


<div class="card-body">


<h5 class="fw-bold mb-3">

🥤 Chọn size

</h5>




<asp:RadioButtonList 
    ID="rblSize"
    runat="server"
    RepeatDirection="Vertical"
    CssClass="size-list"
    AutoPostBack="true"
    OnSelectedIndexChanged="CalculateTotal">



<asp:ListItem 
    Value="M"
    Selected="True">

Size M

</asp:ListItem>



<asp:ListItem 
    Value="L">

Size L

</asp:ListItem>


</asp:RadioButtonList>






<div class="mt-3">


<span class="badge bg-danger me-2">


Size M:

<asp:Label ID="lblPriceM"
    runat="server">
</asp:Label>


đ


</span>




<span class="badge bg-success">


Size L:

<asp:Label ID="lblPriceL"
    runat="server">
</asp:Label>


đ


</span>


</div>



</div>


</div>









<!-- TOPPING -->

<div class="card shadow-sm mb-4">


<div class="card-body">


<h5 class="fw-bold mb-3">


<i class="fa-solid fa-plus-circle"></i>

Chọn topping thêm


</h5>





<asp:CheckBoxList
    ID="cblToppings"
    runat="server"
    CssClass="topping-list"
    RepeatColumns="2"
    RepeatDirection="Horizontal"
    RepeatLayout="Table"
    AutoPostBack="true"
    OnSelectedIndexChanged="CalculateTotal">


</asp:CheckBoxList>




</div>


</div>









<!-- SỐ LƯỢNG -->


<div class="mb-4">


<label class="fw-bold mb-2">

Số lượng

</label>



<div class="input-group"
style="width:150px">



<button type="button"
class="btn btn-outline-secondary"
onclick="decreaseQty()">

-

</button>




<asp:TextBox ID="txtQuantity"
    runat="server"
    CssClass="form-control text-center"
    Text="1">
</asp:TextBox>





<button type="button"
class="btn btn-outline-danger"
onclick="increaseQty()">

+

</button>



</div>


</div>









<!-- THÀNH TIỀN -->


<div class="card shadow-sm mb-4">


<div class="card-body">


<h5 class="fw-bold">

Thành tiền

</h5>




<h3 class="text-danger fw-bold">


<asp:Label ID="lblTotalPrice"
    runat="server"
    Text="0">

</asp:Label>


đ


</h3>



</div>


</div>









<!-- BUTTON -->


<div class="d-flex gap-3">


<asp:Button
    ID="btnAddToCart"
    runat="server"
    Text="🛒 Thêm vào giỏ hàng"
    CssClass="btn btn-danger btn-lg"
    OnClick="btnAddToCart_Click" />




<a href="Menu.aspx"
class="btn btn-outline-secondary btn-lg">


← Quay lại


</a>



</div>





</div>


</div>


</div>



</ContentTemplate>



<Triggers>


<asp:AsyncPostBackTrigger
    ControlID="rblSize"
    EventName="SelectedIndexChanged" />



<asp:AsyncPostBackTrigger
    ControlID="cblToppings"
    EventName="SelectedIndexChanged" />



</Triggers>


</asp:UpdatePanel>









<script>


    function increaseQty() {

        var qty =
            document.getElementById(
    '<%=txtQuantity.ClientID%>'
    );


    var value =
    parseInt(qty.value);


    value++;


    qty.value=value;


}







function decreaseQty()
{

    var qty =
    document.getElementById(
    '<%=txtQuantity.ClientID%>'
    );


        var value =
            parseInt(qty.value);



        if (value > 1) {

            value--;

        }


        qty.value = value;


    }



</script>



</asp:Content>