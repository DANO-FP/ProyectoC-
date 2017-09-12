<%@ Page Title="BRS" Language="C#" MasterPageFile="~/a.Master" AutoEventWireup="true" CodeBehind="ABMZona.aspx.cs" Inherits="Funcionarios.ABMZona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content2">
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;
                    </td>
                <td align="center" valign="middle"> 
                    &nbsp;</td>
                <td style="text-align: center" align="left">
                    &nbsp;
                </td>
                <td style="text-align: center">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
                <td align="center" valign="middle" class="Names">
                <asp:Label ID="lblDpto" runat="server" Text="ID Departamento" CssClass="NamesDef"></asp:Label>
                    &nbsp;
                </td>
                <td align="center" valign="middle">
                    <asp:DropDownList ID="ddlDpto" runat="server" CssClass="Tbox">
                        <asp:ListItem Value="">Seleccione Departamento</asp:ListItem>
                        <asp:ListItem Value="A"></asp:ListItem>
                        <asp:ListItem Value="B"></asp:ListItem>
                        <asp:ListItem Value="C"></asp:ListItem>
                        <asp:ListItem Value="D"></asp:ListItem>
                        <asp:ListItem Value="E"></asp:ListItem>
                        <asp:ListItem Value="F"></asp:ListItem>
                        <asp:ListItem Value="G"></asp:ListItem>
                        <asp:ListItem Value="H"></asp:ListItem>
                        <asp:ListItem Value="I"></asp:ListItem>
                        <asp:ListItem Value="J"></asp:ListItem>
                        <asp:ListItem Value="K"></asp:ListItem>
                        <asp:ListItem Value="L"></asp:ListItem>
                        <asp:ListItem Value="M"></asp:ListItem>
                        <asp:ListItem Value="N"></asp:ListItem>
                        <asp:ListItem Value="O"></asp:ListItem>
                        <asp:ListItem Value="P"></asp:ListItem>
                        <asp:ListItem Value="Q"></asp:ListItem>
                        <asp:ListItem Value="R"></asp:ListItem>
                        <asp:ListItem Value="S"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td valign="middle" class="style1" align="left">
                    <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                        Text="Buscar Zona" CssClass="Button" />
                </td>
                <td align="center" valign="middle" class="Names">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
                <td align="center" valign="middle">
                    &nbsp;</td>
                <td valign="middle" align="left">
                <asp:Button ID="btnModificar" runat="server" Text="Editar Zona" 
                    onclick="btnModificar_Click" CssClass="Button" />
                    </td>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
                <td align="center" valign="middle" class="Names">
                <asp:Label ID="lblAcron" runat="server" 
                    Text="Acrónimo" CssClass="NamesDef"></asp:Label>
                </td>
                <td align="center" valign="middle">
                <asp:TextBox ID="txtAcron" runat="server" style="text-align: center" 
                        CssClass="Tbox"></asp:TextBox>
                </td>
                <td valign="middle" align="left">
                    <asp:Button ID="btnAlta" runat="server" Text="Alta Zona" 
                    onclick="btnAlta_Click" CssClass="Button" />
                </td>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
                <td align="center" valign="middle">
                    &nbsp;</td>
                <td valign="middle" align="left">
                <asp:Button ID="btnBaja" runat="server" Text="Eliminar Zona" onclick="btnBaja_Click" 
                            CssClass="Button" />
                </td>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
                <td align="center" valign="middle" class="Names">
                <asp:Label ID="lblNomOf" runat="server"
                    Text="Nombre Oficial" CssClass="NamesDef"></asp:Label>
                </td>
                <td align="center" valign="middle">
                <asp:TextBox ID="txtNomOf" runat="server" style="text-align: center" 
                        CssClass="Tbox"></asp:TextBox>
                    </td>
                <td valign="middle" align="left">
                    <asp:Button ID="btnNvaConsulta" runat="server" onclick="btnNvaConsulta_Click" 
                        Text="Nueva Consulta" CssClass="Button" />
                </td>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" valign="middle" class="style2">
                    </td>
                <td align="center" valign="middle" class="style2">
                    </td>
                <td align="center" valign="middle" class="style2">
                    &nbsp;</td>
                <td align="center" valign="middle">
                <asp:Button ID="btnAgregaServ" runat="server" Text="Alta Servicio" 
                    onclick="btnAgregaServ_Click" Width="162px" CssClass="Button" />
                    </td>
                <td align="center" valign="middle" class="style2">
                    </td>
            </tr>
            <tr>
                <td align="center" valign="middle">
                    </td>
                <td align="center" valign="middle">
                <asp:Label ID="lblHabitantes" runat="server" style="text-align: left" 
                    Text="Habitantes" CssClass="NamesDef"></asp:Label>
                    </td>
                <td align="center" valign="middle">
                <asp:TextBox ID="txtHabitantes" runat="server" style="text-align: center" 
                        CssClass="Tbox"></asp:TextBox>
                </td>
                <td align="center" valign="middle">
                <asp:Button ID="btnEliminarServ" runat="server" Text="Baja Servicio" 
                    Width="162px" onclick="btnEliminarServ_Click" CssClass="Button" />
                    </td>
                <td align="center" valign="middle">
                    </td>
            </tr>
            <tr>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
                <td align="center" valign="middle">
                    &nbsp;</td>
                <td align="center" valign="middle">
                    &nbsp;</td>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
                <td align="center" valign="middle" class="Names">
                    <asp:Label ID="lblNomDep" runat="server" Text="Departamento" 
                        CssClass="NamesDef"></asp:Label>
                </td>
                <td align="center" valign="middle">
                    <asp:TextBox ID="txtNomDep" runat="server" 
                        style="text-align: center; font-weight: 700; font-style: italic;" 
                        CssClass="Tbox"></asp:TextBox>
                </td>
                <td align="center" valign="middle">
                    &nbsp;</td>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
                <td align="center" valign="middle">
                    &nbsp;</td>
                <td align="center" valign="middle">
                    &nbsp;</td>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
                <td align="center" valign="middle" class="Names">
                <asp:Label ID="lblAgregarServ" runat="server" CssClass="Names" 
                    Text="Ingrese el nombre del servicio"></asp:Label>
                </td>
                <td align="center" valign="middle">
                <asp:TextBox ID="txtServicio" runat="server" style="text-align: center" 
                    Width="149px" CssClass="Tbox"></asp:TextBox>
                </td>
                <td align="center" valign="middle">
                <asp:Label ID="lblInfo" runat="server" 
                    
                    
                        style="color: #0000FF; font-weight: 700; font-size: large; background-color: #00CC66" 
                        CssClass="Names"></asp:Label>
                <asp:Label ID="lblError" runat="server" 
                    style="color: #FF0000; font-weight: 700; font-size: large; background-color: #FFCCCC"></asp:Label>
                </td>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
                <td align="center" valign="middle">
                <asp:GridView ID="gvServicios" runat="server" AutoGenerateColumns="False" 
                    style="text-align: center" Width="313px">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Servicios" />
                    </Columns>
                </asp:GridView>
                </td>
                <td align="center" valign="middle">
                <asp:Label ID="lblInfoServ" runat="server" CssClass="Names"></asp:Label>
                </td>
                <td align="center" valign="middle" class="Names">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="5" valign="middle">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="5" valign="middle">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="5" valign="middle">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    <div>
        </div>
        <div>
        </div>
        </div>
</asp:Content>
