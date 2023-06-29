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
    public partial class Delete : System.Web.UI.Page
    {
        private string baseurl = "https://www.infotecker.co.za/api/SATRI_api/";

        private int removing(string fid)
        {
            string url = string.Format(baseurl+"removeFile?fileID=" + fid);

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
            string s = Request.QueryString["ID"];
            string[] str = s.Split(':');
            string a = str[0];

            int n = removing(str[1]);

            if (n == 1)
            {
                if (a.Equals("EXECUTIVE_DIRECTOR"))
                {
                    Response.Redirect("ExecutiveDirectorAccount.aspx");

                }
                else if (a.Equals("SENIOR_RESEARCHER"))
                {
                    Response.Redirect("SeniorResearcherAccount.aspx");

                }
                else if (a.Equals("RESEARCHER"))
                {
                    Response.Redirect("ResearcherAccount.aspx");
                }
                else if (a.Equals("ADMINISTRATOR"))
                {
                    Response.Redirect("AdministratorAccount.aspx");
                }

            }
            else
            {

                del.Text = "TRY TO DELETE THE FILE AGAIN, SOMETHING WENT WRONG";
                del.Visible = true;
            }


        }
    }
}