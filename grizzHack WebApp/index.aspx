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
<body>
    <br />
    <h1>NAME OF THING</h1>

            <form runat="server" id="upload" method="post" enctype="multipart/form-data">

                <div class="upload">
                    <h3>Connect Code</h3>
                    <asp:TextBox class="form-control" ID="txtNumbers" runat="server" style="text-align:center" pattern="\d*" maxlength="5"></asp:TextBox>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text="[STATUS]"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    
                </div>

                <br />
                    <div class="upload">
                            <div class="drop" id="divUpload" style="text-align:center; margin: 20px 20px 20px 20px;">
                                <asp:FileUpload ID="FileUpload1" Style="display: none" runat="server" onchange="upload()" />
                                <input type="button" value="Upload Image" class="btn btn-primary btn-lg" onclick="showBrowseDialog()"/>
                    
                                <asp:Button runat="server" ID="hideButton" Text="" Style="display: none;"/>

                                <script type="text/javascript" language="javascript">
                                    function showBrowseDialog() {
                                        var fileuploadctrl = document.getElementById('<%= FileUpload1.ClientID %>');
                                        fileuploadctrl.click();
                                    }

                                    function upload() {
                                        var btn = document.getElementById('<%= hideButton.ClientID %>');
                                        btn.click();
                                    }
                                </script>    
                </div>
            </div>
    </form>
</body>
</html>