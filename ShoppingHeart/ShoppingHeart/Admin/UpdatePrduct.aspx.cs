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
    public partial class UpdatePrduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

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
               /* ShoppingCart k = new ShoppingCart();
                k.ProductName = TextBox1.Text;
                k.ProductID = Convert.ToInt32(TextBox4.Text);
                //k.ProductImage = @"D:\vs_shiv\ShoppingHeart\ShoppingHeart\ProductImages\" + FileUpload1.FileName;
                k.ProductImage = b;
                k.ProductPrice = Convert.ToInt32(TextBox3.Text);
                k.ProductDescription = TextBox2.Text;
                k.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                k.TotalProducts = Convert.ToInt32(txtProductQuantity.Text);
                int a=k.UpdateNewProduct();
               
             /*   //alert show new product added,
                Response.Write("<script>alert('New Product added')</script>");
                //Label1.Text = "new product added";
                ClearText();
                Response.Redirect("~/Admin/AddNewProduct.aspx?alert=success");*/



                String cs1 = System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ToString();
                SqlConnection con = new SqlConnection(cs1);
                SqlCommand cmd = new SqlCommand();
                SqlParameter sp1 = new SqlParameter("@Name", SqlDbType.VarChar);
                sp1.Value = TextBox1.Text;
                SqlParameter sp2 = new SqlParameter("@ProductID", SqlDbType.Int);
                sp2.Value = Convert.ToInt32(TextBox4.Text);
                SqlParameter sp3 = new SqlParameter("@Description", SqlDbType.VarChar);
                sp3.Value = TextBox2.Text;
                SqlParameter sp4 = new SqlParameter("@Price", SqlDbType.Int);
                sp4.Value = Convert.ToInt32(TextBox3.Text);
                SqlParameter sp5 = new SqlParameter("@Image", SqlDbType.VarChar);
                sp5.Value = b;
                SqlParameter sp6 = new SqlParameter("@CategoryID", SqlDbType.Int);
                sp6.Value = Convert.ToInt32(ddlCategory.DataValueField);
                SqlParameter sp7 = new SqlParameter("@TotalProducts", SqlDbType.VarChar);
                sp7.Value = Convert.ToInt32(txtProductQuantity.Text);
                cmd.Parameters.Add(sp1);
                cmd.Parameters.Add(sp2);
                cmd.Parameters.Add(sp3);
                cmd.Parameters.Add(sp4);
                cmd.Parameters.Add(sp5);
                cmd.Parameters.Add(sp6);
                cmd.Parameters.Add(sp7);
                cmd.Connection = con;
                //cmd.CommandText = "update P set P.Name=@Name, P.Description=@Description, P.Price=@Price, P.Image=@Image,P.CategoryID=@CategoryID,P.TotalProducts=@TotalProducts From Products_new P INNER JOIN Category C ON P.CategoryID=C.CategoryID where P.ProductID=@ProductID ";
                cmd.CommandText = "update Product_new set Name=@Name, Description=@Description, Price=@Price, Image=@Image,CategoryID=@CategoryID,TotalProducts=@TotalProducts where ProductID=@ProductID ";
                con.Open();
                int a = cmd.ExecuteNonQuery();
                con.Close();
                if (a > 0)
                    Label1.Text = "Account of " + TextBox1.Text + " modified successfully";
                else
                    Label1.Text = "Account does not exists";

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
