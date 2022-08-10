using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AccesoDatosextraordinario;
using EntidadesExtraordinario;

namespace LogicaNegocioExtraordinario
{
    public class LogicaNegocios
    {
        private AccesoSQL operacion = null;
        public LogicaNegocios(string cadconexion)
        {
            operacion = new AccesoSQL(cadconexion);
        }

        public string MiMessageBox(string titulo, string msg, short tip)
        {
            string icono = "";
            switch (tip)
            {
                case 1:
                    icono = "'info'";
                    break;
                case 2:
                    icono = "'success'";
                    break;
                case 3:
                    icono = "'error'";
                    break;
                case 4:
                    icono = "'question'";
                    break;
            }
            string functionjs = "Mensaje('" + titulo + "','" + msg + "'," + icono + ");";
            return functionjs;
        }
        //Inserciones 
        
        public Boolean InsertaraProveeObra(string Recibio, string Entrega, int Cantidad, DateTime Fecha_Entre, Double Precio, int ID_Obra, int ID_Material,int ID_Proveedor , ref string m)
        {
            string sentencia = "insert into Provee_De_Materi_Obra(Recibio,Entrega,Cantidad,Fecha_Entre,Precio,ID_Obra,ID_Material,ID_Proveedor)" +
                "values(@Recibio, @Entrega, @Cantidad, @Fecha_Entre, @Precio, @ID_Obra, @ID_Material, @ID_Proveedor); ";
            SqlParameter[] coleccion = new SqlParameter[]
            {

                new SqlParameter("Recibio",SqlDbType.VarChar,30),
                new SqlParameter("Entrega",SqlDbType.VarChar,30),
                new SqlParameter("Cantidad",SqlDbType.Int),
                new SqlParameter("Fecha_Entre",SqlDbType.Date),
                new SqlParameter("Precio",SqlDbType.Float),
                new SqlParameter("ID_Obra",SqlDbType.Int),
                new SqlParameter("ID_Material",SqlDbType.Int),
                new SqlParameter("ID_Proveedor",SqlDbType.Int)

            };
            coleccion[0].Value = Recibio;
            coleccion[1].Value = Entrega;
            coleccion[2].Value = Cantidad;
            coleccion[3].Value = Fecha_Entre;
            coleccion[4].Value = Precio;
            coleccion[5].Value = ID_Obra;
            coleccion[6].Value = ID_Material;
            coleccion[7].Value = ID_Proveedor;

            Boolean salida = false;
            operacion.ModificarBDMasseguro(sentencia, operacion.Abrirconexion(ref m), ref m, coleccion);
            return salida;
        }
        
        public Boolean InsertarMaterial(string Descripcion_Mat, string Marca, string Presentacion, int ID_Tipo, ref string m)
        {
            string sentencia = "insert into Material(Descripcion_Mat,Marca,Presentacion,ID_Tipo) values(@Descripcion_Mat,@Marca,@Presentacion,@ID_Tipo);";
            SqlParameter[] coleccion = new SqlParameter[]
            {

                new SqlParameter("Descripcion_Mat",SqlDbType.VarChar,40),
                new SqlParameter("Marca",SqlDbType.VarChar,60),
                new SqlParameter("Presentacion",SqlDbType.VarChar,60),
                new SqlParameter("ID_Tipo",SqlDbType.Int),
                
            };
            coleccion[0].Value = Descripcion_Mat;
            coleccion[1].Value = Marca;
            coleccion[2].Value = Presentacion;
            coleccion[3].Value = ID_Tipo;

            Boolean salida = false;
            operacion.ModificarBDMasseguro(sentencia, operacion.Abrirconexion(ref m), ref m, coleccion);
            return salida;
        }
        
