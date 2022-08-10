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
    public partial class WebForm3 : System.Web.UI.Page
    {
        LogicaNegocios objBL = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objBL = new LogicaNegocios(ConfigurationManager.ConnectionStrings["cn1"].ConnectionString);
                Session["BL"] = objBL;
                Material();
                obra();
                Proveedor();
                ProveeMat();
                


            }
            else
            {
                objBL = (LogicaNegocios)Session["BL"];
                GridView1.DataSource = Session["material"];
                GridView1.DataBind();
                GridView2.DataSource = Session["obra"];
                GridView2.DataBind();
                GridView3.DataSource = Session["proveedor"];
                GridView3.DataBind();
                GridView5.DataSource = Session["provemat"];
                GridView5.DataBind();
                GridView6.DataSource = Session["provemat"];
                GridView6.DataBind();
            }
        }
        public void Material()
        {
            string m = "";
            Session["material"] = objBL.obtenMaterial(ref m);
            GridView1.DataSource = Session["material"];
            GridView1.DataBind();
            


        }
        public void obra()
        {
            string m = "";
            Session["obra"] = objBL.obtenobra(ref m);
            GridView2.DataSource = Session["obra"];
            GridView2.DataBind();
            


        }
        public void Proveedor()
        {
            string m = "";
            Session["proveedor"] = objBL.obtenProveedor(ref m);
            GridView3.DataSource = Session["proveedor"];
            GridView3.DataBind();
            


        }
        public void ProveeMat()
        {
            string m = "";
            Session["provemat"] = objBL.obtenproveema(ref m);
            GridView5.DataSource = Session["provemat"];
            GridView5.DataBind();
            GridView6.DataSource = Session["provemat"];
            GridView6.DataBind();



        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string md = "";
            string m = "";
            if (GridView3.SelectedIndex >= 0)
            {
                if (GridView1.SelectedIndex >= 0)
                {

                    if (GridView2.SelectedIndex >= 0)
                    {

                        string z = "";

                        objBL.InsertaraProveeObra(TextBox1.Text, TextBox2.Text, Convert.ToInt32(TextBox3.Text), Convert.ToDateTime(TextBox4.Text), Convert.ToDouble(TextBox4.Text),Convert.ToInt16(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text), Convert.ToInt16(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text), Convert.ToInt16(GridView3.Rows[GridView3.SelectedIndex].Cells[1].Text), ref z);
                        TextBox6.Text = z;
                        md = objBL.MiMessageBox("CONSULTA CORRECTA", z, 2);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
                    }
                    else
                    {
                        TextBox6.Text = "Consulta Incorrecta";
                        md = objBL.MiMessageBox("No se pudo Insertar correctamente", m, 3);
                        TextBox6.Text = m;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
                    }
                }
                else
                {
                    TextBox6.Text = "Consulta Incorrecta";
                    md = objBL.MiMessageBox("No se pudo Insertar correctamente", m, 3);
                    TextBox6.Text = m;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
                }
            }
            else
            {
                TextBox6.Text = "Consulta Incorrecta";
                md = objBL.MiMessageBox("No se pudo Insertar correctamente", m, 3);
                TextBox6.Text = m;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            GridView4.DataSource = objBL.obtenproveema(ref m);
            GridView4.DataBind();
            TextBox6.Text = m;
            md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            if (GridView5.SelectedIndex >= 0)
            {

                string z = "";
                objBL.ActualizarProveeObra( Convert.ToString(GridView5.Rows[GridView5.SelectedIndex].Cells[1].Text),TextBox8.Text, ref z);
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
    }
}