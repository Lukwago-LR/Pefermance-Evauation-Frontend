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
    public partial class RefuseComment : System.Web.UI.Page
    {
        private string baseurl = "https://www.infotecker.co.za/api/SATRI_api/";

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

        private int verifCom(int cid, string stat)
        {
            string url = string.Format(baseurl + "UpdateVerifiedComments?C_ID=" + cid + "&&status=" + stat);

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
            if (!IsPostBack)
            {
                fileName.FVar = Request.QueryString["ID"];
            }
               
        }

        protected void C_Click(object sender, EventArgs e)
        {
            string[] str = fileName.FVar.Split(':');

            int n = -1;
            while (n == -1)
            {
               n = verifCom(Convert.ToInt32(str[0]), "UNVERIFIED");
            }

            if (n == 1)
            {
                commenting(Convert.ToInt32(str[2]), Convert.ToInt32(str[2]), Convert.ToInt32(str[4]), descrip.Text, "FEEDBACK", 0);
            }
            

            if (str[3].Equals("EXECUTIVE_DIRECTOR"))
            {
                Response.Redirect("ExecutiveDirectorAccount.aspx");
            }
            else
            {
                Response.Redirect("SeniorResearcherAccount.aspx");

            }

        }
    }
}