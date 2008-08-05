using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class controles_Pregunta : System.Web.UI.UserControl
{
    private int _nPreg;
    private DataSet _ds;
    private bool _isRandom;
    private int _maxnpreg;
    private List<int> _materias;

    #region Propiedades

    public int nPreg
    {
        get { return this._nPreg; }
    }

    public bool IsRandom
    {
        get { return this._isRandom; }
        set { this._isRandom = value; }
    }

    public int SelectedOpc
    {
        get
        {
            try
            {
                return int.Parse(((Label)this.FindControl("lblOpt" + (this.rbtnOpt.SelectedIndex + 1).ToString())).ToolTip);
            }
            catch(Exception ex)
            { return -1; }
        }
    }

    public int SelectedPregCode
    {
        get
        {
            try
            {
                return (int)Session["SelectedPregCode"];
            }
            catch (NullReferenceException nex)
            { return -1; }
        }
    }

    public int MaxnPreg
    {
        get { return this._maxnpreg; }
        set { this._maxnpreg = value; }
    }

    public List<int> Materias
    {
        get { return this._materias; }
        set { this._materias = value; }
    }

    #endregion

    #region Metodos

    public controles_Pregunta()
    {
        this.Materias = new List<int>();
    }

    //Elimina todas las imagenes generadas en la carpeta temporal que servian para mostrarlas en la pagina web
    private void EliminarTemp()
    {
        //Si la pagina no ha viajado al servidor...
        if (!this.IsPostBack)
        {
            //Obtenemos todos los archivos de ese directorio
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Temp/"));
            FileInfo[] fi = di.GetFiles();
            //Despues de obtenerlos, los borramos
            foreach (FileInfo f in fi)
            {
                f.Delete();
            }
        }
    }

    //Pasa a visible = false todos los controles
    private void EsconderTodo()
    {        
        this.lblOpt1.Visible = false;
        this.lblOpt2.Visible = false;
        this.lblOpt3.Visible = false;
        this.lblOpt4.Visible = false;
        this.lblPregunta.Visible = false;
        this.imgOpt1.Visible = false;
        this.imgOpt2.Visible = false;
        this.imgOpt3.Visible = false;
        this.imgOpt4.Visible = false;
        this.imgPregunta.Visible = false;
        this.lblOpcionesTitulo.Visible = false;
        this.rbtnOpt.Visible = false;
        this.lblPreguntaTitulo.Visible = false;
        this.lblConteo.Visible = false;        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.EliminarTemp();
        this.CargarTablas();
        this.EsconderTodo();
        if (((List<int>)Session["preguntas"]).Count == 0)
            this.MostrarNoHayPreguntas();
        else
        {
            this.MostrarPregunta();
            this.MostrarOpciones();
        }
    }

    public void CargarPreguntas()
    {
        ((List<int>)Session["preguntas"]).Clear();
        if(this._ds == null)
            this.CargarTablas();
        foreach (DataRow fila in this._ds.Tables["preguntas"].Rows)
            ((List<int>)Session["preguntas"]).Add((int)fila["id_preguntas"]);
    }

    /// <summary>
    /// Rellena todos los objetos dataTable con todos los valores de las tablas correspondientes
    /// </summary>
    public void CargarTablas()
    {
        string sqlQuery = "SELECT * FROM tb_preguntas";
        if (this.Materias.Count > 0)
            sqlQuery += " where fk_id_materia= " + this.Materias[0];
        for (int i = 1; i < this.Materias.Count; i++)
            sqlQuery += " or fk_id_materia= " + this.Materias[i];
        this._ds = new DataSet("dataset1");
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter(new SqlCommand(sqlQuery, cn));
        if (cn.State == ConnectionState.Closed)
            cn.Open();
        da.Fill(this._ds, "preguntas");
        da.SelectCommand = new SqlCommand("SELECT * FROM tb_opcion", cn);
        da.Fill(this._ds, "opciones");
        da.SelectCommand = new SqlCommand("SELECT * FROM tb_imagen", cn);
        da.Fill(this._ds, "imagenes");
        cn.Close();
    }

    /// <summary>
    /// Devuelve el subindice aleatorio correspondiente con una fila de la tabla preguntas y lo asigna al nPreg
    /// </summary>
    /// <returns></returns>
    public int siguientePregunta()
    {   //Si el dataset esta vacio, lo relleno
        if(this._ds == null)
            this.CargarTablas();
        //Creo un objeto random para devolver valores aleatorios
        Random rnd = new Random();
        try
        {   //Me devuelve un valor aleatorio entre cero y el numero de preguntas restantes que faltan de contestar
            int cual = rnd.Next(0, ((List<int>)Session["preguntas"]).Count); //antes count-1
            //En esta variable de sesion guardo el codigo de la pregunta seleccionada, tomada de la variable de sesion de preguntas
            Session["SelectedPregCode"] = ((List<int>)Session["preguntas"])[cual];
            //cual es el subindice de la pregunta seleccionada en mi variable de sesion preguntas donde esta las preguntas faltantes a responder
            //pero necesito saber donde esta esta pregunta(cual es su subindice) en mi arreglo de filas de la tabla preguntas
            //lo obtengo con el siguiente metodo
            this._nPreg = CualFilaEs((int)Session["SelectedPregCode"]);
        }
        catch (ArgumentOutOfRangeException iex)  //antes IndexOutOfRanteException
        { 
            this._nPreg = 0;
            Session["SelectedPregCode"] = this._ds.Tables["preguntas"].Rows[nPreg]["id_preguntas"];
        }
        //En que pregunta voy? lo se contando cuantas respuestas tengo en mi variable de sesion
        //Cuantas preguntas son? son ya sea, las preguntas que faltan contestar(session[preguntas]) mas las respuestas contestadas(session[respuestas])
        //o lo que me pusieron en la propiedad MaxNpreg, el minimo de estos dos
        this.lblConteo.Text = "Pregunta " + (((Hashtable)Session["respuestas"]).Count + 1).ToString() + " de "
            + Math.Min(((List<int>)Session["preguntas"]).Count + ((Hashtable)Session["respuestas"]).Count,this.MaxnPreg).ToString();
        //Retorna el subindice de la pregunta selecionada asociada con las filas de la tabla pregunas
        return nPreg;
    }

    private int CualFilaEs(int codPreg)
    {
        if (this._ds != null)
        {
            for (int i = 0; i < this._ds.Tables["preguntas"].Rows.Count; i++)
                if ((int)this._ds.Tables["preguntas"].Rows[i]["id_preguntas"] == codPreg)
                    return i;
        }
        return 0;
    }

    /// <summary>
    /// Muestra en su correspondiente Label el texto de la pregunta o su imagen
    /// </summary>
    public void MostrarPregunta()
    {
        this.lblPregunta.Text = (string)this._ds.Tables["preguntas"].Rows[this.nPreg]["pregunta"];
        //Muestro el <label>
        this.lblPregunta.Visible = true;
        this.lblConteo.Visible = true;
        this.lblOpcionesTitulo.Visible = true;
        this.lblPreguntaTitulo.Visible = true;
        this.rbtnOpt.Visible = true;
        //Si posee algo en su campo fk_id_img, es una imagen. Se muestra.
        if (!(this._ds.Tables["preguntas"].Rows[this.nPreg]["fk_id_img"] is System.DBNull))
        {
            string rutaImg = "";
            //Buscamos el registro de la tabla imagenes que coincida con el del codigo que tenemos
            for (int i = 0; i < this._ds.Tables["imagenes"].Rows.Count; i++)
            {
                //Cuando lo hayamos, creamos el archivo temporal en disco y obtenemos su ruta atraves de GetImg()
                if ((int)this._ds.Tables["imagenes"].Rows[i]["id_imagen"] == (int)this._ds.Tables["preguntas"].Rows[this.nPreg]["fk_id_img"])
                { rutaImg = this.GetImg(i); break; }
            }
            //Si la ruta existe (o sea si encontro un registro asociado en la tabla imagenes) se le asigna al control image
            if (rutaImg != "")
            {
                this.imgPregunta.ImageUrl = rutaImg;
                this.imgPregunta.Height = 100;
                this.imgPregunta.Width = 100;
            }
            //Muestro el <image>
            this.imgPregunta.Visible = true;
        }

    }

    public void MostrarNoHayPreguntas()
    {
        this.lblConteo.Text = "No hay preguntas a mostrar";
    }

    public void MostrarOpciones()
    {
        int counter = 0;
        //Busco los registros en la tabla opciones que coincidan con la pregunta seleccionada
        foreach (DataRow fila in this._ds.Tables["opciones"].Rows)
        {
            //Cuando los encuentro...
            if ((int)this._ds.Tables["preguntas"].Rows[nPreg]["id_preguntas"] == (int)fila["fk_id_prg"])
            {
                //El contador me sirve para saber a cuales de mis controles [radio,label,image] les asigno el valor encontrado
                //counter me sirve para saber cual opcion he encontrado[1,2,3 o 4]
                counter++;
                //Muestro cada una de las opciones
                this.MostrarOpcion(fila, counter);
            }
        }
    }

    /// <summary>
    /// Muestra una opcion en la fila de controles [option,label,img]
    /// </summary>
    /// <param name="fila">el objeto DataRow que contiene los datos de la opcion</param>
    /// <param name="Counter">El numero de la opcion [1,2,3 o 4]</param>
    private void MostrarOpcion(DataRow fila, int Counter)
    {
        ((Label)this.FindControl("lblOpt" + Counter.ToString())).Text = (string)fila["descripcion"];
        ((Label)this.FindControl("lblOpt" + Counter.ToString())).ToolTip = ((int)fila["id_opcion"]).ToString();
        ((Label)this.FindControl("lblOpt" + Counter.ToString())).Visible = true;
        if (!(fila["fk_id_img"] is System.DBNull))
        {
            string rutaImg = "";
            for (int i = 0; i < this._ds.Tables["opciones"].Rows.Count; i++)
            {
                if ((int)fila["fk_id_img"] == (int)this._ds.Tables["imagenes"].Rows[i]["id_imagen"])
                { rutaImg = this.GetImg(i); break; }
            }
            if (rutaImg != "")
            {
                ((Image)this.FindControl("imgOpt" + Counter.ToString())).ImageUrl = rutaImg;
                ((Image)this.FindControl("imgOpt" + Counter.ToString())).Visible = true;
            }
        }
    }


    /// <summary>
    /// Devuelve la ruta de una imagen temporal creada en base al regisro de la tabla imagenes
    /// </summary>
    /// <param name="cual">El subindice del registro de la tabla imagenes</param>
    /// <returns>La ruta del archivo creado</returns>
    private string GetImg(int cual)
    {
        byte[] file = (byte[])this._ds.Tables["imagenes"].Rows[cual]["imagen"];
        string rutaCompleta = Server.MapPath("~/Temp/") + "img" + System.DateTime.Now.Millisecond.ToString().ToLower() + ".jpg"; //lindo el detalle del tiempo NO?
        FileStream archivo = new FileStream(rutaCompleta, FileMode.Create);
        archivo.Write(file, 0, file.Length);
        archivo.Close();
        return rutaCompleta;
    }

    public void UnSelect()
    {
        this.rbtnOpt.SelectedIndex = -1;
    }

    #endregion
}