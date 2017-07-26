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



namespace acceso_cc.Formularios
{
    public partial class frmLabs : Form
    {
        static int idPersona;

        private bool EstanCamposLlenos()
        {
            if (this.txtUsuario.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtUsuario.Focus();
                return false;
            }
            else if (this.txtContrasena.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtContrasena.Focus();
                return false;
            }
            else if (this.txtConfirmar.Text == String.Empty)
            {
                MessageBox.Show("Este campo debe de ser llenado correctamente", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtConfirmar.Focus();
                return false;
            }
            else if (this.txtContrasena.Text != this.txtConfirmar.Text)
            {
                MessageBox.Show("Las Contraseñas no Coenciden", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtContrasena.Text = String.Empty;
                this.txtConfirmar.Text = String.Empty;
                this.txtContrasena.Focus();
                return false;
            }

            return true;
        }
        private bool ConfirmarUsuario()
        {
            string qry = "";
            string verificarusuario = "";
            string verificarcontrasena = "";

            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");
            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);
            SqlCommand sqlCMD = new SqlCommand();


            qry = "SELECT usuario AS Usuario, contrasena AS Contrasena" + "\n";
            qry = qry + "FROM usuarios" + "\n";
            qry = qry + " WHERE usuario = '" + this.txtUsuario.Text + "' and contrasena = '" + this.txtContrasena.Text + "'";

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
                        verificarusuario = sqlDR["Usuario"].ToString();
                        verificarcontrasena = sqlDR["Contrasena"].ToString();
                    }
                }

                sqlCNX.Close();
            }


