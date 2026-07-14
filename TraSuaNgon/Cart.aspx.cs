using System;
using System.Collections.Generic;
using Model;

namespace TraSuaNgon
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCart();
            }
        }

        private void LoadCart()
        {
            if (Session["Cart"] == null)
            {
                pnlEmpty.Visible = true;
                pnlCart.Visible = false;
                return;
            }

            List<CartItem> cart =
                (List<CartItem>)Session["Cart"];

            if (cart.Count == 0)
            {
                pnlEmpty.Visible = true;
                pnlCart.Visible = false;
                return;
            }

            pnlEmpty.Visible = false;
            pnlCart.Visible = true;

            gvCart.DataSource = cart;
            gvCart.DataBind();

            decimal total = 0;

            foreach (var item in cart)
            {
                total += item.TotalPrice;
            }

            lblGrandTotal.Text =
                total.ToString("N0");
        }

        protected void gvCart_RowCommand(
            object sender,
            System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            List<CartItem> cart =
                Session["Cart"] as List<CartItem>;

            if (cart == null)
                return;

            int index =
                Convert.ToInt32(
                    e.CommandArgument);

            // Tăng số lượng
            if (e.CommandName == "Increase")
            {
                cart[index].Quantity++;

                cart[index].TotalPrice =
                    cart[index].Quantity *
                    cart[index].UnitPrice;
            }

            // Giảm số lượng
            else if (e.CommandName == "Decrease")
            {
                if (cart[index].Quantity > 1)
                {
                    cart[index].Quantity--;

                    cart[index].TotalPrice =
                        cart[index].Quantity *
                        cart[index].UnitPrice;
                }
            }

            // Xóa sản phẩm
            else if (e.CommandName == "DeleteItem")
            {
                cart.RemoveAt(index);
            }

            Session["Cart"] = cart;

            // reload lại trang để cập nhật GridView
            Response.Redirect(Request.RawUrl);
        }

        // ===============================
        // THANH TOÁN
        // ===============================

        protected void btnCheckout_Click(
            object sender,
            EventArgs e)
        {
            // Nếu chưa đăng nhập
            if (Session["UserID"] == null)
            {
                Session["ReturnUrl"] =
                    "Checkout.aspx";

                Response.Redirect(
                    "Login.aspx");

                return;
            }

            // Nếu đã đăng nhập
            Response.Redirect(
                "Checkout.aspx");
        }
    }
}