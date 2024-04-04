using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace UHESSimao
{
    public partial class FonteDeTensao : Equipamento
    {
        public String especie = "Fonte";

        public FonteDeTensao()
        {
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Height = 5;
            this.Width = 50;

            AtualizaCor(this.Especie, this.V);

            InitializeComponent();
        }

        public void AtualizaCor(String especie, double V)
        {
            switch (especie)
            {
                case "Fonte":
                    this.BackColor = (V > 0 ? Const.ColorBarraOn : Const.ColorBarraOff);
                    this.BackgroundImage = null;
                    break;
                case "UG_parada":
                    this.BackColor = Color.Silver;
                    break;
                case "UG_pronta":
                    this.BackColor = Color.Purple;
                    break;
                case "UG_giro":
                    this.BackColor = Color.Yellow;
                    break;
                case "UG_excitada":
                    this.BackColor = Color.Violet;
                    break;
                case "UG_sincronizada":
                    this.BackColor = Color.Pink;
                    break;
                case "UG_erro":
                    this.BackColor = Color.Orange;
                    break;
            }
        }

        public String Especie
        {
            get { return this.especie; }
            set
            {
                this.especie = value;
                AtualizaCor(this.especie, this.V);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
