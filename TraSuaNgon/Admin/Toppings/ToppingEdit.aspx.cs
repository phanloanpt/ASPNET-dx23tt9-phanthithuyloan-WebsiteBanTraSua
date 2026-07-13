using BLL;
using Model;
using System;

namespace TraSuaNgon.Admin.Toppings
{
    public partial class ToppingEdit : System.Web.UI.Page
    {
        ToppingBLL toppingBLL =
            new ToppingBLL();

        int id;

        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            // kiểm tra có id hay không
            if (!int.TryParse(
                    Request.QueryString["id"],
                    out id))
            {
                Response.Redirect(
                    "ToppingList.aspx");

                return;
            }

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            Topping t =
                toppingBLL.GetToppingByID(id);

            if (t == null)
            {
                Response.Redirect(
                    "ToppingList.aspx");

                return;
            }

            txtName.Text =
                t.ToppingName;

            txtPrice.Text =
                t.Price.ToString();

            imgPreview.ImageUrl =
                "~/Assets/images/toppings/" +
                t.ImageURL;

            chkStatus.Checked =
                t.Status;
        }

        protected void btnSave_Click(
            object sender,
            EventArgs e)
        {
            Topping t =
                new Topping();

            t.ToppingID = id;
            t.ToppingName = txtName.Text;
            t.Price = Convert.ToDecimal(txtPrice.Text);
            string imageName =
    toppingBLL.GetToppingByID(id).ImageURL;

            if (fuImage.HasFile)
            {
                imageName =
                    System.IO.Path.GetFileName(
                        fuImage.FileName);

                string savePath =
                    Server.MapPath(
                        "~/Assets/images/toppings/" +
                        imageName);

                fuImage.SaveAs(savePath);
            }

            t.ImageURL = imageName;
            t.Status = chkStatus.Checked;

            toppingBLL.UpdateTopping(t);

            Response.Redirect(
                "ToppingList.aspx");
        }
    }
}