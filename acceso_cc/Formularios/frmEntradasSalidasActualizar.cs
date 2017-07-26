using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Media;
using Excel = Microsoft.Office.Interop.Excel;
using CrystalReport = CrystalDecisions.CrystalReports.Engine;
using System.Configuration;


namespace acceso_cc.Formularios
{
    public partial class frmEntradasSalidasActualizar : Form
    {
        private long id;

        public long ID
        {
            get { return id; }
            set { id = value; }

        }
        public frmEntradasSalidasActualizar()
        {
            InitializeComponent();
        }

        private void frmEntradasSalidasActualizar_Load(object sender, EventArgs e)
        {
            this.LlenarComboLaboratorios();
            this.LlenarComboTipoCarrera();
            this.LlenarComboSiglas();
            this.LlenarComboPeriodoMes();
            this.LlenarComboPeriodoAño();
            this.LlenarComboNumTetra();
            this.LlenarComboGrupo();
           
            long id = this.ID;
            string qry = "";
            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");
            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);
            SqlCommand sqlCMD = new SqlCommand();

            qry = @"SELECT fecha AS Fecha, hora_entrada AS HoraEn, hora_salida AS HoraSal
                                    FROM registro_cc
                                    WHERE id_entrada_salida = " + id;

            sqlCMD.CommandText = qry;
            sqlCMD.CommandType = System.Data.CommandType.Text;
            SqlDataReader sqlDR = null;
            sqlCMD.Connection = sqlCNX;

            try
            {
                sqlCNX.Open();
                sqlDR = sqlCMD.ExecuteReader();
                if (sqlDR.HasRows == true)
                {

                    while (sqlDR.Read() == true)
                    {
                        this.dtpFecha.Text = sqlDR["Fecha"].ToString();
                        this.dtpHoraEntrada.Text = sqlDR["HoraEn"].ToString();
                        this.dtpHoraSalida.Text = sqlDR["HoraSal"].ToString();
                    }

                }
                sqlCNX.Close();
            }
            catch (SqlException exc)
            {
                MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LlenarComboSiglas()
        {


            // Variable para almacenar la consulta en una cadena de texto
            string qry = "";

            // Cadena de conexión tomada del archivo de configuración
            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");

            // Declarar variable para la conexion de la BD pasarle la cadena de conexion que guardamos anteriormente
            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);

            // Bloque try para capturar errores
            try
            {

                SqlCommand Comando = new SqlCommand();

                //c= id
                //d= nombre del estado
                // distinct

                qry = @"SELECT id_carrera AS ID, siglas AS Nombre FROM carreras";

                Comando.CommandText = qry;

                // Abrimos la conexion
                sqlCNX.Open();

                Comando.Connection = sqlCNX;
                SqlDataAdapter sqlAdaper = new SqlDataAdapter(Comando);

                DataTable dtDatos = new DataTable();

                // Aqui lleno mi Datatable con lo especificado en la consulta
                sqlAdaper.Fill(dtDatos);

                // Cerramos la conexion
                sqlCNX.Close();


                // Llenado del combo
                this.cboSiglas.DataSource = dtDatos;       // Le decimos que la fuente es el DataTable
                this.cboSiglas.ValueMember = "ID";         // Este ValueMenber no se observa, ojo que es el ID que mandaremos a la BD
                this.cboSiglas.DisplayMember = "Nombre";   // Esto es lo que se mostrara en el campo.


            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Err
            }
        }



        private void LlenarComboTipoCarrera()
        {


            // Variable para almacenar la consulta en una cadena de texto
            string qry = "";

            // Cadena de conexión tomada del archivo de configuración
            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");

            // Declarar variable para la conexion de la BD pasarle la cadena de conexion que guardamos anteriormente
            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);

            // Bloque try para capturar errores
            try
            {

                SqlCommand Comando = new SqlCommand();

                //c= id
                //d= nombre del estado
                // distinct

                qry = @"SELECT id_tipo_carrera AS ID, nombre AS Nombre FROM tipo_carrera";

                Comando.CommandText = qry;

                // Abrimos la conexion
                sqlCNX.Open();

                Comando.Connection = sqlCNX;
                SqlDataAdapter sqlAdaper = new SqlDataAdapter(Comando);

                DataTable dtDatos = new DataTable();

                // Aqui lleno mi Datatable con lo especificado en la consulta
                sqlAdaper.Fill(dtDatos);

                // Cerramos la conexion
                sqlCNX.Close();


                // Llenado del combo
                this.cboTipoCarrera.DataSource = dtDatos;       // Le decimos que la fuente es el DataTable
                this.cboTipoCarrera.ValueMember = "ID";         // Este ValueMenber no se observa, ojo que es el ID que mandaremos a la BD
                this.cboTipoCarrera.DisplayMember = "Nombre";   // Esto es lo que se mostrara en el campo.


            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Err
            }
        }



        private void LlenarComboPeriodoMes()
        {
            this.cboPeriodoMes.Items.Add("Ene - Abr");
            this.cboPeriodoMes.Items.Add("May - Ago");
            this.cboPeriodoMes.Items.Add("Sep - Dic");

        }


        private void LlenarComboPeriodoAño()
        {
            this.cboPeriodoAño.Items.Clear();
            int i = 0;
            for (i = 2016; i <= 2026; i++)
            {
                this.cboPeriodoAño.Items.Add(i);
            }

        }



        private void LlenarComboNumTetra()
        {
            this.cboTetra.Items.Clear();
            int i = 0;
            for (i = 1; i <= 11; i++)
            {
                this.cboTetra.Items.Add(i);
            }

        }

        private void LlenarComboGrupo()
        {
            this.cboGrupo.Items.Add("A");
            this.cboGrupo.Items.Add("B");
            this.cboGrupo.Items.Add("C");
            this.cboGrupo.Items.Add("D");

        }






        private void LlenarComboLaboratorios()
        {


            // Variable para almacenar la consulta en una cadena de texto
            string qry = "";

            // Cadena de conexión tomada del archivo de configuración
            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");

            // Declarar variable para la conexion de la BD pasarle la cadena de conexion que guardamos anteriormente
            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);

            // Bloque try para capturar errores
            try
            {

                SqlCommand Comando = new SqlCommand();

                //c= id
                //d= nombre del estado
                // distinct

                qry = @"SELECT id_laboratorio AS ID, nombre  AS Nombre FROM laboratorios";

                Comando.CommandText = qry;

                // Abrimos la conexion
                sqlCNX.Open();

                Comando.Connection = sqlCNX;
                SqlDataAdapter sqlAdaper = new SqlDataAdapter(Comando);

                DataTable dtDatos = new DataTable();

                // Aqui lleno mi Datatable con lo especificado en la consulta
                sqlAdaper.Fill(dtDatos);

                // Cerramos la conexion
                sqlCNX.Close();


                // Llenado del combo
                this.cboLaboratorio.DataSource = dtDatos;       // Le decimos que la fuente es el DataTable
                this.cboLaboratorio.ValueMember = "ID";         // Este ValueMenber no se observa, ojo que es el ID que mandaremos a la BD
                this.cboLaboratorio.DisplayMember = "Nombre";   // Esto es lo que se mostrara en el campo.



            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Err
            }
        }



    }
}
