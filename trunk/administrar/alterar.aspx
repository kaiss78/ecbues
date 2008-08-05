<%--<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="alterar.aspx.cs" Inherits="_Default" %>--%>
<%@ Page Language="C#" MasterPageFile="~/administrar/ecbues.admin.master" AutoEventWireup="true" CodeFile="alterar.aspx.cs" Inherits="administrar_alterar"%>
<%@ Register Src="../controles/ManipularPregunta.ascx" TagName="ManipularPregunta" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
        <!-- El contenido va aqui... -->
    <asp:ImageButton ID="imgbtnRegresar" runat="server" ImageUrl="~/imagenes/jpg/atras.jpg"
        OnClick="imgbtnSiguiente_Click" Width="40px" />
        <h2>Agrega una pregunta:</h2>
        <i>materia:<% =(string)Session["materia"] %> modalidad:<% =(string)Session["modalidad"] %><br /></i>
          <div class="content-box">
              <uc1:ManipularPregunta id="agrPregunta" runat="server">
              </uc1:ManipularPregunta>
          </div>
        <!-- Final de el contenido de la pagina -->
</asp:Content>        