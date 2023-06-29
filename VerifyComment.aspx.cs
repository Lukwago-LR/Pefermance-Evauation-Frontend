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
    public partial class VerifyComment : System.Web.UI.Page
    {
        private string baseurl = "https://www.infotecker.co.za/api/SATRI_api/";

        private int verifCom(int cid, string stat)
        {
            string url = string.Format(baseurl+"UpdateVerifiedComments?C_ID=" + cid + "&&status=" + stat);

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

        private int commenting(int cid, int sid, int rid, string d, string com, int ab)
        {
            string url = string.Format(baseurl + "comment?C_ID=" + cid + "&&ID=" + sid + "&&Recipient=" + rid + "&&Descrip=" + d + "&&comment_Type=" + com + "&&compReceiver=" + ab);

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

        private int exeverify(string cid)
        {
            string url = string.Format(baseurl + "updatecommentadmin?C_ID=" + cid);

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

            commenting(Convert.ToInt32(str[3]), Convert.ToInt32(str[3]), Convert.ToInt32(str[2]), "Comment about you has been verified", "FEEDBACK", 0);
            if (str[1].Equals("EXECUTIVE_DIRECTOR"))
            {
                exeverify(str[0]);
                Response.Redirect("ExecutiveDirectorAccount.aspx");
            }
            else
            {
                verifCom(Convert.ToInt32(str[0]), "VERIFIED");
                Response.Redirect("SeniorResearcherAccount.aspx");
            }
            
        }
    }
}