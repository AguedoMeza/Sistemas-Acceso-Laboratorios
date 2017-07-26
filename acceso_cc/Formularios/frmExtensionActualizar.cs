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

// Importante para leer el archivo de configuración
using System.Configuration;

//using System.Collections.Specialized;

// Para poder conectar con la Base de Datos
using System.Data.SqlClient;



namespace acceso_cc.Formularios
{
    public partial class frmExtensionActualizar : Form
    {

  
        // Ojo esta propiedad es la clave para pasar el id entre formularios
        private long id;

        public long ID
        {
            get { return id; }
            set { id = value; }
        }



        public frmExtensionActualizar()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            this.txtNombre.Text = String.Empty;
            this.rtbDireccion.Text = String.Empty;
            this.mskTelefono.Text = String.Empty;
            this.txtCorreo.Text = String.Empty;
            this.txtNombre.Focus();
            SystemSounds.Beep.Play();
        }

        private bool EstanCamposLlenos()
        {
            if (this.txtNombre.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Extensiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNombre.Focus();
                return false;
            }
            else if (this.rtbDireccion.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Extensiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.rtbDireccion.Focus();
                return false;
            }
            else if (this.mskTelefono.MaskFull == false)
            {
                MessageBox.Show("Este campo debe de ser llenado correctamente", "Extensiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.mskTelefono.Focus();
                return false;
            }
            else if (this.EsMailValido(this.txtCorreo.Text) == false)
            {
                MessageBox.Show("Este campo debe de ser llenado correctamente", "Extensiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCorreo.Focus();
                return false;
            }

            return true;
        }

        bool EsMailValido(string Email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                return addr.Address == Email;
            }
            catch
            {
                return false;
            }
        }

        private void frmExtensionActualizar_Load(object sender, EventArgs e)
        {

            // Ojo este id proviene del formulario frmExtension, recuerden que en este formulario se agrego
            // una propiedad llamada ID, cuando mando llamar este formulario paso el id mediante esta propiedad
            // para poder saber que registro voy a mostrar y posteriormente actualizar.
            long id = this.ID;

            // Variable para almacenar la consulta en una cadena de texto
            string qry = "";

            // Cadena de conexión tomada del archivo de configuración
            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");

            // Declarar variable para la conexion de la BD 
            // y pasarle la cadena de conexion que guardamos 
            // anteriormente
            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);

            // Declaramos un objeto del tipo command e instanciamos
            SqlCommand sqlCMD = new SqlCommand();

            // Realizamos la consulta que nos traera los datos nescesarios
            qry = "SELECT nombre AS Nombre, direccion AS Direccion, telefono AS Teléfono, correo AS Correo" + "\n";
            qry = qry + "FROM extensiones" + "\n";
            qry = qry + " WHERE id_extension = " + id ;

            // Se le asigna la consulta al Objeto Command
            sqlCMD.CommandText = qry;

            // Le decimos que es una cadena de texto la que se pasara
            sqlCMD.CommandType = System.Data.CommandType.Text;

            // DataReader para leer los resultados de la consulta
            SqlDataReader sqlDR = null;

            // Asignamos la conexion al objeto Commando
            sqlCMD.Connection = sqlCNX;

            // Bloque try para capturar errores
            try
            {

                // Abrimos la conexion
                sqlCNX.Open();

                // Executamos el comando y le asignamos el resultado al 
                // DataReader para despues ver los registros devueltos
                sqlDR = sqlCMD.ExecuteReader();

                // Validamos que el DataReader tenga informacion
                if (sqlDR.HasRows == true)
                {

                    while (sqlDR.Read() == true)
                    {
                        this.txtNombre.Text = sqlDR["Nombre"].ToString();
                        this.rtbDireccion.Text = sqlDR["Direccion"].ToString();
                        this.mskTelefono.Text = sqlDR["Teléfono"].ToString();
                        this.txtCorreo.Text = sqlDR["Correo"].ToString();

                    }

                }

                // Cerrar conexion
                sqlCNX.Close();

            }

            catch (SqlException exc)
            {
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("No se pudo establecer la conexión a la BD","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }

        private void brnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.EstanCamposLlenos() == true)
            {

                long id = this.ID;

               //string cadenaConexion  =@"Data Source=HUGO-PC\SQLEXPRESSTIC02;Initial Catalog=acceso_cc; user id = hugo; password = america1" ;

                // Cadena de conexión tomada del archivo de configuración
                string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");

                // Declarar variable para la conexion de la BD 
                // y pasarle la cadena de conexion que guardamos 
                // anteriormente
                SqlConnection sqlCNX = new SqlConnection(cadenaConexion);

                // Declaramos un objeto del tipo command e instanciamos
                SqlCommand sqlCMD = new SqlCommand();

                // Bloque try para capturar errores
                try
                {

                    // Variable para almacenar la consulta en una cadena de texto
                    string qry = "";

                    // Verifiquen que aqui solo pongo la consulta de inserción 
                    // Pues ya tengo instanciados todos los objetos nescesarios
                    // Nota: Repasen la sintaxis del INSERT INTO
                    qry = "UPDATE extensiones" + "\n";
                    qry = qry + "SET nombre = '" + this.txtNombre.Text + "'," + "\n";
                    qry = qry + "direccion = '" + this.rtbDireccion.Text + "'," + "\n";
                    qry = qry + "telefono = '" + this.mskTelefono.Text + "'," + "\n";
                    qry = qry + "correo = '" + this.txtCorreo.Text + "'";
                    qry = qry + "WHERE id_extension = " + id;

                    // Le decimos que es una cadena de texto la que se pasara
                    sqlCMD.CommandType = System.Data.CommandType.Text;

                    // Se le asigna la consulta al Objeto Command
                    sqlCMD.CommandText = qry;

                    // Asignamos la conexion al objeto Commando
                    sqlCMD.Connection = sqlCNX;

                    // Abrimos la conexion
                    sqlCNX.Open();

                    // Executamos el comando en esta caso la consulta de inserción
                    sqlCMD.ExecuteReader();

                    // Cerramos la conexión
                    sqlCNX.Close();

                    MessageBox.Show("Se modificó un registro correctamente","Extensiones",MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Dispose();

                }

                catch (SqlException exc)
                {
                    //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("No se pudo establecer la conexión a la BD","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }

            }
        }

 
    }
}
