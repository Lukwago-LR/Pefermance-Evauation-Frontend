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
    public partial class Comment : System.Web.UI.Page
    {
        private string baseurl = "https://www.infotecker.co.za/api/SATRI_api/";

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
        private List<string> allEmployees()
        {
            string url = string.Format(baseurl + "getallEmployeeAsync");

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
        private int commenting(int cid, int sid, int rid, string d, string com, int ab)
        {
            string url = string.Format(baseurl+"comment?C_ID=" + cid + "&&ID=" + sid + "&&Recipient=" + rid + "&&Descrip=" + d + "&&comment_Type=" + com + "&&compReceiver=" + ab);     

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

        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            string s = Request.QueryString["ID"];
            string[] strC = s.Split(':');
            id = Convert.ToInt32(strC[0]);
            dynamic list = allEmployees();
            var user = singleEmployee(id);

            if(strC[1].Equals("FEED"))
            {

                DropDownList2.Items.Add(new ListItem("FEEDBACK", "FEEDBACK"));

                foreach (string sa in list)
                {
                    string[] str = sa.Split(':');
                    //You can send feedback to anybody
                    if (!(user[6].Equals(str[6])))
                    {
                        DropDownList1.Items.Add(new ListItem(str[1] + " " + str[2], str[6]));
                    }

                }
                about.Visible = false;
                DropDownList3.Items.Add(new ListItem("NO","NO"));               
            }
            else
            {
                DropDownList2.Items.Add(new ListItem("COMPLEMENT", "COMPLEMENT"));
                DropDownList2.Items.Add(new ListItem("COMPLAINT", "COMPLAINT"));

                switch (user[0])
                {
                   
                    case "RESEARCHER":                        

                        foreach (string sa in list)
                        {
                            string[] str = sa.Split(':');
                            if (str[0].Equals("SENIOR_RESEARCHER"))
                            {
                                DropDownList1.Items.Add(new ListItem(str[1] + " " + str[2], str[6]));
                            }

                            if (!(str[6].Equals(s)) && (str[0].Equals("ADMINISTRATOR")))
                            {
                                DropDownList3.Items.Add(new ListItem(str[1] + " " + str[2], str[6]));
                            }

                        }
                        break;
                  
                    case "SENIOR_RESEARCHER":

                        foreach (string sa in list)
                        {
                            string[] str = sa.Split(':');
                            if ((str[0].Equals("EXECUTIVE_DIRECTOR")))
                            {
                                DropDownList1.Items.Add(new ListItem(str[1] + " " + str[2], str[6]));
                            }

                            if (!(str[6].Equals(s)) && (str[0].Equals("ADMINISTRATOR")))
                            {
                                DropDownList3.Items.Add(new ListItem(str[1] + " " + str[2], str[6]));
                            }

                        }
                        break;
                }

            }          

        }
        protected void Comment_Click(object sender, EventArgs e)
        {
            if ((DropDownList3.SelectedValue).Equals("NO"))
            {

                int n = commenting(id, id, Convert.ToInt32(DropDownList1.SelectedValue), descrip.Text, DropDownList2.Text, Convert.ToInt32(DropDownList1.SelectedValue));
                if (n == 1)
                {
                    error.Visible = true;
                    error.Text = "Feedback received";
                }
                else
                {
                    error.Visible = true;
                    error.Text = "Feed  not received, please try again";

                }
            }
            else
            {
                if (!(DropDownList3.SelectedValue).Equals(DropDownList1.SelectedValue))
                {
                    int n = commenting(id, id, Convert.ToInt32(DropDownList1.SelectedValue), descrip.Text, DropDownList2.Text, Convert.ToInt32(DropDownList3.SelectedValue));
                    if (n == 1)
                    {

                        var user3 = singleEmployee(Convert.ToInt32(DropDownList3.SelectedValue));

                        if (user3[0].Equals("ADMINISTRATOR"))
                        {
                            commenting(id, id, Convert.ToInt32(DropDownList1.SelectedValue), "A Comment About An Administrator Has been Forwarded", "FEEDBACK", 0);
                        }

                        error.Visible = true;
                        error.Text = "Comment received";
                    }
                    else
                    {
                        error.Visible = true;
                        error.Text = "Comment  not received, please try again";
                    }

                }
                else
                {
                    error.Visible = true;
                    error.Text = "Complaint/Complaint Recipient and Person Complained or complemented-about must not be the same";

                }                

            }

        }
    }
}