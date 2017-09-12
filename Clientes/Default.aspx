<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Clientes.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="StylsCliente.css" />
</head>
<body>
    <form id="form1" runat="server">
        <table>
        <tr>
        <td>
            <img alt="Logo" src="Logo.png" style="text-align:center; width:500px;" />
        </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="lblSeleccion" class="Names" runat="server" Text="Label">Seleccione tipo de busqueda por accion:</asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlAccion" runat="server" CssClass="Tbox">
                 <asp:ListItem Value="0">Seleccionar tipo de accion</asp:ListItem>
                 <asp:ListItem>ALQUILER</asp:ListItem>
                 <asp:ListItem>PERMUTA</asp:ListItem>
                 <asp:ListItem>VENTA</asp:ListItem>
            </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="lblFProp" class="Names" runat="server" Text="Label">Filtro por tipo de propiedad:</asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlPropiedad" class="Tbox" runat="server">
                 <asp:ListItem Value="0">Seleccionar tipo de propiedad</asp:ListItem>
                 <asp:ListItem Value="1">Apartamento</asp:ListItem>
                 <asp:ListItem Value="2">Casa</asp:ListItem>
                 <asp:ListItem Value="3">Local Comercial</asp:ListItem>
             </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label1" class="Names" runat="server" Text="Label">Seleccione departamento:</asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="Tbox">
                 <asp:ListItem Value="0">Seleccionar departamento</asp:ListItem>
                 <asp:ListItem Value="G">Artigas</asp:ListItem>
                 <asp:ListItem Value="A">Canelones</asp:ListItem>
                 <asp:ListItem Value="E">Cerro Largo</asp:ListItem>
                 <asp:ListItem Value="L">Colonia</asp:ListItem>
                 <asp:ListItem Value="Q">Durazno</asp:ListItem>
                 <asp:ListItem Value="N">Flores</asp:ListItem>
                 <asp:ListItem Value="O">Florida</asp:ListItem>
                 <asp:ListItem Value="P">Lavalleja</asp:ListItem>
                 <asp:ListItem Value="B">Maldonado</asp:ListItem>
                 <asp:ListItem Value="S">Montevideo</asp:ListItem>
                 <asp:ListItem Value="I">Paysandú</asp:ListItem>
                 <asp:ListItem Value="J">Río Negro</asp:ListItem>
                 <asp:ListItem Value="F">Rivera</asp:ListItem>
                 <asp:ListItem Value="C">Rocha</asp:ListItem>
                 <asp:ListItem Value="H">Salto</asp:ListItem>
                 <asp:ListItem Value="M">San José</asp:ListItem>
                 <asp:ListItem Value="K">Soriano</asp:ListItem>
                 <asp:ListItem Value="R">Tacuarembó</asp:ListItem>
                 <asp:ListItem Value="D">Treinta y Tres</asp:ListItem>
             </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label2" CssClass="Names" runat="server" Text="Label">Ingrese el acronimo: </asp:Label>
        </td>
        <td>
         <asp:TextBox ID="txtAcronimo" runat="server" CssClass="Tbox"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label3" CssClass="Names" runat="server" Text="Label">Filtro por precio:</asp:Label>
        </td>
        </tr>
        <td>
            <asp:Label ID="Label4" CssClass="Names" runat="server" Text="Label">Precio minimo: </asp:Label>
            <asp:TextBox ID="txtMin" runat="server" CssClass="Tbox"></asp:TextBox>
        </td>
        <tr>
        <td>
            <asp:Label ID="Label5" CssClass="Names" runat="server" Text="Label">Precio maximo:</asp:Label>
            <asp:TextBox ID="txtMax" runat="server" CssClass="Tbox"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
        <asp:Button ID="btnAplicar" runat="server" onclick="btnAplicar_Click" Text="Aplicar filtros" CssClass="Button" />
        </td>
        <td>
        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar filtros" onclick="btnLimpiar_Click" CssClass="Button" />
        </td>
        </tr>
        <tr>
        <td>
        <asp:Label ID="lblError" runat="server" CssClass="Names"></asp:Label>
        </td>
        </tr>
        </table>
        <asp:Repeater ID="rtPropiedad" runat="server" onitemcommand="Repeater1_ItemCommand">
             <ItemTemplate>
                  <table class="rep">
                         <tr bgcolor="#81F781">
                         <td>
                         Padron: <asp:TextBox ID = "txtPadron" class="TextBox" runat = "server" Text ='<%#Bind("Padron") %>'></asp:TextBox>
                         <br />
                         </td>
                         <td>
                         Direccion: <asp:TextBox ID = "txtDireccion" class="TextBox" runat = "server" Text ='<%#Bind("Direccion") %>'></asp:TextBox>
                         <br />
                         </td>
                         <td>
                         Departamento: <asp:TextBox ID = "txtDpto" class="TextBox" runat = "server" Text ='<%#Bind("Departamento.NombreDep") %>'></asp:TextBox>
                         <br />
                         </td>
                         <td>
                         Acronimo: <asp:TextBox ID = "txtAcronimo" class="TextBox" runat = "server" Text ='<%#Bind("Departamento.Acronimo") %>'></asp:TextBox>
                         <br />
                         </td>
                         <td>
                         Tipo de accion: <asp:TextBox ID = "txtAccion" class="TextBox" runat = "server" Text ='<%#Bind("Accion") %>'></asp:TextBox>
                         <br />
                         </td>
                         <td>
                         <asp:Button ID = "btnCaractristicas" Class="btnCar" runat="server" CommandName ="Caracteristicas" Text="Caracteristicas" />
                         </td>
                         </tr>
                  </table>
              </ItemTemplate>
                  <AlternatingItemTemplate>
                     <table class="rep">
                        <tr bgcolor="#e6ffff">
                        <td>
                        Padron: <asp:TextBox ID = "txtPadron" class="TextBox" runat = "server" Text ='<%#Bind("Padron") %>'></asp:TextBox>
                        <br />
                        </td>
                        <td>
                        Direccion: <asp:TextBox ID = "txtDireccion" class="TextBox" runat = "server" Text ='<%#Bind("Direccion") %>'></asp:TextBox>
                        <br />
                        </td>
                        <td>
                        Departamento: <asp:TextBox ID = "txtDpto" class="TextBox" runat = "server" Text ='<%#Bind("Departamento.NombreDep") %>'></asp:TextBox>
                        <br />
                        </td>
                        <td>
                        Acronimo: <asp:TextBox ID = "txtAcronimo" class="TextBox" runat = "server" Text ='<%#Bind("Departamento.Acronimo") %>'></asp:TextBox>
                        <br />
                        </td>
                        <td>
                        Tipo de accion: <asp:TextBox ID = "txtAccion" class="TextBox" runat = "server" Text ='<%#Bind("Accion") %>'></asp:TextBox>
                        <br />
                        </td>
                        <td>
                        <asp:Button ID = "btnCaractristicas" Class="btnCar" runat="server" CommandName ="Caracteristicas" style = "text-align: center" Text="Caracteristicas" />
                        </td>
                        </tr>
                     </table>
                 </AlternatingItemTemplate>
         </asp:Repeater>
    </form>
</body>
</html>
