<%@ Page Language="C#" MasterPageFile="ecbues.main.master" AutoEventWireup="true" CodeFile="registrarse.aspx.cs" Inherits="Registrarse" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
<center>
    &nbsp;<asp:CreateUserWizard ID="cuwRegistrar" runat="server" AnswerLabelText="Respuesta de Seguridad:"
            AnswerRequiredErrorMessage="Respuesta de Seguridad requerida" BackColor="#F7F6F3"
            BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" CancelButtonText="Cancelar"
            CompleteSuccessText="La cuenta ha sido creada satisfactoriamente" ConfirmPasswordCompareErrorMessage="La contraseña y Confirmar Contraseña deben coincidir"
            ConfirmPasswordLabelText="Confirmar Contraseña:" ConfirmPasswordRequiredErrorMessage="Confirmar Contraseña es requerida"
            ContinueButtonText="Continuar" CreateUserButtonText="Crear Usuario" DuplicateEmailErrorMessage="La dirección de e-mail ya está en uso. Por favor, intente con una dirección diferente"
            DuplicateUserNameErrorMessage="Por favor, ingrese un nombre de usuario diferente"
            EmailRegularExpressionErrorMessage="Por favor ingrese una dirección de e-mail diferente"
            EmailRequiredErrorMessage="E-mail es requerido." FinishCompleteButtonText="Finalizar"
            FinishPreviousButtonText="Atrás" Font-Names="Verdana" Font-Size="0.8em" InvalidAnswerErrorMessage="Por favor ingrese una respuesta de seguridad diferente"
            InvalidEmailErrorMessage="Por favor ingrese una dirección de e-mail válida" InvalidPasswordErrorMessage="Tamaño mínimo de la contraseña: {0}. caracteres no-alfanumericos requeridos: {1}."
            InvalidQuestionErrorMessage="Por favor ingrese una pregunta de seguridad diferente"
            PasswordLabelText="Contraseña:" PasswordRegularExpressionErrorMessage="Por favor ingrese una contraseña diferente."
            PasswordRequiredErrorMessage="Contraseña es requerida." QuestionLabelText="Pregunta de Seguridad:"
            QuestionRequiredErrorMessage="Pregunta de Seguridad es requerida" StartNextButtonText="Siguiente"
            StepNextButtonText="Siguiente:" StepPreviousButtonText="Atrás" UnknownErrorMessage="La cuenta no fue creada. Por favor inténtelo de nuevo"
            UserNameLabelText="Nombre de Usuario:" UserNameRequiredErrorMessage="Nombre de Usuario es requerido." OnCreatedUser="CreateUserWizard1_CreatedUser" CancelDestinationPageUrl="~/default.aspx" ContinueDestinationPageUrl="~/default.aspx">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                    <ContentTemplate>
                        <table border="0" style="font-size: 100%; font-family: Verdana">
                            <tr>
                                <td align="center" colspan="2" style="font-weight: bold; color: white; background-color: #5d7b9d; height: 28px;">
                                    Registrar una nueva cuenta</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de Usuario:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="Nombre de Usuario es requerido." ToolTip="Nombre de Usuario es requerido."
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="Contraseña es requerida." ToolTip="Contraseña es requerida." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirmar Contraseña:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                        ErrorMessage="Confirmar Contraseña es requerida" ToolTip="Confirmar Contraseña es requerida"
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                        ErrorMessage="E-mail es requerido." ToolTip="E-mail es requerido." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Pregunta de Seguridad:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                        ErrorMessage="Pregunta de Seguridad es requerida" ToolTip="Pregunta de Seguridad es requerida"
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 26px">
                                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Respuesta de Seguridad:</asp:Label></td>
                                <td style="height: 26px">
                                    <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                        ErrorMessage="Respuesta de Seguridad requerida" ToolTip="Respuesta de Seguridad requerida"
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="La contraseña y Confirmar Contraseña deben coincidir"
                                        ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: red">
                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                    <ContentTemplate>
                        <table border="0" style="font-size: 100%; font-family: Verdana">
                            <tr>
                                <td align="center" colspan="2" style="font-weight: bold; color: white; background-color: #5d7b9d">
                                    Completado</td>
                            </tr>
                            <tr>
                                <td>
                                    La cuenta ha sido creada satisfactoriamente</td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button ID="ContinueButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC"
                                        BorderStyle="Solid" BorderWidth="1px" CausesValidation="False" CommandName="Continue"
                                        Font-Names="Verdana" ForeColor="#284775" Text="Continuar" ValidationGroup="CreateUserWizard1" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CompleteWizardStep>
            </WizardSteps>
            <SideBarStyle BackColor="#5D7B9D" BorderWidth="0px" Font-Size="0.9em" VerticalAlign="Top" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
            <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
            <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em"
                ForeColor="White" HorizontalAlign="Center" />
            <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
            <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
            <StepStyle BorderWidth="0px" />
        </asp:CreateUserWizard>
    
        <asp:Label ID="lblRol" runat="server" Style="left: -79px; position: relative; top: -57px"
            Text="Elegir Rol:"></asp:Label>
        <asp:DropDownList ID="ddlRol" runat="server" Style="left: -148px; position: relative;
            top: -30px">
            <asp:ListItem Selected="True">Administrador</asp:ListItem>
            <asp:ListItem>Matematicas</asp:ListItem>
            <asp:ListItem>Literatura</asp:ListItem>
            <asp:ListItem>Naturales</asp:ListItem>
            <asp:ListItem>Sociales</asp:ListItem>
        </asp:DropDownList>
        </center>
</asp:Content>

