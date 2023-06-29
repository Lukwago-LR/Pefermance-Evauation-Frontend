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
    public partial class Display : System.Web.UI.Page
    {
        private string baseurl = "https://www.infotecker.co.za/api/SATRI_api/";

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

        private List<string> viewF(string Fid)
        {
            string url = string.Format(baseurl + "viewFiles?id=" + Fid);

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

        private List<string> viewmyComment(string sid)
        {
            string url = string.Format(baseurl + "viewComment_I_Made?id=" + sid);

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

        private List<string> viewcommentaboutMe(string sid)
        {
            string url = string.Format(baseurl + "viewCommentAboutme?id=" + sid);

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

        private List<string> myFeed(string sid)
        {
            string url = string.Format(baseurl + "getFeedback?id=" + sid);

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

        private List<string> accountbyUT(string ut)
        {
            string url = string.Format(baseurl + "getaccountbyUserType?userT=" + ut);

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

        private List<string> ForwardedF(string rec)
        {
            string url = string.Format(baseurl + "getForwardedFile?receiver=" + rec);

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

        private List<string> viewadminCom(int sid)
        {
            string url = string.Format(baseurl + "viewCommentaboutAdministrator?id=" + sid);

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
            string s = Request.QueryString["ID"];
            string[] str = s.Split(':');
            string id = str[0];
            int command = Convert.ToInt32(str[1]);

            var user = singleEmployee(Convert.ToInt32(id));
            switch (user[0])
            {
                case "ADMINISTRATOR":
                    if (command == 3)
                    {
                        dynamic l = viewF(id);
                        var display = "";
                        int num = 0;
                        if (l != null)
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>File name</th>";
                            display += "<th scope='col'>file type</th>";
                            display += "<th scope='col'>File Status</th>";
                            display += "<th scope='col'></th>";
                            display += "<th scope='col'></th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";
                            foreach (string c in l)
                            {
                                string[] a = c.Split(':');
                                string fileName = a[0];
                                string fileType = a[1];
                                string file_status = a[2];

                                num++;

                                display += "<tr>";
                                display += "<th scope='row'>" + num + "</th>";
                                display += "<td>" + fileName + "</td>";
                                display += "<td>" + fileType + "</td>";
                                display += "<td>" + file_status + "</td>";
                                display += "<td><p><a href = 'Delete.aspx?ID=" + user[0] + ":" + a[3] + "'class='btn btn-danger text-light'>DELETE FILE</a></p></td>";
                                if (file_status.Equals("UNVERIFIED"))
                                {
                                    display += "<td><p><a class='btn btn-success text-light' href = 'https://api.infotecker.co.za/unverifiedbobFiles/" + fileName + "'>DOWNLOAD FILE</a></p></td>";
                                }
                                else
                                {
                                    display += "<td><p><a class='btn btn-success text-light' href = 'https://www.infotecker.co.za/bobFiles/" + fileName + "'>DOWNLOAD FILE</a></p></td>";
                                }
                                
                                display += "</tr>";
                            }

                        }
                        else
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>File name</th>";
                            display += "<th scope='col'>file type</th>";
                            display += "<th scope='col'>File Status</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";
                        }
                        display += "</tbody>";
                        display += "</table>";
                        display += "<br>";
                        C1.InnerHtml = display;

                    }
                    else if (command == 5)
                    {
                        dynamic l = viewcommentaboutMe(id);
                        var display = "";
                        int num = 0;

                        if (l != null)
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Recipient Name</th>";
                            display += "<th scope='col'>Status</th>";
                            display += "<th scope='col'>Comment description</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";

                            foreach (string c in l)
                            {
                                string[] a = c.Split(':');
                                string Recipient = a[0];
                                string Status = a[1];
                                string description = a[2];
                                string type = a[3];
                                string[] d = a[4].Split(' ');
                                num++;

                                display += "<tr>";
                                display += "<th scope='row'>" + num + "</th>";
                                display += "<td>" + Recipient + "</td>";
                                display += "<td>" + Status + "</td>";
                                display += "<td>" + description + "</td>";
                                display += "<td>" + type + "</td>";
                                display += "<td>" + d[0] + "</td>";
                                display += "</tr>";                            
                            }                          

                        }
                        else
                        {

                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Recipient Name</th>";
                            display += "<th scope='col'>Status</th>";
                            display += "<th scope='col'>Comment description</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";
                           
                        }
                        display += "</tbody>";
                        display += "</table>";
                        display += "<br>";
                        C1.InnerHtml = display;

                    }
                    else if (command == 7)
                    {
                        dynamic l = myFeed(id);
                        var display = "";
                        int num = 0;

                        if (l != null)
                        {

                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Sender's Name</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Comment Description</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";


                            foreach (string c in l)
                            {
                                string[] a = c.Split(':');
                                string senderD = a[0];
                                string Des = a[1];
                                string type = a[2];
                                string[] d = a[3].Split(' ');
                                num++;

                                display += "<tr>";
                                display += "<th scope='row'>" + num + "</th>";
                                display += "<td>" + senderD + "</td>";
                                display += "<td>" + type + "</td>";
                                display += "<td>" + Des + "</td>";
                                display += "<td>" + d[0] + "</td>";
                                display += "</tr>";

                            }

                        }
                        else
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Sender's Name</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Comment Description</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";

                        }
                        display += "</tbody>";
                        display += "</table>";
                        display += "<br>";
                        C1.InnerHtml = display;

                    }
                    break;
                case "EXECUTIVE_DIRECTOR":
                    if (command == 1)
                    {
                        dynamic l = accountbyUT("ADMINISTRATOR");
                        var display = "";
                        int num = 0;

                        if (l != null)
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Account owner</th>";
                            display += "<th scope='col'></th>";
                            display += "<th scope='col'></th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";

                            foreach (string c in l)
                            {
                                string[] acc_owner = c.Split(':');
                                num++;

                                display += "<tr>";
                                display += "<th scope='row'>" + num + "</th>";
                                display += "<td>" + acc_owner[0] + "  " + acc_owner[1] + ": " + acc_owner[2] + "</td>";
                                display += "<td><p><a href='Verify.aspx?ID=" + acc_owner[3] + ":" + user[0] + ":" + id + "'class='btn btn-success text-light'>VALID</a></p></td>";
                                display += "<td><p><a href='Refuse.aspx?ID=" + acc_owner[3] + ":" + user[0] + ":" + id + "'class='btn btn-danger text-light'>INVALID</a></p></td>";
                                display += "</tr>";
                            }
                        }
                        else
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Account owner</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";
                        }
                        display += "</tbody>";
                        display += "</table>";
                        display += "<br>";
                        C1.InnerHtml = display;

                    }
                    else if (command == 2)
                    {
                        dynamic l = ForwardedF(id);
                        var display = "";
                        int num = 0;

                        if (l != null)
                        {

                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>File name</th>";
                            display += "<th scope='col'>file type</th>";
                            display += "<th scope='col'>File Owner</th>";
                            display += "<th scope='col'></th>";
                            display += "<th scope='col'></th>";
                            display += "<th scope='col'></th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";

                            foreach (string c in l)
                            {
                                string[] a = c.Split(':');
                                string fileName = a[0];
                                string fileType = a[1];
                                string file_owner = a[2];
                                num++;

                                var acc_owner = singleEmployee(Convert.ToInt32(file_owner));

                                display += "<tr>";
                                display += "<th scope='row'>" + num + "</th>";
                                display += "<td>" + fileName + "</td>";
                                display += "<td>" + fileType + "</td>";
                                display += "<td>" + acc_owner[1] + " " + acc_owner[2] + "</td>";
                                display += "<td><a href = 'VerifyFiles.aspx?ID=" + a[3] + ":" + user[0] + ":" + file_owner + ":" + id + "'class='btn btn-success text-light'>VALID</a></td>";
                                display += "<td><a href='Decline.aspx?ID=" + id + ":" + a[3] + ":" + file_owner + "'class='btn btn-danger text-light'>INVALID</a></td>";
                                display += "<td><a class='btn btn-success text-light' href = 'https://www.infotecker.co.za/bobFiles/" + fileName + "'>DOWNLOAD FILE</a></td>";
                                display += "</tr>";
                            }

                        }
                        else
                        {

                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>File name</th>";
                            display += "<th scope='col'>file type</th>";
                            display += "<th scope='col'>File Owner</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";

                        }
                        display += "</tbody>";
                        display += "</table>";
                        display += "<br>";
                        C1.InnerHtml = display;


                    }
                    else if (command == 6)
                    {

                        dynamic l = viewadminCom(Convert.ToInt32(id));
                        var display = "";
                        int num = 0;

                        if (l != null)
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Administrator Name</th>";
                            display += "<th scope='col'>UserType</th>";
                            display += "<th scope='col'>Comment description</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "<th scope='col'></th>";
                            display += "<th scope='col'></th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";

                            foreach (string c in l)
                            {
                                string[] a = c.Split(':');
                                string admin = a[0];
                                string type = a[1];
                                string description = a[2];
                                string Commenttype = a[3];
                                string CommentId = a[4];
                                string adminId = a[5];
                                string senderId = a[6];
                                string[] d = a[7].Split(' ');
                                num++;

                                display += "<tr>";
                                display += "<th scope='row'>" + num + "</th>";
                                display += "<td>" + admin + "</td>";
                                display += "<td>" + type + "</td>";
                                display += "<td>" + description + "</td>";
                                display += "<td>" + Commenttype + "</td>";
                                display += "<td>" + d[0] + "</td>";
                                display += "<td><p><a href = 'VerifyComment.aspx?ID=" + CommentId + ":" + user[0] + ":" + adminId + ":" + id + "'class='btn btn-success text-light'>VERIFY COMMENT</a></p></td>";
                                display += "<td><p><a href = 'RefuseComment.aspx?ID=" + CommentId + ":" + adminId + ":" + id + ":" + user[0] + ":" + senderId + "'class='btn btn-danger text-light'>DECLINE COMMENT</a></p></td>";
                                display += "</tr>";
                            }
                        }
                        else
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Administrator Name</th>";
                            display += "<th scope='col'>UserType</th>";
                            display += "<th scope='col'>Comment description</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "<th scope='col'></th>";
                            display += "<th scope='col'></th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";
                        }

                        display += "</tbody>";
                        display += "</table>";
                        display += "<br>";
                        C1.InnerHtml = display;

                    }
                    else if (command == 7)
                    {
                        dynamic l = myFeed(id);
                        var display = "";
                        int num = 0;

                        if (l != null)
                        {

                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Sender's Name</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Comment Description</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";


                            foreach (string c in l)
                            {
                                string[] a = c.Split(':');
                                string senderD = a[0];
                                string Des = a[1];
                                string type = a[2];
                                string[] d = a[3].Split(' ');
                                num++;

                                display += "<tr>";
                                display += "<th scope='row'>" + num + "</th>";
                                display += "<td>" + senderD + "</td>";
                                display += "<td>" + type + "</td>";
                                display += "<td>" + Des + "</td>";
                                display += "<td>" + d[0] + "</td>";
                                display += "</tr>";

                            }

                        }
                        else
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Sender's Name</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Comment Description</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";

                        }
                        display += "</tbody>";
                        display += "</table>";
                        display += "<br>";
                        C1.InnerHtml = display;

                    }
                    break;
                case "RESEARCHER":
                    if (command == 3)
                    {
                        dynamic l = viewF(id);
                        var display = "";
                        int num = 0;
                        if (l != null)
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>File name</th>";
                            display += "<th scope='col'>file type</th>";
                            display += "<th scope='col'>File Status</th>";
                            display += "<th scope='col'></th>";
                            display += "<th scope='col'></th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";
                            foreach (string c in l)
                            {
                                string[] a = c.Split(':');
                                string fileName = a[0];
                                string fileType = a[1];
                                string file_status = a[2];

                                num++;

                                display += "<tr>";
                                display += "<th scope='row'>" + num + "</th>";
                                display += "<td>" + fileName + "</td>";
                                display += "<td>" + fileType + "</td>";
                                display += "<td>" + file_status + "</td>";
                                display += "<td><p><a href = 'Delete.aspx?ID=" + user[0] + ":" + a[3] + "'class='btn btn-danger text-light'>DELETE FILE</a></p></td>";
                                if (file_status.Equals("UNVERIFIED"))
                                {
                                    display += "<td><p><a class='btn btn-success text-light' href = 'https://api.infotecker.co.za/unverifiedbobFiles/" + fileName + "'>DOWNLOAD FILE</a></p></td>";
                                }
                                else
                                {
                                    display += "<td><p><a class='btn btn-success text-light' href = 'https://www.infotecker.co.za/bobFiles/" + fileName + "'>DOWNLOAD FILE</a></p></td>";
                                }
                                display += "</tr>";
                            }

                        }
                        else
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>File name</th>";
                            display += "<th scope='col'>file type</th>";
                            display += "<th scope='col'>File Status</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";
                        }
                        display += "</tbody>";
                        display += "</table>";
                        display += "<br>";
                        C1.InnerHtml = display;

                    }
                    else if (command == 4)
                    {
                        dynamic l = viewmyComment(id);
                        var display = "";
                        int num = 0;

                        if (l != null)
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Recipient Name</th>";
                            display += "<th scope='col'>Commented About</th>";
                            display += "<th scope='col'>Status</th>";
                            display += "<th scope='col'>Comment description</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";

                            foreach (string c in l)
                            {
                                string[] a = c.Split(':');
                                string Recipient = a[0];
                                string personReferedTo = a[1];
                                string Status = a[2];
                                string description = a[3];
                                string type = a[4];
                                string[] d = a[5].Split(' ');
                                num++;

                                display += "<tr>";
                                display += "<th scope='row'>" + num + "</th>";
                                display += "<td>" + Recipient + "</td>";
                                display += "<td>" + personReferedTo + "</td>";
                                display += "<td>" + Status + "</td>";
                                display += "<td>" + description + "</td>";
                                display += "<td>" + type + "</td>";
                                display += "<td>" + d[0] + "</td>";
                                display += "</tr>";
                            }

                        }
                        else
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Recipient Name</th>";
                            display += "<th scope='col'>Commented About</th>";
                            display += "<th scope='col'>Status</th>";
                            display += "<th scope='col'>Comment description</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";
                        }

                        display += "</tbody>";
                        display += "</table>";
                        display += "<br>";
                        C1.InnerHtml = display;

                    }
                    else if (command == 7)
                    {
                        dynamic l = myFeed(id);
                        var display = "";
                        int num = 0;

                        if (l != null)
                        {

                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Sender's Name</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Comment Description</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";


                            foreach (string c in l)
                            {
                                string[] a = c.Split(':');
                                string senderD = a[0];
                                string Des = a[1];
                                string type = a[2];
                                string[] d = a[3].Split(' ');
                                num++;

                                display += "<tr>";
                                display += "<th scope='row'>" + num + "</th>";
                                display += "<td>" + senderD + "</td>";
                                display += "<td>" + type + "</td>";
                                display += "<td>" + Des + "</td>";
                                display += "<td>" + d[0] + "</td>";
                                display += "</tr>";

                            }

                        }
                        else
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Sender's Name</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Comment Description</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";

                        }
                        display += "</tbody>";
                        display += "</table>";
                        display += "<br>";
                        C1.InnerHtml = display;

                    }
                    break;
                case "SENIOR_RESEARCHER":
                    if (command == 1)
                    {
                        dynamic l = accountbyUT("RESEARCHER");
                        var display = "";
                        int num = 0;

                        if (l != null)
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Account owner</th>";                           
                            display += "<th scope='col'></th>";
                            display += "<th scope='col'></th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";

                            foreach (string c in l)
                            {
                                string[] acc_owner = c.Split(':');
                                num++;

                                display += "<tr>";
                                display += "<th scope='row'>" + num + "</th>";
                                display += "<td>" + acc_owner[0] + "  " + acc_owner[1] + ": " + acc_owner[2] + "</td>";
                                display += "<td><p><a href='Verify.aspx?ID=" + acc_owner[3] + ":" + user[0] + ":" + id + "'class='btn btn-success text-light'>VALID</a></p></td>";
                                display += "<td><p><a href='Refuse.aspx?ID=" + acc_owner[3] + ":" + user[0] + ":" + id + "'class='btn btn-danger text-light'>INVALID</a></p></td>";
                                display += "</tr>";
                            }                           
                        }
                        else
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Account owner</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";
                        }
                        display += "</tbody>";
                        display += "</table>";
                        display += "<br>";
                        C1.InnerHtml = display;

                    }
                    else if (command == 2)
                    {
                        dynamic l = ForwardedF(id);
                        var display = "";
                        int num = 0;

                        if (l != null)
                        {

                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>File name</th>";
                            display += "<th scope='col'>file type</th>";
                            display += "<th scope='col'>File Owner</th>";
                            display += "<th scope='col'></th>";
                            display += "<th scope='col'></th>";
                            display += "<th scope='col'></th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";

                            foreach (string c in l)
                            {
                                string[] a = c.Split(':');
                                string fileName = a[0];
                                string fileType = a[1];
                                string file_owner = a[2];
                                num++;

                                var acc_owner = singleEmployee(Convert.ToInt32(file_owner));

                                display += "<tr>";
                                display += "<th scope='row'>" + num + "</th>";
                                display += "<td>" + fileName + "</td>";
                                display += "<td>" + fileType + "</td>";
                                display += "<td>" + acc_owner[1] +" " + acc_owner[2] + "</td>";
                                display += "<td><a href = 'VerifyFiles.aspx?ID=" + a[3] + ":" + user[0] + ":" + file_owner + ":" + id + "'class='btn btn-success text-light'>VALID</a></td>";
                                display += "<td><a href='Decline.aspx?ID=" + id + ":" + a[3] + ":" + file_owner + "'class='btn btn-danger text-light'>INVALID</a></td>";
                                display += "<td><a class='btn btn-success text-light' href = 'https://www.infotecker.co.za/bobFiles/" + fileName + "'>DOWNLOAD FILE</a></td>";
                                display += "</tr>";
                            }

                        }
                        else
                        {

                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>File name</th>";
                            display += "<th scope='col'>file type</th>";
                            display += "<th scope='col'>File Owner</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";

                        }
                        display += "</tbody>";
                        display += "</table>";
                        display += "<br>";
                        C1.InnerHtml = display;


                    }
                    else if (command == 3)
                    {
                        dynamic l = viewF(id);
                        var display = "";
                        int num = 0;
                        if (l != null)
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>File name</th>";
                            display += "<th scope='col'>file type</th>";
                            display += "<th scope='col'>File Status</th>";
                            display += "<th scope='col'></th>";
                            display += "<th scope='col'></th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";
                            foreach (string c in l)
                            {
                                string[] a = c.Split(':');
                                string fileName = a[0];
                                string fileType = a[1];
                                string file_status = a[2];

                                num++;

                                display += "<tr>";
                                display += "<th scope='row'>" + num + "</th>";
                                display += "<td>" + fileName + "</td>";
                                display += "<td>" + fileType + "</td>";
                                display += "<td>" + file_status + "</td>";
                                display += "<td><p><a href = 'Delete.aspx?ID=" + user[0] + ":" + a[3] + "'class='btn btn-danger text-light'>DELETE FILE</a></p></td>";
                                if (file_status.Equals("UNVERIFIED"))
                                {
                                    display += "<td><p><a class='btn btn-success text-light' href = 'https://api.infotecker.co.za/unverifiedbobFiles/" + fileName + "'>DOWNLOAD FILE</a></p></td>";
                                }
                                else
                                {
                                    display += "<td><p><a class='btn btn-success text-light' href = 'https://www.infotecker.co.za/bobFiles/" + fileName + "'>DOWNLOAD FILE</a></p></td>";
                                }
                                display += "</tr>";
                            }

                        }
                        else
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>File name</th>";
                            display += "<th scope='col'>file type</th>";
                            display += "<th scope='col'>File Status</th>";                           
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";
                        }
                        display += "</tbody>";
                        display += "</table>";
                        display += "<br>";
                        C1.InnerHtml = display;

                    }
                    else if (command == 4)
                    {
                        dynamic l = viewmyComment(id);
                        var display = "";
                        int num = 0;

                        if (l != null)
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Recipient Name</th>";
                            display += "<th scope='col'>Commented About</th>";
                            display += "<th scope='col'>Status</th>";
                            display += "<th scope='col'>Comment description</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";

                            foreach (string c in l)
                            {
                                string[] a = c.Split(':');
                                string Recipient = a[0];
                                string personReferedTo = a[1];
                                string Status = a[2];
                                string description = a[3];
                                string type = a[4];
                                string[] d = a[5].Split(' ');
                                num++;

                                display += "<tr>";
                                display += "<th scope='row'>" + num + "</th>";
                                display += "<td>" + Recipient + "</td>";
                                display += "<td>" + personReferedTo + "</td>";
                                display += "<td>" + Status + "</td>";
                                display += "<td>" + description + "</td>";
                                display += "<td>" + type + "</td>";                                                              
                                display += "<td>" + d[0] + "</td>";
                                display += "</tr>";
                            }
                           
                        }
                        else
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Recipient Name</th>";
                            display += "<th scope='col'>Commented About</th>";
                            display += "<th scope='col'>Status</th>";
                            display += "<th scope='col'>Comment description</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";
                        }

                        display += "</tbody>";
                        display += "</table>";
                        display += "<br>";
                        C1.InnerHtml = display;

                    }
                    else if (command == 6)
                    {

                        dynamic l = viewadminCom(Convert.ToInt32(id));
                        var display = "";
                        int num = 0;

                        if (l != null)
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Administrator Name</th>";
                            display += "<th scope='col'>UserType</th>";
                            display += "<th scope='col'>Comment description</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "<th scope='col'></th>";
                            display += "<th scope='col'></th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";

                            foreach (string c in l)
                            {
                                string[] a = c.Split(':');
                                string admin = a[0];
                                string type = a[1];
                                string description = a[2];
                                string Commenttype = a[3];
                                string CommentId = a[4];
                                string adminId = a[5];
                                string senderId = a[6];
                                string[] d = a[7].Split(' ');
                                num++;

                                display += "<tr>";
                                display += "<th scope='row'>" + num + "</th>";
                                display += "<td>" + admin + "</td>";
                                display += "<td>" + type + "</td>";
                                display += "<td>" + description + "</td>";
                                display += "<td>" + Commenttype + "</td>";
                                display += "<td>" + d[0] + "</td>";
                                display += "<td><p><a href = 'VerifyComment.aspx?ID=" + CommentId + ":" + user[0] + ":" + adminId + ":" + id + "'class='btn btn-success text-light'>VERIFY COMMENT</a></p></td>";
                                display += "<td><p><a href = 'RefuseComment.aspx?ID=" + CommentId + ":" + adminId + ":" + id + ":" + user[0] + ":" + senderId + "'class='btn btn-danger text-light'>DECLINE COMMENT</a></p></td>";
                                display += "</tr>";
                            }                          
                        }
                        else
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Administrator Name</th>";
                            display += "<th scope='col'>UserType</th>";
                            display += "<th scope='col'>Comment description</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "<th scope='col'></th>";
                            display += "<th scope='col'></th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";
                        }

                        display += "</tbody>";
                        display += "</table>";
                        display += "<br>";
                        C1.InnerHtml = display;

                    }
                    else if (command == 7)
                    {
                        dynamic l = myFeed(id);
                        var display = "";
                        int num = 0;

                        if (l != null)
                        {

                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Sender's Name</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Comment Description</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";                          


                            foreach (string c in l)
                            {
                                string[] a = c.Split(':');
                                string senderD = a[0];
                                string Des = a[1];
                                string type = a[2];
                                string[] d = a[3].Split(' ');
                                num++;

                                display += "<tr>";
                                display += "<th scope='row'>"+num+"</th>";
                                display += "<td>"+ senderD +"</td>";
                                display += "<td>" + type + "</td>";
                                display += "<td>" + Des + "</td>";
                                display += "<td>" + d[0] + "</td>";
                                display += "</tr>";                               
                                  
                            }                          

                        }
                        else
                        {
                            display += "<br>";
                            display += "<table class='table table-success table-striped'>";
                            display += "<thead>";
                            display += "<tr>";
                            display += "<th scope='col'>No</th>";
                            display += "<th scope='col'>Sender's Name</th>";
                            display += "<th scope='col'>Comment Type</th>";
                            display += "<th scope='col'>Comment Description</th>";
                            display += "<th scope='col'>Date</th>";
                            display += "</tr>";
                            display += "</thread>";
                            display += "<tbody>";

                        }
                        display += "</tbody>";
                        display += "</table>";
                        display += "<br>";
                        C1.InnerHtml = display;                       

                    }
                    break;
            }

        }

    }
}