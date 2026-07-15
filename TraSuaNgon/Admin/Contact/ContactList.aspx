<%@ Page Title="Quản lý liên hệ khách hàng"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="ContactList.aspx.cs"
    Inherits="TraSuaNgon.Admin.Contact.ContactList" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<div class="container-fluid mt-4">


    <h2 class="text-danger mb-4">

        <i class="fa-solid fa-envelope"></i>

        Quản lý liên hệ khách hàng

    </h2>




    <div class="card shadow">


        <div class="card-body">



            <asp:GridView

                ID="gvContacts"

                runat="server"

                AutoGenerateColumns="False"

                CssClass="table table-bordered table-hover"

                OnRowCommand="gvContacts_RowCommand">



                <Columns>



                    <asp:BoundField
                        DataField="MessageID"
                        HeaderText="Mã" />



                    <asp:BoundField
                        DataField="FullName"
                        HeaderText="Họ tên" />



                    <asp:BoundField
                        DataField="Email"
                        HeaderText="Email" />



                    <asp:BoundField
                        DataField="Phone"
                        HeaderText="SĐT" />



                    <asp:BoundField
                        DataField="CreatedDate"
                        HeaderText="Ngày gửi"
                        DataFormatString="{0:dd/MM/yyyy HH:mm}" />




                    <asp:TemplateField HeaderText="Trạng thái">

                        <ItemTemplate>


                            <asp:Label
                                ID="lblStatus"
                                runat="server"
                                Text='<%# Convert.ToBoolean(Eval("IsRead")) ? "Đã đọc" : "Chưa đọc" %>'
                                CssClass='<%# Convert.ToBoolean(Eval("IsRead")) ? "badge bg-success" : "badge bg-warning text-dark" %>'>
                            </asp:Label>


                        </ItemTemplate>


                    </asp:TemplateField>





                    <asp:TemplateField HeaderText="Xử lý">


                        <ItemTemplate>


                            <asp:Button
                                ID="btnDetail"
                                runat="server"
                                Text="Chi tiết"
                                CssClass="btn btn-danger btn-sm"
                                CommandName="Detail"
                                CommandArgument='<%# Eval("MessageID") %>' />


                        </ItemTemplate>


                    </asp:TemplateField>



                </Columns>




            </asp:GridView>




        </div>


    </div>



</div>



</asp:Content>