            catch (SqlException)
            {

                MessageBox.Show("No se pudo Conectar con a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (verificarusuario == this.txtUsuario.Text)
            {
                MessageBox.Show("El Usuaio ya existe", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtUsuario.Text = String.Empty;
                this.txtUsuario.Focus();
                return false;
            }
            return true;
        }

        private void Limpiar()
        {
            this.txtUsuario.Text = String.Empty;
            this.txtContrasena.Text = String.Empty;
            this.txtConfirmar.Text = String.Empty;
        }


        public frmLabs()
        {
            InitializeComponent();
        }


        //private void brnCancelar_Click(object sender, EventArgs e)
        //{
        //    //this.Limpiar();
        //}

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void frmExtension_Load(object sender, EventArgs e)
        {
            ////this.btnActualizar.Enabled = false;
            this.lblPruebaCombo.Text = Convert.ToString(cmbTipo.SelectedValue);
            this.btnCncelar.Enabled = false;
            //this.btnActualizar.Enabled = false;
            this.btnAgregar.Enabled = false;
            this.txtUsuario.Enabled = false;
            this.txtContrasena.Enabled = false;
            this.txtConfirmar.Enabled = false;
            this.cmbTipo.Enabled = Enabled;

            this.LlenarGrid();
            this.LlenarGridPersonas();
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(this.txtBuscar, "Busque por Nombre de Persona o Usuario");
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
                int Estado = int.Parse(this.dgvInformacion.Rows[filaActual].Cells["EstadoBD"].Value.ToString());

                switch (e.ColumnIndex)
                {
                    case 1:
                        respuesta = MessageBox.Show("¿Desea cambiar el estado del registro?", "Usuarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (respuesta == DialogResult.OK)
                        {
                            this.CambiarEstado(id, Estado);
                            this.LlenarGrid();
                        }
                        break;
                    case 2:
                        if (Estado == 0)
                        {
                            MessageBox.Show("Primero debe de cambiar el estado del registro para poder editarlo", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            frmUsrsActualiar form = new frmUsrsActualiar();
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
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                this.dgvInformacion.Cursor = Cursors.Hand;
            }
            else
            {
                this.dgvInformacion.Cursor = Cursors.Arrow;
            }

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
                    qry = @"SELECT usrs.id AS ID, (per.nombre + ' ' + per.ap_paterno + ' ' + per.ap_materno) AS Nombre,
                            usrs.usuario AS Usuario, tusrs.nombre AS Tipo, usrs.status AS Estado
                            FROM personas per 
                            INNER JOIN usuarios usrs
                            ON per.id_persona=usrs.id_persona 
                            INNER JOIN tipo_usuarios tusrs
                            ON tusrs.id_tipo_usuario = usrs.id_tipo_usuario";
                }
                else
                {
                    qry = @"SELECT usrs.id AS ID, (per.nombre + ' ' + per.ap_paterno + ' ' + per.ap_materno) AS Nombre,
                            usrs.usuario AS Usuario, tusrs.nombre AS Tipo, usrs.status AS Estado
                            FROM personas per
                            INNER JOIN usuarios usrs
                            ON per.id_persona=usrs.id_persona 
                            INNER JOIN tipo_usuarios tusrs
                            ON tusrs.id_tipo_usuario = usrs.id_tipo_usuario
							WHERE per.nombre LIKE '%" + this.txtBuscar.Text + "%' OR usrs.usuario LIKE '%" + this.txtBuscar.Text + "%'";
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
                //this.dgvInformacion.Columns.Add("Apellidos", "Apellidos");
                this.dgvInformacion.Columns.Add("Usuario", "Usuario");
                this.dgvInformacion.Columns.Add("Tipo", "Tipo");
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
                    this.dgvInformacion.Rows[i].Cells["Usuario"].Value = dtDatos.Rows[i]["Usuario"].ToString();
                    //this.dgvInformacion.Rows[i].Cells["Apellidos"].Value = dtDatos.Rows[i]["Apellidos"].ToString();
                    this.dgvInformacion.Rows[i].Cells["Tipo"].Value = dtDatos.Rows[i]["Tipo"].ToString();

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
                //this.dgvInformacion.Columns["Apellidos"].Width = 250;

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
                qry = "UPDATE usuarios" + "\n";
                qry = qry + "SET status = " + Estado + "\n";
                qry = qry + "WHERE id_usuario = " + ID;

                sqlCMD.CommandType = System.Data.CommandType.Text;
                sqlCMD.CommandText = qry;
                sqlCMD.Connection = sqlCNX;
                sqlCNX.Open();
                sqlCMD.ExecuteReader();
                sqlCNX.Close();

            }

            catch (SqlException exc)
            {
                MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        //private void frmExtension_FormClosing(object sender, FormClosingEventArgs e)
        //{

        //    DialogResult respuesta;

        //    respuesta = MessageBox.Show("¿Desea cerrar el formulario?", "Usuarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //    if (respuesta == DialogResult.Yes)
        //    {
        //        e.Cancel = false;
        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //    }

        //}



        //private void button1_Click(object sender, EventArgs e)
        //{
        //    frmBuscar formulario = new frmBuscar();
        //    formulario.Show();
        //}

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (this.EstanCamposLlenos() == true && ConfirmarUsuario() == true)
            {
                string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");
                SqlConnection sqlCNX = new SqlConnection(cadenaConexion);
                SqlCommand sqlCMD = new SqlCommand();
                string qry = "";


                qry = "INSERT INTO usuarios (id_persona, id_tipo_usuario, usuario, contrasena, status)" + "\n";
                qry = qry + "VALUES('" + idPersona + "',";
                qry = qry + "" + this.cmbTipo.SelectedValue + ", ";
                qry = qry + "'" + this.txtUsuario.Text + "',";
                qry = qry + "'" + this.txtContrasena.Text + "',";
                qry = qry + "1)";

                sqlCMD.CommandType = System.Data.CommandType.Text;
                sqlCMD.CommandText = qry;
                sqlCMD.Connection = sqlCNX;
                sqlCNX.Open();
                sqlCMD.ExecuteReader();
                sqlCNX.Close();

                MessageBox.Show("Usuario Agregado Correctamente", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Limpiar();
                this.LlenarGridPersonas();
                this.LlenarGrid();
            }
        }


        //private void dgvInformacionP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}


        //private void btnPersonas_Click(object sender, EventArgs e)
        //{
        //    frmBuscar buscar = new frmBuscar();
        //    buscar.Show();
        //}

        #region GridPersoans
        private void dgvInformacionPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult respuesta;
            if (this.dgvInformacionPersonas.CurrentRow != null)
            {
                int filaActual = this.dgvInformacionPersonas.CurrentRow.Index;
                idPersona = int.Parse(this.dgvInformacionPersonas.Rows[filaActual].Cells["ID"].Value.ToString());
                int Estado = int.Parse(this.dgvInformacionPersonas.Rows[filaActual].Cells["EstadoBD"].Value.ToString());

                switch (e.ColumnIndex)
                {
                    case 1:
                        respuesta = MessageBox.Show("¿Desea cambiar el estado del registro?", "Usuarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (respuesta == DialogResult.OK)
                        {
                            this.CambiarEstado2(idPersona, Estado);
                            this.LlenarGridPersonas();
                        }
                        break;
                    case 2:
                        if (Estado == 0)
                        {
                            MessageBox.Show("Primero debe de cambiar el estado del registro para poder editarlo", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            this.lblID.Text = Convert.ToString(idPersona);
                            this.btnCncelar.Enabled = true;
                            //this.btnActualizar.Enabled = false;
                            this.btnAgregar.Enabled = true;
                            this.txtUsuario.Enabled = true;
                            this.txtContrasena.Enabled = true;
                            this.txtConfirmar.Enabled = true;
                            this.cmbTipo.Enabled = true;
                            LLenarCombo();
                        
                        }
                        break;

                }
            }
        }

        private void dgvInformacionPersonas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                this.dgvInformacionPersonas.Cursor = Cursors.Hand;
            }
            else
            {
                this.dgvInformacionPersonas.Cursor = Cursors.Arrow;
            }

        }
		
        public void LlenarGridPersonas()
        {
            this.dgvInformacionPersonas.DataSource = null;
            this.dgvInformacionPersonas.Rows.Clear();
            this.dgvInformacionPersonas.Columns.Clear();
            string qry = "";
            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");
            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand Comando = new SqlCommand();

                qry = "";

                if (this.textBuscarPersonas.Text == String.Empty)
                {
                    qry = @"SELECT id_persona AS ID, (per.nombre + ' ' + per.ap_paterno + ' ' + per.ap_materno) AS Nombre, status AS Estado
                        FROM personas per WHERE NOT EXISTS(SELECT id_persona 
                        FROM usuarios usrs WHERE usrs.id_persona=per.id_persona)
                        AND per.status = 1";
                }
                else
                {
                    qry = String.Format(@"SELECT id_persona AS ID,(per.nombre + ' ' + per.ap_paterno + ' ' + per.ap_materno) AS Nombre, status AS Estado
                                          FROM personas per WHERE NOT EXISTS(SELECT id_persona 
                                          FROM usuarios usrs WHERE usrs.id_persona=per.id_persona)
                                          AND per.status = 1
                                          AND (per.nombre LIKE '%{0}%' OR per.ap_paterno LIKE '%{1}%' OR  per.ap_materno LIKE '%{2}%')", this.textBuscarPersonas.Text,
                                          this.textBuscarPersonas.Text,this.textBuscarPersonas.Text);
          
                }

                Comando.CommandText = qry;
                sqlCNX.Open();
                Comando.Connection = sqlCNX;
                SqlDataAdapter sqlAdaper = new SqlDataAdapter(Comando);
                DataTable dtDatos = new DataTable();
                sqlAdaper.Fill(dtDatos);
                sqlCNX.Close();



                this.dgvInformacionPersonas.Columns.Add("#", "#");
                DataGridViewImageColumn columnaImagenUno = new DataGridViewImageColumn();
                columnaImagenUno.Name = "Estado";
                dgvInformacionPersonas.Columns.Add(columnaImagenUno);


                DataGridViewImageColumn columnaImagenDos = new DataGridViewImageColumn();
                columnaImagenDos.Name = "Asignar";
                dgvInformacionPersonas.Columns.Add(columnaImagenDos);

                this.dgvInformacionPersonas.Columns.Add("ID", "ID");
                this.dgvInformacionPersonas.Columns.Add("Nombre", "Nombre");
                //this.dgvInformacionPersonas.Columns.Add("Apellidos", "Apellidos");
                this.dgvInformacionPersonas.Columns.Add("EstadoBD", "EstadoBD");


                for (int i = 0; i < dtDatos.Rows.Count; i++)
                {
                    //mi_variable = DataTable.Rows[i]["NombreCampo"].ToString();
                    this.dgvInformacionPersonas.Rows.Add(); // Agregar nueva fila al dataridview
                    this.dgvInformacionPersonas.Rows[i].Cells["#"].Value = i + 1;

                    this.dgvInformacionPersonas.Rows[i].Height = 25;


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
                        this.dgvInformacionPersonas.Rows[i].Cells["Estado"].Value = Properties.Resources.activo;
                        this.dgvInformacionPersonas.Rows[i].Cells["Asignar"].Value = Properties.Resources.editar;


                        //Cambiar color de una sola celda
                        this.dgvInformacionPersonas.Rows[i].Cells["#"].Style.BackColor = miColor; // Color desde un RGB
                    }
                    else
                    {
                        this.dgvInformacionPersonas.Rows[i].Cells["Estado"].Value = Properties.Resources.inactivo;
                        this.dgvInformacionPersonas.Rows[i].Cells["Asignar"].Value = Properties.Resources.advertencia;

                        this.dgvInformacionPersonas.Rows[i].Cells["#"].Style.BackColor = Color.BlanchedAlmond;
                    }


                    this.dgvInformacionPersonas.Rows[i].Cells["EstadoBD"].Value = dtDatos.Rows[i]["Estado"].ToString();
                    this.dgvInformacionPersonas.Rows[i].Cells["ID"].Value = dtDatos.Rows[i]["ID"].ToString();
                    this.dgvInformacionPersonas.Rows[i].Cells["Nombre"].Value = dtDatos.Rows[i]["Nombre"].ToString();
                    //this.dgvInformacionPersonas.Rows[i].Cells["Apellidos"].Value = dtDatos.Rows[i]["Apellidos"].ToString();
                    

                    if ((i + 1) % 2 == 0)
                    {
                        this.dgvInformacionPersonas.Rows[i].DefaultCellStyle.BackColor = similar;
                    }
                    else
                    {
                        this.dgvInformacionPersonas.Rows[i].DefaultCellStyle.BackColor = claro;
                    }
                }

                // Encabezados de columnas en negritas (Con un estilo de fuente nuevo)
                FontFamily fontFamily = new FontFamily("Arial");
                Font font = new Font(fontFamily, 12, FontStyle.Bold);
                this.dgvInformacionPersonas.ColumnHeadersDefaultCellStyle.Font = font;
                this.dgvInformacionPersonas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;

                // Centramos el titulo de todas las columnas del GridView
                this.dgvInformacionPersonas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Noten que el nombre de las columnas corresponde a los alias (Ver consulta SELECT) de las columnas en la BD
                this.dgvInformacionPersonas.Columns["#"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Cambiar tipo de fuente a toda una columna
                this.dgvInformacionPersonas.Columns["#"].DefaultCellStyle.Font = font;
                this.dgvInformacionPersonas.Columns["#"].DefaultCellStyle.ForeColor = Color.Blue; // Cambiar color de fuente

                // Establecemos el tamaño de las columnas del Gridview
                this.dgvInformacionPersonas.Columns["#"].Width = 40;
                this.dgvInformacionPersonas.Columns["Nombre"].Width = 350;
                this.dgvInformacionPersonas.Columns["Estado"].Visible = false;
                this.dgvInformacionPersonas.Columns["Asignar"].Width = 100;
                this.dgvInformacionPersonas.Columns["ID"].Visible = false;          // La ocupo oculta, luego solo para usar su valor
                this.dgvInformacionPersonas.Columns["EstadoBD"].Visible = false;    // La ocupo oculta, luego solo para usar su valor
                //this.dgvInformacionPersonas.Columns["Apellidos"].Width = 250;

            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CambiarEstado2(int ID, int Estado)
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
                qry = "UPDATE usuarios" + "\n";
                qry = qry + "SET status = " + Estado + "\n";
                qry = qry + "WHERE id_usuario = " + ID;

                sqlCMD.CommandType = System.Data.CommandType.Text;
                sqlCMD.CommandText = qry;
                sqlCMD.Connection = sqlCNX;
                sqlCNX.Open();
                sqlCMD.ExecuteReader();
                sqlCNX.Close();

            }

            catch (SqlException exc)
            {
                MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        private void btnCncelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvInformacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            //long idLogin = this.IDLogin;
            //this.lblPrueba.Text = Convert.ToString(idLogin);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

        }

//        private void btnExcel_Click(object sender, EventArgs e)
//        {
//            //Iniciar una nueva aplicacin en excel
//            Excel.Application appExcel = new Excel.Application();

//            //Iniciar un nuevo libro .. esta es la variable
//            Excel.Workbook libro;

//            //Variable para iniciar una nueva hoja en el libro
//            Excel._Worksheet hoja;
//            object objeto = System.Reflection.Missing.Value;
//            int i = 0;

//            //Colores para la celda
//            Color peterRiver = new Color();
//            peterRiver = Color.FromArgb(19, 240, 181);

//            Color negro = new Color();
//            negro = Color.FromArgb(0, 0, 0);

//            Color emerald = new Color();
//            emerald = Color.FromArgb(239, 160, 23);

//            Color TURQUOISE = new Color();
//            TURQUOISE = Color.FromArgb(239, 160, 23);

//            Color GREENSEA = new Color();
//            GREENSEA = Color.FromArgb(22, 160, 133);

//            Color similar = new Color();
//            similar = Color.FromArgb(52, 152, 219);

//            Color claro = new Color();
//            claro = Color.FromArgb(107, 185, 240);





//            //variable para almacenar la consulta}
//            string qry = "";

//            string cadenaConexion = ConfigurationManager.AppSettings.Get("cadenaConexionSQLServer");


//            SqlConnection sqlCNX = new SqlConnection(cadenaConexion);

//            SqlCommand sqlCMD = new SqlCommand();
//            qry = "";

//            if (this.txtBuscar.Text == String.Empty)
//            {
//                qry = @"SELECT usrs.id AS ID, (per.nombre + ' ' + per.ap_paterno + ' ' + per.ap_materno) AS Nombre,
//                            usrs.usuario AS Usuario, tusrs.nombre AS Tipo, usrs.status AS Estado
//                            FROM personas per INNER JOIN usuarios usrs
//                            ON per.id_persona=usrs.id_persona 
//                            INNER JOIN tipo_usuarios tusrs
//                            ON tusrs.id_tipo_usuario = usrs.id_tipo_usuario";
//            }

//            else
//            {
//                qry = @"SELECT usrs.id AS ID, (per.nombre + ' ' + per.ap_paterno + ' ' + per.ap_materno) AS Nombre,
//                            usrs.usuario AS Usuario, tusrs.nombre AS Tipo, usrs.status AS Estado
//                            FROM personas per INNER JOIN usuarios usrs
//                            ON per.id_persona=usrs.id_persona 
//                            INNER JOIN tipo_usuarios tusrs
//                            ON tusrs.id_tipo_usuario = usrs.id_tipo_usuario
//							WHERE per.nombre LIKE '%" + this.txtBuscar.Text + "%' OR usrs.usuario LIKE '%" + this.txtBuscar.Text + "%'";

//            }




//            sqlCMD.CommandText = qry;

//            sqlCMD.CommandType = System.Data.CommandType.Text;

//            SqlDataReader sqlDR = null;

//            sqlCMD.Connection = sqlCNX;

//            try
//            {
//                sqlCNX.Open();

//                sqlDR = sqlCMD.ExecuteReader();

//                if (appExcel == null)
//                {
//                    MessageBox.Show("Excel no esta correctamente instalado");
//                }

//                libro = appExcel.Workbooks.Add(objeto);

//                hoja = (Excel.Worksheet)libro.Worksheets.get_Item(1); //la hoja que va a tomar
//                hoja.Name = "Usuarios"; //cambiar el nombre de la hoja


//                if (sqlDR.HasRows == true)
//                {
//                    i = 2;

//                    hoja.Range["A1:F1"].Interior.Color = negro;
//                    hoja.Range["A1:F1"].Font.Color = Color.White;

//                    hoja.Cells[1, 1] = "#"; //titulos de la columna
//                    hoja.Cells[1, 2] = "Id";
//                    hoja.Cells[1, 3] = "Nombre";
//                    hoja.Cells[1, 4] = "Usuario";
//                    hoja.Cells[1, 5] = "Tipo";
//                    hoja.Cells[1, 6] = "Estado";

//                    while (sqlDR.Read() == true)
//                    {
//                        hoja.Cells[i, 1] = i - 1;
//                        hoja.Cells[i, 2] = sqlDR["Id"].ToString();
//                        hoja.Cells[i, 3] = sqlDR["Nombre"].ToString();
//                        hoja.Cells[i, 4] = sqlDR["Usuario"].ToString();
//                        hoja.Cells[i, 4] = sqlDR["Tipo"].ToString();
//                        hoja.Cells[i, 4] = sqlDR["Estado"].ToString();


//                        if ((i % 2) == 0)  //si es par pinta de un color 
//                        {
//                            hoja.Range["A" + i + ":" + "F" + i].Interior.Color = similar;
//                        }
//                        else
//                        {
//                            hoja.Range["A" + i + ":" + "F" + i].Interior.Color = claro;
//                        }

//                        i++;
//                    }

//                    hoja.Columns["A:F"].AutoFit(); //anchoe d ela celda se ajusta al texto


//                }

//                appExcel.Visible = true;

//                this.LiberarExcel(appExcel);
//                this.LiberarExcel(libro);
//                this.LiberarExcel(hoja);



//                // Cerrar conexion
//                sqlCNX.Close();

//            }

//            catch (SqlException exc)
//            {
//                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                //MessageBox.Show("No se pudo establecer la conexión a la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

//            }
//        }



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

        private void textBuscarPersonas_TextChanged(object sender, EventArgs e)
        {
            this.LlenarGridPersonas();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

           
        }






    }


}


