using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace NicryptWebControls
{
	/// <summary>
	/// Summary description for LoadingPage.
	/// </summary>
	[DefaultProperty("Text"),
	ToolboxData("<{0}:NicsBar runat=server></{0}:NicsBar>")]
	public class NicsBar : System.Web.UI.WebControls.WebControl
	{
		private string text="HTML Loading Page";
		private string loadHTML1="<SCRIPT LANGUAGE='JavaScript'> if(document.getElementById) {var upLevel = true; }	else if(document.layers) {	var ns4 = true;	}else if(document.all) { var ie4 = true;}function showObject(obj) {	if (ns4) {	obj.visibility = 'show';}else if (ie4 || upLevel) {	obj.style.visibility = 'visible';}} function hideObject(obj) {	if (ns4) {	obj.visibility = 'hide';}	if (ie4 || upLevel) {obj.style.visibility = 'hidden';}	}</SCRIPT>";
		private string loadHTML2="<DIV ID='loadingScreen' STYLE='POSITION: absolute;Z-INDEX:5; LEFT: 5%; TOP: 5%;'>	<TABLE BGCOLOR='#000000' BORDER='5' BORDERCOLOR='#000000' CELLPADDING='10' CELLSPACING='0' borderColorDark='burlywood' borderColorLight='antiquewhite'>	<TR><TD WIDTH='100%' HEIGHT='100%' BGCOLOR='moccasin' ALIGN='middle' VALIGN='center'><p><FONT SIZE='3' COLOR='darkmagenta'><B>La pagina esta cargando, por favor espera...</B></FONT></p><p><IMG SRC='{0}' BORDER='0'></p>	</TD></TR></TABLE></DIV>";
		private string loadHTML3="<script language='javascript'>	if(upLevel)	{	var load = document.getElementById('loadingScreen');	}	else if(ns4)	{		var load = document.loadingScreen;	}	else if(ie4)	{	var load = document.all.loadingScreen;	}	hideObject(load);</script>";
		private string sourceImage="loading.gif";
		
		[Bindable(true), 
		Category("Appearance"), 
		DefaultValue("Cargando")] 
		public string Text 
		{
			get
			{
				return text;
			}
		}

		public string SrcImage 
		{
			get
			{
				return sourceImage;
			}
			set
			{
				sourceImage=value;
			}
		}

		public NicsBar()
		{
			this.Init+=new EventHandler(Init1);
			this.Load+=new EventHandler(Load1);
		}
		
		protected void Init1(Object sender, System.EventArgs e)
		{
			WebControl tmp=sender as WebControl;

			loadHTML2=string.Format(loadHTML2,sourceImage);

			tmp.Page.Response.Write(loadHTML1+loadHTML2);
			tmp.Page.Response.Flush();
		}

		protected void Load1(Object sender, System.EventArgs e)
		{
			WebControl tmp=sender as WebControl;

			tmp.Page.Response.Write(loadHTML3);
		}
	}
}
