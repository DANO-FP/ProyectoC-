<%@ Page Title="BRS" Language="C#" MasterPageFile="~/MPFuncionarios.Master" AutoEventWireup="true" CodeBehind="ABM_Funcionarios.aspx.cs" Inherits="Funcionarios.ABM_Funcionarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="Content2">
    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <asp:Label ID="lblFuncionarioTitle" runat="server" Text="ABM Funcionarios" 
                    CssClass="Title"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="Names">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="Tbox"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                    Text="Buscar" CssClass="Button" />
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="Names">
                <asp:Label ID="lblPass" runat="server" Text="Contraseña :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPass" runat="server" CssClass="Tbox"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnAlta" runat="server" onclick="btnAlta_Click" 
                    Text="Agregar" CssClass="Button" />
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="Names">
                <asp:Label ID="lblPass0" runat="server" Text="Verificar Contraseña :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPass0" runat="server" CssClass="Tbox"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnModificar" runat="server" onclick="btnModificar_Click" 
                    Text="Modificar" CssClass="Button" />
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="Names" colspan="2">
                <asp:Label ID="lblError" runat="server" CssClass="lblError"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnEliminar" runat="server" onclick="btnEliminar_Click" 
                    Text="Eliminar" CssClass="Button" />
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
                <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                    Text="Limpiar" CssClass="Button" />
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
