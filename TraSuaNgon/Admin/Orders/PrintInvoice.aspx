<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="PrintInvoice.aspx.cs"
    Inherits="TraSuaNgon.Admin.Orders.PrintInvoice" %>


<!DOCTYPE html>

<html>
<head runat="server">

<title>Hóa đơn</title>

<style>

body{
    font-family: Arial;
    font-size:13px;
}


.invoice{

    width:80mm;
    margin:auto;

}


.center{
    text-align:center;
}


.line{

    border-top:1px dashed #000;
    margin:8px 0;

}


table{

    width:100%;
    border-collapse:collapse;

}


td{

    padding:3px 0;

}


.right{

    text-align:right;

}


.bold{

    font-weight:bold;

}


.print-btn{

    margin-top:20px;
}


@media print{

    .print-btn{
        display:none;
    }

    body{
        width:80mm;
    }

}

</style>

</head>


<body>


<form id="form1" runat="server">


<div class="invoice">


<div class="center">

<h3>
    TRÀ SỮA NGON
</h3>

<p>
    Địa chỉ: 123 Đường ABC, Phường BDE, TP.HCM
    <br />
    Hotline: 0900 000 0009
</p>

</div>


<div class="line"></div>


<p>
Mã đơn:
<b>
<asp:Label 
ID="lblOrderID"
runat="server"/>
</b>
</p>


<p>
Ngày:
<asp:Label 
ID="lblDate"
runat="server"/>
</p>


<p>
Khách hàng:
<asp:Label 
ID="lblCustomer"
runat="server"/>
</p>


<p>
SĐT:
<asp:Label 
ID="lblPhone"
runat="server"/>
</p>


<div class="line"></div>



<table>


<asp:Repeater 
ID="rptDetail"
runat="server">


<ItemTemplate>


<tr>

<td colspan="2">

<b>
<%# Eval("ProductName") %>
</b>

</td>

</tr>


<tr>

<td>

Size:
<%# Eval("Size") %>
<br/>

SL:
<%# Eval("Quantity") %>

</td>


<td class="right">

<%# Eval("SubTotal","{0:N0}") %> đ

</td>


</tr>


<tr>

<td colspan="2">

Topping:
<%# string.IsNullOrEmpty(Eval("ToppingName").ToString()) 
? "" 
: "Topping: " + Eval("ToppingName") %>

</td>

</tr>


</ItemTemplate>


</asp:Repeater>


</table>



<div class="line"></div>



<table>

<tr>

<td>
Tổng tiền
</td>


<td class="right bold">

<asp:Label
ID="lblTotal"
runat="server"/>

</td>

</tr>


</table>



<div class="line"></div>


<div class="center">

<p>
Cảm ơn quý khách ❤️
</p>

</div>


<button
type="button"
class="print-btn"
onclick="window.print()">

🖨 In hóa đơn

</button>
<button
type="button"
class="print-btn"
onclick="window.location.href='OrderList.aspx';">

← Quay về danh sách đơn hàng

</button>

</div>


</form>


</body>

</html>