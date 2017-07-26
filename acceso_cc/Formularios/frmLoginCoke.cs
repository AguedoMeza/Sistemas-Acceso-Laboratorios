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
using System.Configuration;
using acceso_cc;

namespace acceso_cc.Formularios
{
    public partial class frmLoginCoke : Form
    {
        string confirmUs = "";
        string confirmPass = "";
        int confirmAdmin;

        static int  idLogin;

        public frmLoginCoke()
        {
            InitializeComponent();
        }

        //private void InitializeComponent()
        //{
        //    throw new NotImplementedException();
        //}
        private bool EstanCamposLlenos()
        {
            if (this.txtUsuario.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtUsuario.Focus();
                return false;
            }
            else if (this.txtcontrasena.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtcontrasena.Focus();
                return false;
            }


            return true;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.EstanCamposLlenos() == true)
            {


                string qry = "";
                string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");
                SqlConnection sqlCNX = new SqlConnection(cadenaConexion);
                SqlCommand sqlCMD = new SqlCommand();
                
                qry = @"SELECT usuario AS Usuario, contraseña AS Contrasena,  id_tipo_usuario 
                        FROM usuarios WHERE usuario = '" + this.txtUsuario.Text + "' AND contraseña = '" + this.txtcontrasena.Text + "'";
                
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
                            confirmUs = sqlDR["Usuario"].ToString();
                            confirmPass = sqlDR["Contrasena"].ToString();
                            confirmAdmin = Convert.ToInt32(sqlDR["id_tipo_usuario"]);


                            if (confirmPass == this.txtcontrasena.Text && confirmUs == this.txtUsuario.Text)
                            {
                                this.Close();
                                Formularios.frmPrincipal form = new Formularios.frmPrincipal();
                                form.TipoUsuario = 1;
                                form.Show();
                            }

                        }

                    }

                    else
                    {
                        MessageBox.Show("Usuario o Contraseña Incorrecta", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    sqlCNX.Close();
                }

                catch (SqlException exc)
                {
                    MessageBox.Show("no conexion a BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
            
        