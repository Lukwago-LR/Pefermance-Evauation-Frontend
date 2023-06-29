using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SATRI_CLIENT
{
    public partial class ExecutiveDirectorAccount : System.Web.UI.Page
    {
        private string baseurl = "https://www.infotecker.co.za/api/SATRI_api/";

        private decimal totalMark()
        {
            string url = string.Format(baseurl+"gettotalperformanceGrade");

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
                return (decimal)serialiser.Deserialize(result, typeof(decimal));
            }
            else
            {
                return -1;
            }
        }

        private List<string> evaluate()
        {
            string url = string.Format(baseurl+ "evaluation_totalperf_percent_updating_Grades");

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

        protected void Page_Load(object sender, EventArgs e)
        {
            string str1 = Session["LoggedInUserID"] + ":" + "1";
            string str2 = Session["LoggedInUserID"] + ":" + "2";                
            string str6 = Session["LoggedInUserID"] + ":" + "6";
            string str7 = Session["LoggedInUserID"] + ":" + "7";

            List<string> nam = singleEmployee(Convert.ToInt32(Session["LoggedInUserID"]));

            List<int> months = getmonthGrade();
            int maxValue = months.Max();
            int maxIndex = months.ToList().IndexOf(maxValue) + 1;
            string eMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(maxIndex);

            int minValue = months.Min();
            int minIndex = months.ToList().IndexOf(minValue) + 1;
            string minMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(minIndex);


            List<int> adminComments = calcadminComments();

            List<int> filesRS = calcresearcherFiles();

            int numC = adminComments[0] + adminComments[1];

            int declined = adminComments[2]- (adminComments[0] + adminComments[1]);
            int declinedFiles = filesRS[0] - filesRS[1];

            var display1 = "";
            display1 += "<i class='fa fa-unlock' aria-hidden='true'></i>";
            display1 += "<br />";
            display1 += "<a class='btn btn-secondary' href='Display.aspx?ID=" + str1 + "'> VERIFY ACCOUNT";
            display1 += "</a>";
            C1.InnerHtml = display1;

            var display2 = "";
            display2 += "<i class='fa fa-file' aria-hidden='true'></i>";
            display2 += "<br />";
            display2 += "<a class='btn btn-secondary' href = 'Display.aspx?ID=" + str2 + "'>VERIFY FILE";
            display2 += "</a>";
            C2.InnerHtml = display2;

            var display6 = "";
            display6 += "<i class='fa fa-comments - o' aria-hidden='true'></i>";
            display6 += "<br />";
            display6 += "<a class='btn btn-secondary' href = 'Display.aspx?ID=" + str6 + "'>VERIFY ADMIN FORWARDED COMMENTS";
            display6 += "</a>";
            C6.InnerHtml = display6;

            var display7 = "";
            display7 += "<i class='fa fa-comment - o' aria-hidden='true'></i>";
            display7 += "<br />";
            display7 += "<a class='btn btn-secondary' href = 'Display.aspx?ID=" + str7 + "'>VIEW FEEDBACK";
            display7 += "</a>";
            C7.InnerHtml = display7;

            var display8 = "";
            display8 += "<i class='fa fa-comment - o' aria-hidden='true'></i>";
            display8 += "<br />";
            display8 += "<a class='btn btn-secondary' href = 'Comment.aspx?ID=" + Session["LoggedInUserID"] + ":" + "FEED" + "'>SEND FEEDBACK";
            display8 += "</a>";
            C8.InnerHtml = display8;

            var display11 = "";
            display11 += "<p>" + evaluate()[0] + "</p>";
            ev.InnerHtml = display11;

            var display15 = "";
            display15 += "<p>" + totalMark() + "</p>";
            TT.InnerHtml = display15;

            var display12 = "";

            display12 += "<div class='text-dark'>";
            display12 += "COMMENTS MADE: ";
            display12 += "<span class='badge'>" + adminComments[2] + "</span> ";
            display12 += "</div>";

            display12 += "<div class='text-dark'>";
            display12 += "COMMENTS DECLINED: ";
            display12 += "<span class='badge'>" + declined + "</span> ";
            display12 += "</div>";


            display12 += "<div class='text-dark'>";
            display12 += "VALID COMPLEMENTS: ";
            display12 += "<span class='badge'>"+adminComments[0]+"</span> ";
            display12 += "<span><img src='images/tick.png' height='25' width='35' alt=''/></span>";
            display12 += "</div>";

            display12 += "<div class='text-dark'>";
            display12 += "VALID COMPLAINTS: ";
            display12 += "<span class='badge'>"+adminComments[1]+"</span> ";
            display12 += "<span><img src='images/cross.png' height='25' width='35' alt=''/></span>";
            display12 += "</div>";

            display12 += "<div class='text-dark'>";
            display12 += "COMMENTS EVALUATED: ";
            display12 += "<span class='badge'>" + numC+ "</span>";
            display12 += "</div>";
            adminC.InnerHtml = display12;

            var display13 = "";

            display13 += "<div class='text-dark'>";
            display13 += "FILES FORWARDED: ";
            display13 += "<span class='badge'>" + filesRS[0] + "</span> ";
            display13 += "</div>";


            display13 += "<div class='text-dark'>";
            display13 += "FILES DECLINED: ";
            display13 += "<span class='badge'>" + declinedFiles + "</span> ";
            display13 += "<span><img src='images/cross.png' height='25' width='35' alt=''/></span>";
            display13 += "</div>";

            display13 += "<div class='text-dark'>";
            display13 += "VALID FILES: ";
            display13 += "<span class='badge'>" + filesRS[1] + "</span> ";
            display13 += "<span><img src='images/tick.png' height='25' width='35' alt=''/></span>";
            display13 += "</div>";

            files.InnerHtml = display13;

            var display14 = "";

            display14 += "<div class='text-dark'>";
            display14 += "MOST PRODUCTIVE MONTH: ";
            display14 += "<span class='text-success'>" + eMonth + "</span> ";
            display14 += "<div>TOTAL PERFORMACE GRADE INCREASE: ";
            display14 += "<span class='badge'>" + maxValue  + "</span> ";
            display14 +=  "</div>";
            display14 += "</div>";

            display14 += "<div class='text-dark'>";
            display14 += "LEAST PRODUCTIVE MONTH: ";
            display14 += "<span class='text-danger'>" + minMonth  + "</span> ";
            display14 += "<div>TOTAL PERFORMACE GRADE INCREASE: ";
            display14 += "<span class='badge'>" + minValue + "</span> ";
            display14 += "</div>";
            display14 += "</div>";

            mP.InnerHtml = display14;


            var display17 = "";
            display17 += "<center><b>EXECUTIVE DIRECTOR:" + ' ' + nam[1] + ' ' + nam[2] + " </b></center>";
            name.InnerHtml = display17;

        }

        private List<int> getmonthGrade()
        {
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            int num11 = 0;
            int num12 = 0;

            List<int> eM = new List<int>();

            List<string> all = allEmployees();
            if (all != null)
            {
                foreach (string s in all)
                {
                    string[] str = s.Split(':');

                    if (str[0].Equals("RESEARCHER") || str[0].Equals("SENIOR_RESEARCHER"))
                    {
                        List<string> f = viewF(str[6]);
                        if (f != null)
                        {
                            foreach (string c in f)
                            {
                                string[] a = c.Split(':');
                                string file_date = a[4];
                                string file_status = a[2];
                                string eD = file_date.Substring(5, 2);

                                if (file_status.Equals("EVALUATED"))
                                {
                                    switch (eD)
                                    {
                                        case "01":
                                            num1++;
                                            break;
                                        case "02":
                                            num2++;
                                            break;
                                        case "03":
                                            num3++;
                                            break;
                                        case "04":
                                            num4++;
                                            break;
                                        case "05":
                                            num5++;
                                            break;
                                        case "06":
                                            num6++;
                                            break;
                                        case "07":
                                            num7++;
                                            break;
                                        case "08":
                                            num8++;
                                            break;
                                        case "09":
                                            num9++;
                                            break;
                                        case "10":
                                            num10++;
                                            break;
                                        case "11":
                                            num11++;
                                            break;
                                        case "12":
                                            num12++;
                                            break;
                                    }
                                }

                                
                            }
                        }


                        List<string> coms = viewmyComment(str[6]);
                        if (coms != null)
                        {
                            foreach (string cR in coms)
                            {
                                string[] aC = cR.Split(':');
                                string type = aC[4];
                                string Status = aC[2];
                                string[] com_date = aC[5].Split(' ');
                                string eDmonth = com_date[0].Substring(5, 2);

                                if (type.Equals("COMPLEMENT") && Status.Equals("EVALUATED"))
                                {
                                    switch (eDmonth)
                                    {
                                        case "01":
                                            num1++;
                                            break;
                                        case "02":
                                            num2++;
                                            break;
                                        case "03":
                                            num3++;
                                            break;
                                        case "04":
                                            num4++;
                                            break;
                                        case "05":
                                            num5++;
                                            break;
                                        case "06":
                                            num6++;
                                            break;
                                        case "07":
                                            num7++;
                                            break;
                                        case "08":
                                            num8++;
                                            break;
                                        case "09":
                                            num9++;
                                            break;
                                        case "10":
                                            num10++;
                                            break;
                                        case "11":
                                            num11++;
                                            break;
                                        case "12":
                                            num12++;
                                            break;
                                    }

                                }

                                


                            }
                        }

                    }
                }
            }

            eM.Add(num1);
            eM.Add(num2);
            eM.Add(num3);
            eM.Add(num4);
            eM.Add(num5);
            eM.Add(num6);
            eM.Add(num7);
            eM.Add(num8);
            eM.Add(num9);
            eM.Add(num10);
            eM.Add(num11);
            eM.Add(num12);

            return eM;
        }

        private List<int> calcresearcherFiles()
        {
                int num1 = 0;
                int num2 = 0;

                List<int> eFiles = new List<int>();

                List<string> all = allEmployees();
                if (all != null)
                {
                    foreach (string s in all)
                    {
                        string[] str = s.Split(':');
                        if (str[0].Equals("RESEARCHER") || str[0].Equals("SENIOR_RESEARCHER"))
                        {
                            List<string> f = viewF(str[6]);

                            if (f != null)
                            {
                                foreach (string c in f)
                                {
                                    string[] a = c.Split(':');
                                    string file_status = a[2];

                                    if (file_status.Equals("EVALUATED"))
                                    {
                                        num1++;
                                    }                                   
                                     num2++;                                    
                                   
                                }
                            }

                        }
                    }

                }
                eFiles.Add(num2);
                eFiles.Add(num1);             

               return eFiles;
           
        }

        private List<int> calcadminComments()
        {
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;

            List<int> wanted = new List<int>();

            List<string> all = allEmployees();
            if(all != null)
            {
                foreach (string s in all)
                {
                    string[] str = s.Split(':');
                    if (str[0].Equals("ADMINISTRATOR"))
                    {
                        List<string> comms = viewcommentaboutMe(str[6]);

                        if(comms != null)
                        {
                            foreach (string c in comms)
                            {
                                string[] a = c.Split(':');
                                string type = a[3];
                                string Status = a[1];

                                if (type.Equals("COMPLEMENT") && Status.Equals("EVALUATED"))
                                {
                                    num1++;
                                }
                                else if (type.Equals("COMPLAINT") && Status.Equals("EVALUATED"))
                                {
                                    num2++;
                                }
                                num3++;
                            }
                        }
                        
                    }
                }

            }
            wanted.Add(num1);
            wanted.Add(num2);
            wanted.Add(num3);

            return wanted;            
        }
    }
}