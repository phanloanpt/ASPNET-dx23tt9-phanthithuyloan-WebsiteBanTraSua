<%@ Page Title="Quản lý topping"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="ToppingList.aspx.cs"
    Inherits="TraSuaNgon.Admin.Toppings.ToppingList" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="container mt-4">

        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2>
                <i class="fa-solid fa-circle-plus text-primary"></i>
                Quản lý Topping
            </h2>

            <asp:Button
                ID="btnAdd"
                runat="server"
                Text="+ Thêm topping"
                CssClass="btn btn-success"
                PostBackUrl="~/Admin/Toppings/ToppingAdd.aspx" />
        </div>

        <asp:GridView
            ID="gvToppings"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="table table-bordered table-hover align-middle"
            GridLines="None">

            <Columns>

                <asp:BoundField
                    DataField="ToppingID"
                    HeaderText="ID" />

                <asp:BoundField
                    DataField="ToppingName"
                    HeaderText="Tên topping" />

                <asp:BoundField
                    DataField="Price"
                    HeaderText="Giá"
                    DataFormatString="{0:N0} đ" />

                <asp:TemplateField HeaderText="Ảnh">
                    <ItemTemplate>

                        <img src='<%# ResolveUrl("~/Assets/images/toppings/" + Eval("ImageURL")) %>'
                             width="60"
                             height="60"
                             style="object-fit:cover;border-radius:10px;border:1px solid #ddd;" />

                    </ItemTemplate>
                </asp:TemplateField>

                <asp:CheckBoxField
                    DataField="Status"
                    HeaderText="Hiển thị" />

                <asp:TemplateField HeaderText="Thao tác">
                    <ItemTemplate>

                        <a class="btn btn-warning btn-sm"
                           href='ToppingEdit.aspx?id=<%# Eval("ToppingID") %>'>
                            <i class="fa-solid fa-pen"></i>
                            Sửa
                        </a>

                        <asp:LinkButton
                            ID="btnDelete"
                            runat="server"
                            Text="Xóa"
                            CssClass="btn btn-danger btn-sm"
                            CommandArgument='<%# Eval("ToppingID") %>'
                            OnClick="btnDelete_Click"
                            OnClientClick="return confirm('Bạn có chắc muốn xóa topping này không?');">
                        </asp:LinkButton>

                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

            <HeaderStyle CssClass="table-dark" />

        </asp:GridView>

    </div>

</asp:Content>