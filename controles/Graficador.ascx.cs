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
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

public partial class controles_Graficador : System.Web.UI.UserControl
{
    private int nMax = 2;
    private string[] productCount = new string[2];
    private string[] productName = new string[2];
    private string[] productPercent = new string[2];
    private float[] Angle = new float[2];
    private int _aprobado = 0;
    private int _reprobado = 0;

	public int Aprobado
	{
		set { _aprobado = value; }
	}

    public int Reprobado
    {
        set { _reprobado = value; }
    }


    public string strNombreArchivo = System.IO.Path.GetTempPath() + "graRAC.gif";

    private void Page_Load(object sender, System.EventArgs e)
    {
        GetList3();
        DrawGraphic3();
    }

    private void GetList3()
    {
        try
        {
            productPercent[0] = _aprobado.ToString();
            Angle[0] = (float)(Convert.ToInt32(productPercent[0]) * 3.6);
            productName[0] = "Porcentaje preguntas ganadas";
            productPercent[1] = _reprobado.ToString();
            Angle[1] = (float)(Convert.ToInt32(productPercent[1]) * 3.6);
            productName[1] = "Porcentaje preguntas perdidas";
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Exception : " + ex.Message.Replace("'", "") + "');</script>");
        }
    }

    private void DrawGraphic3()
    {
        Response.ContentType = "image/Gif";
        const int width = 700, height = 200;

        Bitmap objBitmap = new Bitmap(width, height);
        Graphics objGraphics = Graphics.FromImage(objBitmap);

        // Create a black background for the border
        objGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0,
        width, height);

        Draw3DPieChart(ref objGraphics);

        // Save the image to a file
        objBitmap.Save(strNombreArchivo, ImageFormat.Gif);

        // clean up...
        objGraphics.Dispose();
        objBitmap.Dispose();
    }

    // Draws a 3D pie chart where ever slice is 45 degrees in value
    void Draw3DPieChart(ref Graphics objGraphics)
    {
        // Create location and size of ellipse.
        int x = 60;
        int y = 20;
        int width = 200;
        int height = 100;


        // Create start.
        float startAngle = 0;

        SolidBrush objBrush = new SolidBrush(Color.Aqua);

        objGraphics.SmoothingMode = SmoothingMode.AntiAlias;

        Color[] color_rgb = {Color.FromArgb(20,120,255), Color.FromArgb(255,0,0),
            Color.FromArgb(100,100,100), Color.FromArgb(0,255,0),
            Color.FromArgb(0,255,192), Color.FromArgb(192,192,0),
            Color.FromArgb(100,0,192), Color.FromArgb(0,0,255)};

        for (int iLoop = 0; iLoop < 15; iLoop++)
        {
            startAngle = 0;
            for (int i = 0; i < nMax; i++)
            {
                objBrush.Color = color_rgb[i];
                if (iLoop == 14)
                    objGraphics.FillPie(objBrush, x,
                    y - iLoop + 25, width, height, startAngle, Angle[i]);
                else
                    objGraphics.FillPie(new HatchBrush(HatchStyle.Percent50,
                    color_rgb[i]), x,
                    y - iLoop + 25, width, height, startAngle, Angle[i]);
                startAngle += Angle[i];
            }
        }

        for (int i = 0; i < nMax; i++)
        {
            objBrush.Color = color_rgb[i];

            objGraphics.FillRectangle(objBrush, x + width + 80, y + i * 18, 14, 14);
            objGraphics.DrawString(productName[i], new Font("Courier New", 11), new SolidBrush(Color.FromArgb(0, 0, 0)),
            x + width + 100, y + i * 18);
            objGraphics.DrawString(productPercent[i] + "%", new Font("Courier New", 11), new SolidBrush(Color.FromArgb(0, 0, 0)),
            x + width + 20, y + i * 18);

            objGraphics.DrawString(productCount[i], new Font("Courier New", 10), new SolidBrush(Color.FromArgb(0, 0, 0)),
            x + width + 310, y + i * 18);
        }

    }
}
