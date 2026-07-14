<%@ Page Title="Liên hệ"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="LienHe.aspx.cs"
    Inherits="TraSuaNgon.LienHe" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<style>

.contact-card
{
    border-radius:18px;
    height:100%;
}


.contact-title
{
    color:#5A3825;
    font-weight:700;
}


.contact-icon
{
    color:#E91E63;
}


.contact-input
{
    width:100%;
    padding:12px;
    border-radius:10px;
}


.contact-info p
{
    font-size:16px;
    margin-bottom:18px;
}


</style>



<div class="container mt-5 mb-5">



    <h2 class="text-center mb-5"
        style="color:#E91E63;font-weight:700">


        <i class="fa-solid fa-envelope me-2"></i>

        Liên hệ với Trà Sữa NGON


    </h2>





    <div class="row g-4 align-items-stretch">





        <!-- THÔNG TIN CỬA HÀNG -->

        <div class="col-lg-6">


            <div class="card shadow border-0 p-4 contact-card">



                <h4 class="contact-title mb-4">

                    <i class="fa-solid fa-store contact-icon me-2"></i>

                    Thông tin cửa hàng

                </h4>




                <div class="contact-info">


                    <p>
                        <i class="fa-solid fa-location-dot contact-icon me-2"></i>

                        123 Đường ABC, TP.HCM

                    </p>



                    <p>
                        <i class="fa-solid fa-phone contact-icon me-2"></i>

                        0909 999 999

                    </p>



                    <p>
                        <i class="fa-solid fa-envelope contact-icon me-2"></i>

                        trasuangon@gmail.com

                    </p>



                    <p>
                        <i class="fa-solid fa-clock contact-icon me-2"></i>

                        08:00 - 22:00 mỗi ngày

                    </p>


                </div>





                <img src="<%= ResolveUrl("~/Assets/images/banners/banner0.jpg") %>"
                     class="img-fluid rounded mt-auto"
                     style="height:350px;object-fit:cover;" />


            </div>


        </div>









        <!-- FORM LIÊN HỆ -->


        <div class="col-lg-6">


            <div class="card shadow border-0 p-4 contact-card">



                <h4 class="contact-title mb-4">


                    <i class="fa-solid fa-paper-plane contact-icon me-2"></i>


                    Gửi lời nhắn cho chúng tôi


                </h4>






                <div class="mb-3">


                    <label class="fw-semibold">
                        Họ và tên
                    </label>


                    <asp:TextBox
                        ID="txtName"
                        runat="server"
                        CssClass="form-control contact-input" />


                </div>






                <div class="mb-3">


                    <label class="fw-semibold">
                        Email
                    </label>


                    <asp:TextBox
                        ID="txtEmail"
                        runat="server"
                        CssClass="form-control contact-input" />


                </div>






                <div class="mb-3">


                    <label class="fw-semibold">
                        Số điện thoại
                    </label>


                    <asp:TextBox
                        ID="txtPhone"
                        runat="server"
                        CssClass="form-control contact-input" />


                </div>






                <div class="mb-3">


                    <label class="fw-semibold">
                        Nội dung
                    </label>


                    <asp:TextBox
                        ID="txtMessage"
                        runat="server"
                        CssClass="form-control contact-input"
                        TextMode="MultiLine"
                        Rows="5" />


                </div>







                <div class="text-center mt-3">


                    <asp:Button
                        ID="btnSend"
                        runat="server"
                        Text="Gửi liên hệ"
                        CssClass="btn btn-danger px-5 py-2"
                        OnClick="btnSend_Click" />


                </div>







                <asp:Label
                    ID="lblMessage"
                    runat="server"
                    CssClass="d-block text-center text-success fw-bold mt-4">

                </asp:Label>




            </div>



        </div>





    </div>


</div>



</asp:Content>