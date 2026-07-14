<%@ Page Title="Chi tiết tin tức"
    Language="C#"
    MasterPageFile="~/Site.master"
    AutoEventWireup="true"
    CodeBehind="NewsDetail.aspx.cs"
    Inherits="TraSuaNgon.NewsDetail" %>


<asp:Content 
    ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


<div class="container mt-5 mb-5">


    <asp:Panel ID="pnlNews"
        runat="server">


        <h1 class="fw-bold mb-3">
            <asp:Label 
                ID="lblTitle"
                runat="server">
            </asp:Label>
        </h1>



        <div class="text-muted mb-3">

            <i class="fa fa-user"></i>

            <asp:Label 
                ID="lblAuthor"
                runat="server">
            </asp:Label>


            |

            <asp:Label 
                ID="lblDate"
                runat="server">
            </asp:Label>

        </div>




        <asp:Image
            ID="imgNews"
            runat="server"
            CssClass="img-fluid rounded shadow mb-4" />




        <p class="lead">

            <asp:Label
                ID="lblSummary"
                runat="server">
            </asp:Label>

        </p>



        <hr />


        <div>

            <asp:Literal
                ID="litContent"
                runat="server">
            </asp:Literal>

        </div>


    </asp:Panel>


</div>


</asp:Content>