<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CustomerAPI.Index" %>

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
            <asp:Label ID="lblID" runat="server" Text="Identificacion"></asp:Label>
&nbsp;
            <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblname" runat="server" Text="Nombre Completo"></asp:Label>
&nbsp;
            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblphone" runat="server" Text="Telefono"></asp:Label>
&nbsp;
            <asp:TextBox ID="txtphone" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblphone0" runat="server" Text="Correo Electronico"></asp:Label>
&nbsp;
            <asp:TextBox ID="txtphone0" runat="server" Width="173px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblphone1" runat="server" Text="Notas"></asp:Label>
&nbsp;
            <br />
            <asp:TextBox ID="txtphone1" runat="server" Height="110px" Width="357px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblmsj" runat="server" Text="msj"></asp:Label>
            <br />
            <asp:Button ID="btnAdd" runat="server" Text="Agregar" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="Button" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnShow" runat="server" Text="Mostrar Reporte" />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
