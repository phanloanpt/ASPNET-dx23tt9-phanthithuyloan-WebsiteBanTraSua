<%@ Page Title="Quản lý danh mục"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="CategoryList.aspx.cs"
    Inherits="TraSuaNgon.Admin.Categories.CategoryList" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<div class="container-fluid mt-4">


    <div class="d-flex justify-content-between align-items-center mb-4">


        <h2 class="text-danger">

            <i class="fa-solid fa-list"></i>

            Quản lý danh mục

        </h2>



        <a href="CategoryAdd.aspx"
           class="btn btn-danger">

            <i class="fa-solid fa-plus"></i>

            Thêm danh mục

        </a>


    </div>





    <div class="card shadow">


        <div class="card-body">



            <asp:GridView
                ID="gvCategory"
                runat="server"

                AutoGenerateColumns="False"

                CssClass="table table-bordered table-hover"

                OnRowCommand="gvCategory_RowCommand">



                <Columns>



                    <%-- MÃ DANH MỤC --%>

                    <asp:BoundField
                        DataField="CategoryID"
                        HeaderText="Mã danh mục" />





                    <%-- TÊN DANH MỤC --%>

                    <asp:BoundField
                        DataField="CategoryName"
                        HeaderText="Tên danh mục" />





                    <%-- MÔ TẢ --%>

                    <asp:BoundField
                        DataField="Description"
                        HeaderText="Mô tả" />





                    <%-- TRẠNG THÁI --%>

                    <asp:BoundField
                        DataField="Status"
                        HeaderText="Trạng thái" />







                    <%-- CRUD --%>

                    <asp:TemplateField HeaderText="Xử lý">


                        <ItemTemplate>



                            <asp:Button
                                ID="btnEdit"
                                runat="server"

                                Text="Sửa"

                                CssClass="btn btn-warning btn-sm me-2"

                                CommandName="EditCategory"

                                CommandArgument='<%# Eval("CategoryID") %>' />





                            <asp:Button
                                ID="btnDelete"
                                runat="server"

                                Text="Xóa"

                                CssClass="btn btn-danger btn-sm"

                                CommandName="DeleteCategory"

                                CommandArgument='<%# Eval("CategoryID") %>'

                                OnClientClick="return confirm('Bạn có chắc muốn xóa danh mục này?');" />



                        </ItemTemplate>


                    </asp:TemplateField>



                </Columns>



            </asp:GridView>




        </div>


    </div>



</div>


</asp:Content>