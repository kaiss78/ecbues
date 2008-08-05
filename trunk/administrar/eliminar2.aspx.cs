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

using System.Data.SqlClient;

public partial class administrar_modificar2 : System.Web.UI.Page
{
    public void Page_Load(Object sender, EventArgs e)
    {
    }

    protected void imgbtnSiguiente_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("default.aspx");
    }
}
