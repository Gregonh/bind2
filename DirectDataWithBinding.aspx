<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DirectDataWithBinding.aspx.cs" Inherits="binding_prueba.DirectDataWithBinding" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <asp:DropDownList ID="lstProduct" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <br />
            <br />
            <br />
            <asp:Panel ID="pnlCategory" runat="server" Visible="False"  HorizontalAlign="Left">
            <asp:Label ID="lblRecordInfo" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:ListBox ID="lstCategory" runat="server"></asp:ListBox>
            <br />
            <br />
            <br />
            <asp:Button ID="cmdUpdate" runat="server" OnClick="cmdUpdate_Click" Text="Update" />
            </asp:Panel>
            
            <br />
            <asp:Label ID="lblResults" runat="server" Text=""></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
