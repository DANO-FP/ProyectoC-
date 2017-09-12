<%@ Page Title="Bienvenido a BRS" Language="C#" MasterPageFile="~/MPFuncionarios.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Funcionarios.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    $(Document).ready(function(){
        $("#PrincipalPage").fadeIn(4000);
    });
</script>
    <div id="PrincipalPage">
    
        <img id="Logo1"; src="Img/Logo.png" />
        <p>
        Bienvenido 
        <asp:Label ID="lblUsuario" runat="server"></asp:Label>
        </p>
        </div>
</asp:Content>
