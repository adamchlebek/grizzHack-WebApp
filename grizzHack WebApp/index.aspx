<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="grizzHack_WebApp.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no, minimal-ui">
    <link href="stylesheet.css" rel="stylesheet" type="text/css" media="all" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <meta charset="utf-8" />
    <title>Home</title>
</head>
<body style="background-color: lightgray">
    <br />
    <h1>NAME OF THING</h1>
        <form runat="server" id="upload" method="post" enctype="multipart/form-data">

            <div runat="server" class="upload" id ="divConnect">
                <h3>Connect Code</h3>
                <asp:TextBox class="form-control" ID="txtNumbers" runat="server" style="text-align:center;" pattern="\d*" maxlength="5"></asp:TextBox>
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
                <hr />
                <asp:Label ID="lblConnectionCode" runat="server" Text="[#####]" class="connectionCode"></asp:Label>
                <asp:LinkButton ID="newConnection" runat="server" OnClick="newConnection_Click">New Connection?</asp:LinkButton>
                <br />
            </div>

            <div runat="server" id="divUpload" class="upload">
                <div class="drop" style="text-align:center; margin: 20px 20px 20px 20px;">
                    <asp:FileUpload id="FileUploadControl" runat="server" accept=".png,.jpg,.jpeg,.gif" />
                    <asp:Button runat="server" id="btnUpload" text="Upload" onclick="UploadButton_Click" />
                    <br /><br />
                    <asp:Label runat="server" id="lblUploadStatus" text="Select an Image." />
                </div>
            </div>
    </form>
</body>
</html>