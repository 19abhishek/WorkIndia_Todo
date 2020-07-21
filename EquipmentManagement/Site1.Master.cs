using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquipmentManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sessionrole = Session["role"] as string;
                if(string.IsNullOrEmpty(sessionrole))
                {
                    LinkButton1.Visible = true;
                    //LinkButton4.Visible = true;
                    LinkButton3.Visible = true;
                    LinkButton7.Visible = true;

                    LinkButton6.Visible = true;
                    LinkButton11.Visible = true;
                    LinkButton5.Visible = false;
                    LinkButton8.Visible = false;
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; // user login link button
                    //LinkButton2.Visible = false; // sign up link button

                    LinkButton3.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello " + Session["username"].ToString();


                    LinkButton6.Visible = false ; // admin login link button
                    LinkButton8.Visible = true;
                    LinkButton11.Visible = false; // author management link button
                    //LinkButton12.Visible = false; // publisher management link button
                    LinkButton5.Visible = false; // book inventory link button
                    //LinkButton9.Visible = false; // book issuing link button
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; // user login link button
                    //LinkButton2.Visible = false; // sign up link button

                    LinkButton3.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello Admin";


                    LinkButton6.Visible = false; // admin login link button
                    LinkButton5.Visible = true; // author management link button
                    //LinkButton12.Visible = true; // publisher management link button
                    LinkButton8.Visible = false ; // book inventory link button
                    LinkButton11.Visible = false ; // book issuing link button
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminProductEntry.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("userParameterEntry.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";

            LinkButton1.Visible = true;
            //LinkButton4.Visible = true;
            LinkButton3.Visible = true;
            LinkButton7.Visible = true;

            LinkButton6.Visible = true;
            LinkButton11.Visible = true;
            LinkButton5.Visible = false;
            LinkButton8.Visible = false;

            Response.Redirect("homepage.aspx");
        }
    }
}