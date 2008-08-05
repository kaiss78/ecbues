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

public partial class examinar_Resultados : System.Web.UI.Page
{
    private void Page_Load(object sender, System.EventArgs e)
    {
        int nAprobadas=0;
        int nReprobadas=0;
        int totalRespuestas = ((Hashtable)Session["respuestas"]).Count;
        int correcta = 0;
        IDictionaryEnumerator de = ((Hashtable)Session["respuestas"]).GetEnumerator();
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
        cn.Open();
        SqlCommand cmd = new SqlCommand("SELECT fk_opcion_correcta FROM tb_preguntas WHERE id_preguntas = @id",cn);
        cmd.Parameters.Add("@id", SqlDbType.Int);
        while(de.MoveNext())
        {
            cmd.Parameters["@id"].Value = de.Key;
            correcta = (int)cmd.ExecuteScalar();
            if ((int)de.Value == correcta)
                nAprobadas++;
            else
                nReprobadas++;
        }
        cn.Close();
        Graficador1.Aprobado = (nAprobadas*100)/totalRespuestas;  //(int)nAprobadas/totalRespuestas*100;
        Graficador1.Reprobado = (nReprobadas*100)/totalRespuestas;
    }
}