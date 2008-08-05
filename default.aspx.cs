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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void lgnMain_LoggedIn(object sender, EventArgs e)
    {
        Response.Redirect("privado/Default.aspx");
    }
    protected void ImageAll_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("examinar/default.aspx?subject=all&n=25");
    }
    protected void ImageCiencias_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("examinar/default.aspx?subject=scie&n=100");
    }
    protected void imgMatematicas_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("examinar/default.aspx?subject=math&n=100");
    }
    protected void imgSociales_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("examinar/default.aspx?subject=soc&n=100");
    }
    protected void imgLenguaje_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("examinar/default.aspx?subject=lang&n=100");
    }
}