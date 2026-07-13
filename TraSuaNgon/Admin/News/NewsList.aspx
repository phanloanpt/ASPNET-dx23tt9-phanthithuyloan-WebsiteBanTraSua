<%@ Page Title="Quản lý tin tức"
    Language="C#"
    MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="NewsList.aspx.cs"
    Inherits="TraSuaNgon.Admin.News.NewsList" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="container-fluid mt-4">

    <div class="d-flex justify-content-between mb-3">

        <h2 class="text-danger">
            <i class="fa-solid fa-newspaper"></i>
            Quản lý tin tức
        </h2>

        <a href="NewsAdd.aspx"
           class="btn btn-danger">
            <i class="fa-solid fa-plus"></i>
            Thêm tin tức
        </a>

    </div>

    <asp:GridView
        ID="gvNews"
        runat="server"
        AutoGenerateColumns="False"
        CssClass="table table-bordered table-hover"
        OnRowCommand="gvNews_RowCommand">

        <Columns>

            <asp:BoundField
                DataField="NewsID"
                HeaderText="ID" />

            <asp:ImageField
                DataImageUrlField="ImageURL"
                HeaderText="Ảnh">
                <ControlStyle Width="100px"
                    Height="70px" />
            </asp:ImageField>

            <asp:BoundField
                DataField="Title"
                HeaderText="Tiêu đề" />

            <asp:BoundField
                DataField="Author"
                HeaderText="Tác giả" />

            <asp:TemplateField
                HeaderText="Nổi bật">

                <ItemTemplate>
                    <%# Convert.ToBoolean(Eval("IsFeatured"))
                    ? "⭐ Có"
                    : "Không" %>
                </ItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField
                HeaderText="Trạng thái">

                <ItemTemplate>
                    <%# Convert.ToBoolean(Eval("Status"))
                    ? "Hiển thị"
                    : "Ẩn" %>
                </ItemTemplate>

            </asp:TemplateField>

            <asp:BoundField
                DataField="CreatedDate"
                HeaderText="Ngày tạo"
                DataFormatString="{0:dd/MM/yyyy HH:mm}" />

            <asp:TemplateField HeaderText="Thao tác">

                <ItemTemplate>

                    <asp:Button
                        ID="btnEdit"
                        runat="server"
                        Text="Sửa"
                        CssClass="btn btn-warning btn-sm"
                        CommandName="EditNews"
                        CommandArgument='<%# Eval("NewsID") %>' />

                    <asp:Button
                        ID="btnDelete"
                        runat="server"
                        Text="Xóa"
                        CssClass="btn btn-danger btn-sm"
                        CommandName="DeleteNews"
                        CommandArgument='<%# Eval("NewsID") %>'
                        OnClientClick="return confirm('Xóa tin này?');" />

                </ItemTemplate>

            </asp:TemplateField>

        </Columns>

    </asp:GridView>

</div>

</asp:Content>