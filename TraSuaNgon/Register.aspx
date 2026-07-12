<%@ Page Title="Đăng ký"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Register.aspx.cs"
    Inherits="TraSuaNgon.Register" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<div class="container mt-5 mb-5">


<div class="row justify-content-center">


<div class="col-md-6">


<div class="card shadow border-0">


<div class="card-body p-4">



<h3 class="text-center text-danger mb-4">

<i class="fa-solid fa-user-plus"></i>

Đăng ký tài khoản

</h3>





<asp:Label ID="lblMessage"
    runat="server"
    CssClass="text-danger text-center d-block mb-3">
</asp:Label>







<div class="mb-3">

<label>
Họ và tên
</label>


<asp:TextBox ID="txtFullName"
    runat="server"
    CssClass="form-control"
    placeholder="Nhập họ tên">
</asp:TextBox>


</div>








<div class="mb-3">

<label>
Email
</label>


<asp:TextBox ID="txtEmail"
    runat="server"
    CssClass="form-control"
    placeholder="Nhập email">
</asp:TextBox>


</div>









<div class="mb-3">

<label>
Mật khẩu
</label>


<asp:TextBox ID="txtPassword"
    runat="server"
    TextMode="Password"
    CssClass="form-control"
    placeholder="Nhập mật khẩu">
</asp:TextBox>


</div>








<div class="mb-3">

<label>
Số điện thoại
</label>


<asp:TextBox ID="txtPhone"
    runat="server"
    CssClass="form-control"
    placeholder="Nhập số điện thoại">
</asp:TextBox>


</div>








<div class="mb-3">

<label>
Địa chỉ
</label>


<asp:TextBox ID="txtAddress"
    runat="server"
    CssClass="form-control"
    placeholder="Nhập địa chỉ">
</asp:TextBox>


</div>








<asp:Button ID="btnRegister"
    runat="server"
    Text="Đăng ký"
    CssClass="btn btn-danger w-100"
    OnClick="btnRegister_Click" />








<div class="text-center mt-3">


Đã có tài khoản?


<a href="Login.aspx"
   class="text-danger">

Đăng nhập

</a>


</div>






</div>

</div>


</div>


</div>


</div>


</asp:Content>