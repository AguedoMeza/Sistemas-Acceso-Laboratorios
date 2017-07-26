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
    public partial class frmDocentes : Form
    {
        public frmDocentes()
        {
            InitializeComponent();
        }

        private void frmDocentes_Load(object sender, EventArgs e)
        {
            this.LlenarGrid();
            this.LlenarGridDocentes();
            this.gpbInformacion.Enabled = false;

        }

        //METODOS
        private void Limpiar()
        {
            this.txtBuscarPersona.Text = String.Empty;
            this.lblNombreCompleto.Text = String.Empty;
            this.lblExtension.Text = String.Empty;
            this.lblIdPersona.Text = String.Empty;
            this.txtClave.Text = String.Empty;


            SystemSounds.Beep.Play();
        }

        private bool EstanCamposLlenos()
        {
            if (this.txtClave.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Docentes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtClave.Focus();
                return false;
            }

            return true;
        }

        private bool ConfirmarClave()
        {
            string qry = "";
            string verificarClave = "";
            

            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");
            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);
            SqlCommand sqlCMD = new SqlCommand();


            qry = "SELECT id_docente AS Clave" + "\n";
            qry = qry + "FROM docentes" + "\n";
            qry = qry + " WHERE id_docente = '" + this.txtClave.Text + "'";

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
                        verificarClave = sqlDR["Clave"].ToString();
                        
                    }
                }

                sqlCNX.Close();
            }


            catch (SqlException)
            {

                MessageBox.Show("No se pudo Conectar con a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (verificarClave == this.txtClave.Text)
            {
                MessageBox.Show("La clave existente, ingresa otra", "Docentes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtClave.Text = String.Empty;
                this.txtClave.Focus();
                this.gpbInformacion.Enabled = true;
                return false;
            }
            return true;
        }

        public void LlenarGrid()
        {

            // Vaciar Data Grid
            this.dgvInformacionPersona.DataSource = null;
            this.dgvInformacionPersona.Rows.Clear();
            this.dgvInformacionPersona.Columns.Clear();

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

                if (this.txtBuscarPersona.Text == String.Empty)
                {
                    qry = @"SELECT per.id_persona AS ID, (per.nombre + ' ' + per.ap_paterno + ' ' + per.ap_materno) AS Nombre, ex.nombre AS Extension
                            FROM personas as per LEFT JOIN docentes as doc 
                            ON per.id_persona = doc.id_persona
                            LEFT JOIN extensiones as ex
                            ON ex.id_extension = per.id_extension
                            WHERE doc.id_persona IS NULL AND per.id_extension != 0
                            AND per.status =  1"; 


                }
                else
                {
                    qry = @"SELECT per.id_persona AS ID, (per.nombre + ' ' + per.ap_paterno + ' ' + per.ap_materno) AS Nombre, ex.nombre AS Extension
                            FROM personas as per LEFT JOIN docentes as doc 
                            ON per.id_persona = doc.id_persona
                            LEFT JOIN extensiones as ex
                            ON ex.id_extension = per.id_extension
                            WHERE doc.id_persona IS NULL AND per.id_extension != 0
                            AND per.status =  1"; 
                    qry = qry + "AND  per.nombre LIKE '%" + this.txtBuscarPersona.Text + "%' OR per.ap_paterno LIKE '%" + this.txtBuscarPersona.Text + "%' OR per.ap_materno LIKE '%" + this.txtBuscarPersona.Text + "%'";

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
                this.dgvInformacionPersona.Columns.Add("#", "#"); //0

                //this.dgvInformacion.Columns.Add("ID", "ID");
                this.dgvInformacionPersona.Columns.Add("Nombre", "Nombre"); //1
                this.dgvInformacionPersona.Columns.Add("ID", "ID"); // 2
                this.dgvInformacionPersona.Columns.Add("Extension", "Extension"); //3

                DataGridViewImageColumn asignar = new DataGridViewImageColumn(); //4
                asignar.Name = "Asignar";
                dgvInformacionPersona.Columns.Add(asignar);



                //con esta solo linea yo puedo alimentar mi grilla, pero, no agrega las columnas especiales de tipo imagen y no permite saber cual es el estado individual del registro
                //osea no puedo personalizar las columnas 
                //
                //this.dgvInformacion.DataSource = dtDatos;
                //

                // Recorrer el Datatable para tomar sus valores 1 a 1
                for (int i = 0; i < dtDatos.Rows.Count; i++)
                {
                    //mi_variable = DataTable.Rows[i]["NombreCampo"].ToString();
                    this.dgvInformacionPersona.Rows.Add(); // Agregar nueva fila al dataridview
                    this.dgvInformacionPersona.Rows[i].Cells["#"].Value = i + 1;
                    //los 25 son de los pixeles que mide de altura cada registro
                    this.dgvInformacionPersona.Rows[i].Height = 20;

                    Color miColor = new Color();
                    miColor = Color.FromArgb(147, 49, 30);
                    Color similar = new Color();
                    similar = Color.FromArgb(52, 152, 219);

                    Color claro = new Color();
                    claro = Color.FromArgb(107, 185, 240);

                    this.dgvInformacionPersona.Rows[i].Cells["Asignar"].Value = Properties.Resources.editar;



                    //this.dgvInformacionPersona.Rows[i].Cells["ID"].Value = dtDatos.Rows[i]["ID"].ToString();
                    this.dgvInformacionPersona.Rows[i].Cells["Nombre"].Value = dtDatos.Rows[i]["Nombre"].ToString();
                    this.dgvInformacionPersona.Rows[i].Cells["Extension"].Value = dtDatos.Rows[i]["Extension"].ToString();
                    this.dgvInformacionPersona.Rows[i].Cells["ID"].Value = dtDatos.Rows[i]["ID"].ToString();

                    //Cambiar los colores de los registros, de fondo
                    if ((i + 1) % 2 == 0)
                    {
                        this.dgvInformacionPersona.Rows[i].DefaultCellStyle.BackColor = similar;
                    }
                    else
                    {
                        this.dgvInformacionPersona.Rows[i].DefaultCellStyle.BackColor = claro;
                    }
                }

                // Encabezados de columnas en negritas (Con un estilo de fuente nuevo)
                FontFamily fontFamily = new FontFamily("Arial");
                Font font = new Font(fontFamily, 9, FontStyle.Bold);
                this.dgvInformacionPersona.ColumnHeadersDefaultCellStyle.Font = font;



                // Centramos el titulo de todas las columnas del GridView
                this.dgvInformacionPersona.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Noten que el nombre de las columnas corresponde a los alias (Ver consulta SELECT) de las columnas en la BD
                this.dgvInformacionPersona.Columns["#"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Cambiar tipo de fuente a toda una columna
                this.dgvInformacionPersona.Columns["#"].DefaultCellStyle.Font = font;
                this.dgvInformacionPersona.Columns["#"].DefaultCellStyle.ForeColor = Color.Blue; // Cambiar color de fuente

                //Establecemos el tamaño de las columnas del Gridview
                this.dgvInformacionPersona.Columns["Nombre"].Width = 300;
                this.dgvInformacionPersona.Columns["#"].Width = 25;
                this.dgvInformacionPersona.Columns["Asignar"].Width = 65;

                this.dgvInformacionPersona.Columns["ID"].Visible = false;          // La ocupo oculta, luego solo para usar su valor
                this.dgvInformacionPersona.Columns["Extension"].Visible = false;


            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Err
            }
        }



        #region DATAGRIDDOCENTES
        public void LlenarGridDocentes()
        {

            // Vaciar Data Grid
            this.dgvDocentes.DataSource = null;
            this.dgvDocentes.Rows.Clear();
            this.dgvDocentes.Columns.Clear();

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

                if (this.txtBuscarDocente.Text == String.Empty)
                {
                    qry = "SELECT doc.id_docente AS ID,(per.nombre + ' ' + per.ap_paterno + ' ' + per.ap_materno) AS Nombre, ex.nombre AS Extension, doc.status AS Estado" + "\n";
                    qry = qry + "FROM docentes doc" + "\n";
                    qry = qry + "INNER JOIN personas per ON per.id_persona = doc.id_persona " + "\n";
                    qry = qry + "INNER JOIN extensiones ex ON per.id_extension = ex.id_extension" + "\n";
                    


                }
                else
                {


                    qry = "SELECT doc.id_docente AS ID,(per.nombre + ' ' + per.ap_paterno + ' ' + per.ap_materno) AS Nombre, ex.nombre AS Extension, doc.status AS Estado" + "\n";
                    qry = qry + "FROM docentes doc" + "\n";
                    qry = qry + "INNER JOIN personas per ON per.id_persona = doc.id_persona " + "\n";
                    qry = qry + "INNER JOIN extensiones ex ON per.id_extension = ex.id_extension" + "\n";
                    qry = qry + "WHERE per.nombre LIKE '%" + this.txtBuscarDocente.Text + "%' OR per.ap_paterno LIKE '%" + this.txtBuscarDocente.Text + "%' OR per.ap_materno LIKE '%" + this.txtBuscarDocente.Text + "%'";
                }



                //CONSULTA DGV ABAJO

                //qry = "SELECT doc.id_docente, per.id_persona AS ID, (per.nombre + ' ' + per.ap_paterno + per.ap_materno) AS Nombre, ex.nombre AS Extension" + "\n";
                //qry = qry + "FROM personas per" + "\n";
                //qry = qry + "INNER JOIN extensiones ex ON per.id_extension = ex.id_extension" + "\n";
                //qry = qry + "INNER JOIN docentes doc ON doc.id_persona = per.id_persona " + "\n";



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
                this.dgvDocentes.Columns.Add("#", "#"); //0
                this.dgvDocentes.Columns.Add("EstadoBD", "EstadoBD");//1
                this.dgvDocentes.Columns.Add("ID", "ID");//2
                this.dgvDocentes.Columns.Add("Nombre", "Nombre"); //3
                this.dgvDocentes.Columns.Add("Extension", "Extension");//4

                DataGridViewImageColumn columnaImagenUno = new DataGridViewImageColumn();
                columnaImagenUno.Name = "Estado";
                dgvDocentes.Columns.Add(columnaImagenUno);




                //con esta solo linea yo puedo alimentar mi grilla, pero, no agrega las columnas especiales de tipo imagen y no permite saber cual es el estado individual del registro
                //osea no puedo personalizar las columnas 
                //
                //this.dgvInformacion.DataSource = dtDatos;
                //

                // Recorrer el Datatable para tomar sus valores 1 a 1
                for (int i = 0; i < dtDatos.Rows.Count; i++)
                {
                    //mi_variable = DataTable.Rows[i]["NombreCampo"].ToString();
                    this.dgvDocentes.Rows.Add(); // Agregar nueva fila al dataridview
                    this.dgvDocentes.Rows[i].Cells["#"].Value = i + 1;
                    //los 25 son de los pixeles que mide de altura cada registro
                    this.dgvDocentes.Rows[i].Height = 20;
                    Color miColor = new Color();
                    miColor = Color.FromArgb(147, 49, 30);
                    Color similar = new Color();
                    similar = Color.FromArgb(52, 152, 219);

                    Color claro = new Color();
                    claro = Color.FromArgb(107, 185, 240);

                    if (dtDatos.Rows[i]["Estado"].ToString() == "1")
                    {
                        this.dgvDocentes.Rows[i].Cells["Estado"].Value = Properties.Resources.activo;

                    }
                    else
                    {
                        this.dgvDocentes.Rows[i].Cells["Estado"].Value = Properties.Resources.inactivo;

                    }



                    //this.dgvInformacionPersona.Rows[i].Cells["ID"].Value = dtDatos.Rows[i]["ID"].ToString();
                    this.dgvDocentes.Rows[i].Cells["ID"].Value = dtDatos.Rows[i]["ID"].ToString();
                    this.dgvDocentes.Rows[i].Cells["Nombre"].Value = dtDatos.Rows[i]["Nombre"].ToString();
                    this.dgvDocentes.Rows[i].Cells["Extension"].Value = dtDatos.Rows[i]["Extension"].ToString();
                    this.dgvDocentes.Rows[i].Cells["EstadoBD"].Value = dtDatos.Rows[i]["Estado"].ToString();



                    //Cambiar los colores de los registros, de fondo
                    if ((i + 1) % 2 == 0)
                    {
                        this.dgvDocentes.Rows[i].DefaultCellStyle.BackColor = similar;
                    }
                    else
                    {
                        this.dgvDocentes.Rows[i].DefaultCellStyle.BackColor = claro;
                    }
                }

                // Encabezados de columnas en negritas (Con un estilo de fuente nuevo)
                FontFamily fontFamily = new FontFamily("Arial");
                Font font = new Font(fontFamily, 9, FontStyle.Bold);
                this.dgvDocentes.ColumnHeadersDefaultCellStyle.Font = font;


                // Centramos el titulo de todas las columnas del GridView
                this.dgvDocentes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Noten que el nombre de las columnas corresponde a los alias (Ver consulta SELECT) de las columnas en la BD
                this.dgvDocentes.Columns["#"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Cambiar tipo de fuente a toda una columna
                this.dgvDocentes.Columns["#"].DefaultCellStyle.Font = font;
                this.dgvDocentes.Columns["#"].DefaultCellStyle.ForeColor = Color.Blue; // Cambiar color de fuente

                //Establecemos el tamaño de las columnas del Gridview
                this.dgvDocentes.Columns["#"].Width = 25;
                this.dgvDocentes.Columns["ID"].Visible = false;          // La ocupo oculta, luego solo para usar su valor
                this.dgvDocentes.Columns["Nombre"].Width = 300;
                this.dgvDocentes.Columns["Extension"].Width = 65;
                this.dgvDocentes.Columns["EstadoBD"].Visible = false;




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
                qry = "UPDATE docentes" + "\n";
                qry = qry + "SET status = " + Estado + "\n";
                qry = qry + "WHERE id_docente = " + ID;

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

        #endregion





        private void AsignarDocente(int IdPersona, string NombreCompleto, string Extension)
        {
            this.lblIdPersona.Text = IdPersona.ToString();
            this.lblNombreCompleto.Text = NombreCompleto;
            this.lblExtension.Text = Extension;

        }







        private void dgvInformacionPersona_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {


            //para el cursor
            if (e.ColumnIndex == 4)
            {
                this.dgvInformacionPersona.Cursor = Cursors.Hand;
            }
            else
            {
                this.dgvInformacionPersona.Cursor = Cursors.Arrow;
            }
        }

        private void dgvInformacionPersona_CellClick(object sender, DataGridViewCellEventArgs e)
        {



            //MessageBox.Show(dgvInformacion.CurrentCell.Value.ToString());

            DialogResult respuesta;

            int filaActual = this.dgvInformacionPersona.CurrentRow.Index;
            //int asignar = int.Parse(this.dgvInformacionPersona.Rows[filaActual].Cells["Asignar"].Value.ToString());
            int id = int.Parse(this.dgvInformacionPersona.Rows[filaActual].Cells["ID"].Value.ToString());
            string nombre = this.dgvInformacionPersona.Rows[filaActual].Cells["Nombre"].Value.ToString();
            string extension = this.dgvInformacionPersona.Rows[filaActual].Cells["Extension"].Value.ToString();


            switch (e.ColumnIndex)
            {
                case 4:
                    respuesta = MessageBox.Show("¿Desea asignar a Docente?", "Docentes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        this.AsignarDocente(id, nombre, extension);

                        this.gpbInformacion.Enabled = true;
                        this.gpbBuscarPersona.Enabled = false;
                    }

                    else
                    {

                        this.gpbInformacion.Enabled = false;
                    }
                    break;


            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.gpbInformacion.Enabled = false;
            this.gpbBuscarPersona.Enabled = true;
        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {

            //MessageBox.Show("Se agrego un registro correctamente", "Docentes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.Limpiar();
            //this.LlenarGrid(); //llenar el de abajo

            this.gpbInformacion.Enabled = false;



            if (this.EstanCamposLlenos() == true && this.ConfirmarClave() == true)
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





                    qry = "INSERT INTO docentes(id_docente, id_persona, status)" + "\n";
                    qry = qry + "VALUES('" + this.txtClave.Text + "', ";
                    qry = qry + "'" + this.lblIdPersona.Text + "', ";
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

                    MessageBox.Show("Se agrego un registro correctamente", "Docentes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Limpiar();
                    this.LlenarGrid();
                    this.LlenarGridDocentes();
                    
                }

                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show("No se pudo establecer la conexión a la BD","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }


            }



        }

        private void gpbBuscarPersona_Enter(object sender, EventArgs e)
        {

        }

        private void dgvDocentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDocentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult respuesta;

            int filaActual = this.dgvDocentes.CurrentRow.Index;
            int estado = int.Parse(this.dgvDocentes.Rows[filaActual].Cells["EstadoBD"].Value.ToString());
            int id = int.Parse(this.dgvDocentes.Rows[filaActual].Cells["ID"].Value.ToString());

            switch (e.ColumnIndex)
            {
                case 5:
                    respuesta = MessageBox.Show("¿Desea cambiar el estado del registro?", "Docentes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        this.CambiarEstado(id, estado);
                        this.LlenarGridDocentes();
                    }
                    break;

            }
        }

        private void frmDocentes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.LlenarGridDocentes();
        }

        private void dgvDocentes_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                this.dgvDocentes.Cursor = Cursors.Hand;
            }
            else
            {
                this.dgvDocentes.Cursor = Cursors.Arrow;
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

            if (this.txtBuscarDocente.Text == String.Empty)
            {
                qry = @"SELECT doc.id_docente,(per.nombre + ' ' + per.ap_paterno + per.ap_materno) AS nombre_persona, ex.nombre AS nombre_extension, doc.status AS status
                        FROM docentes doc
                        INNER JOIN personas per ON per.id_persona = doc.id_persona 
                        INNER JOIN extensiones ex ON per.id_extension = ex.id_extension"; 

            }
            else
            {
                qry = @"SELECT doc.id_docente,(per.nombre + ' ' + per.ap_paterno + per.ap_materno) AS nombre_persona, ex.nombre AS nombre_extension, doc.status AS status
                        FROM docentes doc
                        INNER JOIN personas per ON per.id_persona = doc.id_persona 
                        INNER JOIN extensiones ex ON per.id_extension = ex.id_extension"; 
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
                crReport.Load(path + "\\Reportes" + "\\crDocentes.rpt");
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

            if (this.txtBuscarDocente.Text == String.Empty)
            {
                qry = @"SELECT doc.id_docente AS ID,(per.nombre + ' ' + per.ap_paterno + per.ap_materno) AS Nombre, ex.nombre AS Extension, doc.status AS Estado
                        FROM docentes doc
                        INNER JOIN personas per ON per.id_persona = doc.id_persona 
                        INNER JOIN extensiones ex ON per.id_extension = ex.id_extension"; 

            }
            else
            {
                qry = @"SELECT doc.id_docente AS ID,(per.nombre + ' ' + per.ap_paterno + per.ap_materno) AS Nombre, ex.nombre AS Extension, doc.status AS Estado
                        FROM docentes doc
                        INNER JOIN personas per ON per.id_persona = doc.id_persona 
                        INNER JOIN extensiones ex ON per.id_extension = ex.id_extension"; 
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
                hoja.Name = "Docentes";


                // Validamos que el DataReader tenga informacion
                if (sqlDR.HasRows == true)
                {
                    i = 2;

                    hoja.Range["A1:E1"].Interior.Color = negro;
                    hoja.Range["A1:E1"].Font.Color = Color.White;

                    hoja.Cells[1, 1] = "#";
                    hoja.Cells[1, 2] = "ID";
                    hoja.Cells[1, 3] = "Nombre";
                    hoja.Cells[1, 4] = "Extension";
                    hoja.Cells[1, 5] = "Estado";


                    while (sqlDR.Read() == true)
                    {
                        hoja.Cells[i, 1] = i - 1;
                        hoja.Cells[i, 2] = sqlDR["ID"].ToString();
                        hoja.Cells[i, 3] = sqlDR["Nombre"].ToString();
                        hoja.Cells[i, 4] = sqlDR["Extension"].ToString();
                        hoja.Cells[i, 5] = sqlDR["Estado"].ToString();


                        if ((i % 2) == 0)
                        {
                            hoja.Range["A" + i + ":" + "E" + i].Interior.Color = similar;
                        }
                        else
                        {
                            hoja.Range["A" + i + ":" + "E" + i].Interior.Color = claro;
                        }

                        i++;
                    }

                    hoja.Columns["A:E"].AutoFit();


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

        private void txtBuscarPersona_TextChanged(object sender, EventArgs e)
        {
            this.LlenarGrid();
        }

        private void txtBuscarDocente_TextChanged(object sender, EventArgs e)
        {
            this.LlenarGridDocentes();
        }

    }
}
