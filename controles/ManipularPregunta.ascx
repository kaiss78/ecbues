<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ManipularPregunta.ascx.cs"
    Inherits="controles_agregapregunta" %>
<table>
    <tr>
        <td>
        <center>
            <asp:Label ID="lblAviso" runat="server" Text="[ AVISO ]" Font-Bold="True" ForeColor="Blue"></asp:Label></center>
            <table style="width: 100%">
                <tr>
                    <td>
                        Pregunta:</td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="validar_pregunta" runat="server" ErrorMessage="Debe introducir una pregunta" ControlToValidate="txtPregunta" Display="Static"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPregunta" runat="server" Height="70px" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
                </tr>
            </table>
            <br />
            <table style="width: 100%; height: 55%">
                <tr>
                    <td>
                        Respuestas:</td>
                </tr>
                <tr>
                    <td style="width: 75%; height: 100%">
                        <table>
                            <tr>
                                <td style="width: 16px; height: 14px">
                                </td>
                                <td style="width: 60px; height: 14px">
                                    Opción:</td>
                                <td align="center" style="width: 76px; height: 14px">
                                    Usar imagen:</td>
                                <td style="width: 207px; height: 14px">
                                    Subir imagen:</td>
                                <td align="center" style="width: 20px; height: 14px">
                                    Vista previa:</td>
                            </tr>
                            <tr>
                                <td style="width: 16px; height: 19px">
                                    1</td>
                                <td style="width: 60px; height: 19px">
                                    <asp:TextBox ID="txt1" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validador_opcion1" runat="server" ErrorMessage="Introduzca la opcion 1"  ControlToValidate="txt1"  Display="Static" Width="153px"></asp:RequiredFieldValidator></td>
                                <td align="center" style="width: 76px; height: 19px">
                                    <asp:CheckBox ID="chk1" runat="server" AutoPostBack="True" OnCheckedChanged="chk1_CheckedChanged" /></td>
                                <td style="width: 207px; height: 19px">
                                    <center>
                                        <asp:Label ID="lblaviso1" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
                                        <asp:FileUpload ID="fup1" runat="server" Enabled="False" />
                                    </center>
                                </td>
                                <td align="center" style="width: 20px; height: 19px">
                                    <center>
                                        <asp:Image ID="img1" runat="server" /><br />
                                        <asp:Button ID="btnVP1" runat="server" OnClick="btnVP1_Click" Text="Vista Previa"
                                            Width="80px" Enabled="False" /></center>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 16px">
                                    2</td>
                                <td style="width: 60px">
                                    <asp:TextBox ID="txt2" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validador_opcion2" runat="server" ErrorMessage="Introduzca la opcion 2" ControlToValidate="txt2" Display="Static" Width="153px"></asp:RequiredFieldValidator></td>
                                <td align="center" style="width: 76px">
                                    <asp:CheckBox ID="chk2" runat="server" AutoPostBack="True" OnCheckedChanged="chk2_CheckedChanged" /></td>
                                <td style="width: 207px">
                                    <center>
                                        <asp:Label ID="lblaviso2" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
                                        <asp:FileUpload ID="fup2" runat="server" Enabled="False" />
                                    </center>
                                </td>
                                <td align="center" style="width: 20px">
                                    <center>
                                        <asp:Image ID="img2" runat="server" />
                                        <asp:Button ID="btnVP2" runat="server" OnClick="btnVP2_Click" Text="Vista Previa"
                                            Width="80px" Enabled="False" /></center>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 16px">
                                    3</td>
                                <td style="width: 60px">
                                    <asp:TextBox ID="txt3" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validador_opcion3" ControlToValidate="txt3" runat="server" ErrorMessage="Introduzca la opcion 3" Display="Static" Width="151px"></asp:RequiredFieldValidator></td>
                                <td align="center" style="width: 76px">
                                    <asp:CheckBox ID="chk3" runat="server" AutoPostBack="True" OnCheckedChanged="chk3_CheckedChanged" /></td>
                                <td style="width: 207px">
                                    <center>
                                        <asp:Label ID="lblaviso3" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
                                        <asp:FileUpload ID="fup3" runat="server" Enabled="False" />
                                    </center>
                                </td>
                                <td align="center" style="width: 20px">
                                    <center>
                                        <asp:Image ID="img3" runat="server" />
                                        <asp:Button ID="btnVP3" runat="server" OnClick="btnVP3_Click" Text="Vista Previa"
                                            Width="80px" Enabled="False" />
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 16px">
                                    4</td>
                                <td style="width: 60px">
                                    <asp:TextBox ID="txt4" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validador_opcion4" ControlToValidate="txt4" runat="server" ErrorMessage="Introduzca la opcion 4" Display="Static" Width="152px"></asp:RequiredFieldValidator></td>
                                <td align="center" style="width: 76px">
                                    <asp:CheckBox ID="chk4" runat="server" AutoPostBack="True" OnCheckedChanged="chk4_CheckedChanged" /></td>
                                <td style="width: 207px">
                                    <center>
                                        <asp:Label ID="lblaviso4" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
                                        <asp:FileUpload ID="fup4" runat="server" Enabled="False" /></center>
                                </td>
                                <td align="center" style="width: 20px">
                                    <asp:Image ID="img4" runat="server" />
                                    <asp:Button ID="btnVP4" runat="server" OnClick="btnVP4_Click" Text="Vista Previa"
                                        Width="80px" Enabled="False" /></td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 25%; height: 100%">
                        <br />
                        Opci&#243;n correcta:<br />
                        <asp:RadioButtonList ID="rbntlRespuesta" runat="server" Width="100%">
                            <asp:ListItem Value="1">Opci&#243;n 1</asp:ListItem>
                            <asp:ListItem Value="2">Opci&#243;n 2</asp:ListItem>
                            <asp:ListItem Value="3">Opci&#243;n 3</asp:ListItem>
                            <asp:ListItem Value="4">Opci&#243;n 4</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="validar_radio" runat="server"  ControlToValidate="rbntlRespuesta" ErrorMessage="Debe elegir una opción" Display="static" Height="23px" Width="127px"></asp:RequiredFieldValidator></td>
                </tr>
            </table>
            <asp:ImageButton ID="imgbtnAgregar" runat="server" Height="72px" ImageAlign="Right"
                ImageUrl="~/imagenes/jpg/ira.jpg" OnClick="imgbtnAgregar_Click" /></td>
    </tr>
</table>
