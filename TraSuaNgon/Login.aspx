<%@ Page Title="Đăng nhập"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="TraSuaNgon.Login" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<div class="container mt-5 mb-5">


    <div class="row justify-content-center">


        <div class="col-md-5">


            <div class="card shadow">


                <div class="card-header bg-danger text-white text-center">


                    <h3>

                        <i class="fa-solid fa-user"></i>

                        Đăng nhập

                    </h3>


                </div>




                <div class="card-body">



                    <div class="mb-3">

                        <label>
                            Email
                        </label>


                        <asp:TextBox ID="txtEmail"
                            runat="server"
                            CssClass="form-control">
                        </asp:TextBox>


                    </div>





                    <div class="mb-3">

                        <label>
                            Mật khẩu
                        </label>


                        <asp:TextBox ID="txtPassword"
                            runat="server"
                            TextMode="Password"
                            CssClass="form-control">
                        </asp:TextBox>


                    </div>





                    <asp:Label ID="lblMessage"
                        runat="server"
                        CssClass="text-danger">
                    </asp:Label>






                    <asp:Button ID="btnLogin"
                        runat="server"
                        Text="Đăng nhập"
                        CssClass="btn btn-danger w-100 mt-3"
                        OnClick="btnLogin_Click" />





                    <div class="text-center mt-3">


                        <span>
                            Chưa có tài khoản?
                        </span>


                        <a href="Register.aspx"
                           class="text-danger">

                            Đăng ký ngay

                        </a>


                    </div>




                </div>



            </div>


        </div>


    </div>


</div>


</asp:Content>