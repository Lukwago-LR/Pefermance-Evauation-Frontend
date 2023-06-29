using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SATRI_CLIENT
{

    public partial class ChangeProfile : System.Web.UI.Page
    {
        private string baseurl = "https://www.infotecker.co.za/api/SATRI_api/";
        string p;
        string c;
        string em;
        string cp;


        private int edit(string c, string e, string p, int i)
        {
            string url = string.Format(baseurl + "updateProfile?contact=" + c + "&&email=" + e + "&&password=" + p + "&&ID=" + i);

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

        private List<string> singleEmployee(int empid)
        {
            string url = string.Format(baseurl + "getEmployeebyIdAsync?id=" + empid);

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
                return (List<string>)serialiser.Deserialize(result, typeof(List<string>));
            }
            else
            {
                return null;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string s = Request.QueryString["ID"];
                global.GlobalVar = s;
                List<string> l = singleEmployee(Convert.ToInt32(s));
                contact.Text = l[4];
                email.Text = l[5];

            }
            else
            {

                c = contact.Text;
                em = email.Text;
                p = Password.Text;
                cp = ConfirmPass.Text;

            }

        }

        protected void Edit_Click(object sender, EventArgs e)
        {

            if (p != cp)
            {
                error.Text = "Passwords do not match";
                error.Visible = true;
            }
            else
            {
                //integer function returning 1 for success               
                int ed = edit(c, em, p, Convert.ToInt32(global.GlobalVar));
                if (ed == 1)
                {
                    error.Text = "profile was successfully updated";
                    error.Visible = true;
                }
                else
                {
                    error.Text = "profile update failed";
                    error.Visible = true;
                }

            }

        }

    }          
 
}