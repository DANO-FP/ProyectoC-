<%@ Page Title="BRS" Language="C#" MasterPageFile="~/MPFuncionarios.Master" AutoEventWireup="true" CodeBehind="ABM_Apartamento.aspx.cs" Inherits="Funcionarios.ABM_Apartamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="Content2">
    <table style="width:100%;">
            <tr>
                <td colspan="3" style="text-align: center" class="Title">
                    ABM de Apartamentos</td>
            </tr>
            <tr>
                <td class="Names">
                    Padrón:
                </td>
                <td>      
                    <asp:TextBox ID="txtPadron" runat="server" style="margin-left: 0px" 
                        CssClass="Tbox"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                        Text="Buscar" CssClass="Button" Width="137px" />
                </td>
            </tr>
            <tr>
                <td class="Names">
                    Precio:</td>
                <td>
                    <asp:TextBox ID="txtPrecio" runat="server" style="margin-left: 0px" 
                        CssClass="Tbox"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnAlta" runat="server" Text="Agregar" onclick="btnAlta_Click" 
                        CssClass="Button" Width="138px" />
                </td>
            </tr>
            <tr>
                <td class="Names">
                    Cantidad de baños:</td>
                <td>
                    <asp:TextBox ID="txtBaños" runat="server" style="margin-left: 0px" 
                        CssClass="Tbox"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnBaja" runat="server" Text="Eliminar" onclick="btnBaja_Click" 
                        CssClass="Button" />
                </td>
            </tr>
            <tr>
                <td class="Names">
                    Cantidad de habitaciones:</td>
                <td>
                    <asp:TextBox ID="txtHabitantes" runat="server" style="margin-left: 0px" 
                        CssClass="Tbox"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnModificacion" runat="server" Text="Modificar" 
                        onclick="btnModificacion_Click" CssClass="Button" Width="145px" />
                </td>
            </tr>
            <tr>
                <td class="Names">
                    Metros cuadrados edificados:</td>
                <td>
                    <asp:TextBox ID="txtMtEd" runat="server" style="margin-left: 0px" 
                        CssClass="Tbox"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnLimpiar" runat="server" EnableTheming="True" 
                        Text="Limpiar" onclick="btnLimpiar_Click"
                        CssClass="Button" Width="141px" />
                </td>
            </tr>
            <tr>
                <td class="Names">
                    Direccion:</td>
                <td>
                    <asp:TextBox ID="txtDireccion" runat="server" style="margin-left: 0px" 
                        CssClass="Tbox"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="Names">
                    Accion:</td>
                <td>
                    <asp:DropDownList ID="ddlAccion" runat="server" CssClass="Tbox">
                        <asp:ListItem>ALQUILER</asp:ListItem>
                        <asp:ListItem>PERMUTA</asp:ListItem>
                        <asp:ListItem>VENTA</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="Names">
                    Piso: 
                </td>
                <td>
                    <asp:TextBox ID="txtPiso" runat="server" style="margin-left: 0px" 
                        CssClass="Tbox"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="Names">
                    Ascensor:
                </td>
                <td class="style1">
                    <asp:CheckBox ID="chbAscensor" runat="server" CssClass="Check" />
                </td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="Names">
                    Departamento:</td>
                <td>
                    <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="Tbox">
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
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="Names">
                    Acronimo de la zona:</td>
                <td>
                    <asp:TextBox ID="txtAcronimo" runat="server" style="margin-left: 0px" 
                        CssClass="Tbox"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblError" runat="server" CssClass="lblError"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="Names">
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
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        </div>
</asp:Content>
