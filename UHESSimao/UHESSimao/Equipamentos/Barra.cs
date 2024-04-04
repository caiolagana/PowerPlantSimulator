using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UHESSimao
{
    public partial class Barra : Equipamento
    {
        public Barra()
        {
            this.BackColor = Const.ColorBarraOff;
            this.Height = 5;
            this.Width = 50;

            InitializeComponent();
        }
    }
}
