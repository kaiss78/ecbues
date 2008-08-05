<%@ Page Language="C#" MasterPageFile="~/examinar/ecbues.examen.master" AutoEventWireup="true"
    CodeFile="Resultados.aspx.cs" Inherits="examinar_Resultados" Title="Untitled Page" %>
<%@ Register Src="../controles/Graficador.ascx" TagName="Graficador" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="Server">
    <img src="../imagenes/jpg/examen_ya.jpg" style="position: absolute" />
    <center>
        <uc1:Graficador id="Graficador1" runat="server">
    </uc1:Graficador><br />
    <asp:Label ID="lblAviso" runat="server" Text="Este es el porcentaje de preguntas acertadas..." Font-Bold="True"></asp:Label></center>
</asp:Content>
