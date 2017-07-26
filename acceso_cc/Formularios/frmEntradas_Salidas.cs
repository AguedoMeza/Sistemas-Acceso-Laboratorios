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

// Para poder utilizar las Clases referentes a Excel
using Excel = Microsoft.Office.Interop.Excel;

// Poder utilizar la herramienta de Crystal Report
using CrystalReport = CrystalDecisions.CrystalReports.Engine;

namespace acceso_cc.Formularios
{
    public partial class frmEntradas_Salidas : Form
    {
        public frmEntradas_Salidas()
        {
            InitializeComponent();
        }






        public void LlenarGridDocentes()
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
                int extension = this.cboExtension.SelectedIndex + 1;
                SqlCommand Comando = new SqlCommand();

                qry = "";

                qry = @" SELECT doc.id_docente AS ID, per.nombre AS Nombre, per.ap_paterno AS ApellidoP, per.ap_materno AS ApellidoM
                FROM personas per INNER JOIN docentes doc ON per.id_persona = doc.id_persona 
                WHERE per.id_extension = " + extension + "\n";
                //                




                Comando.CommandText = qry;

                // Abrimos la conexion
                sqlCNX.Open();

                Comando.Connection = sqlCNX;
                SqlDataAdapter sqlAdaper = new SqlDataAdapter(Comando);
                DataTable dtDatos = new DataTable();
                sqlAdaper.Fill(dtDatos);

                // Cerramos la conexion
                sqlCNX.Close();

                // Agregar columnas al Datagridview (Base de Datos)


                this.dgvInformacion.Columns.Add("#", "#");
                this.dgvInformacion.Columns.Add("ID", "ID");
                this.dgvInformacion.Columns.Add("Nombre", "Nombre");
                this.dgvInformacion.Columns.Add("Apellido Paterno", "Apellido Paterno");
                this.dgvInformacion.Columns.Add("Apellido Materno", "Apellido Materno");



                DataGridViewImageColumn columnaImagenDos = new DataGridViewImageColumn();
                columnaImagenDos.Name = "EstadoIcono2";
                columnaImagenDos.HeaderText = "Asignar";
                dgvInformacion.Columns.Add(columnaImagenDos);


                //this.dgvInformacion.DataSource = dtDatos;

