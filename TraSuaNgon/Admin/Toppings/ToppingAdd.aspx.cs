using BLL;
using Model;
using System;

namespace TraSuaNgon.Admin.Toppings
{
    public partial class ToppingAdd : System.Web.UI.Page
    {
        ToppingBLL toppingBLL =
            new ToppingBLL();

        protected void btnSave_Click(
            object sender,
            EventArgs e)
        {
            Topping t =
                new Topping();

            t.ToppingName =
                txtName.Text.Trim();

            t.Price =
                Convert.ToDecimal(
                    txtPrice.Text);

            // Chỉ lưu tên file vào DB
            string fileName = "";

            if (fuImage.HasFile)
            {
                fileName =
                    System.IO.Path.GetFileName(
                        fuImage.FileName);

                string savePath =
                    Server.MapPath(
                        "~/Assets/images/toppings/" +
                        fileName);

                fuImage.SaveAs(savePath);
            }

            t.ImageURL = fileName;

            t.Status =
                chkStatus.Checked;

            t.CreatedDate =
                DateTime.Now;

            if (toppingBLL.InsertTopping(t))
            {
                Response.Redirect(
                    "ToppingList.aspx");
            }
        }
    }
}