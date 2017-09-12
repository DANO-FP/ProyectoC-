<%@ Page Title="" Language="C#" MasterPageFile="~/MPFuncionarios.Master" AutoEventWireup="true" CodeBehind="ABM_ZonaNuevo.aspx.cs" Inherits="Funcionarios.ABM_ZonaNuevo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblIdDepto" runat="server" Text="ID Departamento"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlDepartamento" runat="server">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="btnBuscarZona" runat="server" onclick="btnBuscarZona_Click" 
                Text="Buscar zona" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblAcronimo" runat="server" Text="Acronimo"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAcronimo" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="btnAltaZona" runat="server" Text="Alta zona" 
                onclick="btnAltaZona_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblNombreOficial" runat="server" Text="Nombre Oficial"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtNombreOficial" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="btnBajaZona" runat="server" Text="Baja zona" 
                onclick="btnBajaZona_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblHabitantes" runat="server" Text="Cantidad de habitantes"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtCantHabitantes" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="btnModificarZona" runat="server" Text="Modificar zona" 
                onclick="btnModificarZona_Click" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Label ID="lblNombreServicio" runat="server" Text="Nombre servicio"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtServicios" runat="server" 
                ontextchanged="txtServicios_TextChanged"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnAltaServicio" runat="server" Text="Alta servicio" 
                onclick="btnAltaServicio_Click" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="btnBajaServicio" runat="server" Text="Baja servicio" 
                onclick="btnBajaServicio_Click" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td colspan="2">
                <asp:GridView ID="gvServicios" runat="server" AutoGenerateColumns="False" 
                    style="text-align: center" Width="313px">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Servicios" />
                    </Columns>
                </asp:GridView>
                </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
