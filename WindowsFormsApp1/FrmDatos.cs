using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmDatos : Form
    {
        public FrmDatos()
        {
            InitializeComponent();

            for(int i=1; i<=100; i++) {
                comboBox1.Items.Add(i);
            }
        }
    }
}
