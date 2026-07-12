<%@ Page Title="Sửa danh mục"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="CategoryEdit.aspx.cs"
    Inherits="TraSuaNgon.Admin.Categories.CategoryEdit" %>



<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">



<div class="container-fluid mt-4">


    <h2 class="text-warning mb-4">

        <i class="fa-solid fa-pen-to-square"></i>

        Sửa danh mục

    </h2>




    <div class="card shadow">


        <div class="card-body">



            <div class="mb-3">

                <label class="form-label">
                    Tên danh mục
                </label>


                <asp:TextBox
                    ID="txtCategoryName"
                    runat="server"
                    CssClass="form-control">
                </asp:TextBox>


            </div>






            <div class="mb-3">

                <label class="form-label">
                    Mô tả
                </label>


                <asp:TextBox
                    ID="txtDescription"
                    runat="server"
                    TextMode="MultiLine"
                    Rows="4"
                    CssClass="form-control">
                </asp:TextBox>


            </div>







            <div class="mb-3">

                <label class="form-label">
                    Trạng thái
                </label>


                <asp:DropDownList
                    ID="ddlStatus"
                    runat="server"
                    CssClass="form-control">


                    <asp:ListItem Value="True">
                        Hiển thị
                    </asp:ListItem>


                    <asp:ListItem Value="False">
                        Ẩn
                    </asp:ListItem>


                </asp:DropDownList>


            </div>







            <asp:Button
                ID="btnUpdate"
                runat="server"
                Text="Cập nhật"
                CssClass="btn btn-warning"
                OnClick="btnUpdate_Click" />



            <a href="CategoryList.aspx"
               class="btn btn-secondary ms-2">

                Quay lại

            </a>



        </div>


    </div>


</div>



</asp:Content>