﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataSetMultipleTableBinding.aspx.cs" Inherits="binding_prueba.DataSetMultipleTableBinding" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:gridview runat="server" ID="GridView1"></asp:gridview>
            <asp:GridView ID="GridView2" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
