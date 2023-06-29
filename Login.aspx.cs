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
    public partial class Login : System.Web.UI.Page
    {
        private string baseurl = "https://www.infotecker.co.za/api/SATRI_api/";

        private string[] getloginDetails(string s1, string s2)
        {
            string url = string.Format(baseurl + "Login?email=" + s1 + "&&password=" + s2);

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
                return (string[])serialiser.Deserialize(result, typeof(string[]));
            }
            else
            {
                return null;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void login_Click(object sender, EventArgs e)
        {
            if (email.Text != "" && password.Text != "")
            {
                string[] strDetails = getloginDetails(email.Text, password.Text);

                if (strDetails == null)
                {
                    error.Text = "Wrong password or email";
                    error.Visible = true;
                }
                else if (strDetails[2].Equals("VERIFIED"))
                {
                    Session["LoggedInUserID"] = strDetails[0];

                    if (strDetails[1].Equals("EXECUTIVE_DIRECTOR"))
                    {
                        Response.Redirect("ExecutiveDirectorAccount.aspx");

                    }
                    else if (strDetails[1].Equals("SENIOR_RESEARCHER"))
                    {
                        Response.Redirect("SeniorResearcherAccount.aspx");

                    }
                    else if (strDetails[1].Equals("RESEARCHER"))
                    {
                        Response.Redirect("ResearcherAccount.aspx");

                    }
                    else if (strDetails[1].Equals("ADMINISTRATOR"))
                    {
                        Response.Redirect("AdministratorAccount.aspx");
                    }                   
                }
                else if (strDetails[2].Equals("UNVERIFIED"))
                {
                    Response.Redirect("Welcome.aspx");
                }

            }
            else
            {
                error.Text = "Wrong password or email";
                error.Visible = true;
            }         
                        
        }

        protected void reg_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}