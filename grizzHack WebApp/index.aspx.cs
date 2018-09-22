using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace grizzHack_WebApp
{
    public partial class index : System.Web.UI.Page
    {
        bool connected = false;
        tcpClient tcp = new tcpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            divStatus.Visible = false;
            try
            {
                tcp.start();
                lblStatus.Text = "Press Enter to Connect...";
            }
            catch
            {
                lblStatus.Text = "Server Offline.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                
            }
            
            //Try to checkFor Cookies

            if (connected == false)
            {
                divUpload.Visible = false;
            }
            else {
                divUpload.Visible = true;
            }
        }

        protected void txtNumbers_TextChanged(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                lblUploadStatus.Text = "Uploading...";
                string imageStr = Convert.ToBase64String(FileUploadControl.FileBytes);
                tcp.sendData("image" + ";" + txtNumbers.Text + ";" + "12345" + ";" + imageStr);
                divUpload.Visible = true;
                divStatus.Visible = true;
                lblUploadStatus.Text = "Image Sent.";
            }
            else {
                divUpload.Visible = true;
                divStatus.Visible = true;
                lblUploadStatus.Text = "No Image Selected.";
            }
        }

        protected void newConnection_Click(object sender, EventArgs e)
        {
            divUpload.Visible = false;
            divConnect.Visible = true;
            txtNumbers.Text = "";
            lblStatus.ForeColor = System.Drawing.Color.Black;
            divStatus.Visible = false;
        }

        protected void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtNumbers.Text.Length == 5)
            {
                UpdatePanel1.Update();
                lblStatus.Text = "Trying to Connect...";
                //Try to Connect to that length
                tcp.sendData("newphone" + ";" + txtNumbers.Text + ";" + "12345");

                while (tcp.recievedData.Count == 0)
                {

                }

                string connectionStatus = tcp.recievedData[0].ToString();

                if (connectionStatus.Equals("FAIL"))
                {
                    lblStatus.Text = "Unable to Connect.";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    divUpload.Visible = false;
                    divConnect.Visible = true;
                }
                else
                {
                    lblConnectionCode.Text = txtNumbers.Text;
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    divUpload.Visible = true;
                    divConnect.Visible = false;
                    divStatus.Visible = true;
                }

            }
            }
        }
}