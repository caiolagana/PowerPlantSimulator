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
    public partial class Equipamento : Control
    {
        public double transforma = 1;
        public double tensao = Const.V0;
        public List<Equipamento> adjascentes;
        public String link = "null";

        public Equipamento()
        {
            InitializeComponent();
        }

        public double V
        {
            get { return this.tensao; }
            set { this.tensao = value; }
        }

        public String Link
        {
            get { return this.link; }
            set { this.link = value; }
        }

        public double Transforma
        {
            get { return this.transforma; }
            set { this.transforma = value; }
        }
    }
}
