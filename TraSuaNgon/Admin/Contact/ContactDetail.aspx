<%@ Page Title="Chi tiết liên hệ"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="ContactDetail.aspx.cs"
    Inherits="TraSuaNgon.Admin.Contact.ContactDetail" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<div class="container-fluid mt-4">

    <h2 class="text-danger mb-4">
        <i class="fa-solid fa-envelope-open-text"></i>
        Chi tiết liên hệ khách hàng
    </h2>


    <div class="card shadow">

        <div class="card-body">


            <p>
                <b>Họ tên:</b>
                <asp:Label ID="lblName" runat="server" />
            </p>


            <p>
                <b>Email:</b>
                <asp:Label ID="lblEmail" runat="server" />
            </p>


            <p>
                <b>Số điện thoại:</b>
                <asp:Label ID="lblPhone" runat="server" />
            </p>


            <p>
                <b>Tiêu đề:</b>
                <asp:Label ID="lblSubject" runat="server" />
            </p>


            <p>
                <b>Ngày gửi:</b>
                <asp:Label ID="lblDate" runat="server" />
            </p>


            <hr />


            <h5>Nội dung:</h5>

            <div class="border rounded p-3 bg-light">

                <asp:Label 
                    ID="lblMessage"
                    runat="server" />

            </div>


            <br />


            <asp:Button
                ID="btnRead"
                runat="server"
                Text="✓ Đánh dấu đã đọc"
                CssClass="btn btn-success"
                OnClick="btnRead_Click" />


            <a href="ContactList.aspx"
               class="btn btn-secondary ms-2">

                Quay lại

            </a>


        </div>

    </div>


</div>


</asp:Content>