using System;
using System.Collections.Generic;
using Model;


namespace TraSuaNgon
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {


        protected void Page_Load(
            object sender,
            EventArgs e)
        {


            LoadCartCount();

            CheckLogin();


        }







        // ==========================
        // CẬP NHẬT SỐ LƯỢNG GIỎ HÀNG
        // ==========================

        private void LoadCartCount()
        {

            int count = 0;



            if (Session["Cart"] != null)
            {


                List<CartItem> cart =
                    (List<CartItem>)Session["Cart"];




                foreach (CartItem item in cart)
                {

                    count += item.Quantity;

                }


            }





            lblCartCount.Text =
                count.ToString();



        }









        // ==========================
        // KIỂM TRA ĐĂNG NHẬP
        // ==========================

        private void CheckLogin()
        {



            if (Session["UserID"] != null)
            {


                pnlGuestTop.Visible = false;


                pnlUserTop.Visible = true;




                if (Session["FullName"] != null)
                {

                    lblUserNameTop.Text =
                        Session["FullName"].ToString();

                }



            }

            else
            {


                pnlGuestTop.Visible = true;


                pnlUserTop.Visible = false;


            }



        }



    }
}