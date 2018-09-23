<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="app.aspx.cs" Inherits="grizzHack_WebApp.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no, minimal-ui">
    <link href="stylesheet.css" rel="stylesheet" type="text/css" media="all" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <meta charset="utf-8" />
    <title>Pictacom</title>
</head>
<body style="background-color: #120E1B">
    <br />
    <h1 style="font-weight: bold; color: #FFF; font-size: 500%; font-family: berlin">Pictacom</h1>
    <form runat="server" id="upload" method="post" enctype="multipart/form-data">

        <div runat="server" class="upload" id="divConnect">
            <h3>Connect Code</h3>
            <asp:TextBox class="form-control" ID="txtNumbers" runat="server" Style="text-align: center; align-content: center;" pattern="\d*" MaxLength="5" Font-Size="Larger"></asp:TextBox>
            <br />
            <asp:Button ID="btnConnect" runat="server" class="btn btn-success" Text="Connect" OnClick="btnConnect_Click" />
            <br />
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label ID="lblStatus" runat="server" Text="Waiting for Connection Code..."></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div runat="server" class="upload" id="divStatus">
            <h3>Conected To</h3>
            <br />
            <asp:Label ID="lblConnectionCode" runat="server" Style="font-size: xx-large" Text="[#####]" class="connectionCode"></asp:Label>
            <br />
            <asp:LinkButton ID="newConnection" runat="server" OnClick="newConnection_Click">New Connection?</asp:LinkButton>
            <br />
        </div>

        <div runat="server" id="divUpload" class="upload">
            <div class="drop" style="text-align: center; margin: 20px 20px 20px 20px;">
                <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:FileUpload ID="FileUploadControl" runat="server" accept=".png,.jpg,.jpeg,.gif" />
                        <br />
                        <div class="upload-btn-wrapper">
                            <asp:Button runat="server" class="uploadButton" ID="btnUpload" Text="Upload" OnClick="UploadButton_Click" />
                        </div>
                        <br />
                        <br />
                        <asp:Label runat="server" ID="lblUploadStatus" Text="Select an Image." />
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div runat="server" id="divCheck" class="checkmark">
                    <svg version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px"
                        viewBox="0 0 161.2 161.2" enable-background="new 0 0 161.2 161.2" xml:space="preserve">
                        <path class="path" fill="none" stroke="#7DB0D5" stroke-miterlimit="10" d="M425.9,52.1L425.9,52.1c-2.2-2.6-6-2.6-8.3-0.1l-42.7,46.2l-14.3-16.4
	c-2.3-2.7-6.2-2.7-8.6-0.1c-1.9,2.1-2,5.6-0.1,7.7l17.6,20.3c0.2,0.3,0.4,0.6,0.6,0.9c1.8,2,4.4,2.5,6.6,1.4c0.7-0.3,1.4-0.8,2-1.5
	c0.3-0.3,0.5-0.6,0.7-0.9l46.3-50.1C427.7,57.5,427.7,54.2,425.9,52.1z" />
                        <circle class="path" fill="none" stroke="#7DB0D5" stroke-width="4" stroke-miterlimit="10" cx="80.6" cy="80.6" r="62.1" />
                        <polyline class="path" fill="none" stroke="#7DB0D5" stroke-width="6" stroke-linecap="round" stroke-miterlimit="10" points="113,52.8
	74.1,108.4 48.2,86.4 " />

                        <circle class="spin" fill="none" stroke="#7DB0D5" stroke-width="4" stroke-miterlimit="10" stroke-dasharray="12.2175,12.2175" cx="80.6" cy="80.6" r="73.9" />
                    </svg>

                    <p>Image Sent!</p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>