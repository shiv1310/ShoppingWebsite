using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ShoppingHeart.BussinessLayer;

namespace ShoppingHeart.Admin
{
    public partial class AddEditCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)     //it ge t executed only 1st time when page gets loaded
            {
                GetCategories();
                AddSubmitEvent();
                if (Request.QueryString["alert"] == "succcess")
                {
                    Response.Write("<script>alert('Record saved successfully')</script>");
                }
            }
        }
        private void AddSubmitEvent()
        {
            UpdatePanel updatepanel = Page.Master.FindControl("AdminUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = Button1.UniqueID;
            updatepanel.Triggers.Add(trigger);
        }
        private void GetCategories()
        {
            ShoppingCart k = new ShoppingCart();
            DataTable dt = k.GetCategories();
            if (dt.Rows.Count > 0)
            {
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataSource = dt;
                ddlCategory.DataBind();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {/*
       string cs1 = System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ToString();
        SqlConnection con = new SqlConnection(cs1);
        SqlCommand cmd = new SqlCommand();
        SqlParameter sp1 = new SqlParameter("@uname", SqlDbType.VarChar);
        sp1.Value = TextBox1.Text;
        SqlParameter sp2 = new SqlParameter("@pwd", SqlDbType.VarChar);
        sp2.Value = TextBox2.Text;
        cmd.Parameters.Add(sp1);
        cmd.Parameters.Add(sp2);
        cmd.Connection = con;
        cmd.CommandText = "insert into login values(@uname,@pwd)";
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
       // Label3.Text="User Account "+TextBox1.Text+" Created Successfully";*/
            if (FileUpload1.PostedFile != null)
            {
                SaveProductPhoto();
                string filename = FileUpload1.PostedFile.FileName;
                string b;
                int p = filename.LastIndexOf("\\");
                if (p > 0)
                {
                    b = filename.Substring(p + 1);
                }
                else
                {
                    b = filename;
                }
                ShoppingCart k = new ShoppingCart();
                k.ProductName = TextBox1.Text;
                //k.ProductImage = @"D:\vs_shiv\ShoppingHeart\ShoppingHeart\ProductImages\" + FileUpload1.FileName;
                k.ProductImage = b;
                k.ProductPrice = Convert.ToInt32( TextBox3.Text);
                k.ProductDescription = TextBox2.Text;
                k.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                k.TotalProducts = Convert.ToInt32(txtProductQuantity.Text);
                k.UpdateNewProduct();
                //alert show new product added,
                Response.Write("<script>alert('Updated Product added')</script>");
                //Label1.Text = "new product added";
               ClearText();
               Response.Redirect("~/Admin/UpdateProduct.aspx?alert=success");

            }
            else
            {
                Response.Write("<script>alert('please upload photo')</script>");
                //Alert.Show("Upload product photo");
            }

        }
        public void ClearText()
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            FileUpload1 = null;
            txtProductQuantity.Text = string.Empty;
           

        }

        public void SaveProductPhoto()
        {
            string filename = FileUpload1.PostedFile.FileName;
            string b;
           
            int p = filename.LastIndexOf("\\");
            if (p > 0)
            {
                b = filename.Substring(p + 1);
            }
            else
            {
                b = filename;
            }
            	

            string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);

            //check file name length
            if (filename.Length > 90)
            {   //Alert.Show("image name should not exceed 96 characteres!!!"); 
            }
            //check file type
            else if (fileExt!=".jpeg" && fileExt!=".bmp" && fileExt!=".png" &&fileExt!=".jpg")
            {
                //Alert.Show("only jpeg,bmp and png images are allowed");
            }
            else if (FileUpload1.PostedFile.ContentLength > 4000000)
            { 
                //Alert.Show("only jpeg,bmp and png images are allowed");
            }
            else
            {
                // saves image in website folder.
                FileUpload1.PostedFile.SaveAs(Server.MapPath(b));
            }
        }
    }
}