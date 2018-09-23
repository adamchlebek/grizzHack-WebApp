using System;

namespace grizzHack_WebApp
{
    public partial class index1 : System.Web.UI.Page
    {
        protected void btnWebApp_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://grizzyhack.gear.host/app.aspx");
        }

        protected void btnDownloadClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://grizzyhack.gear.host/PictacomClient.exe");
        }
    }
}