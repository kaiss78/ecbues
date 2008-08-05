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

public partial class controles_agregapregunta : System.Web.UI.UserControl
{
    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
    string strModalidad = "";
    string strIdPregunta = "";
    private DataSet _ds;

    public void CargarPregunta()
    {
        string sqlQuery = "SELECT * FROM tb_preguntas WHERE (id_preguntas = '" + strIdPregunta + "');";
        this._ds = new DataSet("dataBD");
        SqlDataAdapter da = new SqlDataAdapter(new SqlCommand(sqlQuery, sqlCon));
        if (sqlCon.State == ConnectionState.Closed)
        {
            sqlCon.Open();
        }
        da.Fill(this._ds, "tbpregunta");
        da.SelectCommand = new SqlCommand("SELECT * FROM tb_opcion WHERE (fk_id_prg = '" + strIdPregunta + "');", sqlCon);
        da.Fill(this._ds, "tbopciones");
        da.SelectCommand = new SqlCommand("SELECT *  FROM tb_imagen INNER JOIN tb_opcion ON tb_imagen.id_imagen = tb_opcion.fk_id_img", sqlCon);
        da.Fill(this._ds, "tbimagenes");
        sqlCon.Close();
    }

    public void MostrarPregunta()
    {
        this.txtPregunta.Text = (string)this._ds.Tables["tbpregunta"].Rows[0]["pregunta"];
        //Si posee algo en su campo fk_id_img, es una imagen. Se muestra.
        //if (!(this._ds.Tables["tbpreguntas"].Rows[0]["fk_id_img"] is System.DBNull))
        //{
        //    string rutaImg = "";
        //    if ((int)this._ds.Tables["tbimagenes"].Rows[0]["id_imagen"] == (int)this._ds.Tables["preguntas"].Rows[0]["fk_id_img"])
        //    {
        //        rutaImg = this.GetImg(0);
        //    }
        //}
        //if (rutaImg != "")
        //{
        //    this.imgPregunta.ImageUrl = rutaImg;
        //    this.imgPregunta.Height = 100;
        //    this.imgPregunta.Width = 100;
        //}
        //this.imgPregunta.Visible = true;
    }

    public void MostrarOpciones()
    {
        int counter = 0;
        int r = (int)this._ds.Tables["tbpregunta"].Rows[0]["fk_opcion_correcta"];
        //Busco los registros en la tabla opciones que coincidan con la pregunta seleccionada

        foreach (DataRow fila in this._ds.Tables["tbopciones"].Rows)
        {
            if (r == (int)this._ds.Tables["tbopciones"].Rows[counter]["id_opcion"])
            {
                rbntlRespuesta.SelectedIndex = counter;
            }
            counter++;
            this.MostrarOpcion(fila, counter);
        }
    }

    private void MostrarOpcion(DataRow fila, int Counter)
    {
        ((TextBox)this.FindControl("txt" + Counter.ToString())).Text = (string)fila["descripcion"];
        //((Label)this.FindControl("txt" + Counter.ToString())).Visible = true;
        if (!(fila["fk_id_img"] is System.DBNull))
        {
            string rutaImg = "";
            for (int i = 0; i < this._ds.Tables["tbopciones"].Rows.Count; i++)
            {
                if ((int)fila["fk_id_img"] == (int)this._ds.Tables["tbimagenes"].Rows[i]["id_imagen"])
                {
                    rutaImg = this.GetImg(i);
                    ((CheckBox)this.FindControl("chk" + Counter.ToString())).Checked = true;
                    break;
                }
            }
            if (rutaImg != "")
            {
                ((Image)this.FindControl("img" + Counter.ToString())).ImageUrl = rutaImg;
                //((Image)this.FindControl("img" + Counter.ToString())).Height = 100;
                //((Image)this.FindControl("img" + Counter.ToString())).Width = 100;
                //((Image)this.FindControl("img" + Counter.ToString())).Visible = true;
            }

        }
        else
        {
            //string rutaImg = Server.MapPath("~/Temp/") + "noimagen.gif";
            //((Image)this.FindControl("img" + Counter.ToString())).ImageUrl = Server.MapPath("~/imagenes/") + "noimagen.gif";
            ((Image)this.FindControl("img" + Counter.ToString())).Visible = true;
            ((Button)this.FindControl("btnVP" + Counter.ToString())).Visible = false;
        }
    }

