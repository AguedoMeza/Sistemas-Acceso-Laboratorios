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
using System.Configuration;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using CrystalReport = CrystalDecisions.CrystalReports.Engine;

namespace acceso_cc.Formularios
{
    public partial class frmCarreras : Form
    {
        public frmCarreras()
        {
            InitializeComponent();
        }

        private void frmCarreras_Load(object sender, EventArgs e)
        {
            //this.EstanCamposLlenos();
            this.LlenarGrid();
           // this.CambiarEstado();
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



                private void Limpiar()
        {
            this.txtNombre.Text = String.Empty;
            this.txtSiglas.Text = String.Empty;
            this.txtNombre.Focus();
            SystemSounds.Beep.Play();
        }








        public void LlenarGrid()
        {


            this.dgvInformacion.DataSource = null;
            this.dgvInformacion.Rows.Clear();
            this.dgvInformacion.Columns.Clear();


            string qry = "";

            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");



            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);

            SqlCommand Comando = new SqlCommand();



            try
            {

                

                qry = "";

                if (this.txtBuscar.Text == String.Empty)
                {
                    qry = "SELECT id_carrera AS ID, nombre AS Nombre, siglas AS Siglas, status AS Estado" + "\n";
                    qry = qry + "FROM carreras" + "\n";

                }
                else
                {
                    qry = "SELECT id_carrera AS ID, nombre AS Nombre, siglas AS Siglas, status AS Estado" + "\n";
                    qry = qry + "FROM carreras" + "\n";
                    qry = qry + "WHERE nombre LIKE '%" + this.txtBuscar.Text + "%' OR siglas LIKE '%" + this.txtBuscar.Text + "%'";
                }

                Comando.CommandText = qry;

                sqlCNX.Open();

                Comando.Connection = sqlCNX;
                SqlDataAdapter sqlAdaper = new SqlDataAdapter(Comando);


                DataTable dtDatos = new DataTable();


                sqlAdaper.Fill(dtDatos);


                sqlCNX.Close();


                this.dgvInformacion.Columns.Add("#", "#");

                //para agregar columnas con imagenes

                DataGridViewImageColumn columnaImagenUno = new DataGridViewImageColumn();
                columnaImagenUno.Name = "Estado";
                dgvInformacion.Columns.Add(columnaImagenUno);


                DataGridViewImageColumn columnaImagenDos = new DataGridViewImageColumn();
                columnaImagenDos.Name = "Editar";
                dgvInformacion.Columns.Add(columnaImagenDos);

                this.dgvInformacion.Columns.Add("ID", "ID");
                this.dgvInformacion.Columns.Add("Nombre", "Nombre");
                this.dgvInformacion.Columns.Add("Siglas", "Siglas");
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
                        this.dgvInformacion.Rows[i].Cells["Editar"].Value = Properties.Resources.editar;

                        
                    }


                    this.dgvInformacion.Rows[i].Cells["EstadoBD"].Value = dtDatos.Rows[i]["Estado"].ToString();
                    this.dgvInformacion.Rows[i].Cells["ID"].Value = dtDatos.Rows[i]["ID"].ToString();
                    this.dgvInformacion.Rows[i].Cells["Nombre"].Value = dtDatos.Rows[i]["Nombre"].ToString();
                    this.dgvInformacion.Rows[i].Cells["Siglas"].Value = dtDatos.Rows[i]["Siglas"].ToString();

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
                this.dgvInformacion.Columns["Siglas"].Width = 100;


            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                qry = "UPDATE carreras" + "\n";
                qry = qry + "SET status = " + Estado + "\n";
                qry = qry + "WHERE id_carrera = " + ID;

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





        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.EstanCamposLlenos() == true)
            {
                string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");

                SqlConnection sqlCNX = new SqlConnection(cadenaConexion);

                SqlCommand sqlCMD = new SqlCommand();


                try
                {
                    string qry = "";

                    qry = "INSERT INTO carreras(nombre, siglas, status)" + "\n";
                    qry = qry + "VALUES('" + this.txtNombre.Text + "', ";
                    qry = qry + "'" + this.txtSiglas.Text + "', ";
                    qry = qry + "1)";

                    sqlCMD.CommandType = System.Data.CommandType.Text;
                    sqlCMD.CommandText = qry;
                    sqlCMD.Connection = sqlCNX;
                    sqlCNX.Open();
                    sqlCMD.ExecuteReader();
                    sqlCNX.Close();

                    MessageBox.Show("Se agrego un registro correctamente", "Carreras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Limpiar();
                    this.LlenarGrid();
                }
                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }




        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.LlenarGrid();
        }





        private void dgvInformacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            }






        private void dgvInformacion_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {

        }





