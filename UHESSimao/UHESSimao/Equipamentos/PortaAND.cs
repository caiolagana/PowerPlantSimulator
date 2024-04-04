﻿using System;
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
    public partial class PortaAND : PortaLogica
    {
        public PortaAND()
        {
            this.BackgroundImage = UHESSimao.Properties.Resources.and;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackColor = Color.LightSteelBlue;
            this.Height = 50;
            this.Width = 50;

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
