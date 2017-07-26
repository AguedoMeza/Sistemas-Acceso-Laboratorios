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
using System.Media; 
using Excel = Microsoft.Office.Interop.Excel;
using CrystalReport = CrystalDecisions.CrystalReports.Engine;

namespace acceso_cc.Formularios
{
    public partial class frmPersonas : Form
    {
       
        public frmPersonas()
        {
            InitializeComponent();
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
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










        private void LlenarComboEstado()
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

                qry = "SELECT distinct c_estado AS ID, d_estado AS Nombre" + "\n";
                qry = qry + "FROM sepomex" + "\n";
                qry = qry + "GROUP BY c_estado, d_estado" + "\n";
                qry = qry + "ORDER BY d_estado" + "\n";

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
                this.cbxEstado.DataSource = dtDatos;       // Le decimos que la fuente es el DataTable
                this.cbxEstado.ValueMember = "ID";         // Este ValueMenber no se observa, ojo que es el ID que mandaremos a la BD
                this.cbxEstado.DisplayMember = "Nombre";   // Esto es lo que se mostrara en el campo.

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

        private void LlenarComboMunicipio(int ID)
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

                qry = "SELECT c_mnpio AS ID, d_mnpio AS Nombre" + "\n";
                qry = qry + "FROM sepomex" + "\n";
                qry = qry + "WHERE c_estado = " + ID + "\n";
                qry = qry + "GROUP BY c_mnpio, d_mnpio" + "\n";
                qry = qry + "ORDER BY d_mnpio" + "\n";


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

                this.cbxMunicipio.DataSource = dtDatos;       // Le decimos que la fuente es el DataTable
                this.cbxMunicipio.ValueMember = "ID";         // Este ValueMenber no se observa, ojo que es el ID que mandaremos a la BD
                this.cbxMunicipio.DisplayMember = "Nombre";   // Esto es lo que se mostrara en el campo.

                // Estas 3 propiedades me sirven para poder tener autocompletado en mi combobox
                // Observen el Metodo Autocompletado es un metodo que recibe como parametro un DataTable
                // y regresa una lista especial que es fundamental para lograr el efecto de autocompletar
                //this.cboMunicipio.AutoCompleteCustomSource = this.AutoCompletado(dtDatos);
                //this.cboMunicipio.AutoCompleteMode = AutoCompleteMode.Suggest;
                //this.cboMunicipio.AutoCompleteSource = AutoCompleteSource.CustomSource;



            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Err
            }
        }



        private void cbxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = "";

