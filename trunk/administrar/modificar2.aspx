<%@ Page Language="C#" MasterPageFile="~/administrar/ecbues.admin.master" AutoEventWireup="true" CodeFile="modificar2.aspx.cs" Inherits="administrar_modificar2" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <asp:ImageButton ID="imgbtnRegresar" runat="server" ImageUrl="~/imagenes/jpg/atras.jpg"
        OnClick="imgbtnSiguiente_Click" Width="40px" />
        <h2>Selecciona la pregunta a modificar...</h2>
    <asp:GridView ID="grdPreguntas" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
        DataKeyNames="id_preguntas" DataSourceID="SqPregunta" Width="753px" Font-Names="Verdana" 
        Font-Size="Small" CellPadding="4" GridLines="None" Height="214px" OnSelectedIndexChanged="grdPreguntas_SelectedIndexChanged" ForeColor="#333333" PageSize="5" EmptyDataText="Al parecer no hay registros asociados con esta materia...">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Seleccionar" HeaderText="Seleccionar..."/>
            <asp:BoundField DataField="id_preguntas" HeaderText="id_preguntas" ReadOnly="True"
                SortExpression="id_preguntas" />
            <asp:BoundField DataField="pregunta" HeaderText="Pregunta" SortExpression="pregunta" />
        </Columns>
        <RowStyle BorderColor="Black" BorderStyle="Double" BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BorderColor="Black" BorderStyle="Double" BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" BorderColor="Transparent" BorderStyle="Double" ForeColor="#284775" />
        <HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <SelectedRowStyle Wrap="True" BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <EmptyDataRowStyle Font-Bold="True" Font-Size="Large" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqPregunta" runat="server" ConnectionString="<%$ ConnectionStrings:cadenaConeccion %>"
        SelectCommand="SELECT [id_preguntas], [pregunta] FROM [tb_preguntas] WHERE ([fk_id_materia] = @fk_id_materia)">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="fk_id_materia" SessionField="materia"
                Type="Byte"/> 
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

