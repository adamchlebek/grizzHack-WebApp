using System;
using System.IO;

namespace grizzHack_WebApp
{
    public partial class index : System.Web.UI.Page
    {
        private tcpClient tcp = new tcpClient();
        string connectionNumber;
        string computerCode;
        string phoneCode;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                tcp.start();
                lblStatus.Text = "Waiting for Connection Code...";
            }
            catch
            {
                lblStatus.Text = "Server Offline.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }

                divStatus.Visible = false;
                divUpload.Visible = false;
                

                //Try to checkFor Cookies
                //Get Both cookies


                try
                {
                    computerCode = Request.Cookies["compCode"].Value;
                }
                catch
                {
                    computerCode = "";
                }

                try
                {
                    phoneCode = Request.Cookies["phoneCode"].Value;
                }
                catch
                {
                    Random random = new Random();
                    int randomNumber = random.Next(11111, 100000);

                    phoneCode = randomNumber.ToString();
                    Response.Cookies["phoneCode"].Value = phoneCode;
                }

                connectionNumber = computerCode;

            if (!Page.IsPostBack) {
                if (computerCode != "")
                {
                    if (tryConnect(connectionNumber, phoneCode, false))
                    {
                        lblConnectionCode.Text = connectionNumber;
                        divConnect.Visible = false;
                        divStatus.Visible = true;
                        divUpload.Visible = true;
                    }
                    else
                    {
                        divConnect.Visible = true;
                        divStatus.Visible = false;
                        divUpload.Visible = false;
                    }

                }
            }

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            UpdatePanel2.Update();
            if (FileUploadControl.HasFile)
            {
                lblUploadStatus.Text = "Uploading...";
                imgLoading.Visible = true;
                UpdatePanel2.Update();
                string imageStr = Convert.ToBase64String(FileUploadControl.FileBytes);

                try
                {
                    connectionNumber = Request.Cookies["compCode"].Value;
                    if (connectionNumber == "") {
                        connectionNumber = txtNumbers.Text;
                    }
                } catch {
                    connectionNumber = txtNumbers.Text;
                }
                
                tcp.sendData("image" + ";" + connectionNumber + ";" + phoneCode + ";" + imageStr);        
                divUpload.Visible = true;
                divStatus.Visible = true;
                lblUploadStatus.Text = "Image Sent.";
                imgLoading.Visible = false;
            }
            else
            {
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
                connectionNumber = txtNumbers.Text;
                UpdatePanel1.Update();
                lblStatus.Text = "Trying to Connect...";

                if (tryConnect(txtNumbers.Text, phoneCode, true))
                {
                    Response.Cookies["compCode"].Value = connectionNumber;
                    lblConnectionCode.Text = connectionNumber;
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    divUpload.Visible = true;
                    divConnect.Visible = false;
                    divStatus.Visible = true;
                }
                else {
                    lblStatus.Text = "Unable to Connect.";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    divUpload.Visible = false;
                    divConnect.Visible = true;

                }
            }
            else
            {
                lblStatus.Text = "Not enough characters.";
            }
        }

        public bool tryConnect(string connectionStr, string pCode, bool status) {
            if (status)
            {
                tcp.sendData("newphone" + ";" + connectionStr + ";" + pCode);
            }
            else {
                tcp.sendData("oldphone" + ";" + connectionStr + ";" + pCode);
            }
            

            while (tcp.recievedData.Count == 0)
            {
            }

            string connectionStatus;

            try
            {
                connectionStatus = tcp.recievedData[0].ToString();
            }
            catch
            {
                connectionStatus = "FAIL";
            }

            if (connectionStatus.Equals("FAIL"))
            {
                return false;
            }
            else {
                return true;
            }
        }

        protected void txtNumbers_TextChanged(object sender, EventArgs e)
        {

        }
    }
}