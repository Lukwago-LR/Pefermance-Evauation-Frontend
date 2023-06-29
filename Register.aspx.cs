using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SATRI_CLIENT
{
    public partial class Register : System.Web.UI.Page
    {
        private string baseurl = "https://www.infotecker.co.za/api/SATRI_api/";

        private int reg(string t, string fn, string sn, string ut, string c, string e, string p)
        {
            string url = string.Format(baseurl+"RegisterAsync?title=" + t + "&&firstname=" + fn + "&&surname=" + sn + "&&userType=" + ut + "&&contact=" + c + "&&email=" + e + "&&password=" + p);

            WebRequest obj = WebRequest.Create(url);

            obj.Method = "GET";
            HttpWebResponse response = null;

            response = (HttpWebResponse)obj.GetResponse();

            string result = null;

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader r = new StreamReader(stream);
                result = r.ReadToEnd();
                r.Close();
            }
            if (result != null)
            {
                var serialiser = new System.Web.Script.Serialization.JavaScriptSerializer();
                return (int)serialiser.Deserialize(result, typeof(Int32));
            }
            else
            {
                return -1;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Click(object sender, EventArgs e)
        {
            if (Password.Text != ConfirmPass.Text)
            {
                error.Text = "Passwords do not match";
                error.Visible = true;
            }
            else
            {
                //integer function returning 1 for success, 0 for user already exists and -1 for catastrophy 
                int registered = reg(DropDownList1.Text, firstname.Text, surname.Text, DropDownList2.Text, contact.Text, email.Text, Password.Text);

                if (registered == 1)
                {


                    Response.Redirect("Login.aspx");
                }
                else if (registered == -1)
                {
                    error.Text = "Something went wrong, please try again later";
                    error.Visible = true;
                }
                else if (registered == 0)
                {
                    error.Text = "The user already exists";
                }
            }


        }
    }
}