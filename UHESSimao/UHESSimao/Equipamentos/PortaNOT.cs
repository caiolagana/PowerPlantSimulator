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
    public partial class PortaNOT : PortaLogica
    {
        public PortaNOT()
        {
            this.BackgroundImage = UHESSimao.Properties.Resources.not;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackColor = Color.LightSteelBlue;
            this.Height = 50;
            this.Width = 50;

            InitializeComponent();
        }
    }
}
