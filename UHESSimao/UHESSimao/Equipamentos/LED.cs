using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHESSimao
{
    public partial class LED : Equipamento
    {
        public bool estado = Const.LedON;

        public LED()
        {
            this.BackColor = Const.ColorLedOff;
            this.Height = 30;
            this.Width = 30;

            InitializeComponent();
        }

        public void AtualizaCor(bool estado)
        {
            this.BackColor = estado == Const.LedON ? Const.ColorLedOn : Const.ColorLedOff;
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
    }
}
