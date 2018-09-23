using System;

namespace grizzHack_WebApp
{
    public partial class index : System.Web.UI.Page
    {
        private tcpClient tcp = new tcpClient();
        private string connectionNumber;
        private string computerCode;
        private string phoneCode;
        bool isCookie = false;

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

            if (!Page.IsPostBack) {
                divCheck.Visible = false;
                divStatus.Visible = false;
                divUpload.Visible = false;

                //Try to checkFor Cookies
                //Get Both cookies
            }


            if (Request.QueryString["id"] != null)
            {
                connectionNumber = Request.QueryString["id"];

            }
            else
            {
                try
                {
                    computerCode = Request.Cookies["compCode"].Value;
                    isCookie = true;
                }
                catch
                {
                    computerCode = "";
                }

                connectionNumber = computerCode;
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


            

            if (!Page.IsPostBack)
            {
                if (connectionNumber != "")
                {
                    if (tryConnect(connectionNumber, phoneCode, !isCookie))
                    {
                        lblConnectionCode.Text = connectionNumber;
                        divConnect.Visible = false;
                        divStatus.Visible = true;
                        divUpload.Visible = true;
                    }
                    else
                    {
                        txtNumbers.Text = connectionNumber;
                        lblStatus.Text = "Unable to Connect.";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        divConnect.Visible = true;
                        divStatus.Visible = false;
                        divUpload.Visible = false;
                    }
                }
                
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
                else
                {
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

        protected void FileUpload_Uploading(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                lblStatus.Text = "Ready to Send!";
            }
        }

        public bool tryConnect(string connectionStr, string pCode, bool status)
        {
            if (status)
            {
                tcp.sendData("newphone" + ";" + connectionStr + ";" + pCode);
            }
            else
            {
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
            else
            {
                return true;
            }
        }

        protected void btnUpload_Click1(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                string imageStr = Convert.ToBase64String(FileUploadControl.FileBytes);

                try
                {
                    connectionNumber = Request.Cookies["compCode"].Value;
                    if (connectionNumber == "")
                    {
                        connectionNumber = txtNumbers.Text;
                    }
                }
                catch
                {
                    connectionNumber = txtNumbers.Text;
                }
                lblUploadStatus.Visible = false;
                tcp.sendData("image" + ";" + connectionNumber + ";" + phoneCode + ";" + imageStr);
                divUpload.Visible = true;
                divStatus.Visible = true;
                divCheck.Visible = true;
            }
            else
            {
                divUpload.Visible = true;
                divStatus.Visible = true;
                lblUploadStatus.Text = "No Image Selected.";
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
                UpdatePanel2.Update();
                if (FileUploadControl.HasFile)
                {
                    UpdatePanel2.Update();
                    System.Threading.Thread.Sleep(500);
                    string imageStr = Convert.ToBase64String(FileUploadControl.FileBytes);

                    try
                    {
                        connectionNumber = Request.Cookies["compCode"].Value;
                        if (connectionNumber == "")
                        {
                            connectionNumber = txtNumbers.Text;
                        }
                    }
                    catch
                    {
                        connectionNumber = txtNumbers.Text;
                    }
                    lblUploadStatus.Visible = false;
                    tcp.sendData("image" + ";" + connectionNumber + ";" + phoneCode + ";" + imageStr);
                    divUpload.Visible = true;
                    divStatus.Visible = true;
                    divCheck.Visible = true;
                }
                else
                {
                    divUpload.Visible = true;
                    divStatus.Visible = true;
                    lblUploadStatus.Text = "No Image Selected.";
                }

        }
    }
}