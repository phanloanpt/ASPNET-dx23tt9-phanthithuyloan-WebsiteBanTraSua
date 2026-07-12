using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;


namespace TraSuaNgon
{
    public partial class ProductDetail : System.Web.UI.Page
    {


        private ProductBLL productBLL = new ProductBLL();

        private ToppingBLL toppingBLL = new ToppingBLL();




        protected void Page_Load(
            object sender,
            EventArgs e)
        {


            if (!IsPostBack)
            {


                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("Menu.aspx");
                    return;
                }



                LoadProduct();

                LoadToppings();

                CalculateTotal(null, null);


            }


        }







        // ==============================
        // LOAD PRODUCT
        // ==============================

        private void LoadProduct()
        {

            int productId;


            if (!int.TryParse(
                Request.QueryString["id"],
                out productId))
            {
                Response.Redirect("Menu.aspx");
                return;
            }



            Product product =
                productBLL.GetProductByID(productId);



            if (product == null)
            {
                Response.Redirect("Menu.aspx");
                return;
            }



            lblProductName.Text =
                product.ProductName;



            lblDescription.Text =
                product.Description;



            lblPriceM.Text =
                product.PriceM.ToString("N0");



            lblPriceL.Text =
                product.PriceL.ToString("N0");



            imgProduct.ImageUrl =
                "~/Assets/images/products/"
                + product.ImageURL;


        }









        // ==============================
        // LOAD TOPPING
        // ==============================

        private void LoadToppings()
        {

            cblToppings.Items.Clear();



            var toppings =
                toppingBLL.GetAllToppings();




            foreach (var topping in toppings)
            {

                ListItem item =
                    new ListItem();



                item.Text =
                    topping.ToppingName
                    + " +"
                    + topping.Price.ToString("N0")
                    + "đ";



                item.Value =
                    topping.ToppingID.ToString();




                cblToppings.Items.Add(item);

            }


        }









        // ==============================
        // TÍNH GIÁ
        // ==============================

        protected void CalculateTotal(
            object sender,
            EventArgs e)
        {


            int productId;



            if (!int.TryParse(
                Request.QueryString["id"],
                out productId))
            {
                return;
            }




            Product product =
                productBLL.GetProductByID(productId);




            if (product == null)
            {
                return;
            }




            decimal total;



            if (rblSize.SelectedValue == "L")
            {
                total = product.PriceL;
            }
            else
            {
                total = product.PriceM;
            }







            foreach (ListItem item in cblToppings.Items)
            {

                if (item.Selected)
                {

                    int toppingId =
                        Convert.ToInt32(item.Value);



                    var topping =
                        toppingBLL.GetAllToppings()
                        .FirstOrDefault(
                            x => x.ToppingID == toppingId);



                    if (topping != null)
                    {
                        total += topping.Price;
                    }

                }

            }







            int quantity = 1;


            int.TryParse(
                txtQuantity.Text,
                out quantity);



            if (quantity <= 0)
            {
                quantity = 1;
            }



            total =
                total * quantity;



            lblTotalPrice.Text =
                total.ToString("N0");


        }









        // ==============================
        // ADD TO CART
        // ==============================

        protected void btnAddToCart_Click(
            object sender,
            EventArgs e)
        {


            int productId =
                Convert.ToInt32(
                    Request.QueryString["id"]);




            Product product =
                productBLL.GetProductByID(productId);




            if (product == null)
            {
                return;
            }






            List<CartItem> cart;



            if (Session["Cart"] == null)
            {

                cart =
                    new List<CartItem>();

            }
            else
            {

                cart =
                (List<CartItem>)Session["Cart"];

            }







            string size =
                rblSize.SelectedValue;







            decimal price;


            if (size == "L")
            {
                price = product.PriceL;
            }
            else
            {
                price = product.PriceM;
            }







            int quantity = 1;


            int.TryParse(
                txtQuantity.Text,
                out quantity);



            if (quantity <= 0)
            {
                quantity = 1;
            }








            decimal toppingPrice = 0;


            List<int> toppingIds =
                new List<int>();


            List<string> toppingNames =
                new List<string>();






            var toppings =
                toppingBLL.GetAllToppings();






            foreach (ListItem item in cblToppings.Items)
            {

                if (item.Selected)
                {


                    int toppingId =
                        Convert.ToInt32(item.Value);



                    toppingIds.Add(toppingId);





                    var topping =
                        toppings.FirstOrDefault(
                            x => x.ToppingID == toppingId);



                    if (topping != null)
                    {

                        toppingPrice +=
                            topping.Price;


                        toppingNames.Add(
                            topping.ToppingName);

                    }


                }


            }









            CartItem newItem =
                new CartItem();




            newItem.ProductID =
                product.ProductID;



            newItem.ProductName =
                product.ProductName;



            newItem.ImageURL =
                product.ImageURL;



            newItem.Size =
                size;



            newItem.Quantity =
                quantity;



            newItem.UnitPrice =
                price + toppingPrice;



            newItem.TotalPrice =
                newItem.UnitPrice * quantity;




            newItem.ToppingIDs =
                toppingIds;



            newItem.ToppingNames =
                string.Join(", ", toppingNames);









            // ==============================
            // KIỂM TRA SẢN PHẨM ĐÃ CÓ CHƯA
            // ==============================


            CartItem existing =
                cart.FirstOrDefault(x =>
                    x.ProductID == newItem.ProductID
                    &&
                    x.Size == newItem.Size
                    &&
                    x.ToppingNames == newItem.ToppingNames
                );







            if (existing != null)
            {


                existing.Quantity += quantity;



                existing.TotalPrice =
                    existing.Quantity *
                    existing.UnitPrice;


            }

            else
            {

                cart.Add(newItem);

            }








            Session["Cart"] =
                cart;






            // reload để Master cập nhật icon cart

            Response.Redirect(
                Request.RawUrl);


        }



    }
}