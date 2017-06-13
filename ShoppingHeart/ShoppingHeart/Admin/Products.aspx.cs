using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingHeart.BussinessLayer;
using System.Data;

namespace ShoppingHeart.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetProducts(0);
            }
        }

        private void GetProducts(int CategoryID)
        {
            ShoppingCart k = new ShoppingCart();
            k.CategoryID = CategoryID;
            DataTable dt = k.GetCategories();
            gvAvailableProducts.DataSource = null;
            gvAvailableProducts.DataSource = k.GetAllProducts();
            gvAvailableProducts.DataBind();
           
        }
    }
}