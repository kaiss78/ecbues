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

public partial class administrar_modificar3 : System.Web.UI.Page
{
    SqlConnection sqlCon = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\bd_ecbues.mdf;Integrated Security=True;User Instance=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        //int parm;
        //parm = Int32.Parse(Request.QueryString[0]);
        //string strCon = "";
        //try
        //{
        //    strCon = "SELECT [pregunta] FROM tb_preguntas WHERE (id_preguntas = " + parm + ");";
        //    SqlCommand comCon = new SqlCommand(strCon, sqlCon);
        //    if (comCon.Connection.State == ConnectionState.Closed)
        //    {
        //        comCon.Connection.Open();
        //    }
        //    comCon.ExecuteNonQuery();
        //}

        //catch (Exception ex)
        //{
        //   txtmpregunta.Text = "Ocurrio un error: " + ex.Message;
        //}
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("modificar2.aspx");
    }
    protected void btnmodificar_Click(object sender, EventArgs e)
    {
        
    }
    protected void imgbtnSiguiente_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("modificar2.aspx");
    }
}
