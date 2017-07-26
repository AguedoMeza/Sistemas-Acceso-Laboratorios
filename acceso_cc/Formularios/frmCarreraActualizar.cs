using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

using System.Data.SqlClient;

namespace acceso_cc.Formularios
{
    public partial class frmCarreraActualizar : Form
    {
        private long id;

        public long ID
        {
            get { return id; }
            set { id = value; }
        }

        public frmCarreraActualizar()
        {
            InitializeComponent();
        }



        private void Limpiar()
        {
            this.txtNombre.Text = String.Empty;
            this.txtSiglas.Text = String.Empty;
            this.txtNombre.Focus();
            
        }


        private bool EstanCamposLlenos()
        {
            if (this.txtNombre.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Carreras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNombre.Focus();
                return false;
            }
            else if (this.txtSiglas.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Carreras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtSiglas.Focus();
                return false;
            }
            return true;

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.EstanCamposLlenos() == true)
            {
                long id = this.ID;


                string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");

                SqlConnection sqlCNX = new SqlConnection(cadenaConexion);

                SqlCommand sqlCMD = new SqlCommand();

                try
                {
                    string qry = "";


                    qry = "UPDATE carreras" + "\n";
                    qry = qry + "SET nombre_carrera = '" + this.txtNombre.Text + "'," + "\n";
                    qry = qry + "siglas = '" + this.txtSiglas.Text + "'" + "\n";

                    qry = qry + "WHERE id_carrera = " + id;

                    sqlCMD.CommandType = System.Data.CommandType.Text;
                    sqlCMD.CommandText = qry;
                    sqlCMD.Connection = sqlCNX;
                    sqlCNX.Open();
                    sqlCMD.ExecuteReader();
                    sqlCNX.Close();

                    MessageBox.Show("Se modificó un registro correctamente", "Carreras", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Dispose();
                }
                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show("No se pudo establecer la conexión a la BD","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        
        }



        private void frmCarreraActualizar_Load(object sender, EventArgs e)
        {
            long id = this.ID;

            string qry = "";

            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");
            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);
            SqlCommand sqlCMD = new SqlCommand();


            qry = "SELECT nombre AS Nombre, siglas AS Siglas" + "\n";
            qry = qry + "FROM carreras" + "\n";
            qry = qry + " WHERE id_carrera = " + id;

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
                        this.txtNombre.Text = sqlDR["Nombre"].ToString();
                        this.txtSiglas.Text = sqlDR["Siglas"].ToString();
                    }

                }
                sqlCNX.Close();
            }

            catch (SqlException exc)
            {
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmCarreraActualizar_Load_1(object sender, EventArgs e)
        {
            long id = this.ID;
            string qry = "";
            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");
            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);
            SqlCommand sqlCMD = new SqlCommand();

            qry = @"select nombre AS Nombre,siglas AS Siglas
                            from carreras 
                            where id_carrera = " + id;

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

                        this.txtNombre.Text = sqlDR["Nombre"].ToString();
                        this.txtSiglas.Text = sqlDR["Siglas"].ToString();

                    }
                }

                sqlCNX.Close();
            }

            catch (SqlException exc)
            {
                MessageBox.Show("No se pudo establecer la conexion  ala BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }

        }

    }
}
