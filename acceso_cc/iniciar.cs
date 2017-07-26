using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acceso_cc
{
   public class iniciar : System.Windows.Forms.ApplicationContext
   {
       public iniciar()
       {
           Formularios.frmLoginCoke formulario = new Formularios.frmLoginCoke();
           formulario.Show();
       }
   }
}
