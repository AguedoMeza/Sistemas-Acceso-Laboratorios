using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalReport = CrystalDecisions.CrystalReports.Engine;
namespace acceso_cc.Formularios
{
    public partial class frmVisualizador : Form
    {
        public frmVisualizador(CrystalReport.ReportDocument Reporte)
        {
            InitializeComponent();

            this.crvVisualizador.ReportSource = Reporte;
        }
        private void frmVisualizador_Load(object sender, EventArgs e)
        {

        }

        private void crvVisualizador_Load(object sender, EventArgs e)
        {

        }
    }
}
