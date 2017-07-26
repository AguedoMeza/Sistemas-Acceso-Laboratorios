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
    public partial class frmPersonasActualizar : Form
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public frmPersonasActualizar()
        {
            InitializeComponent();
            
        }

                private void Limpiar()
        {
            this.txtNombre.Text = String.Empty;
            this.txtApPaterno.Text = String.Empty;
            this.txtApMaterno.Text = String.Empty;
            this.dtpFechaNacimiento.Text = String.Empty;
            //this.sexo.Text = String.Empty;
            this.mskTelefono.Text = String.Empty;
            this.lblEstado.Text = String.Empty;
            this.lblMunicipio.Text = String.Empty;
            this.lblColonia.Text = String.Empty;
            this.lblCalle.Text = String.Empty;
            this.txtNumero.Text = String.Empty;
            this.mskCP.Text = String.Empty;
            this.txtNombre.Focus();
            SystemSounds.Beep.Play();

        }

               private bool EstanCamposLlenos()
        {
            if (this.txtNombre.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Personas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNombre.Focus();
                return false;
            }
            else if (this.txtApPaterno.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Personas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtApPaterno.Focus();
                return false;
            }
            else if (this.txtApMaterno.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Personas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtApMaterno.Focus();
                return false;
            }
            else if (this.dtpFechaNacimiento.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Personas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFechaNacimiento.Focus();
                return false;
            }


            else if (this.mskTelefono.MaskFull == false)
            {
                MessageBox.Show("Este campo debe de ser llenado correctamente", "Personas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.mskTelefono.Focus();
                return false;
            }
            else if (this.txtEstado.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Personas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtEstado.Focus();
                return false;
            }
            else if (this.txtMunicipio.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Personas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMunicipio.Focus();
                return false;
            }
            else if (this.txtColonia.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Personas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtColonia.Focus();
                return false;
            }
            else if (this.txtCalle.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Personas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCalle.Focus();
                return false;
            }
            else if (this.txtNumero.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado correctamente", "Extensiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNumero.Focus();
                return false;
            }
            else if (this.mskCP.MaskFull == false)
            {
                MessageBox.Show("Este campo debe de ser llenado correctamente", "Extensiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.mskCP.Focus();
                return false;
            }


            return true;
        }


               private void LlenarComboExtension()
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

                       qry = @"SELECT id_extension AS ID, nombre FROM extensiones AS Nombre";

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
                       this.cbxExtension.DataSource = dtDatos;       // Le decimos que la fuente es el DataTable
                       this.cbxExtension.ValueMember = "ID";         // Este ValueMenber no se observa, ojo que es el ID que mandaremos a la BD
                       this.cbxExtension.DisplayMember = "Nombre";   // Esto es lo que se mostrara en el campo.

                       // Estas 3 propiedades me sirven para poder tener autocompletado en mi combobox
                       // Observen el Metodo Autocompletado es un metodo que recibe como parametro un DataTable
                       // y regresa una lista especial que es fundamental para lograr el efecto de autocompletar
                       //cboEstado.AutoCompleteCustomSource = this.AutoCompletado(dtDatos);
                       //cboEstado.AutoCompleteMode = AutoCompleteMode.Suggest;
                       //cboEstado.AutoCompleteSource = AutoCompleteSource.CustomSource;


                   }

                   catch (SqlException exc)
                   {
                       MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       //MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Err
                   }
               }




              private void frmPersonasActualizar_Load(object sender, EventArgs e)
           {

            this.LlenarComboExtension(); 

             // Ojo este id proviene del formulario frmExtension, recuerden que en este formulario se agrego
            // una propiedad llamada ID, cuando mando llamar este formulario paso el id mediante esta propiedad
            // para poder saber que registro voy a mostrar y posteriormente actualizar.
            long id = this.Id;

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
            qry = "SELECT id_persona AS ID, nombre , ap_paterno, ap_materno , sexo, fecha_nacimiento, telefono, estado, municipio, colonia, calle, numero, cp , status AS Estado, id_extension" + "\n";
            qry = qry + "FROM personas" + "\n";
            qry = qry + " WHERE id_persona = " + id ;

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


                //string sexo = "";
                //    if (this.rdbHombre.Checked == true)
                //    {
                //        sexo = "m";
                //    }
                //    else
                //    {
                //        sexo = "f";
                //    }

                    string fecha = this.dtpFechaNacimiento.Value.ToString("yyyy-MM-dd");

                 //Validamos que el DataReader tenga informacion
                if (sqlDR.HasRows == true)
                {

                    while (sqlDR.Read() == true)
                    {
                        this.txtNombre.Text = sqlDR["nombre"].ToString();
                        this.txtApPaterno.Text = sqlDR["ap_paterno"].ToString();
                        this.txtApMaterno.Text = sqlDR["ap_materno"].ToString();                       
                        //this.sexo = sqlDR["sexo"].ToString();
                        this.dtpFechaNacimiento.Text = sqlDR["fecha_nacimiento"].ToString();
                        this.mskTelefono.Text = sqlDR["telefono"].ToString();
                        this.txtEstado.Text = sqlDR["estado"].ToString();
                        this.txtMunicipio.Text = sqlDR["municipio"].ToString();
                        this.txtColonia.Text = sqlDR["colonia"].ToString();
                        this.txtCalle.Text = sqlDR["calle"].ToString();
                        this.txtNumero.Text = sqlDR["numero"].ToString();
                        this.mskCP.Text = sqlDR["cp"].ToString();

                        this.cbxExtension.SelectedValue = sqlDR["id_extension"].ToString();


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


 

    
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
               if (this.EstanCamposLlenos() == true)
            {

                long id = this.Id;

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
                    string sexo = "";
                    if (this.rdbHombre.Checked == true)
                    {
                        sexo = "m";
                    }
                    else
                    {
                        sexo = "f";
                    }

                    string fecha = this.dtpFechaNacimiento.Value.ToString("yyyy-MM-dd");

                    // Verifiquen que aqui solo pongo la consulta de inserción 
                    // Pues ya tengo instanciados todos los objetos nescesarios
                    // Nota: Repasen la sintaxis del INSERT INTO
                    qry = "UPDATE personas" + "\n";
                    qry = qry + "SET nombre = '" + this.txtNombre.Text + "'," + "\n";
                    qry = qry + "ap_paterno = '" + this.txtApPaterno.Text + "'," + "\n";
                    qry = qry + "ap_materno = '" + this.txtApMaterno.Text + "'," + "\n";
                    qry = qry + "fecha_nacimiento = '" + this.dtpFechaNacimiento.Text + "'," + "\n";
                   //qry = qry + "'" + fecha + "', "; 
                    qry = qry + "sexo = '" + sexo + "', ";                  
                    qry = qry + "telefono = '" + this.mskTelefono.Text + "'," + "\n";
                    qry = qry + "estado = '" + this.txtEstado.Text + "'," + "\n";
                    qry = qry + "municipio = '" + this.txtMunicipio.Text + "'," + "\n";
                    qry = qry + "colonia = '" + this.txtColonia.Text + "'," + "\n";
                    qry = qry + "calle = '" + this.txtCalle.Text + "'," + "\n";
                    qry = qry + "numero = '" + this.txtNumero.Text + "'," + "\n";
                    qry = qry + "cp = '" + this.mskCP.Text + "'";
                    qry = qry + "WHERE id_persona = " + id;

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

                    MessageBox.Show("Se modificó un registro correctamente","Personas",MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Dispose();

                }

                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show("No se pudo establecer la conexión a la BD","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }

            }
        
        }
        

         

    }
} 