    private string GetImg(int cual)
    {
        byte[] file = (byte[])this._ds.Tables["tbimagenes"].Rows[cual]["imagen"];
        string rutaCompleta = Server.MapPath("~/Temp/") + "img" + System.DateTime.Now.Millisecond.ToString().ToLower() + ".jpg"; //lindo el detalle del tiempo NO?
        FileStream archivo = new FileStream(rutaCompleta, FileMode.Create);
        archivo.Write(file, 0, file.Length);
        archivo.Close();
        return rutaCompleta;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (lblAviso.Text == "[ AVISO ]")
        {
            lblAviso.Text = "";
        }
        //HACK
        strModalidad = (string)Session["modalidad"];
        strIdPregunta = (string)Session["idpregunta"];

        if (strModalidad == "modificar" && strIdPregunta != "")
        {
            this.CargarPregunta();
            this.MostrarPregunta();
            this.MostrarOpciones();
        }
        else
        {
            if (((string)Session["pregunta_agregada"]) == "si")
            {
                lblAviso.Text = "¡Pregunta ingresada exitosamente!";
                //no hay una manera mas elegante de hacer esto?
                txtPregunta.Text = "";
                txt1.Text = "";
                txt2.Text = "";
                txt3.Text = "";
                txt4.Text = "";
                chk1.Checked = false;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                this.rbntlRespuesta.ClearSelection();
                Session["pregunta_agregada"] = "no";
            }
            else
            {
                Session.Add("pregunta_agregada", "no");
                if (IsPostBack) //wow...
                {
                    VerificarEnLoad(this.fup1, this.lblaviso1);
                    VerificarEnLoad(this.fup2, this.lblaviso2);
                    VerificarEnLoad(this.fup3, this.lblaviso3);
                    VerificarEnLoad(this.fup4, this.lblaviso4);
                }
            }
        }
    }

    //Verifica si el archivo tiene una extension correcta...
    public Boolean VerificarFileUpload(FileUpload fupcontrol)
    {
        Boolean archivoBIEN = false;
        if (fupcontrol.HasFile) //Hay que hacer esto por CADA File Upload...
        {
            String extArchivo = System.IO.Path.GetExtension(fupcontrol.FileName).ToLower(); //GET EXTENSION YEAAAAH!
            if (extArchivo == ".jpg") { archivoBIEN = true; }
            //soporte para varios tipos de imagenes, que lastima... falta tiempo
            //String[] extPermitidas = { ".gif", ".png", ".jpeg", ".jpg" };
            //for (int i = 0; i < extPermitidas.Length; i++)
            //{
            //    if (extArchivo == extPermitidas[i])
            //    {
            //        archivoBIEN = true;
            //    }
            //}
        }
        return archivoBIEN;
    }

    public Boolean VerificarEnLoad(FileUpload fup, Label lbl)
    {
        if (VerificarFileUpload(fup))
        {
            //Esto es para la vista previa...
            //try
            //{
            //    fup.PostedFile.SaveAs(Server.MapPath("~/Temp/") + fup.FileName);
            //    lbl.Text = "¡Archivo subido con exito!";
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    lbl.Text = "¡El archivo no se pudo subir." + ex.Message;
            //    return false;
            //}
            lbl.Text = "¡Archivo subido con exito!";
            return true;
        }
        else
        {
            if (fup.FileName != null)
            {
                lbl.Text = "";
            }
            else
            {
                lbl.Text = "¡TIPO de archivo incorrecto";
            }
            return false;
        }
    }

