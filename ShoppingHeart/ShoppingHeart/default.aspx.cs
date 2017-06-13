using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingHeart.BussinessLayer;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Web.Configuration;

namespace ShoppingHeart
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblCategoryName.Text = "Popular Products For Shopping";
                GetCategory();
                GetProducts(0);//get all products
            }
            lblAvailableStockAlert.Text = string.Empty;
        }
        private void GetCategory()
        {
            ShoppingCart k = new ShoppingCart();
            dlCategories.DataSource = null;
            dlCategories.DataSource = k.GetCategories();
            dlCategories.DataBind();
        }
        private void GetProducts(int CategoryID1)
        {
            ShoppingCart k = new ShoppingCart();
            k.CategoryID = CategoryID1;
            dlProducts.DataSource = null;
            dlProducts.DataSource = k.GetAllProducts(); 
            dlProducts.DataBind();
        }

        protected void btnAddtoCart_Click(object sender, EventArgs e)
        {
            string ProductID= Convert.ToInt16((((Button)sender).CommandArgument)).ToString();
            string ProductQuantity = "1";

            DataListItem currentItem = (sender as Button).NamingContainer as DataListItem;
            Label lblAvailableStock = currentItem.FindControl("lblAvailableStock") as Label;
            int i = 0;

            if (Session["MyCart"] != null)
            {
                DataTable dt = (DataTable)Session["MyCart"];
                var checkProduct = dt.AsEnumerable().Where(r => r.Field<string>("ProductID") == ProductID); //to check whether product is already added or not
                if (checkProduct.Count() == 0)
                {
                    string query = "select * from Products_new where ProductID=" + ProductID;
                    DataTable dtProducts = GetData(query);

                    DataRow dr = dt.NewRow();
                    dr["ProductID"] = ProductID;
                    dr["Name"] = Convert.ToString(dtProducts.Rows[0]["Name"]);
                    dr["Description"] = Convert.ToString(dtProducts.Rows[0]["Description"]);
                    dr["Price"] = Convert.ToString(dtProducts.Rows[0]["Price"]);
                    dr["Image"] = Convert.ToString(dtProducts.Rows[0]["Image"]);
                    dr["TotalProducts"] = ProductQuantity;
                    dr["AvailableStock"] = lblAvailableStock.Text;
                    dt.Rows.Add(dr);

                    dt.Rows.Add(ProductID);
                    Session["MyCart"] = dt;
                    if (i==0)
                    btnShoppingHeart.Text = Convert.ToString(dt.Rows.Count-1);
                    if (i == 1)
                        btnShoppingHeart.Text = Convert.ToString(dt.Rows.Count - 3);
                    if (i == 2)
                        btnShoppingHeart.Text = Convert.ToString(dt.Rows.Count - 4);
                    if (i == 3)
                        btnShoppingHeart.Text = Convert.ToString(dt.Rows.Count - 5);
                    i++;
                }
                
            }
            else
            {   
                string query="select * from Products_new where ProductID="+ ProductID ;
                DataTable dtProducts=GetData(query);

                DataTable dt=new DataTable();

                dt.Columns.Add("ProductID",typeof(string));
                dt.Columns.Add("Name",typeof(string));
                dt.Columns.Add("Description",typeof(string));
                dt.Columns.Add("Price",typeof(string));
                dt.Columns.Add("Image",typeof(string));
                dt.Columns.Add("TotalProducts",typeof(string));
                dt.Columns.Add("AvailableStock",typeof(string));
               

                DataRow dr=dt.NewRow();
                dr["ProductID"]=ProductID;
                dr["Name"]=Convert.ToString(dtProducts.Rows[0]["Name"]);
                dr["Description"]=Convert.ToString(dtProducts.Rows[0]["Description"]);
                dr["Price"]=Convert.ToString(dtProducts.Rows[0]["Price"]);
                dr["Image"]=Convert.ToString(dtProducts.Rows[0]["Image"]);
                dr["TotalProducts"]=ProductQuantity;
                dr["AvailableStock"]=lblAvailableStock.Text;
                dt.Rows.Add(dr);

                Session["MyCart"]=dt;
                btnShoppingHeart.Text=dt.Rows.Count.ToString();


            }
           HighlightCartProducts();
        }
        private void HighlightCartProducts()
        { 
            if(Session["MyCart"]!=null)
            {
                DataTable dtproductAddedtoCart = (DataTable)Session["MyCart"];
                if (dtproductAddedtoCart.Rows.Count > 0)
                {
                    foreach (DataListItem item in dlProducts.Items)
                    {
                        HiddenField hfProductID = item.FindControl("hfProductID") as HiddenField;
                        if (dtproductAddedtoCart.AsEnumerable().Any(row => hfProductID.Value==row.Field<string>("ProductID")))
                        {
                            Button btnAddToCart = item.FindControl("btnAddToCart") as Button;
                            btnAddToCart.BackColor = System.Drawing.Color.Green;
                            btnAddToCart.Text = "Added To Cart";
                        }
                    }
                }
            }
        }
        public DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            string conn = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection con = new SqlConnection(conn);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);

            con.Close();
            return dt;

        }

        
        protected void btnShoppingHeart_Click(object sender, EventArgs e)
        {
            GetMyCart();
            lblCategoryName.Text ="Products in your shopping cart";
            lblProductsName.Text = "Coustomer Details";
          /*  pnlMyCart.Visible = true;
            pnlCheckOut.Visible = true;
            pnlCategory.Visible = true;
            pnlProducts.Visible = false;
           */
        }
        private void GetMyCart()
        {
            DataTable dtproducts;
            if (Session["MyCart"] != null)
            {
                dtproducts = (DataTable)Session["MyCart"];
            }
            else
            {
                dtproducts = new DataTable();
            }
            if (dtproducts.Rows.Count > 0)
            {
                txtTotalProducts.Text = dtproducts.Rows.Count.ToString();
                btnShoppingHeart.Text = dtproducts.Rows.Count.ToString();
                dlCartProducts.DataSource = dtproducts;
                dlCartProducts.DataBind();
               UpdateTotalBill();

                pnlMyCart.Visible = true;
                pnlCheckOut.Visible = true;
                pnlEmptyCart.Visible = false;
                pnlCategory.Visible = false;
                pnlProducts.Visible = false;
                pnlOrderPlacedSuccessfully.Visible = false; 
            }
            else
            {
                pnlMyCart.Visible = false;
                pnlCheckOut.Visible = false;
                pnlEmptyCart.Visible = true;
                pnlCategory.Visible = false;
                pnlProducts.Visible = false;
                pnlOrderPlacedSuccessfully.Visible = false;

                dlCartProducts.DataSource = null;
                dlCartProducts.DataBind();
                txtTotalProducts.Text = "0";
                txtPrice.Text = "0";
                btnShoppingHeart.Text = "0";
            }
        }
        private void UpdateTotalBill()
        {
            long TotalPrice = 0;
            long TotalProducts = 0;
            foreach(DataListItem item in dlCartProducts.Items )
            {
                Label PriceLabel = item.FindControl("lblPrice") as Label;
                TextBox ProductQuantity = item.FindControl("txtProductQuantity") as TextBox;
                long ProductPrice=Convert.ToInt32(PriceLabel.Text) * Convert.ToInt32(ProductQuantity.Text);
                TotalPrice = TotalPrice + ProductPrice;
                TotalProducts = TotalProducts + Convert.ToInt32(ProductQuantity.Text);
            }
            txtPrice.Text = Convert.ToString(TotalPrice);
            txtTotalProducts.Text = Convert.ToString(TotalProducts);
        }


        protected void txtProductQuantity_TextChanged(object sender, EventArgs e)
        {
            TextBox txtQuantity = (sender as TextBox);

            DataListItem currentItem = (sender as TextBox).NamingContainer as DataListItem;
            HiddenField ProductID = currentItem.FindControl("hfProductID") as HiddenField;
            Label lblAvailableStock = currentItem.FindControl("lblAvailableStock") as Label;

            if (txtQuantity.Text == string.Empty || txtQuantity.Text == "0" || txtQuantity.Text == "1")
            {
                txtQuantity.Text = "1";
            }
            else
            {
                if (Session["MyCart"] != null)
                {
                    if (Convert.ToInt64(txtQuantity.Text) <= Convert.ToInt64(lblAvailableStock.Text))
                    {
                        DataTable dt = (DataTable)Session["MyCart"];
                        DataRow[] rows = dt.Select("ProductID=" + ProductID.Value + " ");
                        int index = dt.Rows.IndexOf(rows[0]);
                        dt.Rows[index]["TotalProducts"] = txtQuantity.Text;
                        Session["MyCart"] = dt;
                    }
                    else
                    {
                        lblAvailableStockAlert.Text = "Alert...Buyout should not be more than AvailableStock";
                        txtQuantity.Text = "1";
                    }
                }
            }
            UpdateTotalBill();
        }
        protected void lbtnCategory_Click(object sender, EventArgs e)
        {
            pnlMyCart.Visible = false;
            pnlProducts.Visible = true;
            int CategoryID = Convert.ToInt16(((LinkButton)sender).CommandArgument);
            GetProducts(CategoryID);
            HighlightCartProducts();
            //heighlight cart products
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            lblCategoryName.Text = "Popular Products For Shopping";
            lblProductsName.Text = "Products";

            pnlCategory.Visible = true;
            pnlProducts.Visible = true;
            pnlMyCart.Visible = false;
            pnlCheckOut.Visible = false;
            pnlEmptyCart.Visible = false;
            pnlOrderPlacedSuccessfully.Visible = false;

            GetProducts(0);
            HighlightCartProducts();
        }

        protected void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            string ProductID = Convert.ToInt32((((Button)sender).CommandArgument)).ToString();
            if (Session["MyCart"] != null)
            {
                DataTable dt = (DataTable)Session["MyCart"];
                DataRow drr = dt.Select("ProductID=" + ProductID + " ").FirstOrDefault();
                if (drr != null)
                {
                    dt.Rows.Remove(drr); 
                }
                Session["MyCart"] = dt;
            }
            GetMyCart();
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            string productids = string.Empty;
            DataTable dt;
            string trans = string.Empty;
         

            if (Session["MyCart"] != null)
            {
                dt = (DataTable)Session["MyCart"];
      
                ShoppingCart k = new ShoppingCart();
                k.CategoryName = txtName.Text;
                k.CustomerEmailID = txtEmailID.Text;
                k.CustomerAddress = txtAddress.Text;
                k.CustomerPhoneNo = txtPhone.Text;
                k.TotalProducts = Convert.ToInt32(txtTotalProducts.Text);
                k.TotalPrice = Convert.ToInt32(txtPrice.Text);
                k.ProductList = productids;
                k.PaymentMethod = rblPaymentMethod.SelectedItem.Text;

         String cs1 = System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ToString();
        SqlConnection con = new SqlConnection(cs1);
        SqlCommand cmd = new SqlCommand();
        SqlParameter sp1 = new SqlParameter("@CustomerName", SqlDbType.VarChar);
        sp1.Value=txtName.Text;
        SqlParameter sp2 = new SqlParameter("@CustomerEmailID", SqlDbType.VarChar);
        sp2.Value = txtEmailID.Text;
        SqlParameter sp3 = new SqlParameter("@CustomerPhoneNo", SqlDbType.VarChar);
        sp3.Value = txtPhone.Text;
        SqlParameter sp4 = new SqlParameter("@CustomerAddress", SqlDbType.VarChar);
        sp4.Value = txtAddress.Text;
        SqlParameter sp5 = new SqlParameter("@TotalProducts", SqlDbType.Int);
        sp5.Value = Convert.ToInt32(txtTotalProducts.Text);
        SqlParameter sp6 = new SqlParameter("@TotalPrice", SqlDbType.Int);
        sp6.Value = Convert.ToInt32(txtPrice.Text);
                SqlParameter sp7 = new SqlParameter("@PaymentMethod", SqlDbType.VarChar);
        sp7.Value = rblPaymentMethod.SelectedItem.Text;

        cmd.Parameters.Add(sp1);
        cmd.Parameters.Add(sp2);
        cmd.Parameters.Add(sp3);
        cmd.Parameters.Add(sp4);
        cmd.Parameters.Add(sp5);
        cmd.Parameters.Add(sp6);
                cmd.Parameters.Add(sp7);

        cmd.Connection = con;
        cmd.CommandText = "insert into CustomerDetails (CustomerName,CustomerEmailID,CustomerPhoneNo,CustomerAddress,TotalProducts,TotalPrice,PaymentMethod) values (@CustomerName,@CustomerEmailID,@CustomerPhoneNo,@CustomerAddress,@TotalProducts,@TotalPrice,@PaymentMethod) select @@IDENTITY as CustomerID";

        con.Open();
        int a = cmd.ExecuteNonQuery();
        con.Close();



                String cs2= System.Configuration.ConfigurationManager.ConnectionStrings ["MyConn"].ToString ();
    SqlConnection con1=new SqlConnection(cs2);
    SqlCommand cmd1= new SqlCommand();
    cmd1.Connection=con1;
    cmd1.CommandText = "select * from CustomerDetails";
    con1.Open ();
    SqlDataReader dr1=cmd1.ExecuteReader();
      //DataTable dtResult = k.SaveCustomerDetails();

                for(int i=0; i < dt.Rows.Count && dr1.Read(); i++)
                {   
                    ShoppingCart SaveProducts=new ShoppingCart();
                    SaveProducts.CustomerID = Convert.ToInt32(dr1["Id"].ToString());
                    SaveProducts.ProductID = Convert.ToInt32(dt.Rows[i][0]);
                    //SaveProducts.ProductID = Convert.ToInt32(dt.Rows[i]["ProductID"]);
                    SaveProducts.TotalProducts = Convert.ToInt32(dt.Rows[i][6]);
                    //SaveProducts.TotalProducts = Convert.ToInt32(dt.Rows[i]["TotalProducts"]);
                    SaveProducts.SaveCustomerProducts();
                    trans = dr1["Id"].ToString();
                }

                Session.Clear();
                GetMyCart();

                lblTransactionNo.Text="Your Transaction no is "+ trans;

                pnlCategory.Visible = false;
                pnlProducts.Visible = false;
                pnlMyCart.Visible = false;
                pnlCheckOut.Visible = false;
                pnlEmptyCart.Visible = false;
                pnlOrderPlacedSuccessfully.Visible = true;

               SendOrderPlacedAlert(txtName.Text,txtEmailID.Text,trans);
                
                txtName.Text=string.Empty;
                txtEmailID.Text=string.Empty;
                txtPhone.Text=string.Empty;
                txtAddress.Text=string.Empty;
                txtPrice.Text="0";
                txtTotalProducts.Text="0";
            
                    con1.Close();
            }


        }
        private string PopulateOrderEmailBody(string customerName,string transaction)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/OrderTemplate.htm")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{CustomerName}", customerName);
            body = body.Replace("{OrderNo}", transaction);
            body = body.Replace("{TransactionURL}", "http://www.ShoppingHeart.com/TrackYourOrder.aspx?Id=" + transaction);
            return body;
        }

        private void SendOrderPlacedAlert(string CustomerName, string CustomerEmailID, String TransactionNo)
        {
            string body = this.PopulateOrderEmailBody(CustomerName, TransactionNo);
            EmailEngine.SendEmail(CustomerEmailID,"Shopping ...your order Details",body);
        }


       
    }
}