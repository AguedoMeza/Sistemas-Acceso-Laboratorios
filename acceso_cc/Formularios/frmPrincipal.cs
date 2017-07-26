using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acceso_cc.Formularios
{
    public partial class frmPrincipal : Form
    {
        private long confirmAdmin;
        public long TipoUsuario
        {
            get { return confirmAdmin; }
            set { confirmAdmin = value; }
        }

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            long confirmarAdmin = this.TipoUsuario;
 

            if (confirmAdmin == 2)
            {
                //Ocultar Menu Usuarios
                this.personasToolStripMenuItem.Visible = false;
                this.carrerasToolStripMenuItem.Visible = false;
                this.holaToolStripMenuItem.Visible = false;
                this.docentesToolStripMenuItem.Visible = false;
                this.laboratoriosToolStripMenuItem.Visible = false;
                //this.entradasSalidasToolStripMenuItem.Visible = false;
               // this.entradasSalidasToolStripMenuItem.Visible = true;
            }
            else if (confirmAdmin == 1)
            {
                this.personasToolStripMenuItem.Visible = true;
                this.extensionesToolStripMenuItem.Visible = true;
                this.holaToolStripMenuItem.Visible = true;
                this.docentesToolStripMenuItem.Visible = true;
                this.laboratoriosToolStripMenuItem.Visible = true;
                //this.entradasSalidasToolStripMenuItem.Visible = true;
                this.carrerasToolStripMenuItem.Visible = true;

            }
        }
    
       

        private void hOlaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void holaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmLabs form = new frmLabs();
            form.MdiParent = this;
            form.Show();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void laboratoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLaboratorios form = new frmLaboratorios();
            form.MdiParent = this;
            form.Show();
        }

        private void docentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocentes form = new frmDocentes();
            form.MdiParent = this;
            form.Show();
            
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonas form = new frmPersonas();
            form.MdiParent = this;
            form.Show();
        }

        private void entradasSalidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEntradas_Salidas from = new frmEntradas_Salidas();
            from.MdiParent = this;
            from.Show();
        }

        private void carrerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCarreras form = new frmCarreras();
            form.MdiParent = this;
            form.Show();
        }

        private void extensionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExtension form = new frmExtension();
            form.MdiParent = this;
            form.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
