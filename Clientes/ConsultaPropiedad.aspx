<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaPropiedad.aspx.cs" Inherits="Clientes.ConsultaPropiedad" %>

<%@ Register assembly="Controles" namespace="Controles" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StylsCliente.css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <table style="margin-left:25%;">
    <tr>
    <td>
    <cc1:Compositive ID="Compositive1" runat="server" />
    </td>
    <td>
    <asp:Button ID="btnAtras" runat="server" Text="Atras" CssClass="Button" 
            onclick="Button1_Click" />
    </td>
    </tr>
    <tr>
    <td>
        <asp:Button ID="btnSolicitar" runat="server" onclick="btnSolicitar_Click" 
            Text="Solicitar visita" CssClass="Button" />
    </td>
    <td>
        &nbsp;</td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="lbltitulo" runat="server" Text="Agenda tu visita aquí" 
            CssClass="Title" ></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="Names"></asp:Label>
        </td>
    </tr>
    <tr>
    <td>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="Tbox"></asp:TextBox>
    </td>
    <td>
        <asp:Button ID="btnAgregar" runat="server" CssClass="Button" Text="Agendar" 
            onclick="btnAgregar_Click" />
    </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="lblTel" runat="server" Text="Telefono" CssClass="Names"></asp:Label>
        </td>
    </tr>
    <tr>
    <td>
        <asp:TextBox ID="txtTelefono" runat="server" CssClass="Tbox"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="lblFecha" runat="server" Text="Fecha" CssClass="Names"></asp:Label>
        </td>
    </tr>
    <tr>
    <td>
        <asp:TextBox ID="txtFecha" runat="server" CssClass="Tbox"></asp:TextBox>
    </td>
    </tr> 
    <tr>
    <td>
        <asp:Label ID="lblHora" runat="server" Text="Hora" CssClass="Names"></asp:Label>
    </td>
    </tr> 
    <tr>
    <td>
        <asp:DropDownList ID="ddlHora" runat="server" CssClass="Tbox">
            <asp:ListItem>8:00</asp:ListItem>
            <asp:ListItem>9:00</asp:ListItem>
            <asp:ListItem>10:00</asp:ListItem>
            <asp:ListItem>11:00</asp:ListItem>
            <asp:ListItem>12:00</asp:ListItem>
            <asp:ListItem>13:00</asp:ListItem>
            <asp:ListItem>14:00</asp:ListItem>
            <asp:ListItem>15:00</asp:ListItem>
            <asp:ListItem>16:00</asp:ListItem>
            <asp:ListItem>17:00</asp:ListItem>
            <asp:ListItem>18:00</asp:ListItem>
            <asp:ListItem>19:00</asp:ListItem>
            <asp:ListItem>20:00</asp:ListItem>
        </asp:DropDownList>
    </td>
    </tr> 
    <tr>
    <td>
        &nbsp;</td>
    </tr> 
    <tr>
    <td>
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </td>
    </tr> 
    </table>
    </form>
</body>
</html>
