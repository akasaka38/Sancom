<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="First.aspx.cs" Inherits="SkillUpSample2.First" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="filename" runat="server" type="file" />
        <asp:button ID="Send" runat="server" Text="変換" OnClick="Button_Click" />
    </div>
    </form>
</body>
</html>
