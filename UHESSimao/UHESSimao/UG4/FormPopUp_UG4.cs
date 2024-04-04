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
    public partial class FormPopUp_UG4 : Form
    {
        Form1 Form1;

        public FormPopUp_UG4(Form1 _Form1)
        {
            Form1 = _Form1;

            InitializeComponent();
        }

        private void Botao_Verde_I_UG4_Click(object sender, EventArgs e)
        {
            switch (Form1.PopUpClicado[4])
            {
                case "EXCITADA":
                    Form1.EstadoAlvo[4] = Const.EXCITADA;
                    switch (Form1.EstadoAtual[4])
                    {
                        case Const.MAQUINA_PARADA:
                            Form1.PassoAtual[4] = Const.PASSO_PARTIDA_1;
                            break;
                        case Const.PRONTA_GIRO_1:
                            Form1.PassoAtual[4] = Const.PASSO_PARTIDA_2;
                            break;
                        case Const.PRONTA_GIRO_2:
                            Form1.PassoAtual[4] = Const.PASSO_PARTIDA_3;
                            break;
                        case Const.PRONTA_GIRO_3:
                            Form1.PassoAtual[4] = Const.PASSO_PARTIDA_4;
                            break;
                        case Const.GIRO_MECANICO:
                            Form1.PassoAtual[4] = Const.PASSO_PARTIDA_5;
                            break;
                        case Const.EXCITADA:
                            Form1.FormLogs.log("UG4: Maquina já se encontra EXCITADA");
                            break;
                        case Const.PRE_SINCRONISMO:
                            Form1.FormLogs.log("UG4: Maquina se encontra em PRÉ-SINCRONISMO");
                            break;
                        case Const.SINCRONIZADA:
                            Form1.FormLogs.log("UG4: Maquina se encontra SINCRONIZADA");
                            break;
                    }
                    break;
                case "SINCRONIZADA":
                    Form1.EstadoAlvo[4] = Const.SINCRONIZADA;
                    switch (Form1.EstadoAtual[4])
                    {
                        case Const.MAQUINA_PARADA:
                            Form1.PassoAtual[4] = Const.PASSO_PARTIDA_1;
                            break;
                        case Const.PRONTA_GIRO_1:
                            Form1.PassoAtual[4] = Const.PASSO_PARTIDA_2;
                            break;
                        case Const.PRONTA_GIRO_2:
                            Form1.PassoAtual[4] = Const.PASSO_PARTIDA_3;
                            break;
                        case Const.PRONTA_GIRO_3:
                            Form1.PassoAtual[4] = Const.PASSO_PARTIDA_4;
                            break;
                        case Const.GIRO_MECANICO:
                            Form1.PassoAtual[4] = Const.PASSO_PARTIDA_5;
                            break;
                        case Const.EXCITADA:
                            Form1.PassoAtual[4] = Const.PASSO_PARTIDA_6;
                            break;
                        case Const.PRE_SINCRONISMO:
                            Form1.PassoAtual[4] = Const.PASSO_PARTIDA_7;
                            break;
                        case Const.SINCRONIZADA:
                            Form1.FormLogs.log("UG4: Maquina já se encontra SINCRONIZADA");
                            break;
                    }
                    break;
            }

            Form1.ev_GPM.ElementAt(4).Set();
            Form1.FormPopUp_UG4.Hide();
        }

        private void Botao_Vermelho_O_UG4_Click(object sender, EventArgs e)
        {
            Form1.EstadoAlvo[4] = Const.GIRO_MECANICO;

            switch (Form1.EstadoAtual[4])
            {
                case Const.SINCRONIZADA:
                    Form1.PassoAtual[4] = Const.PASSO_PARADA_1;
                    break;
                case Const.EXCITADA:
                    Form1.PassoAtual[4] = Const.PASSO_PARADA_2;
                    break;
            }

            Form1.ev_GPM.ElementAt(4).Set();
            Form1.FormPopUp_UG4.Hide();
        }
    }
}
