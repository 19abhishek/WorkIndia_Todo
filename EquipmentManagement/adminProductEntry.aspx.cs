using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquipmentManagement
{
    public partial class adminProductEntry : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //add
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfProductExists())
            {
                //Response.Write("<script>alert('Product with this ID already Exist. You cannot add another Product with the same Product ID');</script>");
                addParameter();
            }
            else
            {
                addNewProduct();
                addParameter();
            }
        }


        //update
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfProductExists())
            {
                updateProduct();

            }
            else
            {
                Response.Write("<script>alert('Product does not exist');</script>");
            }
        }

        //delete
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfProductExists())
            {
                deleteProduct();

            }
            else
            {
                Response.Write("<script>alert('Product does not exist');</script>");
            }
        }
        //go
        protected void Button1_Click(object sender, EventArgs e)
        {
            getProductByID();
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox4.Text = "";
        }
        void getProductByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from prod_add_tbl where product_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Author ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void deleteProduct()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from prod_add_tbl WHERE product_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Product Deleted Successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkIfProductExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from prod_add_tbl where product_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void addNewProduct()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO prod_add_tbl(product_id,product_name) values(@product_id,@product_name)", con);

                cmd.Parameters.AddWithValue("@product_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@product_name", TextBox4.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Product added Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void addParameter()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO admin_prod_parameter(Id,Parameter) values(@product_id,@product_parameter)", con);

                cmd.Parameters.AddWithValue("@product_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@product_parameter", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Product added Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updateProduct()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE prod_add_tbl SET product_name=@product_name WHERE product_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@product_name", TextBox4.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Product Updated Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }




    }
}