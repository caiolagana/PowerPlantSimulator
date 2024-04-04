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
    public partial class Form_Vao_03 : Form
    {
        Form1 Form1;

        public Form_Vao_03(Form1 _Form1)
        {
            InitializeComponent();

            Form1 = _Form1;

            foreach (TabPage tab in tabControl1.TabPages)
            {
                foreach (Control equip in tab.Controls)
                {
                    if (equip is Equipamento)
                    {
                        Form1.equipList.Add((Equipamento)equip);
                        Form1.equipDict.Add(equip.Name, Form1.equipList.Count - 1);
                    }

                    if (equip is PontoVazado)
                        Form1.pvazadoList.Add((PontoVazado)equip);

                    if (equip is LED)
                        Form1.LedList.Add((LED)equip);

                    //if (equip is Mostrador)
                    //    Form1.mostradorList.Add((Mostrador)equip);

                    if (equip is Disjuntor)
                        if (((Disjuntor)equip).Link != "null")
                            Form1.linksList.Add((Disjuntor)equip);
                }
            }
        }

        private void button74_Click(object sender, EventArgs e)
        {
            Form1.FormUGs.tabControl1.SelectTab(2);
            Form1.FormUGs.Show();//CHECAR!!!
        }
    }
}
