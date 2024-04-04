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
    public partial class Mostrador : Label
    {
        public String leitura = "null";

        public Mostrador()
        {
            this.BackColor = Color.LightGray;

            InitializeComponent();
        }

        public Mostrador(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public String Leitura
        {
            get { return this.leitura; }
            set { this.leitura = value; }
        }
    }
}
