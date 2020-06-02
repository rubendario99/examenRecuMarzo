using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Recuperacion_DI2aEv;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Alumno> alumnos = new List<Alumno>();
        bool animacion = false;
        public Form1()
        {
            InitializeComponent();
            Alumno alumno1 = new Alumno("ruben", 8);
            Alumno alumno2 = new Alumno("laura", 6);
            Alumno alumno3 = new Alumno("diego", 3);
            Alumno alumno4 = new Alumno("ivan", 10);
            Alumno alumno5 = new Alumno("nombredemasdeveintecaracteres", 8); //nombredemasdeveintec
            Alumno alumno6 = new Alumno("daniel", 5);
            Alumno alumno7 = new Alumno("juan", 6);
            Alumno alumno8 = new Alumno("maria", 5);
            Alumno alumno9 = new Alumno("hermenegildo", 4);
            Alumno alumno10 = new Alumno("heliodoro", 7);
            Alumno alumno11 = new Alumno("cristina", 9);
            Alumno alumno12 = new Alumno("troy", 2);


            alumnos.Add(alumno1);
            alumnos.Add(alumno2);
            alumnos.Add(alumno3);
            alumnos.Add(alumno4);
            alumnos.Add(alumno5);
            alumnos.Add(alumno6);
            alumnos.Add(alumno7);
            alumnos.Add(alumno8);
            alumnos.Add(alumno9);
            alumnos.Add(alumno10);
            alumnos.Add(alumno11);
            alumnos.Add(alumno12);

            foreach (Alumno alumno in alumnos)
            {
                listBox1.Items.Add(alumno);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 1)
            {
                toolTip1.SetToolTip(listBox1, "Selección múltiple");
            }
            if (listBox1.SelectedItems.Count == 1)
            {
                string nombre = alumnos[listBox1.SelectedIndex].Nombre;
                int nota = alumnos[listBox1.SelectedIndex].Nota;

                toolTip1.SetToolTip(listBox1, String.Format("Nombre: {0}\nNota: {1}", nombre, nota));
            }
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
            {
                alumnos.RemoveAt(listBox1.SelectedIndices[i]);
                listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
            }
        }

        private void añadirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDatos frmDatos = new FrmDatos();
            DialogResult dialogResult = frmDatos.ShowDialog();

            switch (dialogResult)
            {
                case DialogResult.OK:

                    string nombre = frmDatos.textBoxNombre.Text;
                    int nota = Convert.ToInt32(frmDatos.comboBox1.SelectedItem);

                    Alumno alumno = new Alumno(nombre, nota);
                    alumnos.Add(alumno);
                    listBox1.Items.Add(alumno);

                    break;
            }
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form2 = new Form();
            form2.Size = new Size(500, 500);

            int x = 0;
            int y = 0;
            int columna = 0;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string nombreAlumno = listBox1.Items[i].ToString();
                int notaAlumno = alumnos[i].Nota;
                columna++;

                //label
                Label lblNombre = new Label();
                lblNombre.Location = new System.Drawing.Point(x, y);
                lblNombre.Name = "lblNombre" + i;
                lblNombre.Text = nombreAlumno;
                lblNombre.Size = new System.Drawing.Size(58, 17);

                //barra timer
                BarraTimer barraTimer = new BarraTimer();
                barraTimer.Location = new System.Drawing.Point(x, y + 40);
                barraTimer.Name = "barraTimer" + i;
                barraTimer.Size = new System.Drawing.Size(100, 100);
                barraTimer.IntervaloTmr = 100;
                barraTimer.Max = notaAlumno*10;
                barraTimer.ActivoTmr = true;

                if (animacion)
                {
                    barraTimer.Manual = false;
                    barraTimer.Valor = 0;
                }
                else
                {
                    barraTimer.Manual = true;
                    barraTimer.Valor = barraTimer.Max;
                }

                form2.Controls.Add(lblNombre);
                form2.Controls.Add(barraTimer);

                if (columna >= 3)
                {
                    x = 0;
                    y += 140;
                    columna = 0;
                }
                else
                {
                    x += 190;
                }

            }

            form2.Show();
        }

        private void chkAnimacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnimacion.Checked)
            {
                animacion = true;
            }
            else
            {
                animacion = false;
            }
        }
    }
}