    #region Check_boxes
    protected void chk1_CheckedChanged(object sender, EventArgs e)
    {
        if (chk1.Checked == true)
        {
            txt1.Enabled = false;
            fup1.Enabled = true;
            validador_opcion1.Enabled = false;
            //btnVP1.Enabled = true;
        }
        else
        {
            txt1.Enabled = true;
            fup1.Enabled = false;
            btnVP1.Enabled = false;
            validador_opcion1.Enabled = true;
        }
    }

    protected void chk2_CheckedChanged(object sender, EventArgs e)
    {
        if (chk2.Checked == true)
        {
            txt2.Enabled = false;
            validador_opcion2.Enabled = false;
            fup2.Enabled = true;
            //btnVP2.Enabled = true;
        }
        else
        {
            txt2.Enabled = true;
            validador_opcion2.Enabled = true;
            fup2.Enabled = false;
            btnVP2.Enabled = false;
        }
    }

    protected void chk3_CheckedChanged(object sender, EventArgs e)
    {
        if (chk3.Checked == true)
        {
            txt3.Enabled = false;
            validador_opcion3.Enabled = false;
            fup3.Enabled = true;
            //btnVP3.Enabled = true;
        }
        else
        {
            txt3.Enabled = true;
            validador_opcion3.Enabled = true;
            fup3.Enabled = false;
            btnVP3.Enabled = false;
        }
    }

    protected void chk4_CheckedChanged(object sender, EventArgs e)
    {
        if (chk4.Checked == true)
        {
            txt4.Enabled = false;
            validador_opcion4.Enabled = false;
            fup4.Enabled = true;
            //btnVP4.Enabled = true;
        }
        else
        {
            txt4.Enabled = true;
            validador_opcion4.Enabled = true;
            fup4.Enabled = false;
            btnVP4.Enabled = false;
        }
    }
    #endregion

    protected void imgbtnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        int intOpcionRespuesta = -77077; //por defecto el valor insertado en el campo fk_opcion_correcta

