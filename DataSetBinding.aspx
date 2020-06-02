<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataSetBinding.aspx.cs" Inherits="binding_prueba.DataSetBinding" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListBox ID="lstAuthor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstAuthor_SelectedIndexChanged" Width="150px"></asp:ListBox>
            <br />
            <br />
            <asp:Label ID="lblResults" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
