using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace UHESSimao
{
    public partial class Disjuntor : Equipamento
    {
        public String especie = "Disjuntor";
        public bool estado = Const.A;
        public int width = 30;
        public int height = 30;

        public Disjuntor()
        {
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this_Click);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            AtualizaCor(e);

            InitializeComponent();
        }

        private void this_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
            }
            else
            {
            }

            Form1.DisjuntorClicado = this.Name;
            estado = !estado;
            Form1.ev_Fluxo.Set();

            AtualizaCor(estado);
        }

        public void AtualizaCor(bool estado)
        {
            switch (especie)
            {
                case "SecBaixo":
                    this.BackgroundImage = (estado == Const.A ? Properties.Resources.SEC_ABE_BAIXO_VET : Properties.Resources.SEC_FEC_BAIXO_VET);
                    break;
                case "SecCima":
                    this.BackgroundImage = (estado == Const.A ? Properties.Resources.SEC_ABE_CIMA_VET : Properties.Resources.SEC_FEC_CIMA_VET);
                    break;
                case "SecDir":
                    this.BackgroundImage = (estado == Const.A ? Properties.Resources.SEC_ABE_DIR_HOR : Properties.Resources.SEC_FEC_DIR_HOR);
                    break;
                case "SecEsq":
                    this.BackgroundImage = (estado == Const.A ? Properties.Resources.SEC_ABE_ESQ_HOR : Properties.Resources.SEC_FEC_ESQ_HOR);
                    break;
                case "Disjuntor":
                    this.BackgroundImage = (estado == Const.A ? Properties.Resources.DJ_ABE : Properties.Resources.DJ_FEC);
                    break;
                case "DisjuntorLogico":
                    this.BackgroundImage = (estado == Const.A ? Properties.Resources.DisjuntorLogicoAberto : Properties.Resources.DisjuntorLogicoFechado);
                    break;
            }
        }

        public bool e
        {
            get { return this.estado; }
            set
            {
                this.estado = (bool)value;
                AtualizaCor(estado);
            }
        }

        public String Especie
        {
            get { return this.especie; }
            set
            {
                this.especie = value;
                AtualizaCor(estado);
            }
        }

        public new int Height
        {
            get { return this.height; }
            set
            {
                this.height = value;
                AtualizaCor(estado);
            }
        }

        public new int Width
        {
            get { return this.width; }
            set
            {
                this.width = value;
                AtualizaCor(estado);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
