<%@ Page Language="C#" MasterPageFile="~/administrar/ecbues.admin.master" AutoEventWireup="true"
    CodeFile="eliminar2.aspx.cs" Inherits="administrar_modificar2" Title="Eliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="Server">
<%--<script language="javascript">
<!--

   function ondeleteclick()
   {
        return confirm("¿Esta seguro que desea eliminar esa pregunta?")
   }
 
   for(i=0;i<document.all.length;i++)
   {
       var x = document.all.item(i)
       if(x!=null && x.name !=null &&  x.name.indexOf("grdPreguntas")==0)
       {
           if(x.value=="Eliminar")
                x.onclick = ondeleteclick
           continue;
      }
 }
//-->
</script>--%>
    <asp:ImageButton ID="imgbtnRegresar" runat="server" ImageUrl="~/imagenes/jpg/atras.jpg"
        OnClick="imgbtnSiguiente_Click" Width="40px" />
        <h2>Eliminar...</h2>
        Advertencia: al hacer click en el boton eliminar se borra <strong>INMEDIATAMENTE </strong> la pregunta.<br />
        Tenga el cuidado de estar seguro de que pregunta eliminar.<br />
        Los cambios realizados no son recuperables.<br />
    <asp:GridView ID="grdView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="id_preguntas" DataSourceID="SqlDS1" CellPadding="4" ForeColor="#333333" GridLines="None" Width="752px" PageSize="5" Font-Names="Verdana" Font-Size="Small" EmptyDataText="Al parecer no hay registros asociados con esta materia..." Height="220px">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" HeaderText="Eliminar Pregunta" DeleteText="Eliminar" ButtonType="Button" />
            <asp:BoundField DataField="id_preguntas" HeaderText="Preguntas" ReadOnly="True"
                SortExpression="id_preguntas" />
            <asp:BoundField DataField="fk_id_materia" HeaderText="Materia" SortExpression="fk_id_materia" />
            <asp:BoundField DataField="pregunta" HeaderText="pregunta" SortExpression="pregunta" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EmptyDataRowStyle Font-Bold="True" Font-Size="Large" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDS1" runat="server" ConflictDetection="CompareAllValues"
        ConnectionString="<%$ ConnectionStrings:cadenaConeccion %>" 
        DeleteCommand="DELETE FROM tb_imagen FROM tb_imagen CROSS JOIN tb_opcion CROSS JOIN tb_preguntas WHERE(tb_imagen.id_imagen=tb_opcion.fk_id_img) AND (tb_preguntas.id_preguntas=tb_opcion.fk_id_prg);DELETE FROM [tb_preguntas] WHERE [id_preguntas] = @original_id_preguntas AND [fk_id_materia] = @original_fk_id_materia AND [pregunta] = @original_pregunta "
        InsertCommand="INSERT INTO [tb_preguntas] ([id_preguntas], [fk_id_materia], [pregunta]) VALUES (@id_preguntas, @fk_id_materia, @pregunta)"
        OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [id_preguntas], [fk_id_materia], [pregunta] FROM [tb_preguntas] WHERE ([fk_id_materia] = @fk_id_materia)"
        UpdateCommand="UPDATE [tb_preguntas] SET [fk_id_materia] = @fk_id_materia, [pregunta] = @pregunta WHERE [id_preguntas] = @original_id_preguntas AND [fk_id_materia] = @original_fk_id_materia AND [pregunta] = @original_pregunta">
        <DeleteParameters>
            <asp:Parameter Name="original_id_preguntas" Type="Int32" />
            <asp:Parameter Name="original_fk_id_materia" Type="Byte" />
            <asp:Parameter Name="original_pregunta" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="fk_id_materia" Type="Byte" />
            <asp:Parameter Name="pregunta" Type="String" />
            <asp:Parameter Name="original_id_preguntas" Type="Int32" />
            <asp:Parameter Name="original_fk_id_materia" Type="Byte" />
            <asp:Parameter Name="original_pregunta" Type="String" />
        </UpdateParameters>
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="fk_id_materia" SessionField="materia"
                Type="Byte" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="id_preguntas" Type="Int32" />
            <asp:Parameter Name="fk_id_materia" Type="Byte" />
            <asp:Parameter Name="pregunta" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>
