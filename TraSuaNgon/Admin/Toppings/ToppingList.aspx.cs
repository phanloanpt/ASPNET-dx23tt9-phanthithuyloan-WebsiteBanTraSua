using BLL;
using System;

namespace TraSuaNgon.Admin.Toppings
{
    public partial class ToppingList : System.Web.UI.Page
    {
        ToppingBLL toppingBLL =
            new ToppingBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            gvToppings.DataSource =
                toppingBLL.GetAllToppings();

            gvToppings.DataBind();
        }

        protected void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            var btn =
                (System.Web.UI.WebControls.LinkButton)sender;

            int id =
                Convert.ToInt32(
                    btn.CommandArgument);

            toppingBLL.DeleteTopping(id);

            LoadData();
        }
    }
}