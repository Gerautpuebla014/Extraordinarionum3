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
    public partial class WebForm1 : System.Web.UI.Page
    {
        LogicaNegocios objBL = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objBL = new LogicaNegocios(ConfigurationManager.ConnectionStrings["cn1"].ConnectionString);
                Session["BL"] = objBL;
                Tipo();
                Material();


            }
            else
            {
                objBL = (LogicaNegocios)Session["BL"];
                GridView1.DataSource = Session["tipo"];
                GridView1.DataBind();
                GridView3.DataSource = Session["material"];
                GridView3.DataBind();
                GridView4.DataSource = Session["material"];
                GridView4.DataBind();

            }
        }

        public void Tipo()
        {
            string m = "";
            Session["tipo"] = objBL.obtentipomat(ref m);
            GridView1.DataSource = Session["tipo"];
            GridView1.DataBind();
            

        }
        public void Material()
        {
            string m = "";
            Session["material"] = objBL.obtenMaterial(ref m);
            GridView3.DataSource = Session["material"];
            GridView3.DataBind();
            GridView4.DataSource = Session["material"];
            GridView4.DataBind();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
               
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            GridView2.DataSource = objBL.obtenMaterial(ref m);
            GridView2.DataBind();
            TextBox5.Text = m;
            md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            
            string m = "";
            string md = "";
            if (GridView1.SelectedIndex >= 0)
            {

                string z = "";
                objBL.InsertarMaterial(TextBox1.Text, TextBox2.Text, TextBox3.Text, Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text), ref z);
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

        protected void Button5_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            if (GridView3.SelectedIndex >= 0)
            {

                string z = "";
                objBL.ActualizarMaterial(TextBox7.Text,Convert.ToInt32(GridView3.Rows[GridView3.SelectedIndex].Cells[1].Text), ref z);
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
    }
}