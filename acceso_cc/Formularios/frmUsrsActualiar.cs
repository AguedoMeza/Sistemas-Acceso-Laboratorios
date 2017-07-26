using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Data.SqlClient;
using System.Configuration;

namespace acceso_cc.Formularios
{

    public partial class frmUsrsActualiar : Form
    {
        private long id;

        public long ID
        {
            get { return id; }
            set { id = value; }
        }

        public frmUsrsActualiar()
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
                qry = "SELECT id_tipo_usuario AS ID, nombre AS Nombre" + "\n";
                qry = qry + "FROM tipo_usuarios" + "\n";
                Comando.CommandText = qry;
                sqlCNX.Open();

                Comando.Connection = sqlCNX;
                SqlDataAdapter sqlAdaper = new SqlDataAdapter(Comando);
                DataTable dtDatos = new DataTable();
                sqlAdaper.Fill(dtDatos);
                sqlCNX.Close();

                this.cmbTipo.DataSource = dtDatos;       // Le decimos que la fuente es el DataTable
                this.cmbTipo.ValueMember = "ID";         // Este ValueMenber no se observa, ojo que es el ID que mandaremos a la BD
                this.cmbTipo.DisplayMember = "Nombre";   // Esto es lo que se mostrara en el campo.
                this.cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUsrsActualiar_Load(object sender, EventArgs e)
        {
            LLenarCombo();
            long id = this.ID;
            string qry = "";
            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");
            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);
            SqlCommand sqlCMD = new SqlCommand();

            qry = @"SELECT usrs.usuario AS Usuario, usrs.contrasena AS Contrasena,
                                    tusrs.nombre AS Tipo
                                    FROM personas per INNER JOIN usuarios usrs
                                    ON per.id_persona=usrs.id_persona 
                                    INNER JOIN tipo_usuarios tusrs
                                    ON tusrs.id_tipo_usuario = usrs.id_tipo_usuario
                                    WHERE id_usuario = " + id;

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
                        this.txtUsuario.Text = sqlDR["Usuario"].ToString();
                        this.txtContrasena.Text = sqlDR["Contrasena"].ToString();
                        this.cmbTipo.Text = sqlDR["Tipo"].ToString();
                    }

                }
                sqlCNX.Close();
            }
            catch (SqlException exc)
            {
                MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualiar_Click(object sender, EventArgs e)
        {
            long id = this.ID;
            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");
            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);
            SqlCommand sqlCMD = new SqlCommand();

            try
            {
            string qry = "";
            qry = @"UPDATE usuarios" + "\n";
            qry = qry + "SET usuario = '" + this.txtUsuario.Text + "'," + "\n";
            qry = qry + "id_tipo_usuario = " + this.cmbTipo.SelectedValue + ", " + "\n";
            qry = qry + "contrasena = '" + this.txtContrasena.Text + "'" + "\n";
            qry = qry + "WHERE id_usuario = " + id;


            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = qry;
            sqlCMD.Connection = sqlCNX;
            sqlCNX.Open();
            sqlCMD.ExecuteReader();
            sqlCNX.Close();

            MessageBox.Show("Se modificó un registro correctamente", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Dispose();

            }

            catch (SqlException exc)
            {

                MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

