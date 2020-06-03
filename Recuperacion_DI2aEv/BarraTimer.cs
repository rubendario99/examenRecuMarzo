using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recuperacion_DI2aEv
{
    [DefaultProperty("Manual")]
    [DefaultEvent("LimiteAlcanzado")]
    public partial class BarraTimer : UserControl
    {
        public BarraTimer()
        {
            InitializeComponent();
        }

        //propiedades
        private bool manual;
        [Category("Examen")]
        [Description("Indica si la barra se maneja manual o automáticamente")]
        public bool Manual
        {
            set
            {
                manual = value;
            }
            get
            {
                return manual;
            }
        }
        private int max;
        [Category("Examen")]
        [Description("Valor máximo que podrá tener la barra de progreso")]
        public int Max
        {
            set
            {
                max = value;
                valor = 0;
                if (value < 0)
                {
                    throw new ArgumentException();
                }
            }
            get
            {
                return max;
            }
        }
        private int valor;
        [Category("Examen")]
        [Description("Valor en un momento dado de la barra de progreso")]
        public int Valor
        {
            set
            {
                valor = value;

                if (valor > Max)
                {
                    valor = Max;
                }
                if (valor < 0)
                {
                    valor = 0;
                }
                if (valor == Max)
                {
                    LimiteAlcanzado?.Invoke(this, EventArgs.Empty);
                    tmr.Enabled = false;
                }

                string textoLabel = String.Format("{0,4}", valor);

                lbl.Text = textoLabel;
            }
            get
            {
                return valor;
            }
        }

        [Category("Examen")]
        [Description("Acceso a la propiedad interval del timer")]
        public int IntervaloTmr
        {
            set
            {
                tmr.Interval = value;
            }
            get
            {
                return tmr.Interval;
            }
        }

        [Category("Examen")]
        [Description("Acceso a la propiedad enabled del timer")]
        public bool ActivoTmr
        {
            set
            {
                tmr.Enabled = value;
            }
            get
            {
                return tmr.Enabled;
            }
        }

        //eventos
        [Category("Examen")]
        [Description("Se lanza cuando es alcanzado el valor maximo")]
        public event EventHandler LimiteAlcanzado;

        [Category("Examen")]
        [Description("Se lanza cuando el mouse entra en el label")]
        public EventHandler LblEnter;

        [Category("Examen")]
        [Description("Se lanza cuando el mouse abandona el label")]
        public EventHandler LblLeave;

        private void lbl_MouseEnter(object sender, EventArgs e)
        {
            LblEnter?.Invoke(this, e);
        }

        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            LblLeave?.Invoke(this, e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen pen = new Pen(new SolidBrush(this.ForeColor), this.FontHeight);
            //e.Graphics.DrawLine(pen, lbl.Width + 10, lbl.Location.Y + 7, this.Width - 10, lbl.Location.Y + 7);
            e.Graphics.DrawLine(pen, lbl.Width + 10, lbl.Location.Y + 7, lbl.Width+valor, lbl.Location.Y + 7);
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            if (Manual == false)
            {
                Valor++;
            }
            this.Refresh();
        }
    }
}
