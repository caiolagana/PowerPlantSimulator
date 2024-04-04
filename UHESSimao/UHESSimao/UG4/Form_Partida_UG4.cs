using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UHESSimao
{
    public partial class Form_Partida_04 : Form
    {
        Form1 Form1;
        private System.Windows.Forms.Timer timer;

        public Form_Partida_04(Form1 _Form1)
        {
            InitializeComponent();

            Form1 = _Form1;

            foreach (TabPage tab in tabControl1.TabPages)
            {
                foreach (Control equip in tab.Controls)
                {
                    if (equip is LED)
                        Form1.LedList.Add((LED)equip);
                }
            }

            timer = new System.Windows.Forms.Timer();
            timer.Enabled = true;
            timer.Interval = 400;
            timer.Tick += new System.EventHandler(this.timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            switch (Form1.PassoAtual[4])
            {
                case Const.PASSO_NULO:
                    button_Passo1_UG4.BackColor = Const.Blink0;
                    button_Passo2_UG4.BackColor = Const.Blink0;
                    button_Passo3_UG4.BackColor = Const.Blink0;
                    button_Passo4_UG4.BackColor = Const.Blink0;
                    button_Passo5_UG4.BackColor = Const.Blink0;
                    button_Passo6_UG4.BackColor = Const.Blink0;
                    button_Passo7_UG4.BackColor = Const.Blink0;
                    break;
                case Const.PASSO_PARTIDA_1:
                    button_Passo1_UG4.BackColor = (button_Passo1_UG4.BackColor == Const.Blink1 ? Const.Blink2 : Const.Blink1);
                    button_Passo2_UG4.BackColor = Const.Blink0;
                    button_Passo3_UG4.BackColor = Const.Blink0;
                    button_Passo4_UG4.BackColor = Const.Blink0;
                    button_Passo5_UG4.BackColor = Const.Blink0;
                    button_Passo6_UG4.BackColor = Const.Blink0;
                    button_Passo7_UG4.BackColor = Const.Blink0;
                    break;
                case Const.PASSO_PARTIDA_2:
                    button_Passo1_UG4.BackColor = Const.Blink0;
                    button_Passo2_UG4.BackColor = (button_Passo2_UG4.BackColor == Const.Blink1 ? Const.Blink2 : Const.Blink1);
                    button_Passo3_UG4.BackColor = Const.Blink0;
                    button_Passo4_UG4.BackColor = Const.Blink0;
                    button_Passo5_UG4.BackColor = Const.Blink0;
                    button_Passo6_UG4.BackColor = Const.Blink0;
                    button_Passo7_UG4.BackColor = Const.Blink0;
                    break;
                case Const.PASSO_PARTIDA_3:
                    button_Passo1_UG4.BackColor = Const.Blink0;
                    button_Passo2_UG4.BackColor = Const.Blink0;
                    button_Passo3_UG4.BackColor = (button_Passo3_UG4.BackColor == Const.Blink1 ? Const.Blink2 : Const.Blink1);
                    button_Passo4_UG4.BackColor = Const.Blink0;
                    button_Passo5_UG4.BackColor = Const.Blink0;
                    button_Passo6_UG4.BackColor = Const.Blink0;
                    button_Passo7_UG4.BackColor = Const.Blink0;
                    break;
                case Const.PASSO_PARTIDA_4:
                    button_Passo1_UG4.BackColor = Const.Blink0;
                    button_Passo2_UG4.BackColor = Const.Blink0;
                    button_Passo3_UG4.BackColor = Const.Blink0;
                    button_Passo4_UG4.BackColor = (button_Passo4_UG4.BackColor == Const.Blink1 ? Const.Blink2 : Const.Blink1);
                    button_Passo5_UG4.BackColor = Const.Blink0;
                    button_Passo6_UG4.BackColor = Const.Blink0;
                    button_Passo7_UG4.BackColor = Const.Blink0;
                    break;
                case Const.PASSO_PARTIDA_5:
                    button_Passo1_UG4.BackColor = Const.Blink0;
                    button_Passo2_UG4.BackColor = Const.Blink0;
                    button_Passo3_UG4.BackColor = Const.Blink0;
                    button_Passo4_UG4.BackColor = Const.Blink0;
                    button_Passo5_UG4.BackColor = (button_Passo5_UG4.BackColor == Const.Blink1 ? Const.Blink2 : Const.Blink1);
                    button_Passo6_UG4.BackColor = Const.Blink0;
                    button_Passo7_UG4.BackColor = Const.Blink0;
                    break;
                case Const.PASSO_PARTIDA_6:
                    button_Passo1_UG4.BackColor = Const.Blink0;
                    button_Passo2_UG4.BackColor = Const.Blink0;
                    button_Passo3_UG4.BackColor = Const.Blink0;
                    button_Passo4_UG4.BackColor = Const.Blink0;
                    button_Passo5_UG4.BackColor = Const.Blink0;
                    button_Passo6_UG4.BackColor = (button_Passo6_UG4.BackColor == Const.Blink1 ? Const.Blink2 : Const.Blink1);
                    button_Passo7_UG4.BackColor = Const.Blink0;
                    break;
                case Const.PASSO_PARTIDA_7:
                    button_Passo1_UG4.BackColor = Const.Blink0;
                    button_Passo2_UG4.BackColor = Const.Blink0;
                    button_Passo3_UG4.BackColor = Const.Blink0;
                    button_Passo4_UG4.BackColor = Const.Blink0;
                    button_Passo5_UG4.BackColor = Const.Blink0;
                    button_Passo6_UG4.BackColor = Const.Blink0;
                    button_Passo7_UG4.BackColor = (button_Passo7_UG4.BackColor == Const.Blink1 ? Const.Blink2 : Const.Blink1);
                    break;
            }
        }

            private void button_Passo1_UG4_Click(object sender, EventArgs e)
        {
            Form1.PassoAtual[4] = Const.PASSO_PARTIDA_1;
            Form1.ev_GPM.ElementAt(4).Set();
        }

        private void button_Passo2_UG4_Click(object sender, EventArgs e)
        {
            Form1.PassoAtual[4] = Const.PASSO_PARTIDA_2;
            Form1.ev_GPM.ElementAt(4).Set();
        }

        private void button_Passo3_UG4_Click(object sender, EventArgs e)
        {
            Form1.PassoAtual[4] = Const.PASSO_PARTIDA_3;
            Form1.ev_GPM.ElementAt(4).Set();
        }

        private void button_Passo4_UG4_Click(object sender, EventArgs e)
        {
            Form1.PassoAtual[4] = Const.PASSO_PARTIDA_4;
            Form1.ev_GPM.ElementAt(4).Set();
        }
    }
}
