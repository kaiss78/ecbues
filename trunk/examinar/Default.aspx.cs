using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class examen : System.Web.UI.Page
{
    string materia;
    int npregs;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Hashtable respuestas = new Hashtable();
            List<int> preguntas = new List<int>();
            Session.Add("respuestas", respuestas);
            Session.Add("preguntas", preguntas);            
            Session["SelectedPregCode"] = 0;
        }
        materia = this.Request.Params.Get("subject");
        npregs = Int32.Parse((this.Request.Params.Get("n")));
        switch (materia)
        {
            case "all":
                for (int i = 0; i < 4; i++)
                    this.MostrarPregunta1.Materias.Add(i);
                break;
            case "scie":
                this.MostrarPregunta1.Materias.Add(1);
                break;
            case "math":
                this.MostrarPregunta1.Materias.Add(0);
                break;
            case "soc":
                this.MostrarPregunta1.Materias.Add(3);
                break;
            case "lang":
                this.MostrarPregunta1.Materias.Add(2);
                break;
        }
        this.MostrarPregunta1.MaxnPreg = npregs;
        this.MostrarPregunta1.CargarTablas();
        if (!this.IsPostBack)
        {
            this.MostrarPregunta1.CargarPreguntas();
            if (((List<int>)Session["preguntas"]).Count > 0)
                this.MostrarPregunta1.siguientePregunta();
        }
    }
    protected void btnSiguiente_Click(object sender, EventArgs e)
    {
        bool condicion = (((Hashtable)Session["respuestas"]).Count < this.MostrarPregunta1.MaxnPreg-1)
            && (((Hashtable)Session["respuestas"]).Count < (((Hashtable)Session["respuestas"]).Count + ((List<int>)Session["preguntas"]).Count)-1);        
        ((Hashtable)Session["respuestas"]).Add(this.MostrarPregunta1.SelectedPregCode, this.MostrarPregunta1.SelectedOpc);
        ((List<int>)Session["preguntas"]).Remove(this.MostrarPregunta1.SelectedPregCode);
        if (!condicion)
            Response.Redirect("resultados.aspx");
        try
        {
            this.MostrarPregunta1.siguientePregunta();            
        }
        catch(Exception ex)
        { condicion = false; }
        this.MostrarPregunta1.UnSelect();
        
            this.btnSiguiente.PostBackUrl = "Default.aspx?subject="+materia+"&n="+npregs;
            this.MostrarPregunta1.MostrarPregunta();
            this.MostrarPregunta1.MostrarOpciones();            
    }
}
