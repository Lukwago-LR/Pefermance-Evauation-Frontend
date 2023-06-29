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
    public partial class Verify : System.Web.UI.Page
    {

        private string baseurl = "https://www.infotecker.co.za/api/SATRI_api/";

        private int verifyAc(int empid, int vid)
        {
            string url = string.Format(baseurl+"UpdateVerifiedAccount?id=" + empid + "&&veriferID=" + vid);

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
                return -1; ;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            string s = Request.QueryString["ID"];
            string[] str = s.Split(':');

            if (str[1].Equals("EXECUTIVE_DIRECTOR"))
            {
                verifyAc(Convert.ToInt32(str[0]), Convert.ToInt32(str[2]));
                Response.Redirect("ExecutiveDirectorAccount.aspx");
            }
            else
            {
                verifyAc(Convert.ToInt32(str[0]), Convert.ToInt32(str[2]));
                Response.Redirect("SeniorResearcherAccount.aspx");
            }

        }
    }
}