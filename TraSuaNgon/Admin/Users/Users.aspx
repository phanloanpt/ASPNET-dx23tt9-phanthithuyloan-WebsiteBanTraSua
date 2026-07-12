<%@ Page Title="Quản lý người dùng"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="Users.aspx.cs"
    Inherits="TraSuaNgon.Admin.Users.Users" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<div class="container-fluid mt-4">


    <!-- TITLE -->

    <div class="d-flex justify-content-between align-items-center mb-4">

        <h2 class="fw-bold text-danger">

            <i class="fa-solid fa-users"></i>

            Quản lý người dùng

        </h2>


    </div>





    <!-- CARD TABLE -->

    <div class="card shadow-sm">


        <div class="card-header bg-danger text-white">


            <h5 class="mb-0">

                Danh sách tài khoản

            </h5>


        </div>




        <div class="card-body">



            <asp:GridView
                ID="gvUsers"
                runat="server"

                AutoGenerateColumns="False"

                CssClass="table table-bordered table-hover align-middle text-center"

                OnRowCommand="gvUsers_RowCommand">


                <Columns>




                    <!-- USER ID -->

                    <asp:BoundField

                        DataField="UserID"

                        HeaderText="ID" />







                    <!-- NAME -->

                    <asp:BoundField

                        DataField="FullName"

                        HeaderText="Họ tên" />







                    <!-- EMAIL -->

                    <asp:BoundField

                        DataField="Email"

                        HeaderText="Email" />







                    <!-- PHONE -->

                    <asp:BoundField

                        DataField="Phone"

                        HeaderText="Số điện thoại" />







                    <!-- ROLE -->

                    <asp:BoundField

                        DataField="Role"

                        HeaderText="Quyền" />







                    <!-- STATUS -->

                    <asp:TemplateField

                        HeaderText="Trạng thái">


                        <ItemTemplate>


                            <span class='badge 
                            <%# Convert.ToBoolean(Eval("Status")) 
                            ? "bg-success" 
                            : "bg-secondary" %>'>


                                <%# Convert.ToBoolean(Eval("Status")) 
                                ? "Hoạt động" 
                                : "Đã khóa" %>


                            </span>


                        </ItemTemplate>


                    </asp:TemplateField>







                    <!-- ACTION -->

                    <asp:TemplateField

                        HeaderText="Thao tác">


                        <ItemTemplate>



                            <asp:LinkButton

                                ID="btnStatus"

                                runat="server"

                                CssClass='<%# 
                                Convert.ToBoolean(Eval("Status"))
                                ? "btn btn-sm btn-danger"
                                : "btn btn-sm btn-success" %>'


                                CommandName="ChangeStatus"


                                CommandArgument='<%# 
                                Eval("UserID") + "|" + Eval("Status") %>'>



                                <i class='<%# 
                                Convert.ToBoolean(Eval("Status"))
                                ? "fa-solid fa-lock"
                                : "fa-solid fa-unlock" %>'>
                                </i>



                                <%# Convert.ToBoolean(Eval("Status"))
                                ? "Khóa"
                                : "Mở khóa" %>


                            </asp:LinkButton>



                        </ItemTemplate>


                    </asp:TemplateField>






                </Columns>



            </asp:GridView>




        </div>


    </div>



</div>



</asp:Content>