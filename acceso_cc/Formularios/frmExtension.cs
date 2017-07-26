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

// Para poder conectar con la Base de Datos
using System.Data.SqlClient;

namespace acceso_cc.Formularios
{
    public partial class frmExtension : Form
    {

        public frmExtension()
        {
            InitializeComponent();
        }


        private void brnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

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

                    // Verifiquen que aqui solo pongo la consulta de inserción 
                    // Pues ya tengo instanciados todos los objetos nescesarios
                    // Nota: Repasen la sintaxis del INSERT INTO
                    qry = "INSERT INTO extensiones(nombre, direccion, telefono, correo, status)" + "\n";
                    qry = qry + "VALUES('" + this.txtNombre.Text + "', ";
                    qry = qry + "'" + this.rtbDireccion.Text + "', ";
                    qry = qry + "'" + this.mskTelefono.Text + "', ";
                    qry = qry + "'" + this.txtCorreo.Text + "', ";
                    qry = qry + "1)";

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

                    MessageBox.Show("Se agrego un registro correctamente","Extensiones",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Limpiar();
                    this.LlenarGrid();
                }

                catch (SqlException exc)
                {
                    //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("No se pudo establecer la conexión a la BD","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }

            }

        }

        private void frmExtension_Load(object sender, EventArgs e)
        {
            this.LlenarGrid();

            // Líneas nescesarias para mostrar un globo de texto, o texto de ayuda 
            // para el control txtBuscar
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(this.txtBuscar, "Busque por nombre o direccion de la extension");
        }


        private void txtInformacion_TextChanged(object sender, EventArgs e)
        {
            this.LlenarGrid();
        }