            if (this.cbxEstado.SelectedValue != null)
            {
                id = this.cbxEstado.SelectedValue.ToString();

                if (!id.Equals("System.Data.DataRowView"))
                {
                    this.LlenarComboMunicipio(int.Parse(id));
                }
            }
        }




        //METODOS
        private void Limpiar()
        {
            this.txtNombre.Text = String.Empty;
            this.txtApPaterno.Text = String.Empty;
            this.txtApMaterno.Text = String.Empty;
            this.dtpFechaNacimiento.Text = String.Empty;
            //this.sexo.Text = String.Empty;
            this.mskTelefono.Text = String.Empty;
            this.txtCorreo.Text = String.Empty;
            this.lblEstado.Text = String.Empty;
            this.lblMunicipio.Text = String.Empty;
            this.lblColonia.Text = String.Empty;
            this.lblCalle.Text = String.Empty;
            this.txtNumero.Text = String.Empty;
            this.mskCP.Text = String.Empty;
            this.txtNombre.Focus();
            SystemSounds.Beep.Play();

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Estado ValueMember " + this.cbxEstado.SelectedValue.ToString());
            //MessageBox.Show("Municipio ValueMember " + this.cbxMunicipio.SelectedValue.ToString());


            if (this.EstanCamposLlenos() == true)
            {

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
                    int idExtension = Convert.ToInt32(this.cbxExtension.SelectedValue);
                        
                    // Verifiquen que aqui solo pongo la consulta de inserción 
                    // Pues ya tengo instanciados todos los objetos nescesarios
                    // Nota: Repasen la sintaxis del INSERT INTO

                    qry = "INSERT INTO personas(nombre, ap_paterno, ap_materno, fecha_nacimiento, sexo, telefono, correo, calle, numero, colonia, cp, municipio, estado, status, id_extension)" + "\n";
                    qry = qry + "VALUES('" + this.txtNombre.Text + "', ";
                    qry = qry + "'" + this.txtApPaterno.Text + "', ";
                    qry = qry + "'" + this.txtApMaterno.Text + "', ";
                    qry = qry + "'" + fecha + "', ";  // AÑO -MES -DIA 
                    qry = qry + "'" + sexo + "', ";
                    qry = qry + "'" + this.mskTelefono.Text + "', ";
                    qry = qry + "'" + this.txtCorreo.Text + "', ";
                    qry = qry + "'" + this.txtCalle.Text + "', ";
                    qry = qry + "'" + this.txtNumero.Text + "', ";
                    qry = qry + "'" + this.txtColonia.Text + "', ";
                    qry = qry + "'" + this.mskCP.Text + "', ";
                    qry = qry + "'" + this.cbxMunicipio.Text + "', ";
                    qry = qry + "'" + this.cbxEstado.Text + "', ";
                    qry = qry + "1,";
                    qry = qry + "" + idExtension + ")";

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

                    MessageBox.Show("Se agrego un registro correctamente", "Personas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Limpiar();
                    this.LlenarGrid();
                }

                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show("No se pudo establecer la conexión a la BD","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }
            }
        }


        private void frmPersonas_Load(object sender, EventArgs e)
        {
            this.LlenarGrid();
            this.LlenarComboEstado();
            this.LlenarComboExtension(); 
            // Líneas nescesarias para mostrar un globo de texto, o texto de ayuda 
            // para el control txtBuscar
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(this.txtBuscar, "Busque por nombre o apellido paterno de la persona");

            rdbHombre.Checked = true;
         
          

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.LlenarGrid();
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
            else if (this.txtCorreo.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Personas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCorreo.Focus();
                return false;
            }
            else if (this.cbxEstado.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Personas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cbxEstado.Focus();
                return false;
            }
            else if (this.cbxMunicipio.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Personas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cbxMunicipio.Focus();
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

        public void LlenarGrid()
        {

            // Vaciar Data Grid
            this.dgvInformacion.DataSource = null;
            this.dgvInformacion.Rows.Clear();
            this.dgvInformacion.Columns.Clear();

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

                qry = "";

                if (this.txtBuscar.Text == String.Empty)
                {
                    qry = "SELECT id_persona AS ID, nombre + ' ' + ap_paterno + ' ' + ap_materno AS [Nombre completo], sexo AS Sexo, fecha_nacimiento AS [Fecha de Nacimiento], telefono AS Teléfono, correo AS Correo, status AS Estado" + "\n";
                    qry = qry + "FROM personas" + "\n";

                }
                else
                {
                    qry = "SELECT id_persona AS ID, nombre + ' ' + ap_paterno + ' ' + ap_materno AS [Nombre completo], sexo AS Sexo, fecha_nacimiento AS [Fecha de Nacimiento], telefono AS Teléfono,correo AS Correo, status AS Estado" + "\n";
                    qry = qry + "FROM personas" + "\n";
                    qry = qry + "WHERE nombre LIKE '%" + this.txtBuscar.Text + "%' OR ap_paterno LIKE '%" + this.txtBuscar.Text + "%' OR ap_materno LIKE '%" + this.txtBuscar.Text + "%'";
                }

                Comando.CommandText = qry;

                // Abrimos la conexion
                sqlCNX.Open();

                Comando.Connection = sqlCNX;
                SqlDataAdapter sqlAdaper = new SqlDataAdapter(Comando);

                //es la grilla de abajo
                DataTable dtDatos = new DataTable();

                //Aqui lleno mi datatable con lo especificado en la consulta
                sqlAdaper.Fill(dtDatos);

                // Cerramos la conexion
                sqlCNX.Close();

                // Agregar columnas al Datagridview (Base de Datos)
                this.dgvInformacion.Columns.Add("#", "#");

                //para agregar columnas con imagenes


                DataGridViewImageColumn columnaImagenUno = new DataGridViewImageColumn();
                columnaImagenUno.Name = "Estado";
                dgvInformacion.Columns.Add(columnaImagenUno);


                DataGridViewImageColumn columnaImagenDos = new DataGridViewImageColumn();
                columnaImagenDos.Name = "Editar";
                dgvInformacion.Columns.Add(columnaImagenDos);

                this.dgvInformacion.Columns.Add("ID", "ID");
                this.dgvInformacion.Columns.Add("Nombre", "Nombre completo");
                this.dgvInformacion.Columns.Add("Sexo", "Sexo");
                this.dgvInformacion.Columns.Add("fecha_nacimiento", "Fecha de Nacimiento"); 
                this.dgvInformacion.Columns.Add("Telefono", "Teléfono");
                this.dgvInformacion.Columns.Add("correo", "Correo");               
                this.dgvInformacion.Columns.Add("EstadoBD", "EstadoBD");

                //con esta solo linea yo puedo alimentar mi grilla, pero, no agrega las columnas especiales de tipo imagen y no permite saber cual es el estado individual del registro
                //osea no puedo personalizar las columnas 
                //
                //this.dgvInformacion.DataSource = dtDatos;
                //

                // Recorrer el Datatable para tomar sus valores 1 a 1
                for (int i = 0; i < dtDatos.Rows.Count; i++)
                {
                    //mi_variable = DataTable.Rows[i]["NombreCampo"].ToString();
                    this.dgvInformacion.Rows.Add(); // Agregar nueva fila al dataridview
                    this.dgvInformacion.Rows[i].Cells["#"].Value = i + 1;
                    //los 25 son de los pixeles que mide de altura cada registro
                    this.dgvInformacion.Rows[i].Height = 25;

                    Color miColor = new Color();
                    miColor = Color.FromArgb(147, 49, 30);
                    Color similar = new Color();
                    similar = Color.FromArgb(52, 152, 219);

                    Color claro = new Color();
                    claro = Color.FromArgb(107, 185, 240);

                    //dtDatos es el datatable
                    // Verificar si viene con status activo
                    if (dtDatos.Rows[i]["Estado"].ToString() == "1")
                    {
                        this.dgvInformacion.Rows[i].Cells["Estado"].Value = Properties.Resources.activo;
                        this.dgvInformacion.Rows[i].Cells["Editar"].Value = Properties.Resources.editar;
                    }
                    else
                    {
                        this.dgvInformacion.Rows[i].Cells["Estado"].Value = Properties.Resources.inactivo;
                        this.dgvInformacion.Rows[i].Cells["Editar"].Value = Properties.Resources.advertencia;
                    }


                    this.dgvInformacion.Rows[i].Cells["EstadoBD"].Value = dtDatos.Rows[i]["Estado"].ToString();
                    this.dgvInformacion.Rows[i].Cells["ID"].Value = dtDatos.Rows[i]["ID"].ToString();
                    this.dgvInformacion.Rows[i].Cells["Nombre"].Value = dtDatos.Rows[i]["Nombre completo"].ToString();
                    this.dgvInformacion.Rows[i].Cells["Sexo"].Value = dtDatos.Rows[i]["Sexo"].ToString();
                    this.dgvInformacion.Rows[i].Cells["fecha_nacimiento"].Value = dtDatos.Rows[i]["fecha de nacimiento"].ToString();
                    this.dgvInformacion.Rows[i].Cells["Telefono"].Value = dtDatos.Rows[i]["Teléfono"].ToString();
                    this.dgvInformacion.Rows[i].Cells["correo"].Value = dtDatos.Rows[i]["Correo"].ToString();
                    

                    //Cambiar los colores de los registros, de fondo
                    if ((i + 1) % 2 == 0)
                    {
                        this.dgvInformacion.Rows[i].DefaultCellStyle.BackColor = similar;
                    }
                    else
                    {
                        this.dgvInformacion.Rows[i].DefaultCellStyle.BackColor = claro; 
                    }
                }

                // Encabezados de columnas en negritas (Con un estilo de fuente nuevo)
                FontFamily fontFamily = new FontFamily("Arial");
                Font font = new Font(fontFamily, 9, FontStyle.Bold);
                this.dgvInformacion.ColumnHeadersDefaultCellStyle.Font = font;


                // Centramos el titulo de todas las columnas del GridView
                this.dgvInformacion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Noten que el nombre de las columnas corresponde a los alias (Ver consulta SELECT) de las columnas en la BD
                this.dgvInformacion.Columns["#"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Cambiar tipo de fuente a toda una columna
                this.dgvInformacion.Columns["#"].DefaultCellStyle.Font = font;
                this.dgvInformacion.Columns["#"].DefaultCellStyle.ForeColor = Color.Blue; // Cambiar color de fuente

                 //Establecemos el tamaño de las columnas del Gridview
                this.dgvInformacion.Columns["#"].Width = 40;
                this.dgvInformacion.Columns["Estado"].Width = 45;
                this.dgvInformacion.Columns["Editar"].Width = 45;
                this.dgvInformacion.Columns["Nombre"].Width = 350;
                this.dgvInformacion.Columns["Sexo"].Width = 45;
                this.dgvInformacion.Columns["Fecha_Nacimiento"].Width = 150;
                this.dgvInformacion.Columns["ID"].Visible = false;          // La ocupo oculta, luego solo para usar su valor
                this.dgvInformacion.Columns["EstadoBD"].Visible = false;    // La ocupo oculta, luego solo para usar su valor
                

            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Err
            }
        }

        private void CambiarEstado(int ID, int Estado)
        {

            if (Estado == 1)
            {
                Estado = 0;
            }
            else
            {
                Estado = 1;
            }

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
                qry = "UPDATE personas" + "\n";
                qry = qry + "SET status = " + Estado + "\n";
                qry = qry + "WHERE id_persona = " + ID;

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

            }

            catch (SqlException exc)
            {
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }



        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }


        void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.LlenarGrid();
        }

        private void frmPersonas_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult respuesta;

            respuesta = MessageBox.Show("¿Desea cerrar el formulario?", "Personas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }


        }

        private void dgvInformacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvInformacion_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dgvInformacion.CurrentCell.Value.ToString());

            DialogResult respuesta;

            int filaActual = this.dgvInformacion.CurrentRow.Index;
            int estado = int.Parse(this.dgvInformacion.Rows[filaActual].Cells["EstadoBD"].Value.ToString());
            int id = int.Parse(this.dgvInformacion.Rows[filaActual].Cells["ID"].Value.ToString());

            switch (e.ColumnIndex)
            {
                case 1:
                    respuesta = MessageBox.Show("¿Desea cambiar el estado del registro?", "´Personas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.OK)
                    {
                        this.CambiarEstado(id, estado);
                        this.LlenarGrid();
                    }
                    break;
                case 2:

                    if (estado == 0)
                    {
                        MessageBox.Show("Primero debe de cambiar el estado del registro para poder editarlo", "Personas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        frmPersonasActualizar form = new frmPersonasActualizar();
                        form.Id = id;

                        // Escuchar el evento del formulario hijo
                        form.FormClosing += new FormClosingEventHandler(form_FormClosing);

                        form.ShowDialog();
                    }
                    break;

            }
        }

        private void dgvInformacion_CellMouseMove_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            //para el cursor
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                this.dgvInformacion.Cursor = Cursors.Hand;
            }
            else
            {
                this.dgvInformacion.Cursor = Cursors.Arrow;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            // Iniciar una nueva aplicacion de excel
            Excel.Application appExcel = new Excel.Application();

            // Iniciar un nuevo libro de trabajo
            Excel.Workbook libro;

            // Iniciar una nueva hoja pata el libro de trabajo
            Excel.Worksheet hoja;
            object objeto = System.Reflection.Missing.Value;
            int i = 0;


            // Colores para poder cambiar el color de celda
            Color peterRiver = new Color();
            peterRiver = Color.FromArgb(52, 152, 219);
            Color negro = new Color();
            negro = Color.FromArgb(0, 0, 0);
            Color emerald = new Color();
            emerald = Color.FromArgb(46, 204, 113);

            Color greensea = new Color();
            greensea = Color.FromArgb(22, 160, 133);
    

            Color nephritis = new Color();
            nephritis = Color.FromArgb(39, 174, 96);



            Color similar = new Color();
            similar = Color.FromArgb(52, 152, 219);

            Color claro = new Color();
            claro = Color.FromArgb(107, 185, 240);





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
            qry = "";

            if (this.txtBuscar.Text == String.Empty)
            {
                qry = "SELECT id_persona AS ID, nombre + ' ' + ap_paterno + ' ' + ap_materno AS [Nombre completo], sexo AS Sexo, fecha_nacimiento AS [Fecha de Nacimiento], telefono AS Teléfono, correo AS Correo, status AS Estado" + "\n";
                qry = qry + "FROM personas" + "\n";

            }
            else
            {
                qry = "SELECT id_persona AS ID, nombre + ' ' + ap_paterno + ' ' + ap_materno AS [Nombre completo], sexo AS Sexo, fecha_nacimiento AS [Fecha de Nacimiento], telefono AS Teléfono, correo AS Correo, status AS Estado" + "\n";
                qry = qry + "FROM personas" + "\n";
                qry = qry + "WHERE nombre LIKE '%" + this.txtBuscar.Text + "%' OR ap_paterno LIKE '%" + this.txtBuscar.Text + "%'";
            }


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

                // Creamos nuestro archivo de excel
                if (appExcel == null)
                {
                    MessageBox.Show("Excel no esta correctamente instalado");
                }

                // Crear un libro utilizando la aplicacion creada anteriormente
                libro = appExcel.Workbooks.Add(objeto);

                // Asignar hoja
                hoja = (Excel.Worksheet)libro.Worksheets.get_Item(1);
                hoja.Name = "Personas";


                // Validamos que el DataReader tenga informacion
                if (sqlDR.HasRows == true)
                {
                    i = 2;

                    hoja.Range["A1:G1"].Interior.Color = negro;
                    hoja.Range["A1:G1"].Font.Color = Color.White;

                    hoja.Cells[1, 1] = "#";
                    hoja.Cells[1, 2] = "Id";
                    hoja.Cells[1, 3] = "Nombre Completo";
                    hoja.Cells[1, 4] = "Sexo";
                    hoja.Cells[1, 5] = "Fecha de Nacimiento";
                    hoja.Cells[1, 6] = "Teléfono";
                    hoja.Cells[1, 7] = "Correo";

                    while (sqlDR.Read() == true)
                    {
                        hoja.Cells[i, 1] = i - 1;
                        hoja.Cells[i, 2] = sqlDR["Id"].ToString();
                        hoja.Cells[i, 3] = sqlDR["Nombre Completo"].ToString();
                        hoja.Cells[i, 4] = sqlDR["Sexo"].ToString();
                        hoja.Cells[i, 5] = sqlDR["Fecha de Nacimiento"].ToString();
                        hoja.Cells[i, 6] = sqlDR["Teléfono"].ToString();
                        hoja.Cells[i, 7] = sqlDR["Correo"].ToString();

                        if ((i % 2) == 0)
                        {
                            hoja.Range["A" + i + ":" + "G" + i].Interior.Color = similar;
                        }
                        else
                        {
                            hoja.Range["A" + i + ":" + "G" + i].Interior.Color = claro;
                        }

                        i++;
                    }

                    hoja.Columns["A:G"].AutoFit();


                }


                //appExcel.DisplayAlerts = false;
                //libro.SaveAs(Application.StartupPath + "\\Ejemplo.xlsx");
                //libro.Close(true, objeto, objeto);
                //appExcel.Quit();

                appExcel.Visible = true;

                this.LiberarExcel(appExcel);
                this.LiberarExcel(libro);
                this.LiberarExcel(hoja);



                // Cerrar conexion
                sqlCNX.Close();

            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void LiberarExcel(object Objeto)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Objeto);
                Objeto = null;
            }
            catch (Exception)
            {
                Objeto = null;

            }
            finally
            {
                GC.Collect();
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
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
            qry = "";

            if (this.txtBuscar.Text == String.Empty)
            {
                qry = "SELECT id_persona, nombre, ap_paterno,ap_materno,sexo, telefono, correo, status " + "\n";
                qry = qry + "FROM personas" + "\n";

            }
            else
            {
                qry = "SELECT id_persona, nombre, ap_paterno, ap_materno, sexo, telefono, correo, status " + "\n";
                qry = qry + "FROM personas" + "\n";
                qry = qry + "WHERE nombre LIKE '%" + this.txtBuscar.Text + "%' OR ap_paterno LIKE '%" + this.txtBuscar.Text + "%'";
            }


            // Bloque try para capturar errores
            try
            {

                SqlCommand Comando = new SqlCommand();


                Comando.CommandText = qry;

                // Abrimos la conexion
                sqlCNX.Open();

                Comando.Connection = sqlCNX;
                SqlDataAdapter sqlAdaper = new SqlDataAdapter(Comando);
                DataTable dtDatos = new DataTable();
                sqlAdaper.Fill(dtDatos);


                // Cerramos la conexion
                sqlCNX.Close();

                String path = Application.StartupPath;

                CrystalReport.ReportDocument crReport = new CrystalReport.ReportDocument();
                crReport.Load(path + "\\Reportes" + "\\crPersonas.rpt");
                crReport.SetDataSource(dtDatos);

                frmVisualizador formulario = new frmVisualizador(crReport);
                formulario.ShowDialog();

            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Err
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            qry = "";


            qry = "SELECT id_persona, nombre, ap_paterno, ap_materno, sexo, telefono, correo, status " + "\n";
            qry = qry + "FROM personas" + "\n";




            // Bloque try para capturar errores
            try
            {

                SqlCommand Comando = new SqlCommand();


                Comando.CommandText = qry;

                // Abrimos la conexion
                sqlCNX.Open();

                Comando.Connection = sqlCNX;
                SqlDataAdapter sqlAdaper = new SqlDataAdapter(Comando);
                DataTable dtDatos = new DataTable();
                sqlAdaper.Fill(dtDatos);


                // Cerramos la conexion
                sqlCNX.Close();

                String path = Application.StartupPath;

                CrystalReport.ReportDocument crReport = new CrystalReport.ReportDocument();
                crReport.Load(path + "\\Reportes" + "\\crPersonas.rpt");
                crReport.SetDataSource(dtDatos);

                frmVisualizador formulario = new frmVisualizador(crReport);
                formulario.ShowDialog();

            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Err
            }
        }

        private void cbxExtension_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gpbDomicilio_Enter(object sender, EventArgs e)
        {

        }

        private void gpbInformacion_Enter(object sender, EventArgs e)
        {

        }




    }
}
