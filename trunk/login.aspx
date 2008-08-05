<%@ Page Language="C#" MasterPageFile="~/ecbues.main.master" AutoEventWireup="true" CodeFile="login.aspx.cs"
    Inherits="_Default" %>

<asp:Content runat="server" ContentPlaceHolderID="contenido" ID="contLogin">
    <div id="core_right">
        <div class="content-box">
            <h3>Validación de Acceso</h3>
            <table style="width: 100%">
                <tr>
                    <td style="height: 140px">
                        <img src="imagenes/jpg/servir.jpg" alt="" height="128" /></td>
                    <td style="height: 140px">
                        <center>
                            <asp:Login ID="lgnIngresar" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4"
                                BorderStyle="Solid" BorderWidth="1px" DestinationPageUrl="~/default.aspx" FailureText="Login Fallido. Intentelo de nuevo."
                                Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" LoginButtonText="Ingresar"
                                PasswordLabelText="Contraseña" PasswordRequiredErrorMessage="Contraseña Requerida"
                                RememberMeText="Recordarme la proxima vez" TitleText="Ingresar" UserNameLabelText="Nombre de Usuario"
                                UserNameRequiredErrorMessage="Nombre de Usuario Requerido" VisibleWhenLoggedIn="False">
                                <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                                <TextBoxStyle Font-Size="0.8em" />
                                <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px"
                                    Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                            </asp:Login>
                            &nbsp;</center>
                        <center>
                            <a href="registrar/registrarse.aspx" title="">Registrate</a></center>
                    </td>
                    <td style="height: 140px">
                        <img src="imagenes/jpg/seguro.jpg" alt="" height="128" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
