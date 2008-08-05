<%@ Page Language="C#" MasterPageFile="~/ecbues.main.master" AutoEventWireup="true"
    CodeFile="default.aspx.cs" Inherits="_Default" Title="ECB - UES FMOcc - Portada" %>

<asp:Content runat="server" ContentPlaceHolderID="contenido" ID="contDefault">
    <!-- Principio Contenido de la pagina -->
        <h2>
            Bienvenida</h2>
        <table style="width: 100%">
            <tr>
                <td style="height: 145px">
                    <p class="MsoNormal" style="margin: 0cm 0cm 0pt">
                        <span style="color: gray; font-family: Perpetua">Bienvenido, como futuro aspirante a
                            <?xml namespace="" ns="urn:schemas-microsoft-com:office:smarttags" prefix="st1" ?><st1:personname productid="la Universidad" w:st="on">la Universidad</st1:personname>
                        </span><span style="font-family: Perpetua"><span style="color: #000000"></span><span
                            style="color: gray">de El Salvador, ponemos a su disposición </span><span style="color: black">
                                <span style="mso-spacerun: yes">&nbsp;</span></span><span style="color: gray">el siguiente
                                    sitio Web, en el cual usted tiene la oportunidad de autoevaluarse y medir sus conocimientos,
                                    todo ello con el objetivo </span><span style="color: black"><span style="mso-spacerun: yes">
                                        &nbsp;</span></span><span style="color: gray">que usted sepa el nivel intelectual que
                                            posee en las diferentes áreas de estudio, previo a un examen de admisión.<?xml namespace=""
                                                ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><o:p></o:p></span></span></p>
                </td>
                <td style="width: 140px; height: 145px;">
                    <img src="imagenes/jpg/internet3.jpg" alt="" height="128" />
                </td>
            </tr>
        </table>
        <br />
        <h3>
            Inicio rápido</h3>
        <table style="width: 100%">
            <tr>
                <td>
                    <img src="imagenes/bachiller.gif" style="border-right: gray thin dashed; border-top: gray thin dashed;
                        float: left; border-left: gray thin dashed; border-bottom: gray thin dashed" />
                Esta sección esta dirigida para todas aquellas personas que desean iniciar su evaluación lo más rápido posible, al acceder a esta sección la evaluación constara de cuatro áreas básicas con 25 preguntas aleatorias de cada una de ellas... Bachiller... ¿estas
                listo?<td style="width: 140px">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="imagenes/jpg/examen.jpg"
                        OnClick="ImageAll_Click" /><center><br /><strong>Click aqui para<br />el inicio rapido</strong></center></td>
            </tr>
        </table>
        <br />
        <h3>
            Examen por categorías</h3>
        <table style="width: 100%">
            <tr>
                <td style="height: 20px">
                    En esta sección puedes&nbsp; examinarte en una de estas cuatro categorías, simplemente tienes que seleccionarla y manos a la obra</td>
            </tr>
        </table>
        <table style="width: 100%; text-align: center;">
            <tr>
                <td>
                    Ciencias de la Naturaleza</td>
                <td>
                    Matemáticas</td>
                <td>
                    Ciencias Sociales</td>
                <td>
                    Lenguaje y Literatura</td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="ImageButton2" runat="server" Height="128px" ImageUrl="~/imagenes/jpg/ciencias1.jpg"
                        OnClick="ImageCiencias_Click" Width="128px" /><center><br /><strong>Click aqui para<br />preguntas de<br />Ciencias Naturales.</strong></center></td>
                <td>
                    <asp:ImageButton ID="ImageButton3" runat="server" Height="128px" ImageUrl="imagenes/jpg/matematicas.jpg"
                        OnClick="imgMatematicas_Click" Width="128px" /><center><br /><strong>Click aqui para<br />preguntas de<br />Matematicas.</strong></center></td>
                <td>
                    <asp:ImageButton ID="ImageButton4" runat="server" Height="128px" ImageUrl="imagenes/jpg/sociales.jpg"
                        OnClick="imgSociales_Click" Width="128px" /><center><br /><strong>Click aqui para<br />preguntas de<br />Ciencias Sociales.</strong></center></td>
                <td>
                    <asp:ImageButton ID="ImageButton5" runat="server" Height="128px" ImageUrl="imagenes/jpg/literatura.jpg"
                        OnClick="imgLenguaje_Click" Width="128px" /><center><br /><strong>Click aqui para<br />preguntas de<br />Lenguaje y literatura.</strong></center></td>
            </tr>
        </table>
    <!-- Final de el contenido de la pagina -->
</asp:Content>
