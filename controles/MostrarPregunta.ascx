<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MostrarPregunta.ascx.cs" Inherits="controles_Pregunta" %>

<table border="0" cellpadding="0" cellspacing="0" width="600px">
    <tr>
        <td valign="top" style="height: 42px">
            <asp:Label ID="lblPreguntaTitulo" runat="server" Text="Pregunta:" Font-Bold="True"></asp:Label>
        </td>
        <td valign="top" style="height: 42px">
        <table border="0" cellpadding="5" cellspacing="5" style="width: 536px">
        <tr><td bgcolor="#ffffff">
            <asp:Label ID="lblPregunta" runat="server" Text="Pregunta de ejemplo" Visible="False"></asp:Label>
            <br />
            <asp:Image ID="imgPregunta" runat="server" Visible="False" />
        </td></tr>
        </table>
        </td>
        </tr>
    <tr>
        <td valign="top">
            <asp:Label ID="lblOpcionesTitulo" runat="server" Text="Opciones:" Font-Bold="True"></asp:Label>
        </td>    
        <td valign="top">       
            <table border="0" cellpadding="2" cellspacing="5" style="width: 536px">
                <tr valign="middle">
                    <td rowspan="4" align="right" valign="middle">                    
                        <asp:RadioButtonList ID="rbtnOpt" runat="server" Height="396px">
                            <asp:ListItem Text="a)" />
                            <asp:ListItem Text="b)" />
                            <asp:ListItem Text="c)" />
                            <asp:ListItem Text="d)" />
                        </asp:RadioButtonList>
                    </td>
                    <td style="width: 323px; height: 60px;">
                        <asp:Label ID="lblOpt1" runat="server" Text="Label" Visible="False"></asp:Label>
                    </td>
                    <td style="height: 60px">
                        <asp:Image ID="imgOpt1" runat="server" Visible="False" />
                    </td>                    
                </tr>
                <tr valign="middle">
                    <td style="width: 323px; height: 60px;">
                        <asp:Label ID="lblOpt2" runat="server" Text="Label" Visible="False"></asp:Label>
                    </td>
                    <td style="height: 60px">
                        <asp:Image ID="imgOpt2" runat="server" Visible="False" />
                    </td>                    
                </tr>
                <tr valign="middle">
                    <td style="width: 323px; height: 60px;">
                        <asp:Label ID="lblOpt3" runat="server" Text="Label" Visible="False"></asp:Label>
                    </td>
                    <td style="height: 60px">
                        <asp:Image ID="imgOpt3" runat="server" Visible="False" />
                    </td>                    
                </tr>
                <tr valign="middle">
                    <td style="width: 323px; height: 60px;">
                        <asp:Label ID="lblOpt4" runat="server" Text="Label" Visible="False"></asp:Label>
                    </td>
                    <td style="height: 60px">
                        <asp:Image ID="imgOpt4" runat="server" Visible="False" />
                    </td>                    
                </tr>
            </table>
            <asp:Label ID="lblConteo" runat="server" Text="Pregunta 1 de ..." Font-Bold="False" Font-Italic="True"></asp:Label></td>
    </tr>
</table>

