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
    public partial class Statistics : System.Web.UI.Page
    {
        private string baseurl = "https://www.infotecker.co.za/api/SATRI_api/";

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
        private decimal totalMark()
        {
            string url = string.Format(baseurl + "gettotalperformanceGrade");

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
        private List<decimal> mark(int d)
        {
            string url = string.Format(baseurl + "getresearcherGrade?id=" + d);

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
                return (List<decimal>)serialiser.Deserialize(result, typeof(List<decimal>));
            }
            else
            {
                return null;
            }
        }
        private decimal adminMark(int d)
        {
            string url = string.Format(baseurl + "getadminGrade?id=" + d);

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

        private int num1 = 0;
        private int num2 = 0;
        private int num3 = 0;
        private int num4 = 0;
        private int num5 = 0;
        private int num6 = 0;
        private int num7 = 0;
        private int num8 = 0;
        private int num9 = 0;
        private int num10 = 0;
        private int num11= 0;
        private int num12 = 0;

        private int numA1 = 0;
        private int numA2 = 0;
        private int numA3 = 0;
        private int numA4 = 0;
        private int numA5 = 0;
        private int numA6 = 0;
        private int numA7 = 0;
        private int numA8 = 0;
        private int numA9 = 0;
        private int numA10 = 0;
        private int numA11 = 0;
        private int numA12 = 0;

        protected void Page_Load(object sender, EventArgs e)
        {           
            string s = Request.QueryString["ID"];
            List<string> emp = singleEmployee(Convert.ToInt32(s));
            List<string> allEmp = allEmployees();
            decimal totalgrade = totalMark();

            if (emp[0].Equals("ADMINISTRATOR"))
            {
                underP.Visible = false;
                overP.Visible = false;
                List<string> commAdmin = viewcommentaboutMe(s);
                if(commAdmin != null)
                {
                    countcommentsperMonth(commAdmin);
                    drawadminperfomancepermonth();
                    fillrewardAdmin(s);
                }               

            }
            else if (emp[0].Equals("SENIOR_RESEARCHER"))
            {
                List<string> myfiles = viewF(s);
                if (allEmp != null && myfiles != null)
                {
                    countfilesperMonth(myfiles);
                    drawperfomancepermonth();
                    fillrewardResearcher(s);
                    underperformingTable(allEmp);
                    overperformingTable(allEmp);
                }      
               

            }
            else if (emp[0].Equals("RESEARCHER"))
            {
                underP.Visible = false;
                overP.Visible = false;
                List<string> myfiles = viewF(s);

                if(myfiles != null && allEmp != null)
                {
                    countfilesperMonth(myfiles);
                    drawperfomancepermonth();
                    fillrewardResearcher(s);
                    underperformingTable(allEmp);
                    overperformingTable(allEmp);
                }
                
            }
            else if (emp[0].Equals("EXECUTIVE_DIRECTOR"))
            {
                if(allEmp != null)
                {
                    underperformingALLTable(allEmp);
                    overperformingALLTable(allEmp);
                    underperformingAdminTable(allEmp);
                    overperformingAdminTable(allEmp);
                }
               

            }
            if(allEmp != null)
            {
                drawperfMonth(allEmp, "ACTUAL VS EXPECTED PERFORMANCE", totalgrade);
                satriperformancePerMonth(allEmp);
                drawsatriperfomancepermonth();
            }
            
           
        }

        private void underperformingAdminTable(List<string> IEmp)
        {
            underAdmin.Visible = false;
            var display = "";
            display += "<div>";
            display += "<h5><b><center>UNDER PERFORMING ADMINISTARTORS</center></b></h5>";
            display += "</div>";

            int num = 0;           
            display += "<table class='table table-bordered table-success'>";
            display += "<thead>";
            display += "<tr>";
            display += "<th scope='col'>No</th>";
            display += "<th scope='col'>Name</th>";
            display += "<th scope='col'>Total Mark</th>";
            display += "</tr>";
            display += " </thead>";
            display += "<tbody>";

            foreach (string sting in IEmp)
            {
                string[] sEmp = sting.Split(':');

                if (sEmp[0].Equals("ADMINISTRATOR"))
                {
                    decimal m = adminMark(Convert.ToInt32(sEmp[6]));

                    if (m <0)
                    {
                        display += "<tr>";
                        display += "<th scope='row'>" + num + "</th>";
                        display += "<td>" + sEmp[1] + " " + sEmp[2] + "</td>";
                        display += "<td>" + m + "</td>";
                        display += "</tr>";
                    }
                    num++;
                }
            }

            display += "</tbody>";
            display += "</table>";
            outcom.InnerHtml = display;
        }

        private void overperformingAdminTable(List<string> IEmp)
        {
            var displaya = "";            
            displaya += "<h5><b><center>EXCELLING ADMINISTARTORS</center></b></h5>";            
            a.InnerHtml = displaya;

            var display = "";
            int num = 0;
            display += "<table class='table table-bordered table-success'>";
            display += "<thead>";
            display += "<tr>";
            display += "<th scope='col'>No</th>";
            display += "<th scope='col'>Name</th>";
            display += "<th scope='col'>Total Mark</th>";
            display += "</tr>";
            display += " </thead>";
            display += "<tbody>";

            foreach (string sting in IEmp)
            {
                string[] sEmp = sting.Split(':');

                if (sEmp[0].Equals("ADMINISTRATOR"))
                {
                    decimal m = adminMark(Convert.ToInt32(sEmp[6]));

                    if (m > 2)
                    {
                        display += "<tr>";
                        display += "<th scope='row'>" + num + "</th>";
                        display += "<td>" + sEmp[1] + " " + sEmp[2] + "</td>";
                        display += "<td>" + m + "</td>";
                        display += "</tr>";
                    }
                    num++;
                }
            }

            display += "</tbody>";
            display += "</table>";
            perMonth.InnerHtml = display;
        }

        private void overperformingALLTable(List<string> IEmp)
        {
            int num = 0;
            var display = "";
            display += "<table class='table table-bordered table-success'>";
            display += "<thead>";
            display += "<tr>";
            display += "<th scope='col'>No</th>";
            display += "<th scope='col'>Name</th>";
            display += "<th scope='col'>Total Mark</th>";
            display += "</tr>";
            display += " </thead>";
            display += "<tbody>";

            foreach (string sting in IEmp)
            {
                string[] sEmp = sting.Split(':');

                if (sEmp[0].Equals("RESEARCHER") || sEmp[0].Equals("SENIOR_RESEARCHER"))
                {
                    List<decimal> m = mark(Convert.ToInt32(sEmp[6]));

                    if (m[3] > 8)
                    {
                        display += "<tr>";
                        display += "<th scope='row'>" + num + "</th>";
                        display += "<td>" + sEmp[1] + " " + sEmp[2] + "</td>";
                        display += "<td>" + m[3] + "</td>";
                        display += "</tr>";
                    }
                    num++;
                }
            }

            display += "</tbody>";
            display += "</table>";
            over.InnerHtml = display;
        }

        private void underperformingALLTable(List<string> IEmp)
        {
            int num = 0;
            var display = "";
            display += "<table class='table table-bordered table-success'>";
            display += "<thead>";
            display += "<tr>";
            display += "<th scope='col'>No</th>";
            display += "<th scope='col'>Name</th>";
            display += "<th scope='col'>Total Mark</th>";
            display += "</tr>";
            display += " </thead>";
            display += "<tbody>";

            foreach (string sting in IEmp)
            {
                string[] sEmp = sting.Split(':');

                if (sEmp[0].Equals("RESEARCHER") || sEmp[0].Equals("SENIOR_RESEARCHER"))
                {
                    List<decimal> m = mark(Convert.ToInt32(sEmp[6]));

                    if (m[3] < 4)
                    {
                        display += "<tr>";
                        display += "<th scope='row'>" + num + "</th>";
                        display += "<td>" + sEmp[1] + " " + sEmp[2] + "</td>";
                        display += "<td>" + m[3] + "</td>";
                        display += "</tr>";
                    }
                    num++;
                }
            }

            display += "</tbody>";
            display += "</table>";
            under.InnerHtml = display;
        }

        private void fillrewardAdmin(string sAdmin)
        {
            decimal m = adminMark(Convert.ToInt32(sAdmin));
            List<string> outC = new rewards().getoutcome();
            var display = "";
            display += "<table class='table table-bordered table-success'>";
            display += "<thead>";
            display += "<tr>";
            display += "<th scope='col'>Count</th>";
            display += "<th scope='col'>Outcome</th>";
            display += "</tr>";
            display += " </thead>";
            display += "<tbody>";
            if (m < 3 && m > 0)
            {
                display += "<tr>";
                display += "<th scope='row'>1</th>";
                display += "<td>" + outC[2] + "</td>";
                display += "</tr>";

            }
            else if (m == 0)
            {
                display += "<tr>";
                display += "<th scope='row'>1</th>";
                display += "<td><Nothing For Being Average</td>";
                display += "</tr>";

            }
            else if (m < 0)
            {
                display += "<tr>";
                display += "<th scope='row'>1</th>";
                display += "<td>" + outC[0] + "</td>";
                display += "</tr>";

                display += "<tr>";
                display += "<th scope='row'>2</th>";
                display += "<td>" + outC[1] + "</td>";
                display += "</tr>";
            }
            else if (m > 2)
            {
                display += "<tr>";
                display += "<th scope='row'>1</th>";
                display += "<td>" + outC[2] + "</td>";
                display += "</tr>";

                display += "<tr>";
                display += "<th scope='row'>2</th>";
                display += "<td>" + outC[3] + "</td>";
                display += "</tr>";

            }
            display += "</tbody>";
            display += "</table>";

            outcom.InnerHtml = display;
        }

        private void drawadminperfomancepermonth()
        {
            var displaya = "";
            displaya += "<h5><b><center>ADMINISTRATOR PERFORMANCE PER MONTH</center></b></h5>";
            a.InnerHtml = displaya;

            var display16 = "";
            display16 += "<canvas id='perfmonthChart' width='250' height='200'></canvas>";
            display16 += "<script>";
            display16 += "var a1 =[" + num1 + "];";
            display16 += "var a2 =[" + num2 + "];";
            display16 += "var a3 =[" + num3 + "];";
            display16 += "var a4 =[" + num4 + "];";
            display16 += "var a5 =[" + num5 + "];";
            display16 += "var a6 =[" + num6 + "];";
            display16 += "var a7 =[" + num7 + "];";
            display16 += "var a8 =[" + num8 + "];";
            display16 += "var a9 =[" + num9 + "];";
            display16 += "var a10 =[" + num10 + "];";
            display16 += "var a11 =[" + num11 + "];";
            display16 += "var a12 =[" + num12 + "];";
            display16 += "var Good = {";
            display16 += "label: 'Performance Rate',";
            display16 += "data: [a1[0],a2[0],a3[0],a4[0],a5[0],a6[0],a7[0],a8[0],a9[0],a10[0],a11[0],a12[0]],";
            display16 += "lineTension: 0.3,";
            display16 += "borderColor: [";
            display16 += "'rgba(255, 0, 0, 1)'";
            display16 += "],";
            display16 += "borderWidth: 2";
            display16 += "};";
            display16 += "var monthData = {";
            display16 += "labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul','Aug','Sep','Oct','Nov','Dec'],";
            display16 += "datasets: [Good]";
            display16 += "};";
            display16 += "var lineChart = new Chart(perfmonthChart, {";
            display16 += "type: 'line',";
            display16 += " data: monthData";
            display16 += "});";
            display16 += "</script>";

            perMonth.InnerHtml = display16;
        }

        private void countcommentsperMonth(List<string> commAdmin)
        {
            foreach (string c in commAdmin)
            {
                string[] a = c.Split(':');
                string status = a[1];
                string type = a[3];
                string d = a[4];
                string month = d.Substring(5, 2);

                if (status.Equals("EVALUATED"))
                {
                    if (type.Equals("COMPLEMENT"))
                    {
                        switch (month)
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
                    else
                    {
                        switch (month)
                        {
                            case "01":
                                num1--;
                                break;
                            case "02":
                                num2--;
                                break;
                            case "03":
                                num3--;
                                break;
                            case "04":
                                num4--;
                                break;
                            case "05":
                                num5--;
                                break;
                            case "06":
                                num6--;
                                break;
                            case "07":
                                num7--;
                                break;
                            case "08":
                                num8--;
                                break;
                            case "09":
                                num9--;
                                break;
                            case "10":
                                num10--;
                                break;
                            case "11":
                                num11--;
                                break;
                            case "12":
                                num12--;
                                break;
                        }

                    }
                   
                }

            }
        }

        private void overperformingTable(List<string> IEmp)
        {
            int num = 0;
            var display = "";
            display += "<table class='table table-bordered table-success'>";
            display += "<thead>";
            display += "<tr>";
            display += "<th scope='col'>No</th>";
            display += "<th scope='col'>Name</th>";
            display += "<th scope='col'>Total Mark</th>";
            display += "</tr>";
            display += " </thead>";
            display += "<tbody>";

            foreach (string sting in IEmp)
            {
                string[] sEmp = sting.Split(':');

                if (sEmp[0].Equals("RESEARCHER"))
                {
                    List<decimal> m = mark(Convert.ToInt32(sEmp[6]));

                    if (m[3] > 8)
                    {
                        display += "<tr>";
                        display += "<th scope='row'>" + num + "</th>";
                        display += "<td>" + sEmp[1] + " " + sEmp[2] + "</td>";
                        display += "<td>" + m[3] + "</td>";
                        display += "</tr>";
                    }
                    num++;
                }
            }

            display += "</tbody>";
            display += "</table>";
            over.InnerHtml = display;

        }

        private void underperformingTable(List<string> IEmp)
        {
            int num = 0;
            var display = "";
            display += "<table class='table table-bordered table-success'>";
            display += "<thead>";
            display += "<tr>";
            display += "<th scope='col'>No</th>";
            display += "<th scope='col'>Name</th>";
            display += "<th scope='col'>Total Mark</th>";
            display += "</tr>";
            display += " </thead>";
            display += "<tbody>";

            foreach (string sting in IEmp)
            {
                string[] sEmp = sting.Split(':');

                if(sEmp[0].Equals("RESEARCHER"))
                {
                    List<decimal> m = mark(Convert.ToInt32(sEmp[6]));                
                    
                    if (m[3] < 4)
                    {
                        display += "<tr>";
                        display += "<th scope='row'>"+num+"</th>";
                        display += "<td>" + sEmp[1]+" "+sEmp[2]+ "</td>";
                        display += "<td>" + m[3] + "</td>";                      
                        display += "</tr>";
                    }
                    num++;                 
                }
            }
           
            display += "</tbody>";
            display += "</table>";
            under.InnerHtml = display;
        }

        private void fillrewardResearcher(string empId)
        {
            List<decimal> m = mark(Convert.ToInt32(empId));
            List<string> outC = new rewards().getoutcome();
            var display = "";
            display += "<table class='table table-bordered table-success'>";
            display += "<thead>";
            display += "<tr>";
            display += "<th scope='col'>Count</th>";
            display += "<th scope='col'>Outcome</th>";
            display += "</tr>";
            display += " </thead>";
            display += "<tbody>";
            if (m[3] < 9 && m[3] > 4)
            {
                display += "<tr>";
                display += "<th scope='row'>1</th>";
                display += "<td>"+outC[2]+"</td>";
                display += "</tr>";

            }
            else if(m[3] == 4)
            {
                display += "<tr>";
                display += "<th scope='row'>1</th>";
                display += "<td><Nothing For Being Average</td>";
                display += "</tr>";

            }
            else if (m[3] < 4)
            {
                display += "<tr>";
                display += "<th scope='row'>1</th>";
                display += "<td>"+ outC[0] + "</td>";
                display += "</tr>";

                display += "<tr>";
                display += "<th scope='row'>2</th>";
                display += "<td>"+ outC[1] + "</td>";
                display += "</tr>";
            }
            else if (m[3] > 8)
            {
                display += "<tr>";
                display += "<th scope='row'>1</th>";
                display += "<td>" + outC[2] + "</td>";
                display += "</tr>";

                display += "<tr>";
                display += "<th scope='row'>2</th>";
                display += "<td>" + outC[3] + "</td>";
                display += "</tr>";

            }           
            display += "</tbody>";
            display += "</table>";

            outcom.InnerHtml = display;
        }

        private void drawsatriperfomancepermonth()
        {
            var display16 = "";
            display16 += "<canvas id='satriperfmonthChart' width='250' height='200'></canvas>";
            display16 += "<script>";
            display16 += "var a1 =[" + numA1 + "];";
            display16 += "var a2 =[" + numA2 + "];";
            display16 += "var a3 =[" + numA3 + "];";
            display16 += "var a4 =[" + numA4 + "];";
            display16 += "var a5 =[" + numA5 + "];";
            display16 += "var a6 =[" + numA6 + "];";
            display16 += "var a7 =[" + numA7 + "];";
            display16 += "var a8 =[" + numA8 + "];";
            display16 += "var a9 =[" + numA9 + "];";
            display16 += "var a10 =[" + numA10 + "];";
            display16 += "var a11 =[" + numA11 + "];";
            display16 += "var a12 =[" + numA12 + "];";
            display16 += "var Good = {";
            display16 += "label: 'SATRI PERFORMANCE VARIATION',";
            display16 += "data: [a1[0],a2[0],a3[0],a4[0],a5[0],a6[0],a7[0],a8[0],a9[0],a10[0],a11[0],a12[0]],";
            display16 += "lineTension: 0.3,";
            display16 += "borderColor: [";
            display16 += "'rgba(255, 0, 0, 1)'";
            display16 += "],";
            display16 += "borderWidth: 2";
            display16 += "};";
            display16 += "var monthData = {";
            display16 += "labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul','Aug','Sep','Oct','Nov','Dec'],";
            display16 += "datasets: [Good]";
            display16 += "};";
            display16 += "var lineChart = new Chart(satriperfmonthChart, {";
            display16 += "type: 'line',";
            display16 += " data: monthData";
            display16 += "});";
            display16 += "</script>";

            monthPerformance.InnerHtml = display16;
        }

        private void satriperformancePerMonth(List<string> lEmp)
        {
            foreach (string sting in lEmp)
            {
                string[] sEmp = sting.Split(':');
                List<string> fil = viewF(sEmp[6]);

                if(fil != null)
                {
                    filperMonth(fil);

                }
               
                if (sEmp[0].Equals("ADMINISTRATOR"))
                {
                    List<string> comments = viewcommentaboutMe(sEmp[6]);
                    if (comments != null)
                    {
                        foreach (string c in comments)
                        {
                            string[] a = c.Split(':');

                            string Status = a[1];
                            string type = a[3];
                            string month = a[4].Substring(5, 2);

                            if (Status.Equals("EVALUATED"))
                            {
                                if (type.Equals("COMPLEMENT"))
                                {
                                    switch (month)
                                    {
                                        case "01":
                                            numA1++;
                                            break;
                                        case "02":
                                            numA2++;
                                            break;
                                        case "03":
                                            numA3++;
                                            break;
                                        case "04":
                                            numA4++;
                                            break;
                                        case "05":
                                            numA5++;
                                            break;
                                        case "06":
                                            numA6++;
                                            break;
                                        case "07":
                                            numA7++;
                                            break;
                                        case "08":
                                            numA8++;
                                            break;
                                        case "09":
                                            numA9++;
                                            break;
                                        case "10":
                                            numA10++;
                                            break;
                                        case "11":
                                            numA11++;
                                            break;
                                        case "12":
                                            numA12++;
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (month)
                                    {
                                        case "01":
                                            numA1--;
                                            break;
                                        case "02":
                                            numA2--;
                                            break;
                                        case "03":
                                            numA3--;
                                            break;
                                        case "04":
                                            numA4--;
                                            break;
                                        case "05":
                                            numA5--;
                                            break;
                                        case "06":
                                            numA6--;
                                            break;
                                        case "07":
                                            numA7--;
                                            break;
                                        case "08":
                                            numA8--;
                                            break;
                                        case "09":
                                            numA9--;
                                            break;
                                        case "10":
                                            numA10--;
                                            break;
                                        case "11":
                                            numA11--;
                                            break;
                                        case "12":
                                            numA12--;
                                            break;
                                    }

                                }

                            }
                        }
                    }
                }
            }       
        }

        private void filperMonth(List<string> fil)
        {
            foreach (string c in fil)
            {
                string[] a = c.Split(':');
                string file_status = a[2];
                string file_date = a[4];
                string month = file_date.Substring(5, 2);

                if (file_status.Equals("EVALUATED"))
                {
                    switch (month)
                    {
                        case "01":
                            numA1++;
                            break;
                        case "02":
                            numA2++;
                            break;
                        case "03":
                            numA3++;
                            break;
                        case "04":
                            numA4++;
                            break;
                        case "05":
                            numA5++;
                            break;
                        case "06":
                            numA6++;
                            break;
                        case "07":
                            numA7++;
                            break;
                        case "08":
                            numA8++;
                            break;
                        case "09":
                            numA9++;
                            break;
                        case "10":
                            numA10++;
                            break;
                        case "11":
                            numA11++;
                            break;
                        case "12":
                            numA12++;
                            break;
                    }
                }

            }

        }

        private void drawperfMonth(List<string> lis, string d, decimal g)
        {      

            var displayb = "";
            displayb += "<h5><b><center>"+d+"</center></b></h5>";
            b.InnerHtml = displayb;
            var display15 = "";
            display15 += "<canvas id='myChart' width='250' height='200'></canvas>";
            display15 += "<script>";
            display15 += "var ctx = document.getElementById('myChart').getContext('2d');";
            display15 += "var a =[" +g+ "];";
            display15 += "var b =[" + (lis.Count-1)*3 +"];";
            display15 += "var myData=[a[0],b[0]];";
            display15 += "var myChart = new Chart(ctx, {";
            display15 += "type: 'bar',";
            display15 += "data: {";
            display15 += "labels: ['Actual OverAll Performance', 'Annual Average OverAll Performance'],";
            display15 += "datasets: [{";
            display15 += "data:myData,";
            display15 += "backgroundColor: [";
            display15 += "'rgba(255, 0, 0, 1)',";
            display15 += "'rgba(42, 187, 155, 1)'";            
            display15 += "],";
            display15 += "borderColor: [";
            display15 += "'rgba(255, 0, 0, 1)',";
            display15 += "'rgba(42, 187, 155, 1)'";
            display15 += "],";
            display15 += "borderWidth: 2";
            display15 += "}]";
            display15 += "},";
            display15 += "options: {";
            display15 += "scales: {";
            display15 += "y: {";
            display15 += "beginAtZero: true";
            display15 += "}";
            display15 += "}";
            display15 += "}";
            display15 += " });";
            display15 += "</script>";

            compGraph.InnerHtml = display15;
        }

        private void drawperfomancepermonth()
        {
            var displaya = "";
            displaya += "<h5><b><center>RESEARCHER PERFORMANCE PER MONTH</center></b></h5>";
            a.InnerHtml = displaya;

            var display16 = "";            
            display16 += "<canvas id='perfmonthChart' width='250' height='200'></canvas>";
            display16 += "<script>";
            display16 += "var a1 =[" + num1 + "];";
            display16 += "var a2 =[" + num2 + "];";
            display16 += "var a3 =[" + num3 + "];";
            display16 += "var a4 =[" + num4 + "];";
            display16 += "var a5 =[" + num5 + "];";
            display16 += "var a6 =[" + num6 + "];";
            display16 += "var a7 =[" + num7 + "];";
            display16 += "var a8 =[" + num8 + "];";
            display16 += "var a9 =[" + num9 + "];";
            display16 += "var a10 =[" + num10 + "];";
            display16 += "var a11 =[" + num11 + "];";
            display16 += "var a12 =[" + num12 + "];";
            display16 += "var Good = {";
            display16 += "label: 'Work Delivered',";
            display16 += "data: [a1[0],a2[0],a3[0],a4[0],a5[0],a6[0],a7[0],a8[0],a9[0],a10[0],a11[0],a12[0]],";
            display16 += "lineTension: 0.3,";
            display16 += "borderColor: [";
            display16 += "'rgba(255, 0, 0, 1)'";
            display16 += "],";
            display16 += "borderWidth: 2";
            display16 += "};";
            display16 += "var monthData = {";
            display16 += "labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul','Aug','Sep','Oct','Nov','Dec'],";
            display16 += "datasets: [Good]";
            display16 += "};";
            display16 += "var lineChart = new Chart(perfmonthChart, {";
            display16 += "type: 'line',";
            display16 += " data: monthData";
            display16 += "});";
            display16 += "</script>";

            perMonth.InnerHtml = display16;
        }

        private void countfilesperMonth(List<string> myfiles)
        {
            foreach (string c in myfiles)
            {
                string[] a = c.Split(':');
                string file_status = a[2];
                string file_date = a[4];
                string month = file_date.Substring(5, 2);

                if (file_status.Equals("EVALUATED"))
                {
                    switch (month)
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