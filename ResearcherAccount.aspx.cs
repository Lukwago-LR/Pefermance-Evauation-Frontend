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
    public partial class ResearcherAccount : System.Web.UI.Page
    {
        private string baseurl = "https://www.infotecker.co.za/api/SATRI_api/";

        private List<decimal> mark(int d)
        {
            string url = string.Format(baseurl+"getresearcherGrade?id=" + d);

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

        protected void Page_Load(object sender, EventArgs e)
        {

            string str3 = Session["LoggedInUserID"] + ":" + "3";
            string str4 = Session["LoggedInUserID"] + ":" + "4";
            string str5 = Session["LoggedInUserID"] + ":" + "5";
            string str7 = Session["LoggedInUserID"] + ":" + "7";

            List<decimal> l = mark(Convert.ToInt32(Session["LoggedInUserID"]));
            List<string> nam = singleEmployee(Convert.ToInt32(Session["LoggedInUserID"]));

            var display3 = "";
            display3 += "<i class='fa fa-file' aria-hidden='true'></i>";
            display3 += "<br />";
            display3 += "<a class='btn btn-secondary' href = 'Display.aspx?ID=" + str3 + "'>VIEW FILE";
            display3 += "</a>";
            C3.InnerHtml = display3;

            var display4 = "";
            display4 += "<i class='fa fa-comments - o' aria-hidden='true'></i>";
            display4 += "<br />";
            display4 += "<a class='btn btn-secondary' href = 'Display.aspx?ID=" + str4 + "'>VIEW COMMENTS I SENT";
            display4 += "</a>";
            C4.InnerHtml = display4;

            var display5 = "";
            display5 += "<i class='fa fa-comments - o' aria-hidden='true'></i>";
            display5 += "<br />";
            display5 += "<a class='btn btn-secondary' href = 'Comment.aspx?ID=" + Session["LoggedInUserID"] + ":" + "COMMENT" + "'>COMMENT";
            display5 += "</a>";
            C5.InnerHtml = display5;

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

            var display9 = "";
            display9 += "<i class='fa fa-file - word - o' aria-hidden='true'></i>";
            display9 += "<br />";
            display9 += "<a class='btn btn-secondary' href = 'UploadFilePage.aspx?ID=" + Session["LoggedInUserID"] + "'>UPLOAD FILE";
            display9 += "</a>";
            C9.InnerHtml = display9;

            var display10 = "";
            display10 += "<p>" + mark(Convert.ToInt32(Session["LoggedInUserID"]))[3] + "</p>";
            TM.InnerHtml = display10;

            var display12 = "";
            display12 += "<p>" + l[2] + "</p>";
            RP.InnerHtml = display12;

            var display13 = "";
            display13 += "<p>" + l[1] + "</p>";
            pub.InnerHtml = display13;

            var display14 = "";
            display14 += "<p>" + l[0] + "</p>";
            dis.InnerHtml = display14;

            var display17 = "";
            display17 += "<center><b>RESEARCHER:" + ' ' + nam[1] + ' ' + nam[2] + " </b></center>";
            name.InnerHtml = display17;

            var display15 = "";
            display15 += "<canvas id='myChart' width='250' height='200'></canvas>";
            display15 += "<script>";
            display15 += "var ctx = document.getElementById('myChart').getContext('2d');";
            display15 += "var a =[" + l[1] + "];";
            display15 += "var b =[" + l[0] + "];";
            display15 += "var c =[" + l[2] + "];";
            display15 += "var myData=[a[0],b[0],c[0]];";
            display15 += "var myChart = new Chart(ctx, {";
            display15 += "type: 'bar',";
            display15 += "data: {";
            display15 += "labels: ['Publications', 'Disseminations', 'Projects'],";
            display15 += "datasets: [{";
            display15 += "data:myData,";
            display15 += "label: 'Work Comparisons',";
            display15 += "borderColor: [";
            display15 += "'rgba(255, 206, 86, 1)'";
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

            graph1.InnerHtml = display15;

            var display16 = "";
            display16 += "<canvas id='perfChart' width='250' height='200'></canvas>";
            display16 += "<script>";
            display16 += "var a =[" + l[3] + "];";
            display16 += "var dataFirst = {";
            display16 += "label: 'Current Performance',";
            display16 += "data: [a[0], a[0], a[0], a[0], a[0], a[0], a[0],a[0], a[0], a[0], a[0], a[0]],";
            display16 += "lineTension: 0.3,";
            display16 += "borderColor: [";
            display16 += "'rgba(255, 206, 86, 1)'";
            display16 += "],";
            display16 += "borderWidth: 2";
            display16 += "};";
            display16 += "var Good = {";
            display16 += "label: 'Good Performance',";
            display16 += "data: [4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5,4.5, 4.5, 4.5, 4.5, 4.5],";
            display16 += "lineTension: 0.3,";
            display16 += "borderColor: [";
            display16 += "'rgba(255, 0, 0, 1)'";
            display16 += "],";
            display16 += "borderWidth: 2";
            display16 += "};";
            display16 += "var dataSecond = {";
            display16 += "label: 'Excellent Performace',";
            display16 += "data: [9,9,9,9,9,9,9,9,9,9,9,9],";
            display16 += "lineTension: 0.3,";
            display16 += "borderColor: [";
            display16 += "'rgba(42, 187, 155, 1)'";
            display16 += "],";
            display16 += "borderWidth: 2";
            display16 += "};";
            display16 += "var speedData = {";
            display16 += "labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul','Aug','Sep','Oct','Nov','Dec'],";
            display16 += "datasets: [dataFirst, Good, dataSecond]";
            display16 += "};";
            display16 += "var lineChart = new Chart(perfChart, {";
            display16 += "type: 'line',";
            display16 += " data: speedData";
            display16 += "});";
            display16 += "</script>";

            myperformChart.InnerHtml = display16;
        }
    }
}