                // Recorrer el Datatable para tomar sus valores 1 a 1
                for (int i = 0; i < dtDatos.Rows.Count; i++)
                {
                    //mi_variable = DataTable.Rows[i]["NombreCampo"].ToString();
                    this.dgvInformacion.Rows.Add(); // Agregar nueva fila al dataridview
                    this.dgvInformacion.Rows[i].Cells["#"].Value = i + 1;
                    this.dgvInformacion.Rows[i].Height = 25;
                    Color miColor = new Color();
                    miColor = Color.FromArgb(147, 49, 30);
                    Color similar = new Color();
                    similar = Color.FromArgb(52, 152, 219);

                    Color claro = new Color();
                    claro = Color.FromArgb(107, 185, 240);

                    this.dgvInformacion.Rows[i].Cells["ID"].Value = dtDatos.Rows[i]["ID"].ToString();

                    this.dgvInformacion.Rows[i].Cells["Nombre"].Value = dtDatos.Rows[i]["Nombre"].ToString();
                    this.dgvInformacion.Rows[i].Cells["Apellido Paterno"].Value = dtDatos.Rows[i]["ApellidoP"].ToString();
                    this.dgvInformacion.Rows[i].Cells["Apellido materno"].Value = dtDatos.Rows[i]["ApellidoM"].ToString();




                    this.dgvInformacion.Rows[i].Cells["EstadoIcono2"].Value = Properties.Resources.activo; // COMO IDENTIFICAMOS LA COLUMNA

                    //if (dtDatos.Rows[i]["Estado"].ToString() == "1")
                    //{
                    //    this.dgvInformacion.Rows[i].Cells["EstadoIcono2"].Value = Properties.Resources.activo; // COMO IDENTIFICAMOS LA COLUMNA

                    //}
                    //else
                    //{
                    //    this.dgvInformacion.Rows[i].Cells["EstadoIcono2"].Value = Properties.Resources.inactivo;

                    //}


                    if ((i + 1) % 2 == 0) //COLOR DE LA CELDAS
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
                Font font = new Font(fontFamily, 10, FontStyle.Bold);
                this.dgvInformacion.ColumnHeadersDefaultCellStyle.Font = font;
                this.dgvInformacion.Columns["#"].DefaultCellStyle.Font = font;


                // Centramos el titulo de todas las columnas del GridView
                this.dgvInformacion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Noten que el nombre de las columnas corresponde a los alias (Ver consulta SELECT) de las columnas en la BD
                this.dgvInformacion.Columns["#"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvInformacion.Columns["Nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvInformacion.Columns["Apellido Paterno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvInformacion.Columns["Apellido Materno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



                // Cambiar tipo de fuente a toda una columna
                this.dgvInformacion.Columns["#"].DefaultCellStyle.Font = font;
                this.dgvInformacion.Columns["#"].DefaultCellStyle.ForeColor = Color.Blue; // Cambiar color de fuente

                // Establecemos el tamaño de las columnas del Gridview
                this.dgvInformacion.Columns["#"].Width = 20;
                this.dgvInformacion.Columns["EstadoIcono2"].Width = 80;

                this.dgvInformacion.Columns["ID"].Visible = false;          // La ocupo oculta, luego solo para usar su valor







            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Err
            }
        }



        private bool EstanCamposLlenos()
        {
            if (this.lblClave.Text == String.Empty)
            {
                MessageBox.Show("Primero debes asignar un docente", "Registro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;

            }

            return true;
        }




        //    public void CamposActualizar()
        //{
        //    string ciclo = this.cboCiclo.Text;
        //    string extension = this.cboExtension.Text;
        //    string laboratorio = this.cboLaboratorios.Text;
        //    string year = this.cboYear.Text;
        //    string tcarrera = this.cboTipoCarrera.Text;
        //    string siglas = this.cboSiglas.Text;
        //    string tetra = this.cboTetra.Text;
        //    string grupo = this.cboTetra.Text;
        //    string turno = this.cboTurno.Text;

        //}



        private void frmEntradas_Salidas_Load(object sender, EventArgs e)
        {

            this.LlenarComboExtension();
            this.cboExtension.SelectedValue = 1;

            this.LlenarComboTipoCarrera();
            this.cboTipoCarrera.SelectedValue = 1;

            this.LlenarComboLaboratorios();
            //this.cboLaboratorios.SelectedValue = 1;

            this.LlenarComboSiglas();
            this.cboExtension.SelectedValue = 1;

            this.LlenarComboTetra();
            this.cboTetra.Text = "1";

            this.LlenarComboLGrupo();
            this.cboLGrupo.Text = "A";

            this.LlenarComboYear();
            this.cboYear.Text = "2016";

            this.LlenarComboCiclo();
            this.cboCiclo.Text = "Ene - Abr";
            this.cboTurno.Text = "Matutino";
            this.cboTurno.DropDownStyle = ComboBoxStyle.DropDownList;

            this.LlenarGridDocentes();
            this.LlenarGridRegistrosES();


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


                qry = "SELECT id_extension AS ID, nombre AS Nombre" + "\n";
                qry = qry + "FROM extensiones" + "\n";

                qry = qry + "ORDER BY id_extension" + "\n";


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
                this.cboExtension.DataSource = dtDatos;       // Le decimos que la fuente es el DataTable
                this.cboExtension.ValueMember = "ID";         // Este ValueMenber no se observa, ojo que es el ID que mandaremos a la BD
                this.cboExtension.DisplayMember = "Nombre";

                this.cboExtension.DropDownStyle = ComboBoxStyle.DropDownList;
                //this.cboEstado.ValueMember = "ID";         // Este ValueMenber no se observa, ojo que es el ID que mandaremos a la BD
                //this.cboEstado.DisplayMember = "Nombre";   // Esto es lo que se mostrara en el campo.

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


                qry = "SELECT id_tipo_carrera AS ID, nombre AS Nombre" + "\n";
                qry = qry + "FROM tipo_carreras" + "\n";
                qry = qry + "ORDER BY id_tipo_carrera" + "\n";


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


                // Ojo la siguiente propiedad me impedira escribir algo en el combo
                this.cboTipoCarrera.DropDownStyle = ComboBoxStyle.DropDownList;

            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Err
            }
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
                int ext = this.cboExtension.SelectedIndex + 1;
                SqlCommand Comando = new SqlCommand();


                qry = "SELECT l.id_laboratorio AS ID, l.nombre AS Nombre" + "\n";
                qry = qry + "FROM laboratorios l" + "\n";
                qry = qry + "inner join extensiones e on e.id_extension = l.id_extension " + "\n";
                qry = qry + "WHERE e.id_extension = " + ext + "\n";


                //                SELECT l.id_laboratorio AS ID, l.nombre AS Nombre
                //FROM  laboratorios l
                //inner join extensiones e on e.id_extension = l.id_extension
                //where e.id_extension = 1
                //qry = qry + "ORDER BY id_laboratorio" + "\n";


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
                this.cboLaboratorios.DataSource = dtDatos;       // Le decimos que la fuente es el DataTable
                this.cboLaboratorios.ValueMember = "ID";         // Este ValueMenber no se observa, ojo que es el ID que mandaremos a la BD
                this.cboLaboratorios.DisplayMember = "Nombre";

                this.cboLaboratorios.DropDownStyle = ComboBoxStyle.DropDownList;
                //this.cboEstado.ValueMember = "ID";         // Este ValueMenber no se observa, ojo que es el ID que mandaremos a la BD
                //this.cboEstado.DisplayMember = "Nombre";   // Esto es lo que se mostrara en el campo.

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

        private void cboLaboratorios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmEntradas_Salidas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmEntradas_Salidas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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


                qry = "SELECT id_carrera AS ID, siglas AS Siglas" + "\n";
                qry = qry + "FROM carreras" + "\n";

                qry = qry + "ORDER BY id_carrera" + "\n";


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
                this.cboSiglas.DisplayMember = "Siglas";

                this.cboSiglas.DropDownStyle = ComboBoxStyle.DropDownList;
                //this.cboEstado.ValueMember = "ID";         // Este ValueMenber no se observa, ojo que es el ID que mandaremos a la BD
                //this.cboEstado.DisplayMember = "Nombre";   // Esto es lo que se mostrara en el campo.

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


        private void LlenarComboTetra()
        {

            int i = 0;
            for (i = 1; i <= 11; i++)
            {
                this.cboTetra.Items.Add(i);

            }

            this.cboTetra.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private void LlenarComboLGrupo()
        {


            this.cboLGrupo.Items.Add("A");
            this.cboLGrupo.Items.Add("B");
            this.cboLGrupo.Items.Add("C");

            this.cboLGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LlenarComboYear()
        {

            int i = 0;
            for (i = 2016; i <= 2024; i++)
            {
                this.cboYear.Items.Add(i);

            }

            this.cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LlenarComboCiclo()
        {


            this.cboCiclo.Items.Add("Ene - Abr");
            this.cboCiclo.Items.Add("May - Ago");
            this.cboCiclo.Items.Add("Sep - Dic");

            this.cboCiclo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cboExtension_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LlenarComboLaboratorios();
            this.LlenarGridDocentes();
        }

        private void dgvInformacion_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                this.dgvInformacion.Cursor = Cursors.Hand;
            }
            else
            {
                this.dgvInformacion.Cursor = Cursors.Arrow;
            }
        }

        private void dgvInformacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // PENDIENTE: ES UN EVENTO PARA CAMBIAR EL ESTADO AL DAR CLIC
            //MessageBox.Show(dgvInformacion.CurrentCell.Value.ToString());

            DialogResult respuesta;

            int filaActual = this.dgvInformacion.CurrentRow.Index;
            //int estado = int.Parse(this.dgvInformacion.Rows[filaActual].Cells["Asignar"].Value.ToString());
            int clave = int.Parse(this.dgvInformacion.Rows[filaActual].Cells["ID"].Value.ToString());
            string docente = this.dgvInformacion.Rows[filaActual].Cells["Nombre"].Value.ToString();



            switch (e.ColumnIndex)
            {
                case 5:
                    respuesta = MessageBox.Show("¿Deseas asignar el docente?", "Docentes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        lblExtension.Text = cboExtension.Text;
                        this.AsignarDocente(docente, clave);
                    }
                    break;
            }
        }


        private void AsignarDocente(string docente, int clave)
        {
            this.lblDocente.Text = docente.ToString();

            this.lblClave.Text = clave.ToString();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
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
                    string horaE = dateTimePicker1.Value.ToString("HH:MM:ss");
                    string fecha = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                    string horaS = dateTimePicker3.Value.ToString("HH:MM:ss");

                    string periodo = cboCiclo.Text + " " + cboYear.Text;
                    string grupo = cboSiglas.Text + cboTetra.Text + "-" + cboLGrupo.Text + this.Turno(this.cboTurno.Text);
                    //string fecha = D
                    // Variable para almacenar la consulta en una cadena de texto
                    string qry = "";

                    // Verifiquen que aqui solo pongo la consulta de inserción 
                    // Pues ya tengo instanciados todos los objetos nescesarios
                    // Nota: Repasen la sintaxis del INSERT INTO
                    qry = "INSERT INTO registro_cc (id_extension, id_docente, id_tipo_carrera, id_carrera, id_laboratorio, fecha, hora_entrada, hora_salida, periodo, grupo, turno)" + "\n";
                    qry = qry + "VALUES('" + cboExtension.SelectedValue + "', ";
                    qry = qry + "'" + lblClave.Text + "', ";
                    qry = qry + "'" + cboTipoCarrera.SelectedValue + "', ";
                    qry = qry + "'" + cboSiglas.SelectedValue + "', ";
                    qry = qry + "'" + cboLaboratorios.SelectedValue + "', ";
                    qry = qry + "'" + fecha + "',";
                    qry = qry + "'" + horaE + "',";
                    qry = qry + "'" + horaS + "',";
                    qry = qry + "'" + periodo + "',";
                    qry = qry + "'" + grupo + "',";
                    qry = qry + "'" + cboTurno.Text + "')";




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

                    MessageBox.Show("Se agregó un registro correctamente", "Entradas y Salidas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Limpiar();
                    this.LlenarGridRegistrosES();
                    //this.LlenarGrid();

                }

                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show("No se pudo establecer la conexión a la BD","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }
            }

        }



        public void LlenarGridRegistrosES()
        {

            // Vaciar Data Grid
            this.dgvRegistroES.DataSource = null;
            this.dgvRegistroES.Rows.Clear();
            this.dgvRegistroES.Columns.Clear();

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
                    qry = @" SELECT r.id_entrada_salida AS ID, (per.nombre + ' ' + per.ap_paterno + ' ' + per.ap_materno) AS Docente,  ex.nombre AS Extension,  carr.nombre AS Carrera, r.grupo AS Grupo,   tic.nombre AS Nivel, lab.nombre AS Laboratorio, r.turno As Turno, r.periodo AS Periodo,   r.fecha AS Fecha, r.hora_entrada AS Hora_Entrada, r.hora_salida AS Hora_Salida
                        from registro_cc r
                        inner join extensiones ex ON r.id_extension = ex.id_extension
                        INNER JOIN personas per ON r.id_docente = per.id_persona 
                        inner join tipo_carreras tic ON r.id_tipo_carrera = tic.id_tipo_carrera
                        inner join carreras carr ON r.id_carrera =carr.id_carrera
                        inner join laboratorios lab ON r.id_laboratorio = lab.id_laboratorio
                        INNER JOIN docentes doc ON per.id_persona = doc.id_persona 
                        order by r.id_entrada_salida";
                }
                else
                {
                    qry = @" SELECT r.id_entrada_salida AS ID, (per.nombre + ' ' + per.ap_paterno + ' ' + per.ap_materno) AS Docente,  ex.nombre AS Extension,  carr.nombre AS Carrera, r.grupo AS Grupo,   tic.nombre AS Nivel, lab.nombre AS Laboratorio, r.turno As Turno, r.periodo AS Periodo,   r.fecha AS Fecha, r.hora_entrada AS Hora_Entrada, r.hora_salida AS Hora_Salida
                        from registro_cc r
                        inner join extensiones ex ON r.id_extension = ex.id_extension
                        INNER JOIN personas per ON r.id_docente = per.id_persona 
                        inner join tipo_carreras tic ON r.id_tipo_carrera = tic.id_tipo_carrera
                        inner join carreras carr ON r.id_carrera =carr.id_carrera
                        inner join laboratorios lab ON r.id_laboratorio = lab.id_laboratorio
                        INNER JOIN docentes doc ON per.id_persona = doc.id_persona 
                        WHERE Docente LIKE '%" + this.txtBuscar.Text + "%' ex.nombre LIKE '%" + this.txtBuscar.Text + "%' order by r.id_entrada_salida";

                }

                //              




                Comando.CommandText = qry;

                // Abrimos la conexion
                sqlCNX.Open();

                Comando.Connection = sqlCNX;
                SqlDataAdapter sqlAdaper = new SqlDataAdapter(Comando);
                DataTable dtDatos = new DataTable();
                sqlAdaper.Fill(dtDatos);

                // Cerramos la conexion
                sqlCNX.Close();

                // Agregar columnas al Datagridview (Base de Datos)


                this.dgvRegistroES.Columns.Add("#", "#");
                this.dgvRegistroES.Columns.Add("ID", "ID");
                this.dgvRegistroES.Columns.Add("Docente", "Docente");
                this.dgvRegistroES.Columns.Add("Extension", "Extension");
                this.dgvRegistroES.Columns.Add("Carrera", "Carrera");
                this.dgvRegistroES.Columns.Add("Grupo", "Grupo");
                this.dgvRegistroES.Columns.Add("Nivel", "Nivel");
                this.dgvRegistroES.Columns.Add("Laboratorio", "Laboratorio");
                this.dgvRegistroES.Columns.Add("Turno", "Turno");
                this.dgvRegistroES.Columns.Add("Periodo", "Periodo");
                this.dgvRegistroES.Columns.Add("Fecha", "Fecha");
                this.dgvRegistroES.Columns.Add("Hora_Entrada", "Hora_Entrada");
                this.dgvRegistroES.Columns.Add("Hora_Salida", "Hora_Salida");



                DataGridViewImageColumn columnaImagenDos = new DataGridViewImageColumn();
                columnaImagenDos.Name = "Editar2";
                columnaImagenDos.HeaderText = "Editar";
                dgvRegistroES.Columns.Add(columnaImagenDos);


                //this.dgvInformacion.DataSource = dtDatos;

                // Recorrer el Datatable para tomar sus valores 1 a 1
                for (int i = 0; i < dtDatos.Rows.Count; i++)
                {
                    //mi_variable = DataTable.Rows[i]["NombreCampo"].ToString();
                    this.dgvRegistroES.Rows.Add(); // Agregar nueva fila al dataridview
                    this.dgvRegistroES.Rows[i].Cells["#"].Value = i + 1;
                    this.dgvRegistroES.Rows[i].Height = 25;
                    this.dgvRegistroES.Rows[i].Cells["ID"].Value = dtDatos.Rows[i]["ID"].ToString();

                    this.dgvRegistroES.Rows[i].Cells["Docente"].Value = dtDatos.Rows[i]["Docente"].ToString();
                    this.dgvRegistroES.Rows[i].Cells["Extension"].Value = dtDatos.Rows[i]["Extension"].ToString();
                    this.dgvRegistroES.Rows[i].Cells["Carrera"].Value = dtDatos.Rows[i]["Carrera"].ToString();
                    this.dgvRegistroES.Rows[i].Cells["Grupo"].Value = dtDatos.Rows[i]["Grupo"].ToString();
                    this.dgvRegistroES.Rows[i].Cells["Nivel"].Value = dtDatos.Rows[i]["Nivel"].ToString();
                    this.dgvRegistroES.Rows[i].Cells["Laboratorio"].Value = dtDatos.Rows[i]["Laboratorio"].ToString();
                    this.dgvRegistroES.Rows[i].Cells["Turno"].Value = dtDatos.Rows[i]["Turno"].ToString();
                    this.dgvRegistroES.Rows[i].Cells["Periodo"].Value = dtDatos.Rows[i]["Periodo"].ToString();
                    this.dgvRegistroES.Rows[i].Cells["Fecha"].Value = dtDatos.Rows[i]["Fecha"].ToString();
                    this.dgvRegistroES.Rows[i].Cells["Hora_Entrada"].Value = dtDatos.Rows[i]["Hora_Entrada"].ToString();
                    this.dgvRegistroES.Rows[i].Cells["Hora_Salida"].Value = dtDatos.Rows[i]["Hora_Salida"].ToString();




                    this.dgvRegistroES.Rows[i].Cells["Editar2"].Value = Properties.Resources.editar; // COMO IDENTIFICAMOS LA COLUMNA

                    //if (dtDatos.Rows[i]["Estado"].ToString() == "1")
                    //{
                    //    this.dgvInformacion.Rows[i].Cells["EstadoIcono2"].Value = Properties.Resources.activo; // COMO IDENTIFICAMOS LA COLUMNA

                    //}
                    //else
                    //{
                    //    this.dgvInformacion.Rows[i].Cells["EstadoIcono2"].Value = Properties.Resources.inactivo;

                    //}


                    if ((i + 1) % 2 == 0) //COLOR DE LA CELDAS
                    {
                        this.dgvRegistroES.Rows[i].DefaultCellStyle.BackColor = Color.Aquamarine;
                    }
                    else
                    {
                        this.dgvRegistroES.Rows[i].DefaultCellStyle.BackColor = Color.DarkCyan;
                    }

                }

                // Encabezados de columnas en negritas (Con un estilo de fuente nuevo)
                FontFamily fontFamily = new FontFamily("Arial");
                Font font = new Font(fontFamily, 10, FontStyle.Bold);
                this.dgvRegistroES.ColumnHeadersDefaultCellStyle.Font = font;
                this.dgvRegistroES.Columns["#"].DefaultCellStyle.Font = font;


                // Centramos el titulo de todas las columnas del GridView
                this.dgvInformacion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Noten que el nombre de las columnas corresponde a los alias (Ver consulta SELECT) de las columnas en la BD
                this.dgvRegistroES.Columns["#"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


                // Cambiar tipo de fuente a toda una columna
                this.dgvRegistroES.Columns["#"].DefaultCellStyle.Font = font;
                this.dgvRegistroES.Columns["#"].DefaultCellStyle.ForeColor = Color.Blue; // Cambiar color de fuente

                // Establecemos el tamaño de las columnas del Gridview
                this.dgvRegistroES.Columns["#"].Width = 20;
                this.dgvRegistroES.Columns["Fecha"].Width = 80;


                this.dgvRegistroES.Columns["ID"].Visible = false;          // La ocupo oculta, luego solo para usar su valor







            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Err
            }
        }


        private string Turno(String TurnoCompleto)
        {

            string letra = "";

            if (TurnoCompleto.Equals("Matutino"))
            {
                letra = "M";
            }
            else if (TurnoCompleto.Equals("Vespertino"))
            {
                letra = "V";
            }
            else
            {
                letra = "S";
            }

            return letra;

        }

        private void dateTimePicker1_FormatChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvRegistroES_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // PENDIENTE: ES UN EVENTO PARA CAMBIAR EL ESTADO AL DAR CLIC
            //MessageBox.Show(dgvInformacion.CurrentCell.Value.ToString());

            DialogResult respuesta;

            int filaActual = this.dgvInformacion.CurrentRow.Index;
            //int estado = int.Parse(this.dgvInformacion.Rows[filaActual].Cells["Editar"].Value.ToString());
            int id = int.Parse(this.dgvInformacion.Rows[filaActual].Cells["ID"].Value.ToString());



            switch (e.ColumnIndex)
            {
                case 13:
                    respuesta = MessageBox.Show("¿Deseas editar el registro?", "Entradas y Salidas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        frmEntradasSalidasActualizar form = new frmEntradasSalidasActualizar();
                        form.ID = id;
                        form.FormClosing += new FormClosingEventHandler(form_FormClosing);
                        form.ShowDialog();
                     }
                    break;
            }
        }


        void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.LlenarGridRegistrosES();
        }
        private void dgvRegistroES_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvRegistroES_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex.Equals(13))
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
            peterRiver = Color.FromArgb(0, 255, 255);
            Color negro = new Color();
            negro = Color.FromArgb(0, 0, 102);
            Color emerald = new Color();
            emerald = Color.FromArgb(46, 204, 113);


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
                qry = "SELECT id_persona AS ID, nombre AS Nombre, ap_paterno AS Apellido_Paterno, ap_materno AS Apellido_Materno, fecha_nacimiento AS Fecha_de_Nacimiento, sexo AS Sexo, telefono AS Teléfono, correo AS Correo, calle AS Calle, numero AS Número, colonia AS Colonia, cp AS Código_Postal, municipio AS Municipio, estado AS Estado, status AS Status" + "\n";
                qry = qry + "FROM personas" + "\n";

            }
            else
            {
                qry = "SELECT id_persona AS ID, nombre AS Nombre, ap_paterno AS Apellido_Paterno, ap_materno AS Apellido_Materno, fecha_nacimiento AS Fecha_de_Nacimiento, sexo AS Sexo, telefono AS Teléfono, correo AS Correo, calle AS Calle, numero AS Número, colonia AS Colonia, cp AS Código_Postal, municipio AS Municipio, estado AS Estado, status AS Status" + "\n";
                qry = qry + "FROM personas" + "\n";
                qry = qry + "WHERE nombre LIKE '%" + this.txtBuscar.Text + "%' OR direccion LIKE '%" + this.txtBuscar.Text + "%'";
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

                    hoja.Range["A1:M1"].Interior.Color = negro;
                    hoja.Range["A1:M1"].Font.Color = Color.White;
                    hoja.Range["A:M"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    hoja.Range["A:M"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;


                    hoja.Cells[1, 1] = "#";
                    hoja.Cells[1, 2] = "Id";
                    hoja.Cells[1, 3] = "Nombre";
                    hoja.Cells[1, 4] = "Fecha_de_Nacimiento";
                    hoja.Cells[1, 5] = "Sexo";
                    hoja.Cells[1, 6] = "Teléfono";
                    hoja.Cells[1, 7] = "Correo";
                    hoja.Cells[1, 8] = "Calle";
                    hoja.Cells[1, 9] = "Número";
                    hoja.Cells[1, 10] = "Colonia";
                    hoja.Cells[1, 11] = "Código_Postal";
                    hoja.Cells[1, 12] = "Municipio";
                    hoja.Cells[1, 13] = "Estado";


                    while (sqlDR.Read() == true)
                    {
                        hoja.Cells[i, 1] = i - 1;
                        hoja.Cells[i, 2] = sqlDR["Id"].ToString();
                        hoja.Cells[i, 3] = sqlDR["Nombre"].ToString();
                        hoja.Cells[i, 4] = sqlDR["Fecha_de_Nacimiento"].ToString();
                        hoja.Cells[i, 5] = sqlDR["Sexo"].ToString();
                        hoja.Cells[i, 6] = sqlDR["Teléfono"].ToString();
                        hoja.Cells[i, 7] = sqlDR["Correo"].ToString();
                        hoja.Cells[i, 8] = sqlDR["Calle"].ToString();
                        hoja.Cells[i, 9] = sqlDR["Número"].ToString();
                        hoja.Cells[i, 10] = sqlDR["Colonia"].ToString();
                        hoja.Cells[i, 11] = sqlDR["Código_Postal"].ToString();
                        hoja.Cells[i, 12] = sqlDR["Municipio"].ToString();
                        hoja.Cells[i, 13] = sqlDR["Estado"].ToString();





                        if ((i % 2) == 0)
                        {
                            hoja.Range["A" + i + ":" + "M" + i].Interior.Color = peterRiver;
                        }
                        else
                        {
                            hoja.Range["A" + i + ":" + "M" + i].Interior.Color = emerald;
                        }

                        i++;
                    }

                    hoja.Columns["A:M"].AutoFit();


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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.LlenarGridRegistrosES();
        }

        private void btnEcxel_Click(object sender, EventArgs e)
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
            peterRiver = Color.FromArgb(0, 255, 255);
            Color negro = new Color();
            negro = Color.FromArgb(0, 0, 102);
            Color emerald = new Color();
            emerald = Color.FromArgb(46, 204, 113);

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
                qry = @" SELECT r.id_entrada_salida AS ID, (per.nombre + ' ' + per.ap_paterno + ' ' + per.ap_materno) AS Docente,  ex.nombre AS Extension,  carr.nombre AS Carrera, r.grupo AS Grupo,   tic.nombre AS Nivel, lab.nombre AS Laboratorio, r.turno As Turno, r.periodo AS Periodo,   r.fecha AS Fecha, r.hora_entrada AS Hora_Entrada, r.hora_salida AS Hora_Salida
                        from registro_cc r
                        inner join extensiones ex ON r.id_extension = ex.id_extension
                        INNER JOIN personas per ON r.id_docente = per.id_persona 
                        inner join tipo_carreras tic ON r.id_tipo_carrera = tic.id_tipo_carrera
                        inner join carreras carr ON r.id_carrera =carr.id_carrera
                        inner join laboratorios lab ON r.id_laboratorio = lab.id_laboratorio
                        INNER JOIN docentes doc ON per.id_persona = doc.id_persona 
                        order by r.id_entrada_salida";

            }
            else
            {
                qry = @" SELECT r.id_entrada_salida AS ID, (per.nombre + ' ' + per.ap_paterno + ' ' + per.ap_materno) AS Docente,  ex.nombre AS Extension,  carr.nombre AS Carrera, r.grupo AS Grupo,   tic.nombre AS Nivel, lab.nombre AS Laboratorio, r.turno As Turno, r.periodo AS Periodo,   r.fecha AS Fecha, r.hora_entrada AS Hora_Entrada, r.hora_salida AS Hora_Salida
                        from registro_cc r
                        inner join extensiones ex ON r.id_extension = ex.id_extension
                        INNER JOIN personas per ON r.id_docente = per.id_persona 
                        inner join tipo_carreras tic ON r.id_tipo_carrera = tic.id_tipo_carrera
                        inner join carreras carr ON r.id_carrera =carr.id_carrera
                        inner join laboratorios lab ON r.id_laboratorio = lab.id_laboratorio
                        INNER JOIN docentes doc ON per.id_persona = doc.id_persona 
                        WHERE Docente LIKE '%" + this.txtBuscar.Text + "%' ex.nombre LIKE '%" + this.txtBuscar.Text + "%' order by r.id_entrada_salida";
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
                hoja.Name = "Entradas y Salidas";


                // Validamos que el DataReader tenga informacion
                if (sqlDR.HasRows == true)
                {
                    i = 2;

                    hoja.Range["A1:M1"].Interior.Color = negro;
                    hoja.Range["A1:M1"].Font.Color = Color.White;
                    hoja.Range["A:M"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    hoja.Range["A:M"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;


                    hoja.Cells[1, 1] = "#";
                    hoja.Cells[1, 2] = "ID";
                    hoja.Cells[1, 3] = "Docente";
                    hoja.Cells[1, 4] = "Extension";
                    hoja.Cells[1, 5] = "Carrera";
                    hoja.Cells[1, 6] = "Grupo";
                    hoja.Cells[1, 7] = "Nivel";
                    hoja.Cells[1, 8] = "Laboratorio";
                    hoja.Cells[1, 9] = "Turno";
                    hoja.Cells[1, 10] = "Periodo";
                    hoja.Cells[1, 11] = "Fecha";
                    hoja.Cells[1, 12] = "Hora_entrada";
                    hoja.Cells[1, 13] = "Hora_salida";



                    while (sqlDR.Read() == true)
                    {
                        hoja.Cells[i, 1] = i - 1;
                        hoja.Cells[i, 2] = sqlDR["Id"].ToString();
                        hoja.Cells[i, 3] = sqlDR["Docente"].ToString();
                        hoja.Cells[i, 4] = sqlDR["Extension"].ToString();
                        hoja.Cells[i, 5] = sqlDR["Carrera"].ToString();
                        hoja.Cells[i, 6] = sqlDR["Grupo"].ToString();
                        hoja.Cells[i, 7] = sqlDR["Nivel"].ToString();
                        hoja.Cells[i, 8] = sqlDR["Laboratorio"].ToString();
                        hoja.Cells[i, 9] = sqlDR["Turno"].ToString();
                        hoja.Cells[i, 10] = sqlDR["Periodo"].ToString();
                        hoja.Cells[i, 11] = sqlDR["Fecha"].ToString();
                        hoja.Cells[i, 12] = sqlDR["Hora_entrada"].ToString();
                        hoja.Cells[i, 13] = sqlDR["Hora_salida"].ToString();






                        if ((i % 2) == 0)
                        {
                            hoja.Range["A" + i + ":" + "M" + i].Interior.Color = similar;
                        }
                        else
                        {
                            hoja.Range["A" + i + ":" + "M" + i].Interior.Color = claro;
                        }

                        i++;
                    }

                    hoja.Columns["A:M"].AutoFit();


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
                qry = @" SELECT r.id_entrada_salida AS ID, (per.nombre + ' ' + per.ap_paterno + ' ' + per.ap_materno) AS Docente,  ex.nombre AS Extension,  carr.nombre AS Carrera, r.grupo AS Grupo,   tic.nombre AS Nivel, lab.nombre AS Laboratorio, r.turno As Turno, r.periodo AS Periodo,   r.fecha AS Fecha, r.hora_entrada AS Hora_Entrada, r.hora_salida AS Hora_Salida
                        from registro_cc r
                        inner join extensiones ex ON r.id_extension = ex.id_extension
                        INNER JOIN personas per ON r.id_docente = per.id_persona 
                        inner join tipo_carreras tic ON r.id_tipo_carrera = tic.id_tipo_carrera
                        inner join carreras carr ON r.id_carrera =carr.id_carrera
                        inner join laboratorios lab ON r.id_laboratorio = lab.id_laboratorio
                        INNER JOIN docentes doc ON per.id_persona = doc.id_persona 
                        order by r.id_entrada_salida";

            }
            else
            {
                qry = @" SELECT r.id_entrada_salida AS ID, (per.nombre + ' ' + per.ap_paterno + ' ' + per.ap_materno) AS Docente,  ex.nombre AS Extension,  carr.nombre AS Carrera, r.grupo AS Grupo,   tic.nombre AS Nivel, lab.nombre AS Laboratorio, r.turno As Turno, r.periodo AS Periodo,   r.fecha AS Fecha, r.hora_entrada AS Hora_Entrada, r.hora_salida AS Hora_Salida
                        from registro_cc r
                        inner join extensiones ex ON r.id_extension = ex.id_extension
                        INNER JOIN personas per ON r.id_docente = per.id_persona 
                        inner join tipo_carreras tic ON r.id_tipo_carrera = tic.id_tipo_carrera
                        inner join carreras carr ON r.id_carrera =carr.id_carrera
                        inner join laboratorios lab ON r.id_laboratorio = lab.id_laboratorio
                        INNER JOIN docentes doc ON per.id_persona = doc.id_persona 
                        WHERE Docente LIKE '%" + this.txtBuscar.Text + "%' ex.nombre LIKE '%" + this.txtBuscar.Text + "%' order by r.id_entrada_salida";
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
                crReport.Load(path + "\\Reportes" + "\\crEntradasSalidas.rpt");
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

    }


}

