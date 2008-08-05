using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Registrarse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblRol.Visible = true;
        ddlRol.Visible = true;
    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        Roles.AddUserToRole(cuwRegistrar.UserName, ddlRol.SelectedValue);
        lblRol.Visible = false;
        ddlRol.Visible = false;
    }
}
