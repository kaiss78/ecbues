using System;
using System.Data;
using System.Configuration;
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
        //if (lgnValidar.LoginText == "Logout")
        //{
        //    Response.Redirect("administrar/default.aspx");
        //}
        //if (lgnMain.Visible == false)
        //{
        //    Response.Redirect("administrar/default.aspx");
        //}
    }

    protected void lgnMain_LoggedIn(object sender, EventArgs e)
    {
        
    }

    protected void lgnMain_Authenticate(object sender, AuthenticateEventArgs e)
    {
        
    }
}
