<%@ Page Language="C#" MasterPageFile="~/administrar/ecbues.admin.master" AutoEventWireup="true"
    CodeFile="modificar3.aspx.cs" Inherits="administrar_modificar3" Title="Untitled Page" %>

<%@ Register Src="../controles/ManipularPregunta.ascx" TagName="ManipularPregunta"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="Server">
    <asp:ImageButton ID="imgbtnRegresar" runat="server" ImageUrl="~/imagenes/jpg/atras.jpg"
        OnClick="imgbtnSiguiente_Click" Width="40px" /><h2>Modifica la pregunta:</h2>
    <uc1:ManipularPregunta ID="ManipularPregunta1" runat="server" />
</asp:Content>