        string strCon = "";
        if (strModalidad == "modificar")
        {
            //strCon = "UPDATE tb_preguntas SET pregunta = '" + this.txtPregunta.Text + "' WHERE(id_preguntas = '" + strIdPregunta + "');";
            //SqlCommand comCon = new SqlCommand(strCon, sqlCon); //creando el objeto para trabajar
            //if (comCon.Connection.State == ConnectionState.Closed)
            //{
            //    comCon.Connection.Open();
            //}
            //comCon.ExecuteNonQuery();
            lblAviso.Text = "Esta opcion aun NO funciona";
        }
        else
        {
            try
            {
                //Generando el codigo autonumerico del campo Pregunta
                int codPreg = this.GenerarCodAutonumerico("SELECT MAX(id_preguntas) FROM [tb_preguntas]");
                //Introduciendo datos a la tabla pregunta
                strCon = "INSERT INTO [tb_preguntas] (id_preguntas ,fk_id_materia, pregunta) VALUES('" + codPreg.ToString() + "','" + (string)Session["materia"] + "','" + txtPregunta.Text + "');";
                SqlCommand comCon = new SqlCommand(strCon, sqlCon); //creando el objeto para trabajar
                if (comCon.Connection.State == ConnectionState.Closed)
                {
                    comCon.Connection.Open();
                }
                comCon.ExecuteNonQuery();

                //InsertarOpcion(comCon, codPreg, this.GenerarcodigoOpc(), txt4.Text, fup4, true);
                if (rbntlRespuesta.SelectedIndex == 0)
                    intOpcionRespuesta = InsertarOpcion(comCon, codPreg, txt1.Text, fup1);
                else
                    InsertarOpcion(comCon, codPreg, txt1.Text, fup1);

                if (rbntlRespuesta.SelectedIndex == 1)
                    intOpcionRespuesta = InsertarOpcion(comCon, codPreg, txt2.Text, fup2);
                else
                    InsertarOpcion(comCon, codPreg, txt2.Text, fup2);

                if (rbntlRespuesta.SelectedIndex == 2)
                    intOpcionRespuesta = InsertarOpcion(comCon, codPreg, txt3.Text, fup3);
                else
                    InsertarOpcion(comCon, codPreg, txt3.Text, fup3);

                if (rbntlRespuesta.SelectedIndex == 3)
                    intOpcionRespuesta = InsertarOpcion(comCon, codPreg, txt4.Text, fup4);
                else
                    InsertarOpcion(comCon, codPreg, txt4.Text, fup4);

                //insertando el codigo de la opcion correcta en donde tiene que ir :p
                comCon.CommandText = "UPDATE tb_preguntas SET fk_opcion_correcta = '" + intOpcionRespuesta.ToString() + "' WHERE(id_preguntas = '" + codPreg.ToString() + "')";
                if (comCon.Connection.State == ConnectionState.Closed)
                {
                    comCon.Connection.Open();
                }
                comCon.ExecuteNonQuery();

                comCon.Connection.Close();
                Session["pregunta_agregada"] = "si";
                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                lblAviso.Text = "Ocurrio un error: " + ex.Message;
            }
        }
    }

    private int InsertarOpcion(SqlCommand comandoSQL, int codigoPregunta, string descripcion, FileUpload fileup)
    {
        int codigoOpcion = this.GenerarcodigoOpc();
        int codigoImagen = InsertarImagenes(comandoSQL, fileup);
        if (codigoImagen == -999) //Si es este el codigo retornado, es porque NO hay imagen
        {
            comandoSQL.CommandText = "INSERT INTO tb_opcion(id_opcion, descripcion, fk_id_prg) VALUES('" + codigoOpcion + "', '" + descripcion + "','" + codigoPregunta + "');";
        }
        else
        {
            comandoSQL.CommandText = "INSERT INTO tb_opcion(id_opcion, descripcion, fk_id_prg, fk_id_img) VALUES('" + codigoOpcion + "', '" + descripcion + "','" + codigoPregunta + "','" + codigoImagen + "');";
        }
        if (comandoSQL.Connection.State == ConnectionState.Closed)
        {
            comandoSQL.Connection.Open();
        }
        comandoSQL.ExecuteNonQuery();

        return codigoOpcion;
    }

    //private int ActualizarOpcion(SqlCommand comandoSQL, int codigoPregunta, string descripcion, FileUpload fup)
    //{
    //    string strFKidImg = "";
    //    if (fup.Enabled && fup.HasFile)
    //    {
    //        comandoSQL.CommandText = "UPDATE tb_imagen SET imagen = @imagen WHERE (id_imagen = '" + strFKidImg + "';";
    //        comandoSQL.Parameters.Clear();
    //        comandoSQL.Parameters.Add(new SqlParameter("@imagen", fup.FileBytes));
    //        if (comandoSQL.Connection.State == ConnectionState.Closed)
    //        {
    //            comandoSQL.Connection.Open();
    //        }
    //        comandoSQL.ExecuteNonQuery();
    //        comandoSQL.Connection.Close();

    //        comandoSQL.CommandText = "UPDATE tb_opcion SET id_opcion='" + "codigOpcion" + "', descripcion='" + descripcion + "', fk_id_img='" + "idimg" +"' WHERE( fk_id_prg= '" + codigoPregunta.ToString() + "');";
    //        if (comandoSQL.Connection.State == ConnectionState.Closed)
    //        {
    //            comandoSQL.Connection.Open();
    //        }
    //        comandoSQL.ExecuteNonQuery();
    //    }
    //}

    private int InsertarImagenes(SqlCommand comandoSQL, FileUpload fup)
    {
        if (fup.Enabled && fup.HasFile)
        {
            //Insertar la imagen a la base de datos:
            //en lugar de concatenar a la cadena del INSERT los valores a insertar
            //se sustituyen por parametros precedidos por el signo '@'
            comandoSQL.CommandText = "INSERT INTO tb_imagen VALUES(@id_imagen, @imagen)";
            int nuevoCodigo = GenerarCodAutonumerico("SELECT MAX(id_imagen) FROM tb_imagen");
            //Se agregan los parametros al arreglo 'Parameters' del comando 'comCon' para que el 
            //se encargue de la sustitucion en la sentencia INSERT cuando la ejecute
            //cada parametro lleva el nombre con el que se introdujo en la cadena 
            //del insert (el precedido por la arroba) y el objeto a insertar
            comandoSQL.Parameters.Clear();
            comandoSQL.Parameters.Add(new SqlParameter("@id_imagen", nuevoCodigo));
            comandoSQL.Parameters.Add(new SqlParameter("@imagen", fup.FileBytes));
            if (comandoSQL.Connection.State == ConnectionState.Closed)
            {
                comandoSQL.Connection.Open();
            }
            comandoSQL.ExecuteNonQuery();
            comandoSQL.Connection.Close();
            return nuevoCodigo;
        }
        return -999;
    }

    //Por motivos de compatibilidad se deja esta funcion...
    private int GenerarcodigoOpc()
    {
        return GenerarCodAutonumerico("SELECT MAX(id_opcion) FROM tb_opcion");
    }

    //Genera el codigo "autonumerico" de un campo dado
    private int GenerarCodAutonumerico(string str)
    {
        SqlCommand cmdGetCode = new SqlCommand(str, this.sqlCon);
        if (cmdGetCode.Connection.State == ConnectionState.Closed)
            cmdGetCode.Connection.Open();
        try
        {
            int maxcode = (int)cmdGetCode.ExecuteScalar();
            cmdGetCode.Connection.Close();
            return maxcode + 1;
        }
        catch (Exception ex)
        { return 0; } //hay que MEJORAR esta exception
    }

    private string CrearImagen(FileUpload FUpload, byte[] file)
    {
        try
        {
            if (this.VerificarFileUpload(FUpload))
            {
                string rutaCompleta = Server.MapPath("~/Temp/") + "img" + System.DateTime.Now.Millisecond.ToString() + System.IO.Path.GetExtension(FUpload.FileName).ToLower(); //lindo el detalle del tiempo NO?
                FileStream archivo = new FileStream(rutaCompleta, FileMode.Create);
                archivo.Write(file, 0, file.Length);
                archivo.Close();
                return rutaCompleta;
            }
            else
            {
                return Server.MapPath("~/imagenes/") + "noimagen.gif";
            }
        }
        catch (Exception ex)
        {
            this.lblAviso.Text = ex.Message;
            return Server.MapPath("~/imagenes/") + "noimagen.gif";
        }
    }

    protected void btnVP1_Click(object sender, EventArgs e)
    {
        //Session.Add("materia", materia);
        ////Session.Add("fup1", this.fup1.FileName);
        this.img1.ImageUrl = this.CrearImagen(fup1, this.fup1.FileBytes);
        this.img1.Height = 100;
        this.img1.Width = 100;
    }
    protected void btnVP2_Click(object sender, EventArgs e)
    {
        this.img2.ImageUrl = this.CrearImagen(fup2, this.fup2.FileBytes);
        this.img2.Height = 100;
        this.img2.Width = 100;
    }
    protected void btnVP3_Click(object sender, EventArgs e)
    {
        this.img3.ImageUrl = this.CrearImagen(fup3, this.fup3.FileBytes);
        this.img3.Height = 100;
        this.img3.Width = 100;
    }
    protected void btnVP4_Click(object sender, EventArgs e)
    {
        this.img4.ImageUrl = this.CrearImagen(fup4, this.fup4.FileBytes);
        this.img4.Height = 100;
        this.img4.Width = 100;
    }
}