<%@ Page Language="C#" MasterPageFile="~/administrar/ecbues.admin.master" AutoEventWireup="true"
    CodeFile="default.aspx.cs" Inherits="administrar_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="Server">
    <!-- El contenido va aqui... -->
    <div class="content-box">
        <h3>
            Administración</h3>
        <br />
        <p>
            Esta sección es la encargada de administrar el contenido del examen en línea, es
            decir se puede agregar preguntas con sus posibles respuestas, modificar preguntas
            ya existentes y eliminar preguntas pertenecientes de cualquier materia que se pretende
            evaluar. La interfaz de Administración esta conformada por una interfaz sencilla
            y fácil de usar. Cuenta con un filtro para seleccionar la Materia que se desea administrar,
            cuenta con un segundo filtro en el que se puede seleccionar una de las 3 operaciones
            para administrar el contenido de cualquier materia (Agregar, modificar, eliminar),
            y un botón que permite tener el control de cada operación de administrar.</p>
        <table width="100%">
            <tr>
            <td width="33%"><h3>Filtro Materia</h3>Permite seleccionar la materia en la que se quiere trabajar. La selección de la
            materia esta limitada a ciertos usuarios, dependiendo de los roles que estos tengan
            asignados. Si se selecciona una materia, únicamente se tendrá acceso a administrar
            el contenido de esa materia.              
                </td>
                <td width="33%" valign="top">
                    <h3>Filtro Administrar</h3>
                    Este filtro le proporciona al usuario las siguientes funciones: Agregar, Modificar
                    y Eliminar preguntas.
                </td>
                <td width="33%" valign="top"><h3>Boton siguiente</h3>
                Da click en el boton siguiente para continuar con la tarea administrativa seleccionada.
                </td>
            </tr>
        </table>
        
        
        <center>
            &nbsp;</center>
        <center>
            <asp:Label ID="lblAvisoMateria" runat="server" Font-Bold="True" Font-Size="Large"
                ForeColor="Blue" Text="..."></asp:Label>&nbsp;</center>
        <br />
        <table width="100%">
            <tr>
                <td style="width: 33%; height: 63px;">
                    <center>
                        <b>Filtro Materia</b></center>
                    <center>
                        <asp:DropDownList ID="lstMateria" runat="server" DataSourceID="sqlMaterias" DataTextField="nombre_materia"
                            DataValueField="id_materia">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="sqlMaterias" runat="server" ConnectionString="<%$ ConnectionStrings:cadenaConeccion %>"
                            SelectCommand="SELECT * FROM [tb_materia]"></asp:SqlDataSource>
                    </center>
                </td>
                <td style="width: 33%; height: 63px;">
                    <center>
                        <asp:DropDownList ID="lstOpcion" runat="server">
                            <asp:ListItem Value="A">AGREGAR</asp:ListItem>
                            <asp:ListItem Value="M">MODIFICAR</asp:ListItem>
                            <asp:ListItem Value="E">ELIMINAR</asp:ListItem>
                        </asp:DropDownList></center>
                </td>
                <td style="width: 33%; height: 63px;">
                    <center>
                        <asp:ImageButton ID="imgbtnSiguiente" runat="server" ImageUrl="~/imagenes/jpg/adelante.jpg"
                            OnClick="imgbtnSiguiente_Click" Width="40px" /></center>
                </td>
            </tr>
        </table>
    </div>
    <!-- Final de el contenido de la pagina -->
</asp:Content>
