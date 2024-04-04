using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UHESSimao
{
    public partial class Losango : Control
    {
        public String especie = "Losango";
        public bool estado = true;

        public Losango()
        {
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this_Click);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            this.Height = 50;
            this.Width = 50;

            AtualizaCor(estado);

            InitializeComponent();
        }

        private void this_Click(object sender, MouseEventArgs e)
        {
            //if (this.Especie == "Losango") this.Estado = !this.Estado;
        }

        public bool Estado
        {
            get { return this.estado; }
            set
            {
                this.estado = (bool)value;
                AtualizaCor(estado);
            }
        }

        public void AtualizaCor(bool estado)
        {
            switch (especie)
            {
                case "Losango":
                    this.BackgroundImage = (estado == false ? Properties.Resources.BT_Loz_Preto : Properties.Resources.BT_Loz_Verde);
                    break;
                case "OnOff":
                    this.BackgroundImage = (estado == false ? Properties.Resources.O_Vermelho : Properties.Resources.I_Verde);
                    break;
                case "OnOffDisabled":
                    this.BackgroundImage = (estado == false ? Properties.Resources.O_Cinza : Properties.Resources.I_Cinza);
                    break;
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
    }
}
