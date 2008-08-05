<%@ Page Language="C#" MasterPageFile="ecbues.examen.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="examen" Title="Untitled Page" %>

<%@ Register Src="../controles/MostrarPregunta.ascx" TagName="MostrarPregunta" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <table border="0">
    <tr><td align="center">
        <uc1:MostrarPregunta ID="MostrarPregunta1" runat="server" />
        
    </td></tr>
    <tr><td align="right">
    <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" OnClick="btnSiguiente_Click" />
    </td></tr>
    </table>    
</asp:Content>