        private void dgvInformacion_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                this.dgvInformacion.Cursor = Cursors.Hand;
            }
            else
            {
                this.dgvInformacion.Cursor = Cursors.Arrow;
            }
        }



        private void frmCarreras_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta;

            respuesta = MessageBox.Show("¿Desea cerrar el formulario?", "Carreras", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            //Iniciar una nueva aplicacin en excel
            Excel.Application appExcel = new Excel.Application();

            //Iniciar un nuevo libro .. esta es la variable
            Excel.Workbook libro;

            //Variable para iniciar una nueva hoja en el libro
            Excel._Worksheet hoja;
            object objeto = System.Reflection.Missing.Value;
            int i = 0;

            //Colores para la celda
            Color peterRiver = new Color();
            peterRiver = Color.FromArgb(19, 240, 181);

            Color negro = new Color();
            negro = Color.FromArgb(0, 0, 0);

            Color emerald = new Color();
            emerald = Color.FromArgb(239, 160, 23);

            Color TURQUOISE = new Color();
            TURQUOISE = Color.FromArgb(239, 160, 23);

            Color GREENSEA = new Color();
            GREENSEA = Color.FromArgb(22, 160, 133);

            Color similar = new Color();
            similar= Color.FromArgb(52, 152, 219);

            Color claro = new Color();
            claro = Color.FromArgb(107, 185, 240);
            




            //variable para almacenar la consulta}
            string qry = "";

            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");


            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);

            SqlCommand sqlCMD = new SqlCommand();
            qry = "";

            if (this.txtBuscar.Text == String.Empty)
            {
                qry = "SELECT id_carrera AS Id, nombre AS Nombre, siglas AS Siglas, status AS Estado" + "\n";
                qry = qry + "FROM carreras" + "\n";
            }

            else
            {
                qry = "SELECT id_carrera AS Id, nombre AS Nombre, siglas AS Siglas, status AS Estado" + "\n";
                qry = qry + "FROM carreras" + "\n";
                qry = qry + "WHERE nombre_carrera LIKE '%" + this.txtBuscar.Text + "%' OR siglas LIKE '%" + this.txtBuscar + "%'";

            }




            sqlCMD.CommandText = qry;

            sqlCMD.CommandType = System.Data.CommandType.Text;

            SqlDataReader sqlDR = null;

            sqlCMD.Connection = sqlCNX;

            try
            {
                sqlCNX.Open();

                sqlDR = sqlCMD.ExecuteReader();

                if (appExcel == null)
                {
                    MessageBox.Show("Excel no esta correctamente instalado");
                }

                libro = appExcel.Workbooks.Add(objeto);

                hoja = (Excel.Worksheet)libro.Worksheets.get_Item(1); //la hoja que va a tomar
                hoja.Name = "Carreras"; //cambiar el nombre de la hoja


                if (sqlDR.HasRows == true)
                {
                    i = 2;

                    hoja.Range["A1:D1"].Interior.Color = negro;
                    hoja.Range["A1:D1"].Font.Color = Color.White;

                    hoja.Cells[1, 1] = "#"; //titulos de la columna
                    hoja.Cells[1, 2] = "Id";
                    hoja.Cells[1, 3] = "Nombre";
                    hoja.Cells[1, 4] = "Siglas";

                    while (sqlDR.Read() == true)
                    {
                        hoja.Cells[i, 1] = i - 1;
                        hoja.Cells[i, 2] = sqlDR["Id"].ToString();
                        hoja.Cells[i, 3] = sqlDR["Nombre"].ToString();
                        hoja.Cells[i, 4] = sqlDR["Siglas"].ToString();


                        if ((i % 2) == 0)  //si es par pinta de un color 
                        {
                            hoja.Range["A" + i + ":" + "D" + i].Interior.Color = similar;
                        }
                        else
                        {
                            hoja.Range["A" + i + ":" + "D" + i].Interior.Color = claro;
                        }

                        i++;
                    }

                    hoja.Columns["A:F"].AutoFit(); //anchoe d ela celda se ajusta al texto


                }

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
                qry = "SELECT id_carrera , nombre_carrera , siglas, status " + "\n";
                qry = qry + "FROM carreras" + "\n";

            }
            else
            {
                qry = "SELECT id_carrera, nombre_carrera, siglas,  status " + "\n";
                qry = qry + "FROM carreras" + "\n";
                qry = qry + "WHERE nombre_carrera LIKE '%" + this.txtBuscar.Text + "%' OR siglas LIKE '%" + this.txtBuscar.Text + "%'"; //filtro
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
                crReport.Load(path + "\\Reportes" + "\\crCarreras.rpt");
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
        void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.LlenarGrid();
        }
        private void dgvInformacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult respuesta;

            if (this.dgvInformacion.CurrentRow != null)
            {


                int filaActual = this.dgvInformacion.CurrentRow.Index;
                int estado = int.Parse(this.dgvInformacion.Rows[filaActual].Cells["EstadoBD"].Value.ToString());
                int id = int.Parse(this.dgvInformacion.Rows[filaActual].Cells["ID"].Value.ToString());


                switch (e.ColumnIndex)
                {
                    case 1:
                        respuesta = MessageBox.Show("¿Desea cambiar el estado del registro?", "Carreras", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (respuesta == DialogResult.OK)
                        {
                            this.CambiarEstado(id, estado);
                            this.LlenarGrid();
                        }
                        break;
                    case 2:

                        if (estado == 0)
                        {
                            MessageBox.Show("Primero debe de cambiar el estado del registro para poder editarlo", "Carreras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            frmCarreraActualizar form = new frmCarreraActualizar();
                            form.ID = id;

                            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
                            form.ShowDialog();

                        }
                        break;
                }

            }
        }






















    }
}
