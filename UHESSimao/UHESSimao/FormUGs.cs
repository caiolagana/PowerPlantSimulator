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
    public partial class FormUGs : Form
    {
        Form1 Form1;

        public FormUGs(Form1 _Form1)
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

        //button MENU
        private void button_MENU_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        //button ESTRUTURAS
        private void button_TelaPrincipal_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        //buttons tela inicial HOME ================================================ tabPage1
        private void button_SE_500_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }
        private void button_SE_AC_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }
        private void button_PRINC_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button_UG04_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }
        private void button_TOM_AGUA_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage10;
        }
        private void button_VERT_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage25;
        }

        //buttons tela PRINCIPAL =====================================================  tabPage2

        private void button75_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void button173_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage12;
        }
        private void button76_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }
        private void button50_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }
        private void button49_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }
        private void button174_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage11;
        }
        private void button65_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage17;
        }
        private void button66_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage22;
        }
        private void button69_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage8;
        }
        private void button70_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage25;
        }

        //buttons tela CONTROLE DA PLANTA ============================================= tabPage3
        private void button25_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button23_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }
        private void button20_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }
        private void button22_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }
        private void button24_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage25;
        }
        private void button72_Click(object sender, EventArgs e)
        {
            Form_Niveis niveis = new Form_Niveis();
            niveis.Show();
        }

        //buttons tela SUBESTAÇÃO DE 500 KV ============================================= tabPage4
        private void button37_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button35_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void button33_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }
        private void button31_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage8;
        }
        private void button77_Click(object sender, EventArgs e)
        {
            Form1.Form_Vao_03.Show();
        }

        //buttons tela CASA DE FORÇA STATUS 480 VCA ======================================= tabPage5
        private void button48_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button46_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }
        private void button44_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }
        private void button47_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void button78_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage16;
        }

        //buttons tela SERVIÇO AUXILIAR 480 VCA DA CASA DE FORÇA ================================= tabPage6
        private void button62_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button60_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }
        private void button61_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void button55_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }
        private void button58_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage8;
        }

        //buttons tela UNIDADE GERADORA 04 ======================================= tabPage7
        private void button74_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button73_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void button71_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage15;
        }
        private void button67_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage12;
        }
        private void button68_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage13;
        }
        private void button42_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage8;
        }
        private void button149_Click_1(object sender, EventArgs e)
        {
            Form1.Form_Vao_03.Show();
        }
        private void button79_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage17;
        }
        private void button80_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage22;
        }
        private void button81_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage18;
        }
        private void button89_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage26;
        }


        //buttons tela SERVIÇO AUXILIAR 125 VCC DA CASA DE FORÇA ======================================= tabPage8
        private void button88_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button87_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void button85_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }
        private void button83_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }

        //buttons tela PRÉ-CONDIÇÃO DA CENTRAL DA TOMADA D`ÁGUA ======================================= tabPage9
        private void button100_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button99_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        //buttons tela CENTRAL OLEODINÂMICA DA TOMADA D`ÁGUA ======================================= tabPage10
        private void button112_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button111_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage11;
        }
        private void button109_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage9;
        }
        private void button63_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage24;
        }
        private void button64_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage25;
        }

        //buttons tela COMPORTAS DA TOMADA D`ÁGUA ======================================= tabPage11
        private void button124_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button122_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void button115_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage10;
        }
        private void button52_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage24;
        }
        private void button90_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage25;
        }

        //buttons tela REGULADOR DE VELOCIDADE DA UNIDADE 04 ======================================= tabPage12
        private void button136_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button135_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void button134_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }
        private void button91_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage20;
        }

        //buttons tela PRÉ-CONDIÇÕES PARA PARTIDA DA UNIDADE 04 ======================================= tabPage13
        private void button148_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button147_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void button146_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }
        private void button140_Click(object sender, EventArgs e)
        {
            Form1.Form_Partida_04.Show();
        }
        private void button145_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }
        private void button139_Click(object sender, EventArgs e)
        {
            Form1.Form_Parada_04.Show();
        }

        //buttons tela PRÉ-CONDIÇÕES DO VÃO 03 ======================================= tabPage14
        private void button175_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button160_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void button159_Click(object sender, EventArgs e)
        {
            Form1.Form_Vao_03.Show();
        }

        //buttons tela SISTEMA DE ÁGUA DE REFRIGERAÇÃO DA UNIDADE 04 ======================================= tabPage15
        private void button172_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button171_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage17;
        }
        private void button170_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }
        private void button92_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage15;
        }

        //buttons tela COMPRESSOR AR SERVIÇOS  ============================================================ tabPage16
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }

        //buttons tela GERADOR 04  ========================================================================== tabPage17
        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage15;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }
        private void button30_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage18;
        }
        private void button32_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage19;
        }
        private void button34_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage21;
        }

        //buttons tela MANCAL DE ESCORA E GUIA INFERIOR DO GERADOR 04 ====================================== tabPage18
        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage15;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }

        //buttons tela MANCAL GUIA SUPERIOR UG 04 ====================================== tabPage19
        private void button13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button14_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage15;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }
        private void button28_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage18;
        }
        private void button36_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage21;
        }
        private void button38_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage19;
        }

        //buttons tela MANCAL GUIA DA TURBINA UG 04 ====================================== tabPage20
        private void button17_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button18_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void button19_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage15;
        }
        private void button21_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }
        private void button26_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage18;
        }
        private void button27_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage19;
        }

        //buttons tela SISTEMA DE REFRIGERAÇÃO DO GERADOR 04 ====================================== tabPage21
        private void button29_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage17;
        }

        //buttons tela TRANSFORMADOR TRAFO 04 ======================================================= tabPage22
        private void button39_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button40_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }
        private void button41_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        //buttons tela NIVEIS E FLUXOS DA UNIDADE GERADORA 04 ======================================================= tabPage23
        private void button43_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage17;
        }

        //buttons tela CENTRAL OLEODINAMICA DO VERTEDOURO ======================================================= tabPage24
        private void button45_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button51_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage11;
        }

        //buttons tela CONTROLE DE POSIÇÃO DAS COMPORTAS DO VERTEDOURO ======================================================= tabPage25
        private void button53_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button54_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void button56_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage11;
        }
        private void button57_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage24;
        }
        private void button59_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage10;
        }

        //buttons tela CURVA DE CAPABILIDADE UG 04 ======================================================= tabPage26
        private void button82_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button84_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }
        private void button86_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage17;
        }

        private void Losango_Excitada_UG4_Click(object sender, EventArgs e)
        {
            Form1.PopUpClicado[4] = "EXCITADA";
            Form1.FormPopUp_UG4.Show();
        }

        private void Losango_Sincronizada_UG4_Click(object sender, EventArgs e)
        {
            Form1.PopUpClicado[4] = "SINCRONIZADA";
            Form1.FormPopUp_UG4.Show();
        }

        private void button_SetPointPotencia_UG4_Click(object sender, EventArgs e)
        {
            Form1.x[4].Pnominal = Double.Parse(textBox_SetPointPotencia_UG4.Text) * 1E6;
        }

        private void button_SetPointTensao_UG4_Click(object sender, EventArgs e)
        {
            Form1.x[4].TensaoExcitacaoPrescrita = Double.Parse(textBox_SetPointTensao_UG4.Text) * (Const.TensaoExcitacaoNominal / Const.TensaoEstatorPrescrita); }
    }
}
