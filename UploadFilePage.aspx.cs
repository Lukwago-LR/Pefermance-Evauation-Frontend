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
    public partial class UploadFilePage : System.Web.UI.Page
    {
        private string baseurl = "https://www.infotecker.co.za/api/SATRI_api/";

        private int uploadF(int sid, string fT, string fN, int rid)
        {
            string url = string.Format(baseurl+"uploadFile?id=" + sid + "&&fType=" + fT + "&&fileName=" + fN + "&&RecipID=" + rid);

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

        private List<string> employeebyuserType(string ut)
        {
            string url = string.Format(baseurl + "getEmployeeByUserType?userT=" + ut);

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

        private string s;
        List<string> user;

        protected void Page_Load(object sender, EventArgs e)
        {
            s = Request.QueryString["ID"];
            user = singleEmployee(Convert.ToInt32(s));

            switch (user[0])
            {
                case "ADMINISTRATOR":
                    Ti.Items.Add(new ListItem("ADMINISTRATOR FILE", "ADMINISTRATOR FILE"));
                    break;
                case "RESEARCHER":
                    Ti.Items.Add(new ListItem("DISSEMINATION", "DISSEMINATION"));
                    Ti.Items.Add(new ListItem("PUBLICATION", "PUBLICATION"));
                    Ti.Items.Add(new ListItem("RESEARCH PROJECT", "RESEARCH PROJECT"));
                    break;
                case "SENIOR_RESEARCHER":
                    Ti.Items.Add(new ListItem("DISSEMINATION", "DISSEMINATION"));
                    Ti.Items.Add(new ListItem("PUBLICATION", "PUBLICATION"));
                    Ti.Items.Add(new ListItem("RESEARCH PROJECT", "RESEARCH PROJECT"));
                    break;
            }

        }

        protected void Submit_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)
            {
                var allowedExt = new string[] { "doc", "docx" };
                var ext = Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower().Replace(".", "");

                if (allowedExt.Contains(ext))
                {
                    if (FileUpload1.PostedFile.ContentLength < 10000000)
                    {
                        int recip = 0;
                        FileUpload1.SaveAs(Server.MapPath("~/files/" + FileUpload1.FileName));
                        switch (user[0])
                        {

                            case "RESEARCHER":

                                List<string> l = employeebyuserType("SENIOR_RESEARCHER");

                                if (l != null)
                                {

                                    int num = new Random().Next(2);
                                    foreach (string str in l)
                                    {
                                        string[] sL = str.Split(':');
                                        if (l.Count > 1)
                                        {

                                            if (num == 0)
                                            {
                                                recip = Convert.ToInt32(sL[0]);


                                            }
                                            else if (num == 1)
                                            {

                                                recip = Convert.ToInt32(sL[0]);
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            recip = Convert.ToInt32(sL[0]);

                                        }

                                    }
                                }
                                if (recip > 0)
                                {
                                    int file1 = uploadF(Convert.ToInt32(s), Ti.Text, FileUpload1.FileName, recip);
                                    if (file1 == 1)
                                    {
                                        error.Text = "File added and forwarded";
                                        error.Visible = true;
                                    }
                                    else if (file1 < 0)
                                    {
                                        error.Text = "Something went wrong, please try uploading the file again";
                                        error.Visible = true;
                                    }

                                }

                                break;


                            case "SENIOR_RESEARCHER":

                                List<string> l2 = employeebyuserType("EXECUTIVE_DIRECTOR");
                                foreach (string str in l2)
                                {
                                    string[] sL = str.Split(':');

                                    recip = Convert.ToInt32(sL[0]);
                                }

                                if (recip > 0)
                                {

                                    int file2 = uploadF(Convert.ToInt32(s), Ti.Text, FileUpload1.FileName, recip);
                                    if (file2 == 1)
                                    {
                                        error.Text = "File added and forwarded";
                                        error.Visible = true;
                                    }
                                    else if (file2 < 0)
                                    {
                                        error.Text = "Something went wrong, please try uploading the file again";
                                        error.Visible = true;
                                    }

                                }

                                break;

                            case "ADMINISTRATOR":

                                List<string> l2A = employeebyuserType("EXECUTIVE_DIRECTOR");
                                foreach (string str in l2A)
                                {
                                    string[] sL = str.Split(':');

                                    recip = Convert.ToInt32(sL[0]);
                                }

                                if (recip > 0)
                                {

                                    int file2 = uploadF(Convert.ToInt32(s), Ti.Text, FileUpload1.FileName, recip);
                                    if (file2 == 1)
                                    {
                                        error.Text = "File added and forwarded";
                                        error.Visible = true;
                                    }
                                    else if (file2 < 0)
                                    {
                                        error.Text = "Something went wrong, please try uploading the file again";
                                        error.Visible = true;
                                    }
                                }

                                break;
                        }
                    }
                    else
                    {
                        error.Text = "File has to less than 10 Mbs";
                        error.Visible = true;

                    }                    

                }
                else
                {
                    error.Text = "Only word documents are uploadable";
                    error.Visible = true;
                }
               
            }
            else
            {
                error.Text = "No uploaded file";
                error.Visible = true;

            }



        }
    }
}