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
using System.Media;
using System.Data.SqlClient;

namespace directorio_utl
{
    public partial class frmLabsActualizar : Form
    {
        private long id;

        public long ID
        {
            get { return id; }
            set { id = value; }
        }
        public frmLabsActualizar()
        {
            InitializeComponent();
        }
        private void LLenarCombo()
        {
            string qry = "";
            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");
            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand Comando = new SqlCommand();
                qry = @"SELECT id_extension AS ID, nombre AS Nombre
                        FROM extensiones
                        WHERE status = 1";


                Comando.CommandText = qry;
                sqlCNX.Open();
                Comando.Connection = sqlCNX;

                SqlDataAdapter sqlAdaper = new SqlDataAdapter(Comando);
                DataTable dtDatos = new DataTable();
                sqlAdaper.Fill(dtDatos);
                sqlCNX.Close();

                this.cmbExt.DataSource = dtDatos;       // Le decimos que la fuente es el DataTable
                this.cmbExt.ValueMember = "ID";         // Este ValueMenber no se observa, ojo que es el ID que mandaremos a la BD
                this.cmbExt.DisplayMember = "Nombre";   // Esto es lo que se mostrara en el campo.
                this.cmbExt.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Err
            }
        }
        private void frmLabsActualizar_Load(object sender, EventArgs e)
        {
            LLenarCombo();
            long id = this.ID;

            string qry = "";
            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");
            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);
            SqlCommand sqlCMD = new SqlCommand();

            qry = @"SELECT lab.nombre AS Nombre, lab.descripcion AS Descripcion,
                    ext.nombre AS Extencion
                    FROM laboratorios lab   
                    INNER JOIN extensiones ext 
                    ON lab.id_extension=ext.id_extension
                    WHERE id_laboratorio = "+id;

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
                        this.txtDescripcion.Text = sqlDR["Descripcion"].ToString();
                        this.cmbExt.Text = sqlDR["Extencion"].ToString();
                     }
                }
                sqlCNX.Close();
            }

            catch (SqlException exc)
            {
                MessageBox.Show("No se pudo establecer la conexión a la BD","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            long id = this.ID;
            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");
            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);
            SqlCommand sqlCMD = new SqlCommand();

            try
            {
            
            string qry = "";
            qry = @"UPDATE laboratorios" + "\n";
            qry = qry + "SET nombre = '" + this.txtNombre.Text + "'," + "\n";
            qry = qry + "id_extension = " + cmbExt.SelectedValue + ", " + "\n";
            qry = qry + "descripcion = '" + this.txtDescripcion.Text + "'" + "\n";
            qry = qry + "WHERE id_laboratorio = " + id;
        
                sqlCMD.CommandType = System.Data.CommandType.Text;
                sqlCMD.CommandText = qry;
                sqlCMD.Connection = sqlCNX;
                sqlCNX.Open();
                sqlCMD.ExecuteReader();
                sqlCNX.Close();

                MessageBox.Show("Se modificó un registro correctamente", "Laboratorios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();

            }

            catch (SqlException exc)
            {
                MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbExt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        }
    }
