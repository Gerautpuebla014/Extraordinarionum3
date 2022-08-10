using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using AccesoDatosextraordinario;
using EntidadesExtraordinario;
using LogicaNegocioExtraordinario;
using System.Configuration;


namespace Extraordinario03
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        LogicaNegocios objBL = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objBL = new LogicaNegocios(ConfigurationManager.ConnectionStrings["cn1"].ConnectionString);
                Session["BL"] = objBL;
                Dueno();
                Encargado();
                Obra();


            }
            else
            {
                objBL = (LogicaNegocios)Session["BL"];
                GridView1.DataSource = Session["encargado"];
                GridView1.DataBind();
                GridView2.DataSource = Session["encargado"];
                GridView2.DataBind();
                GridView4.DataSource = Session["obra"];
                GridView4.DataBind();
                GridView5.DataSource = Session["obra"];
                GridView5.DataBind();

            }
        }

        public void Dueno()
        {
            string m = "";
            Session["dueno"] = objBL.obtendueno(ref m);
            GridView1.DataSource = Session["dueno"];
            GridView1.DataBind();


        }
        public void Encargado()
        {
            string m = "";
            Session["encargado"] = objBL.obtenencargado (ref m);
            GridView2.DataSource = Session["encargado"];
            GridView2.DataBind();


        }
        public void Obra()
        {
            string m = "";
            Session["obra"] = objBL.obtenobra(ref m);
            GridView4.DataSource = Session["obra"];
            GridView4.DataBind();
            GridView5.DataSource = Session["obra"];
            GridView5.DataBind();


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            GridView3.DataSource = objBL.obtenobra(ref m);
            GridView3.DataBind();
            TextBox6.Text = m;
            md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            if (GridView4.SelectedIndex >= 0)
            {

                string z = "";
                objBL.ActualizarObra(TextBox7.Text, Convert.ToInt32(GridView4.Rows[GridView4.SelectedIndex].Cells[1].Text), ref z);
                TextBox9.Text = z;
                md = objBL.MiMessageBox("CONSULTA CORRECTA", z, 2);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }
            else
            {
                TextBox9.Text = "Consulta Incorrecta";
                md = objBL.MiMessageBox("No se pudo Insertar correctamente", m, 3);
                TextBox9.Text = m;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            if (GridView4.SelectedIndex >= 0)
            {

                string z = "";
                objBL.eliminarObra(Convert.ToInt32(GridView5.Rows[GridView5.SelectedIndex].Cells[1].Text), ref z);
                TextBox8.Text = z;
                md = objBL.MiMessageBox("CONSULTA CORRECTA", z, 2);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }
            else
            {
                TextBox8.Text = "Consulta Incorrecta";
                md = objBL.MiMessageBox("No se pudo Insertar correctamente", m, 3);
                TextBox8.Text = m;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string md = "";
            string m = "";
            if (GridView1.SelectedIndex >= 0)
            {

                if (GridView2.SelectedIndex >= 0)
                {

                    string z = "";

                    objBL.InsertarObra(TextBox1.Text, TextBox2.Text, Convert.ToDateTime(TextBox3.Text), Convert.ToDateTime(TextBox4.Text), Convert.ToInt16(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text), Convert.ToInt16(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text), ref z);
                    TextBox4.Text = z;
                    md = objBL.MiMessageBox("CONSULTA CORRECTA", z, 2);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
                }
                else
                {
                    TextBox5.Text = "Consulta Incorrecta";
                    md = objBL.MiMessageBox("No se pudo Insertar correctamente", m, 3);
                    TextBox5.Text = m;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
                }
            }
            else
            {
                TextBox5.Text = "Consulta Incorrecta";
                md = objBL.MiMessageBox("No se pudo Insertar correctamente", m, 3);
                TextBox5.Text = m;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }
        }
    }
}