        private void dgvInformacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dgvInformacion.CurrentCell.Value.ToString());

            DialogResult respuesta;

            


            if (this.dgvInformacion.CurrentRow != null)
            {
                int filaActual = this.dgvInformacion.CurrentRow.Index;
                int estado = int.Parse(this.dgvInformacion.Rows[filaActual].Cells["EstadoBD"].Value.ToString());
                int id = int.Parse(this.dgvInformacion.Rows[filaActual].Cells["ID"].Value.ToString());

                switch (e.ColumnIndex)
                {
                    case 1:
                        respuesta = MessageBox.Show("¿Desea cambiar el estado del registro?", "Extensiones", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (respuesta == DialogResult.OK)
                        {
                            this.CambiarEstado(id, estado);
                            this.LlenarGrid();
                            
                        }
                        break;
                    case 2:

                        if (estado == 0)
                        {
                            MessageBox.Show("Primero debe de cambiar el estado del registro para poder editarlo", "Extensiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {

                            
                            frmExtensionActualizar form = new frmExtensionActualizar();
                            form.ID = id;
                            

                            // Escuchar el evento del formulario hijo
                            form.FormClosing += new FormClosingEventHandler(form_FormClosing); 
 
                            form.ShowDialog();

                        }
                        break;

                }

            }
        }

        // Observen el nombre de este procedimiento form_FormClosing
        // form.FormClosing += new FormClosingEventHandler(form_FormClosing); 
        // Es el mismo que se pasa como parametro
        void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.LlenarGrid();
        }

        private void dgvInformacion_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1 ||e.ColumnIndex == 2)
            {
                this.dgvInformacion.Cursor = Cursors.Hand;
            }
            else
            {
                this.dgvInformacion.Cursor = Cursors.Arrow;
            }
            
        }



        #region Metodos
        private void Limpiar()
        {
            this.txtNombre.Text = String.Empty;
            this.rtbDireccion.Text = String.Empty;
            this.mskTelefono.Text = String.Empty;
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
                    qry = "SELECT id_extension AS ID, nombre AS Nombre, direccion AS Direccion, telefono AS Teléfono, correo AS Correo, status AS Estado" + "\n";
                    qry = qry + "FROM extensiones" + "\n";

                }
                else
                {
                    qry = "SELECT id_extension AS ID, nombre AS Nombre, direccion AS Direccion, telefono AS Teléfono, correo AS Correo, status AS Estado" + "\n";
                    qry = qry + "FROM extensiones" + "\n";
                    qry = qry + "WHERE (nombre LIKE '%" + this.txtBuscar.Text + "%' OR direccion LIKE '%" + this.txtBuscar.Text + "%')";
                }

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


                // Agregar columnas al Datagridview (Base de Datos)
                this.dgvInformacion.Columns.Add("#", "#");

                DataGridViewImageColumn columnaImagenUno = new DataGridViewImageColumn();
                columnaImagenUno.Name = "Estado";
                dgvInformacion.Columns.Add(columnaImagenUno);


                DataGridViewImageColumn columnaImagenDos = new DataGridViewImageColumn();
                columnaImagenDos.Name = "Editar";
                dgvInformacion.Columns.Add(columnaImagenDos);

                this.dgvInformacion.Columns.Add("ID", "ID");
                this.dgvInformacion.Columns.Add("Nombre", "Nombre");
                this.dgvInformacion.Columns.Add("Direccion", "Direccion");
                this.dgvInformacion.Columns.Add("Telefono", "Teléfono");
                this.dgvInformacion.Columns.Add("Correo", "Correo");
                this.dgvInformacion.Columns.Add("EstadoBD", "EstadoBD");

                //this.dgvInformacion.DataSource = dtDatos;

                // Recorrer el Datatable para tomar sus valores 1 a 1
                for (int i = 0; i < dtDatos.Rows.Count; i++)
                {
                    //mi_variable = DataTable.Rows[i]["NombreCampo"].ToString();
                    this.dgvInformacion.Rows.Add(); // Agregar nueva fila al dataridview
                    this.dgvInformacion.Rows[i].Cells["#"].Value = i + 1;
                    
                    this.dgvInformacion.Rows[i].Height = 25;


                    // Clores RGB
                    Color miColor = new Color();
                    miColor = Color.FromArgb(147, 49, 30);

                    Color similar = new Color();
                    similar = Color.FromArgb(52, 152, 219);

                    Color claro = new Color();
                    claro = Color.FromArgb(107, 185, 240);



                    // Verificar si viene con status activo
                    if (dtDatos.Rows[i]["Estado"].ToString() == "1")
                    {
                        this.dgvInformacion.Rows[i].Cells["Estado"].Value = Properties.Resources.activo;
                        this.dgvInformacion.Rows[i].Cells["Editar"].Value = Properties.Resources.editar;


                        // Cambiar color de una sola celda
                        this.dgvInformacion.Rows[i].Cells["#"].Style.BackColor = miColor; // Color desde un RGB
                    }
                    else
                    {
                        this.dgvInformacion.Rows[i].Cells["Estado"].Value = Properties.Resources.inactivo;
                        this.dgvInformacion.Rows[i].Cells["Editar"].Value = Properties.Resources.advertencia;

                        this.dgvInformacion.Rows[i].Cells["#"].Style.BackColor = Color.BlanchedAlmond;
                    }


                    this.dgvInformacion.Rows[i].Cells["EstadoBD"].Value = dtDatos.Rows[i]["Estado"].ToString();
                    this.dgvInformacion.Rows[i].Cells["ID"].Value = dtDatos.Rows[i]["ID"].ToString();
                    this.dgvInformacion.Rows[i].Cells["Nombre"].Value = dtDatos.Rows[i]["Nombre"].ToString();
                    this.dgvInformacion.Rows[i].Cells["Direccion"].Value = dtDatos.Rows[i]["Direccion"].ToString();
                    this.dgvInformacion.Rows[i].Cells["Telefono"].Value = dtDatos.Rows[i]["Teléfono"].ToString();
                    this.dgvInformacion.Rows[i].Cells["Correo"].Value = dtDatos.Rows[i]["Correo"].ToString();

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
                Font font = new Font(fontFamily, 12, FontStyle.Bold);
                this.dgvInformacion.ColumnHeadersDefaultCellStyle.Font = font;
                this.dgvInformacion.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;

                // Centramos el titulo de todas las columnas del GridView
                this.dgvInformacion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Noten que el nombre de las columnas corresponde a los alias (Ver consulta SELECT) de las columnas en la BD
                this.dgvInformacion.Columns["#"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Cambiar tipo de fuente a toda una columna
                this.dgvInformacion.Columns["#"].DefaultCellStyle.Font = font;
                this.dgvInformacion.Columns["#"].DefaultCellStyle.ForeColor = Color.Blue; // Cambiar color de fuente

                // Establecemos el tamaño de las columnas del Gridview
                this.dgvInformacion.Columns["#"].Width = 40;
                this.dgvInformacion.Columns["Estado"].Width = 50;
                this.dgvInformacion.Columns["Editar"].Width = 50;
                this.dgvInformacion.Columns["ID"].Visible = false;          // La ocupo oculta, luego solo para usar su valor
                this.dgvInformacion.Columns["EstadoBD"].Visible = false;    // La ocupo oculta, luego solo para usar su valor
                this.dgvInformacion.Columns["Direccion"].Width = 250;

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
                qry = "UPDATE extensiones" + "\n";
                qry = qry + "SET status = " + Estado +  "\n";
                qry = qry + "WHERE id_extension = " + ID;
   
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
                MessageBox.Show("No se pudo establecer la conexión a la BD","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }

        }

        #endregion

        private void frmExtension_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult respuesta;

            respuesta = MessageBox.Show("¿Desea cerrar el formulario?", "Extensiones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
	        {
                e.Cancel = true;
	        }
	

        }

        private void gpbInformacion_Enter(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
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

        private void btnReporte_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvInformacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
