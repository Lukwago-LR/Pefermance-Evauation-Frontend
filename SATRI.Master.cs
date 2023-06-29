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
    public partial class SATRI : System.Web.UI.MasterPage
    {
        private string baseurl = "https://www.infotecker.co.za/api/SATRI_api/";


        private List<string> evaluate()
        {
            string url = string.Format(baseurl + "evaluation_totalperf_percent_updating_Grades");

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
        private List<string> singleEmployee(int empid)
        {
            string url = string.Format(baseurl+"getEmployeebyIdAsync?id=" + empid);

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
        private int commentNo(string sid)
        {
            string url = string.Format(baseurl+"getcommentNo?id=" + sid);

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
                return 0;
            }

        }
        private int feedbackNo(string sid)
        {
            string url = string.Format(baseurl+"getfeedbackNo?id=" + sid);

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
                return 0;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            evaluate();

            if (Session["LoggedInUserID"] != null)
            {
                lg.Visible = false;
                rg.Visible = false;
                lo.Visible = true;
                notify.Visible = true;
                notify2.Visible = true;

                var user = singleEmployee(Convert.ToInt32(Session["LoggedInUserID"]));
                if (user[0].Equals("EXECUTIVE_DIRECTOR"))
                {
                    var display1 = "";
                    display1 += "<a class='nav-link' href='ExecutiveDirectorAccount.aspx'>Dashboard</a>";
                    d1.InnerHtml = display1;                    
                }
                else if (user[0].Equals("RESEARCHER"))
                {
                    var display1 = "";
                    display1 += "<a class='nav-link' href='ResearcherAccount.aspx'>Dashboard</a>";
                    d1.InnerHtml = display1;

                }
                else if (user[0].Equals("SENIOR_RESEARCHER"))
                {
                    var display1 = "";
                    display1 += "<a class='nav-link' href='SeniorResearcherAccount.aspx'>Dashboard</a>";
                    d1.InnerHtml = display1;

                }
                else if (user[0].Equals("ADMINISTRATOR"))
                {
                    var display1 = "";
                    display1 += "<a class='nav-link' href='AdministratorAccount.aspx'>Dashboard</a>";
                    d1.InnerHtml = display1;

                    int com = commentNo(Convert.ToString(Session["LoggedInUserID"]));
                    var display = "";
                    display += "<a class='nav-link' href='#'>Comment</a>";             
                    notify.InnerHtml = display;

                    var displayA = "";
                    displayA += "<a class='badge'>" + com + "</a>";
                    notifyA.InnerHtml = displayA;
                }
              
                var display2 = "";               
                display2 += "<a class='nav-link' href='#'>Feedback</a>";
                notify2.InnerHtml = display2;

                int fed = feedbackNo(Convert.ToString(Session["LoggedInUserID"]));
                var display2A = "";
                display2A += "<a class='badge'>" +fed+"</a>";
                notify2B.InnerHtml = display2A;

                var display3 = "";
                display3 += "<a class='nav-link' href='ChangeProfile.aspx?ID="+ Convert.ToString(Session["LoggedInUserID"]) + "'>Edit Profile</a>";
                d2.InnerHtml = display3;

                var display4 = "";
                display4 += "<a class='nav-link' href='Statistics.aspx?ID=" + Convert.ToString(Session["LoggedInUserID"]) + "'>Stats</a>";
                d3.InnerHtml = display4;

            }
            else
            {
                lg.Visible = true;
                rg.Visible = true;
                lo.Visible = false;
                notify.Visible = false;
                notify2.Visible = false;
            }
        }
    }
}