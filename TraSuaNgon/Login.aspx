<%@ Page Title="Đăng nhập"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="TraSuaNgon.Login" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<style>

.login-card
{
    border: none;
    border-radius: 15px;
    overflow: hidden;
}

.login-header
{
    background: linear-gradient(135deg,#E91E63,#FF6B9A);
}

.login-input
{
    width: 320px;
    margin: auto;
    border-radius: 10px;
}

.login-input:focus
{
    border-color: #E91E63;
    box-shadow: 0 0 0 .2rem rgba(233,30,99,.25);
}

.login-btn
{
    width: 320px;
    background: #E91E63;
    border: none;
    border-radius: 10px;
    font-weight: 600;
    color: white;
    transition: .3s;
}

.login-btn:hover
{
    background: #C2185B;
    color: white;
}

.register-link
{
    color: #E91E63;
    font-weight: 600;
    text-decoration: none;
}

.register-link:hover
{
    color: #C2185B;
    text-decoration: underline;
}

</style>

<div class="container mt-5 mb-5">

    <div class="row justify-content-center">

        <div class="col-md-5">

            <div class="card shadow login-card">

                <div class="card-header login-header text-white text-center">

                    <h3 class="mb-0">

                        <i class="fa-solid fa-user"></i>

                        Đăng nhập

                    </h3>

                </div>

                <div class="card-body text-center">

                    <div class="mb-3">

                        <label class="fw-bold mb-2">
                            Email
                        </label>

                        <asp:TextBox ID="txtEmail"
                            runat="server"
                            CssClass="form-control login-input">
                        </asp:TextBox>

                    </div>

                    <div class="mb-3">

                        <label class="fw-bold mb-2">
                            Mật khẩu
                        </label>

                        <asp:TextBox ID="txtPassword"
                            runat="server"
                            TextMode="Password"
                            CssClass="form-control login-input">
                        </asp:TextBox>

                    </div>

                    <asp:Label ID="lblMessage"
                        runat="server"
                        CssClass="text-danger d-block mb-2">
                    </asp:Label>

                    <asp:Button ID="btnLogin"
                        runat="server"
                        Text="Đăng nhập"
                        CssClass="btn login-btn mt-2"
                        OnClick="btnLogin_Click" />

                    <div class="mt-4">

                        <span>
                            Chưa có tài khoản?
                        </span>

                        <a href="Register.aspx"
                           class="register-link">

                            Đăng ký ngay

                        </a>

                    </div>

                </div>

            </div>

        </div>

    </div>

</div>

</asp:Content>