        public Boolean InsertarObra(string Nom_Obra, string Direccion, DateTime Fecha_Inicio, DateTime Fecha_Termino, int ID_Dueno, int ID_Encargado, ref string m)
        {
            string sentencia = "insert into Obra(Nom_Obra,Direccion,Fecha_Inicio,Fecha_Termino,ID_Dueno,ID_Encargado) " +
                "values(@Nom_Obra, @Direccion, @Fecha_Inicio, @Fecha_Termino, @ID_Dueno, @ID_Encargado); ";
            SqlParameter[] coleccion = new SqlParameter[]
            {

                new SqlParameter("Nom_Obra",SqlDbType.VarChar,40),
                new SqlParameter("Direccion",SqlDbType.VarChar,60),
                new SqlParameter("Fecha_Inicio",SqlDbType.Date),
                new SqlParameter("Fecha_Termino",SqlDbType.Date),
                new SqlParameter("ID_Dueno",SqlDbType.Int),
                new SqlParameter("ID_Encargado",SqlDbType.Int)

            };
            coleccion[0].Value = Nom_Obra;
            coleccion[1].Value = Direccion;
            coleccion[2].Value = Fecha_Inicio;
            coleccion[3].Value = Fecha_Termino;
            coleccion[4].Value = Fecha_Termino;
            coleccion[5].Value = ID_Dueno;
            coleccion[6].Value = ID_Encargado;

            Boolean salida = false;
            operacion.ModificarBDMasseguro(sentencia, operacion.Abrirconexion(ref m), ref m, coleccion);
            return salida;
        }
        //Consultas Mostrar
        public DataTable obtenMaterial(ref string mensaje)
        {
            string consulta = "select * from Material;";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.Abrirconexion(ref mensaje), ref mensaje);

            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }
        public DataTable obtenProveedor(ref string mensaje)
        {
            string consulta = "select * from Proveedor;";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.Abrirconexion(ref mensaje), ref mensaje);

            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }
        public DataTable obtendueno(ref string mensaje)
        {
            string consulta = "select* from Dueno;";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.Abrirconexion(ref mensaje), ref mensaje);

            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }
        public DataTable obtenobra(ref string mensaje)
        {
            string consulta = "Select * from Obra;";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.Abrirconexion(ref mensaje), ref mensaje);

            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }
        public DataTable obtenproveema(ref string mensaje)
        {
            string consulta = "select * from  Provee_De_Materi_Obra;";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.Abrirconexion(ref mensaje), ref mensaje);

            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }
        public DataTable obtenencargado(ref string mensaje)
        {
            string consulta = "select * from EncargadoObra;";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.Abrirconexion(ref mensaje), ref mensaje);

            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }
        public DataTable obtentipomat(ref string mensaje)
        {
            string consulta = "select * from TipoMaterial;";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.Abrirconexion(ref mensaje), ref mensaje);

            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }
        //Consultas Actualizar
        public Boolean ActualizarMaterial(string descripcion, int material, ref string m)
        {
            string sentencia = "UPDATE Material SET Descripcion_Mat =" + "'" + descripcion +"'" +"where ID_Material=" + material ;
            SqlParameter[] coleccion = new SqlParameter[]
            {


                new SqlParameter("Descripcion_Mat",SqlDbType.VarChar,250),
                new SqlParameter("ID_Material",SqlDbType.Int)

            };
            coleccion[0].Value = descripcion;
            coleccion[1].Value = material;

            Boolean salida = false;
            operacion.ModificarBDMasseguro(sentencia, operacion.Abrirconexion(ref m), ref m, coleccion);
            return salida;
        }
        public Boolean ActualizarObra(string direccion, int obra, ref string m)
        {
            string sentencia = "UPDATE Obra SET Direccion =" + "'" + direccion+ "'"+" where ID_Obra="+ obra ;
            SqlParameter[] coleccion = new SqlParameter[]
            {


                new SqlParameter("Direccion",SqlDbType.VarChar,250),
                new SqlParameter("ID_Obra",SqlDbType.Int)

            };
            coleccion[0].Value = direccion;
            coleccion[1].Value = obra;

            Boolean salida = false;
            operacion.ModificarBDMasseguro(sentencia, operacion.Abrirconexion(ref m), ref m, coleccion);
            return salida;
        }
        public Boolean ActualizarProveeObra(string recibio1, string recibio2, ref string m)
        {
            string sentencia = "UPDATE Provee_De_Materi_Obra SET Entrega =" +  "'" +  recibio1 +"'" + "where Recibio=" +  "'"+ recibio2+"';";
            SqlParameter[] coleccion = new SqlParameter[]
            {


                new SqlParameter("Entrega",SqlDbType.VarChar,250),
                new SqlParameter("Recibio",SqlDbType.VarChar,250)

            };
            coleccion[0].Value = recibio1;
            coleccion[1].Value = recibio2;

            Boolean salida = false;
            operacion.ModificarBDMasseguro(sentencia, operacion.Abrirconexion(ref m), ref m, coleccion);
            return salida;
        }
        //Consultas Eliminar 
        public Boolean eliminarObra(int Obra, ref string m)
        {
            string sentencia = "delete from Obra where ID_Obra = =" + Obra;
            SqlParameter[] coleccion = new SqlParameter[]
            {



                new SqlParameter("ID_Obra",SqlDbType.Int)

            };

            coleccion[1].Value = Obra;

            Boolean salida = false;
            operacion.ModificarBDMasseguro(sentencia, operacion.Abrirconexion(ref m), ref m, coleccion);
            return salida;
        }
        //Consultas especificas
    }
}
