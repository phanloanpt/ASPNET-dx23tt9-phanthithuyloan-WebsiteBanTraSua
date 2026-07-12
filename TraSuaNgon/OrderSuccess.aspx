<%@ Page Title="Đặt hàng thành công"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="OrderSuccess.aspx.cs"
    Inherits="TraSuaNgon.OrderSuccess" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<div class="container mt-5 mb-5">


    <div class="card shadow text-center">


        <div class="card-body p-5">


            <h1 class="text-success mb-4">

                <i class="fa-solid fa-circle-check"></i>

                Đặt hàng thành công!

            </h1>



            <h4>

                Cảm ơn bạn đã mua hàng tại
                <b>Trà Sữa NGON</b>

            </h4>



            <p class="mt-3">

                Mã đơn hàng của bạn:

            </p>



            <h2 class="text-danger">

                #<asp:Label 
                    ID="lblOrderID"
                    runat="server">
                </asp:Label>


            </h2>




            <p class="text-muted mt-3">

                Chúng tôi sẽ xác nhận đơn hàng
                trong thời gian sớm nhất.

            </p>




            <a href="Default.aspx"
               class="btn btn-danger mt-4">

                Về trang chủ

            </a>



        </div>


    </div>


</div>


</asp:Content>