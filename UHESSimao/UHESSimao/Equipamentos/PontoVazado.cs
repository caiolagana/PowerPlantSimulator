using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UHESSimao
{
    public partial class PontoVazado : Control
    {
        public PontoVazado()
        {
            this.BackColor = Color.Yellow;
            this.Height = 20;
            this.Width = 20;

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
