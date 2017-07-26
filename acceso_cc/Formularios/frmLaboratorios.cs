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
    public partial class frmLaboratorios : Form
    {

        public frmLaboratorios()
        {
            InitializeComponent();
        }


        private void brnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
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

                this.cmbExtension.DataSource = dtDatos;       // Le decimos que la fuente es el DataTable
                this.cmbExtension.ValueMember = "ID";         // Este ValueMenber no se observa, ojo que es el ID que mandaremos a la BD
                this.cmbExtension.DisplayMember = "Nombre";   // Esto es lo que se mostrara en el campo.
                this.cmbExtension.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool EstanCamposLlenos()
        {
            if (this.txtNombre.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNombre.Focus();
                return false;
            }
            else if (this.txtDescripcion.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtDescripcion.Focus();
                return false;
            }
            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.EstanCamposLlenos() == true)
            {
                try
                {
                    string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");
                    SqlConnection sqlCNX = new SqlConnection(cadenaConexion);
                    SqlCommand sqlCMD = new SqlCommand();
                    string qry = "";

                    qry = "INSERT INTO laboratorios (nombre, id_extension, descripcion,  status)" + "\n";
                    qry = qry + "VALUES('" + this.txtNombre.Text + "',";
                    qry = qry + "" + this.cmbExtension.SelectedValue + ",";
                    qry = qry + "'" + this.txtDescripcion.Text + "', ";
                    qry = qry + "1)";

                    sqlCMD.CommandType = System.Data.CommandType.Text;
                    sqlCMD.CommandText = qry;
                    sqlCMD.Connection = sqlCNX;
                    sqlCNX.Open();
                    sqlCMD.ExecuteReader();
                    sqlCNX.Close();
                    MessageBox.Show("Se actualizó un registro correctamente", "Laboratorios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Limpiar();
                    this.LlenarGrid();
            }
                catch
                {
                    MessageBox.Show("Fallo la conexion a la BD", "Laboratorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmExtension_Load(object sender, EventArgs e)
        {
            LLenarCombo();
            this.LlenarGrid();
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(this.txtBuscar, "Busque por nombre o apellidos de los usuarios");
        }

        private void txtInformacion_TextChanged(object sender, EventArgs e)
        {
            this.LlenarGrid();
        }

        private void dgvInformacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult respuesta;

            if (this.dgvInformacion.CurrentRow != null)
            {
                int filaActual = this.dgvInformacion.CurrentRow.Index;
                int id = int.Parse(this.dgvInformacion.Rows[filaActual].Cells["ID"].Value.ToString());
                int estado = int.Parse(this.dgvInformacion.Rows[filaActual].Cells["EstadoBD"].Value.ToString());

                switch (e.ColumnIndex)
                {
                    case 1:
                        respuesta = MessageBox.Show("¿Desea cambiar el estado del registro?", "Usuarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

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
                            frmLabsActualizar form = new frmLabsActualizar();
                            form.ID = id;
                            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
                            form.ShowDialog();
                        }
                        break;
                }

            }
        }

   
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
            //this.rtbDireccion.Text = String.Empty;
            //this.mskTelefono.Text = String.Empty;
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


            try
            {

                SqlCommand Comando = new SqlCommand();

                qry = "";

                if (this.txtBuscar.Text == String.Empty)
                {
                    qry = @"SELECT lab.id_laboratorio AS ID, lab.nombre AS Nombre, lab.descripcion 
                            AS Descripcion, ext.nombre AS Extencion, lab.status AS Estado
                            FROM laboratorios lab INNER JOIN extensiones ext 
                            ON lab.id_extension=ext.id_extension
                            WHERE ext.status = 1";
                }
                else
                {
                    qry = @"SELECT lab.id_laboratorio AS ID, lab.nombre AS Nombre, lab.descripcion 
                            AS Descripcion, ext.nombre AS Extencion, lab.status AS Estado
                            FROM laboratorios lab INNER JOIN extensiones ext 
                            ON lab.id_extension=ext.id_extension
                            WHERE ext.status = 1
                            AND lab.nombre LIKE '%" + this.txtBuscar.Text + "%' OR lab.descripcion LIKE '%" + this.txtBuscar.Text + "%'";
                }

                Comando.CommandText = qry;
                sqlCNX.Open();
                Comando.Connection = sqlCNX;
                SqlDataAdapter sqlAdaper = new SqlDataAdapter(Comando);
                DataTable dtDatos = new DataTable();
                sqlAdaper.Fill(dtDatos);
                sqlCNX.Close();


                
                this.dgvInformacion.Columns.Add("#", "#");
                DataGridViewImageColumn columnaImagenUno = new DataGridViewImageColumn();
                columnaImagenUno.Name = "Estado";
                dgvInformacion.Columns.Add(columnaImagenUno);


                DataGridViewImageColumn columnaImagenDos = new DataGridViewImageColumn();
                columnaImagenDos.Name = "Editar";
                dgvInformacion.Columns.Add(columnaImagenDos);

                this.dgvInformacion.Columns.Add("ID", "ID");
                this.dgvInformacion.Columns.Add("Nombre", "Nombre");
                this.dgvInformacion.Columns.Add("Descripcion", "Descripcion");
                this.dgvInformacion.Columns.Add("Extencion", "Extencion");
                this.dgvInformacion.Columns.Add("EstadoBD", "EstadoBD");

                
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

                    // Verificar si viene con status activo
                    if (dtDatos.Rows[i]["Estado"].ToString() == "1")
                    {
                        this.dgvInformacion.Rows[i].Cells["Estado"].Value = Properties.Resources.activo;
                        this.dgvInformacion.Rows[i].Cells["Editar"].Value = Properties.Resources.editar;


                         //Cambiar color de una sola celda
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
                    this.dgvInformacion.Rows[i].Cells["Extencion"].Value = dtDatos.Rows[i]["Extencion"].ToString();
                    this.dgvInformacion.Rows[i].Cells["Descripcion"].Value = dtDatos.Rows[i]["Descripcion"].ToString();

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
                this.dgvInformacion.Columns["Estado"].Width = 70;
                this.dgvInformacion.Columns["Editar"].Width = 50;
                this.dgvInformacion.Columns["ID"].Visible = false;          // La ocupo oculta, luego solo para usar su valor
                this.dgvInformacion.Columns["EstadoBD"].Visible = false;    // La ocupo oculta, luego solo para usar su valor
                this.dgvInformacion.Columns["Descripcion"].Width = 350;

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

           
            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");
            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);
            SqlCommand sqlCMD = new SqlCommand();

            try
            {
                string qry = "";
                qry = "UPDATE laboratorios" + "\n";
                qry = qry + "SET status = " + Estado +  "\n";
                qry = qry + "WHERE id_laboratorio = " + ID;
   
                sqlCMD.CommandType = System.Data.CommandType.Text;
                sqlCMD.CommandText = qry;
                sqlCMD.Connection = sqlCNX;
                sqlCNX.Open();
                sqlCMD.ExecuteReader();
                sqlCNX.Close();

            }

            catch (SqlException exc)
            {
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

        
        //private void dgvInformacionP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        private void btnEcxel_Click(object sender, EventArgs e)
        {
          
            Excel.Application appExcel = new Excel.Application();
            Excel.Workbook libro;
            Excel.Worksheet hoja;
            object objeto = System.Reflection.Missing.Value;
            int i = 0;

            Color peterRiver = new Color();
            peterRiver = Color.FromArgb(52, 152, 219);
            Color negro = new Color();
            negro = Color.FromArgb(0, 0, 0);
            Color emerald= new Color();
            emerald = Color.FromArgb(46, 204, 113);


            Color similar = new Color();
            similar = Color.FromArgb(52, 152, 219);

            Color claro = new Color();
            claro = Color.FromArgb(107, 185, 240);






            string qry = "";
            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");
            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);
            SqlCommand sqlCMD = new SqlCommand();
            qry = "";

            if (this.txtBuscar.Text == String.Empty)
            {
                qry = @"SELECT lab.id_laboratorio AS Id, lab.nombre AS Nombre, lab.descripcion  AS Descripcion, 
                        ext.nombre AS Extencion, lab.status AS Estado
                        FROM laboratorios lab INNER JOIN extensiones ext 
                        ON lab.id_extension=ext.id_extension
                        WHERE ext.status = 1";

            }
            //else
            //{
            //    qry = "SELECT id_extension AS Id, nombre AS Nombre, direccion AS Direccion, telefono AS Teléfono, correo AS Correo, status AS Estado" + "\n";
            //    qry = qry + "FROM extensiones" + "\n";
            //    qry = qry + "WHERE nombre LIKE '%" + this.txtBuscar.Text + "%' OR direccion LIKE '%" + this.txtBuscar.Text + "%'";
            //}

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
                    MessageBox.Show("Excel no esta correctamente instado");
                }

                libro = appExcel.Workbooks.Add(objeto);
                hoja = (Excel.Worksheet)libro.Worksheets.get_Item(1);
                hoja.Name = "Laboratorios";

                if (sqlDR.HasRows == true)
                {
                    i = 2;

                    hoja.Range["A1:F1"].Interior.Color = negro;
                    hoja.Range["A1:F1"].Font.Color = Color.White;

                    hoja.Cells[1, 1] = "#";
                    hoja.Cells[1, 2] = "Id";
                    hoja.Cells[1, 3] = "Nombre";
                    hoja.Cells[1, 4] = "Descripcion";
                    hoja.Cells[1, 5] = "Extencion";

                    while (sqlDR.Read() == true)
                    {
                        hoja.Cells[i, 1] = i - 1;
                        hoja.Cells[i, 2] = sqlDR["Id"].ToString();
                        hoja.Cells[i, 3] = sqlDR["Nombre"].ToString();
                        hoja.Cells[i, 4] = sqlDR["Descripcion"].ToString();
                        hoja.Cells[i, 5] = sqlDR["Extencion"].ToString();

                        if ((i % 2) == 0)
                        {
                            hoja.Range["A" + i + ":" + "F" + i].Interior.Color = similar;
                        }
                        else
                        {
                            hoja.Range["A" + i + ":" + "F" + i].Interior.Color = claro;
                        }

                        i++;
                    }

                    hoja.Columns["A:F"].AutoFit();


                }

                appExcel.Visible = true;
                this.LiberarExcel(appExcel);
                this.LiberarExcel(libro);
                this.LiberarExcel(hoja);
                sqlCNX.Close();
            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

             //if (this.txtBuscar.Text == String.Empty)
             //{
                 qry = @"SELECT lab.id_laboratorio AS Id, lab.nombre AS Nombre, lab.descripcion  AS Descripcion, 
                        ext.nombre AS Extencion, lab.status AS Estado
                        FROM laboratorios lab INNER JOIN extensiones ext 
                        ON lab.id_extension=ext.id_extension
                        WHERE ext.status = 1";

             //}
             //else
             //{
             //    qry = "SELECT id_extension, nombre, direccion, telefono, correo, status" + "\n";
             //    qry = qry + "FROM extensiones" + "\n";
             //    qry = qry + "WHERE nombre LIKE '%" + this.txtBuscar.Text + "%' OR direccion LIKE '%" + this.txtBuscar.Text + "%'";
             //}


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
                 crReport.Load(path + "\\Reportes" + "\\crLaboratorios.rpt");
                 crReport.SetDataSource(dtDatos);

                 //frmVisualizador formulario = new frmVisualizador(crReport);
                 frmVisualizador formulario = new Formularios.frmVisualizador(crReport);  
                 formulario.ShowDialog();

             }

             catch (SqlException exc)
             {
                 MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 //MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Err
             }
         }

         private void groupBox1_Enter(object sender, EventArgs e)
         {

         }
        }


        //private void btnEcxel_Click(object sender, EventArgs e)
        //{
            
        //}

        //private void btnPersonas_Click(s sender, EventArgs e)
        //{
        //    frmBuscar buscar = new frmBuscar();
        //    buscar.Show();
        //}
}


    

