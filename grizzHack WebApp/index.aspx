<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="grizzHack_WebApp.index1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link href="index.css" rel="stylesheet" type="text/css"/>
    <title>Pictacom</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="center-screen">
            <img src="Pictacom.png" style="width: 33%; height: 100px;"/>
            <br/>
            <br/>
            <asp:Button ID="btnWebApp" runat="server" class="btn btn-primary" Text="Webapp" OnClick="btnWebApp_Click" />
            <br />
            <br />
            <asp:Button ID="btnDownloadClient" runat="server" class="btn btn-outline-success" Text="Download Client" />
        </div>
    </form>
</body>
</html>