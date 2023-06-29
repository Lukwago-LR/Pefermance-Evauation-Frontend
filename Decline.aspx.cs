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
    public partial class Decline : System.Web.UI.Page
    {

        private string baseurl = "https://www.infotecker.co.za/api/SATRI_api/";

        private int updateVF(string fid, int sid, string rid, string filest)
        {
            string url = string.Format(baseurl + "UpdateFiles?fileid=" + fid + "&&senderid=" + sid + "&&receiverId=" + rid + "&&filestatus=" + filest);

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

  
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s = Request.QueryString["ID"];
                //reusing file class but this is the id passed from previous page
                fileName.FVar = s;
            }           

        }

        protected void DESC_Click(object sender, EventArgs e)
        {

            string[] str = fileName.FVar.Split(':');

            if (FileUpload2.HasFile)
            {
                var allowedExt = new string[] { "doc", "docx" };
                var ext = Path.GetExtension(FileUpload2.PostedFile.FileName).ToLower().Replace(".", "");

                if (allowedExt.Contains(ext))
                {
                    if (FileUpload2.PostedFile.ContentLength < 10000000)
                    {
                    
                        if (descrip.Text.Length < 1)
                        {
                            error.Text = "Provide feedback please";
                            error.Visible = true;
                        }
                        else
                        {
                            FileUpload2.SaveAs(Server.MapPath("~/declinedFiles/" + FileUpload2.FileName));
                            int n = commenting(Convert.ToInt32(str[0]), Convert.ToInt32(str[0]), Convert.ToInt32(str[2]), descrip.Text, "FEEDBACK", 0);
                            int nn = updateVF(str[1], Convert.ToInt32(str[2]), str[0], "UNVERIFIED");
                            if (n == 1 && nn == 1)
                            {                                
                                error.Text = "File and feedback forwarded";
                                error.Visible = true;
                            }
                            else
                            {
                                error.Text = "Something went wrong, please try uploading the file again";
                                error.Visible = true;
                            }
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