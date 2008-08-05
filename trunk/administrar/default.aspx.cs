using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class administrar_default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] strRol = ((RolePrincipal)User).GetRoles();
        //string strRol = Roles.GetAllRoles()[0];
        Session.Add("rol", strRol[0].ToString().ToLower());
        string strRol2 = (string)Session["rol"];
        if (strRol2 != "administrador")
        {
            this.lstMateria.Enabled = false;
            lblAvisoMateria.Text = "Usted solo puede manipular preguntas de " + strRol2 + ".";
        }
        else
        { 
            lblAvisoMateria.Text = "Usted puede manipular TODAS las materias.";
        } 
    }

    protected void imgbtnSiguiente_Click(object sender, ImageClickEventArgs e)
    {
        string codigoMateria = "";
        string cadenita = (string)Session["rol"];
        switch (cadenita)
        {
            case "matematicas": codigoMateria = "0"; break;
            case "naturales": codigoMateria = "1"; break;
            case "literatura": codigoMateria = "2"; break;
            case "sociales": codigoMateria = "3"; break;
        }
        if (this.lstOpcion.Text == "A")
        {
            if (lstMateria.Enabled)
            {
                Session.Add("materia", this.lstMateria.Text);
            }
            else
            {
                Session.Add("materia", codigoMateria);
            }
            Session.Add("modalidad", "agregar");
            Response.Redirect("alterar.aspx");
        }
        if (this.lstOpcion.Text == "M")
        {
            if (lstMateria.Enabled)
            {
                Session.Add("materia", this.lstMateria.Text);
            }
            else
            {
                Session.Add("materia", codigoMateria);
            }
            Session.Add("modalidad", "modificar");
            Response.Redirect("modificar2.aspx");
        }
        if (this.lstOpcion.Text == "E")
        {
            if (lstMateria.Enabled)
            {
                Session.Add("materia", this.lstMateria.Text);
            }
            else
            {
                Session.Add("materia", codigoMateria);
            }
            Session.Add("modalidad", "eliminar");
            Response.Redirect("eliminar2.aspx");
        }
        
    }
}
