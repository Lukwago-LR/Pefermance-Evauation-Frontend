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
    public partial class VerifyFiles : System.Web.UI.Page
    {
        private string baseurl = "https://www.infotecker.co.za/api/SATRI_api/";

        private int updateVF(string fid, int sid, string rid, string filest)
        {
            string url = string.Format(baseurl+"UpdateFiles?fileid=" + fid + "&&senderid=" + sid + "&&receiverId=" + rid + "&&filestatus=" + filest);

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

            if (str[1].Equals("EXECUTIVE_DIRECTOR"))
            {
                int num = updateVF(str[0], Convert.ToInt32(str[2]), str[3], "VERIFIED");
                Response.Redirect("ExecutiveDirectorAccount.aspx");
            }
            else
            {
                int num = updateVF(str[0], Convert.ToInt32(str[2]), str[3], "VERIFIED");
                Response.Redirect("SeniorResearcherAccount.aspx");
            }

        }
    }
}