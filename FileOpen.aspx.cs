using System;
using System.Diagnostics;

namespace SATRI_CLIENT
{
    public partial class FileOpen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = Request.QueryString["ID"];
            string path = Server.MapPath("files/" + s);            
            Process.Start(path);
        }
    }
}