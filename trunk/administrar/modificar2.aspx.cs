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

public partial class administrar_modificar2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void grdPreguntas_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strParametro = grdPreguntas.SelectedRow.Cells[1].Text;
        Session.Add("idpregunta", strParametro);
        Response.Redirect("modificar3.aspx");// al hacer click en el botón seleccionar me redirecciona a la pagina modificar3
    }
    protected void imgbtnSiguiente_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("default.aspx");
    }
}
