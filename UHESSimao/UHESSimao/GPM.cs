using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace UHESSimao
{
    public class GPM
    {
        Form1 Form1;
        private Stopwatch crono;
        private int ug;
        public bool[] PassoOK = new bool[23];
        public int TempoAguardaResposta = 500;
        public int TempoComandoPasso = 700;
        public bool AUTO = true;

        public GPM(Form1 _Form1, int _ug)
        {
            Form1 = _Form1;
            ug = _ug;
            crono = new Stopwatch();
        }

        public void Set()
        {
            switch (Form1.PassoAtual[ug])
            {
                case Const.PASSO_PARTIDA_1:
                    ComandaPasso01();
                    break;
                case Const.PASSO_PARTIDA_2:
                    ComandaPasso02();
                    break;
                case Const.PASSO_PARTIDA_3:
                    ComandaPasso03();
                    break;
                case Const.PASSO_PARTIDA_4:
                    ComandaPasso04();
                    break;
                case Const.PASSO_PARTIDA_5:
                    ComandaPasso05();
                    break;
                case Const.PASSO_PARTIDA_6:
                    ComandaPasso06();
                    break;
                case Const.PASSO_PARTIDA_7:
                    ComandaPasso07();
                    break;
            }
        }

        public void Write(String msg)
        {
            Form1.FormLogs.log("UG" + ug.ToString() + ": " + msg);
        }

        //==========================================================================================================================================================
        // Passo 1
        //==========================================================================================================================================================

        bool PreRequisitosPasso01()
        {
            bool r = Const.NOK;

            Write("Passo 1: Checando pré-requisitos"); Thread.Sleep(TempoComandoPasso);

            if (((Barra)(Form1.Fluxo.GetEquip("Form1_barraPreCondicoes_UG" + ug.ToString()))).V > 0)
            {
                Write("Passo 1: Pré-requisitos OK");
                r = Const.OK;
            }
            else Write("Passo 1: Pré-requisitos não satisfeitos");

            Thread.Sleep(TempoComandoPasso);

            return r;
        }

        public bool RespostaPasso01()
        {
            bool r = Const.NOK;

            if (((Barra)(Form1.Fluxo.GetEquip("barra_Passo1_UG" + ug.ToString()))).V > 0)
            {
                r = Const.OK;
            }

            return r;
        }

        void ComandaPasso01()
        {
            Write("Iniciando Passo 1"); Thread.Sleep(TempoComandoPasso);
            crono.Restart();

            if (PreRequisitosPasso01())
            {
                Write("Passo 1: Desenergizando Relé de Parada"); Thread.Sleep(Const.TempoDesenergizacaoReleParada);
                //((Disjuntor)(Form1.Fluxo.GetEquip("ValvulaVAR1E0001"))).interruptor_UG[GpmUG] = true;

                Form1.ev_Fluxo.Set();
            }
            else
            {
                Write("Passo 1: Abortando sequência");
                Form1.PassoAtual[ug] = Const.PASSO_NULO;
                return;
            }

            while (RespostaPasso01() == Const.NOK && crono.ElapsedMilliseconds < Const.TempoEtapaMax && Form1.PassoAtual[ug] == Const.PASSO_PARTIDA_1)
            {
                Thread.Sleep(TempoAguardaResposta);
            }

            crono.Stop();

            if (crono.ElapsedMilliseconds > Const.TempoEtapaMax)
            {
                Write("Passo 1: Tempo esgotado. Abortando sequência");
                Form1.PassoAtual[ug] = Const.PASSO_NULO;
                return;
            }

            Form1.ev_Fluxo.Set(); // Atualiza estado maquina

            if (RespostaPasso01() && Form1.EstadoAtual[ug] < Form1.EstadoAlvo[ug] && AUTO)
            {
                Write("Passo 1: Etapa concluida com sucesso. Executando Passo 2");
                Form1.PassoAtual[ug] = Const.PASSO_PARTIDA_2;
            }
            else if (Form1.PassoAtual[ug] == Const.PASSO_PARTIDA_1)
            {
                Write("Passo 1: Etapa concluida com sucesso");
                Form1.PassoAtual[ug] = Const.PASSO_NULO;
            }

            Form1.UltimoPasso[ug] = Const.PASSO_PARTIDA_1;
            Form1.ev_GPM.ElementAt(ug).Set();
            crono.Reset();
        }

        //==========================================================================================================================================================
        // Passo 2
        //==========================================================================================================================================================

        bool PreRequisitosPasso02()
        {
            bool r = Const.NOK;

            Write("Passo 2: Checando pré-requisitos"); Thread.Sleep(TempoComandoPasso);

            if (((Barra)(Form1.Fluxo.GetEquip("barra_Passo1_UG" + ug.ToString()))).V > 0)
            {
                Write("Passo 2: Pré-requisitos OK");
                r = Const.OK;
            }
            else Write("Passo 2: Pré-requisitos não satisfeitos");

            Thread.Sleep(TempoComandoPasso);

            return r;
        }

        public bool RespostaPasso02()
        {
            bool r = Const.NOK;

            if (((Barra)(Form1.Fluxo.GetEquip("barra_Passo2_UG" + ug.ToString()))).V > 0)
            {
                r = Const.OK;
            }

            return r;
        }

        void ComandaPasso02()
        {
            Write("Iniciando Passo 2"); Thread.Sleep(TempoComandoPasso);
            crono.Restart();

            if (PreRequisitosPasso02())
            {
                Write("Passo 2: Excitação Pos. Nom. sem Carga"); Thread.Sleep(Const.TempoExcitacaoPosNomSemCarga);
                //Comanda...

                Write("Passo 2: Desligando Resist. Aquec. Gerador"); Thread.Sleep(Const.TempoDesligResistAquecGerador);
                //Comanda...

                Write("Passo 2: Fechando Disj. Campo"); Thread.Sleep(Const.TempoFechDisjCampo);
                //Comanda...

                Write("Passo 2: Ligando Bomba 1 ou 2 M. Escora"); Thread.Sleep(Const.TempoLigBomba1ou2MancEscora);
                //Comanda...

                Write("Passo 2: Ligando Bomba 1 ou 2 M. Gui"); Thread.Sleep(Const.TempoLigBomba1ou2MancGuia);
                //Comanda...

                Write("Passo 2: Aplicando Freios"); Thread.Sleep(Const.TempoAplicFreio);
                ((Disjuntor)(Form1.Fluxo.GetEquip("disjuntor_Freio_UG" + ug.ToString()))).e = Const.F;
                Form1.ev_Fluxo.Set();

                Write("Passo 2: Ligando Bomba 1 ou 2 Regulador"); Thread.Sleep(Const.TempoLigBomba1ou2RV);
                ((Disjuntor)(Form1.Fluxo.GetEquip("disjuntor_BombaRV_UG" + ug.ToString()))).e = Const.F;
                Form1.ev_Fluxo.Set();

                Write("Passo 2: Fluxo de Oleo M. Guia Inferior"); Thread.Sleep(Const.TempoFluxoOleoMancGuiaInf);
                ((Disjuntor)(Form1.Fluxo.GetEquip("disjuntor_FluxoOleoMGuiaInferior_UG" + ug.ToString()))).e = Const.F;
                Form1.ev_Fluxo.Set();

                Write("Passo 2: Fluxo/Pressão MG/ME/RV"); Thread.Sleep(Const.TempoFluxoPressaoMGMERV);
                //Comanda...

                Write("Passo 2: Abrindo Válvula Tanque R. Veloc."); Thread.Sleep(Const.TempoAbrValvulaTanqueRV);
                //Comanda...
            }
            else
            {
                Write("Passo 2: Abortando sequência");
                Form1.PassoAtual[ug] = Const.PASSO_NULO;
                return;
            }

            while (RespostaPasso02() == Const.NOK && crono.ElapsedMilliseconds < Const.TempoEtapaMax && Form1.PassoAtual[ug] == Const.PASSO_PARTIDA_2)
            {
                Thread.Sleep(TempoAguardaResposta);
            }

            crono.Stop();

            if (crono.ElapsedMilliseconds > Const.TempoEtapaMax)
            {
                Write("Passo 2: Tempo esgotado. Abortando sequência");
                Form1.PassoAtual[ug] = Const.PASSO_NULO;
                return;
            }

            Form1.ev_Fluxo.Set(); // Atualiza estado maquina

            if (RespostaPasso02() && Form1.EstadoAtual[ug] < Form1.EstadoAlvo[ug] && AUTO)
            {
                Write("Passo 2: Etapa concluida com sucesso. Executando Passo 3");
                Form1.PassoAtual[ug] = Const.PASSO_PARTIDA_3;
            }
            else if (Form1.PassoAtual[ug] == Const.PASSO_PARTIDA_2)
            {
                Write("Passo 2: Etapa concluida com sucesso");
                Form1.PassoAtual[ug] = Const.PASSO_NULO;
            }

            Form1.UltimoPasso[ug] = Const.PASSO_PARTIDA_2;
            Form1.ev_GPM.ElementAt(ug).Set();
            crono.Reset();
        }

        //==========================================================================================================================================================
        // Passo 3
        //==========================================================================================================================================================

        bool PreRequisitosPasso03()
        {
            bool r = Const.NOK;

            Write("Passo 3: Checando pré-requisitos"); Thread.Sleep(TempoComandoPasso);

            if (((Barra)(Form1.Fluxo.GetEquip("barra_Passo2_UG" + ug.ToString()))).V > 0)
            {
                Write("Passo 3: Pré-requisitos OK");
                r = Const.OK;
            }
            else Write("Passo 3: Pré-requisitos não satisfeitos");

            Thread.Sleep(TempoComandoPasso);

            return r;
        }

        public bool RespostaPasso03()
        {
            bool r = Const.NOK;

            if (((Barra)(Form1.Fluxo.GetEquip("barra_Passo3_UG" + ug.ToString()))).V > 0)
            {
                r = Const.OK;
            }

            return r;
        }

        void ComandaPasso03()
        {
            Write("Iniciando Passo 3"); Thread.Sleep(TempoComandoPasso);
            crono.Restart();

            if (PreRequisitosPasso03())
            {
                Write("Passo 3: Fluxo Água Refrigeração"); Thread.Sleep(TempoComandoPasso);
                ((Disjuntor)(Form1.Fluxo.GetEquip("disjuntor_FluxoAguaRefr_UG" + ug.ToString()))).e = Const.F;
                Form1.ev_Fluxo.Set();

                Write("Passo 3: Bomba 1 ou 2 Injeção Ligada"); Thread.Sleep(TempoComandoPasso);
                ((Disjuntor)(Form1.Fluxo.GetEquip("disjuntor_Bomba1ou2Injecao_UG" + ug.ToString()))).e = Const.F;
                Form1.ev_Fluxo.Set();

                Write("Passo 3: Pressão de Óleo Bomba de Alta ME"); Thread.Sleep(TempoComandoPasso);
                ((Disjuntor)(Form1.Fluxo.GetEquip("disjuntor_FluxoOleoBombaAltaME_UG" + ug.ToString()))).e = Const.F;
                Form1.ev_Fluxo.Set();
            }
            else
            {
                Write("Passo 3: Abortando sequência");
                Form1.PassoAtual[ug] = Const.PASSO_NULO;
                return;
            }

            while (RespostaPasso03() == Const.NOK && crono.ElapsedMilliseconds < Const.TempoEtapaMax && Form1.PassoAtual[ug] == Const.PASSO_PARTIDA_3)
            {
                Thread.Sleep(TempoAguardaResposta);
            }

            crono.Stop();

            if (crono.ElapsedMilliseconds > Const.TempoEtapaMax)
            {
                Write("Passo 3: Tempo esgotado. Abortando sequência");
                Form1.PassoAtual[ug] = Const.PASSO_NULO;
                return;
            }

            if (RespostaPasso03() && Form1.EstadoAtual[ug] < Form1.EstadoAlvo[ug] && AUTO)
            {
                Write("Passo 3: Etapa concluida com sucesso. Executando Passo 4");
                Form1.PassoAtual[ug] = Const.PASSO_PARTIDA_4;
            }
            else if (Form1.PassoAtual[ug] == Const.PASSO_PARTIDA_3)
            {
                Write("Passo 3: Etapa concluida com sucesso");
                Form1.PassoAtual[ug] = Const.PASSO_NULO;
            }

            Form1.UltimoPasso[ug] = Const.PASSO_PARTIDA_3;
            Form1.ev_GPM.ElementAt(ug).Set();
            crono.Reset();
        }

        //==========================================================================================================================================================
        // Passo 4
        //==========================================================================================================================================================

        bool PreRequisitosPasso04()
        {
            bool r = Const.NOK;

            Write("Passo 4: Checando pré-requisitos"); Thread.Sleep(TempoComandoPasso);

            if (((Barra)(Form1.Fluxo.GetEquip("barra_Passo3_UG" + ug.ToString()))).V > 0)
            {
                Write("Passo 4: Pré-requisitos OK");
                r = Const.OK;
            }
            else Write("Passo 4: Pré-requisitos não satisfeitos");

            Thread.Sleep(TempoComandoPasso);

            return r;
        }

        public bool RespostaPasso04()
        {
            bool r = Const.NOK;

            if (((Barra)(Form1.Fluxo.GetEquip("barra_Passo4_UG" + ug.ToString()))).V > 0)
            {
                r = Const.OK;
            }

            return r;
        }

        void ComandaPasso04()
        {
            Write("Iniciando Passo 4"); Thread.Sleep(TempoComandoPasso);
            crono.Restart();

            if (PreRequisitosPasso04())
            {
                Write("Passo 4: Desaplicando trava distribuidor"); Thread.Sleep(TempoComandoPasso);
                ((Disjuntor)(Form1.Fluxo.GetEquip("disjuntor_TravaDistribuidor_UG" + ug.ToString()))).e = Const.F;
                Form1.ev_Fluxo.Set();

                Write("Passo 4: Desaplicando freios"); Thread.Sleep(TempoComandoPasso);
                ((Disjuntor)(Form1.Fluxo.GetEquip("disjuntor_Freio_UG" + ug.ToString()))).e = Const.A;
                Form1.ev_Fluxo.Set();

                Write("Passo 4: Abrindo distribuidor"); Thread.Sleep(TempoComandoPasso);
                ((Disjuntor)(Form1.Fluxo.GetEquip("disjuntor_RV_UG" + ug.ToString()))).e = Const.F;
                Form1.ev_Fluxo.Set();

                Write("Passo 4: Aguardando velocidade > 50%"); Thread.Sleep(TempoComandoPasso);
                while (((Barra)(Form1.Fluxo.GetEquip("barra_Velocidade50_UG" + ug.ToString()))).V == 0 && crono.ElapsedMilliseconds < Const.TempoEtapaMax && Form1.PassoAtual[ug] == Const.PASSO_PARTIDA_4)
                {
                    Thread.Sleep(TempoAguardaResposta);
                    Form1.ev_Fluxo.Set();
                }

                Write("Passo 4: Desligando bomba 1 e 2 Injeção"); Thread.Sleep(TempoComandoPasso);
                ((Disjuntor)(Form1.Fluxo.GetEquip("disjuntor_Bomba1ou2Injecao_UG" + ug.ToString()))).e = Const.A;
                Form1.ev_Fluxo.Set();

                Write("Passo 4: Aguardando velocidade > 90%"); Thread.Sleep(TempoComandoPasso);
                while (((Barra)(Form1.Fluxo.GetEquip("barra_Velocidade90_UG" + ug.ToString()))).V == 0 && crono.ElapsedMilliseconds < Const.TempoEtapaMax && Form1.PassoAtual[ug] == Const.PASSO_PARTIDA_4)
                {
                    Thread.Sleep(TempoAguardaResposta);
                    Form1.ev_Fluxo.Set();
                }
            }
            else
            {
                Write("Passo 4: Abortando sequência");
                Form1.PassoAtual[ug] = Const.PASSO_NULO;
                return;
            }

            while (RespostaPasso04() == Const.NOK && crono.ElapsedMilliseconds < Const.TempoEtapaMax && Form1.PassoAtual[ug] == Const.PASSO_PARTIDA_4)
            {
                Thread.Sleep(TempoAguardaResposta);
            }

            crono.Stop();

            if (crono.ElapsedMilliseconds > Const.TempoEtapaMax)
            {
                Write("Passo 4: Tempo esgotado. Abortando sequência");
                Form1.PassoAtual[ug] = Const.PASSO_NULO;
                return;
            }

            if (RespostaPasso04() && Form1.EstadoAtual[ug] < Form1.EstadoAlvo[ug] && AUTO)
            {
                Write("Passo 4: Etapa concluida com sucesso. Executando Passo 5");
                Form1.PassoAtual[ug] = Const.PASSO_PARTIDA_5;
            }
            else if (Form1.PassoAtual[ug] == Const.PASSO_PARTIDA_4)
            {
                Write("Passo 4: Etapa concluida com sucesso");
                Form1.PassoAtual[ug] = Const.PASSO_NULO;
            }

            Form1.UltimoPasso[ug] = Const.PASSO_PARTIDA_4;
            Form1.ev_GPM.ElementAt(ug).Set();
            crono.Reset();
        }

        //==========================================================================================================================================================
        // Passo 5
        //==========================================================================================================================================================

        void ComandaPasso05()
        {
        }

        //==========================================================================================================================================================
        // Passo 6
        //==========================================================================================================================================================

        void ComandaPasso06()
        {
        }

        //==========================================================================================================================================================
        // Passo 7
        //==========================================================================================================================================================

        void ComandaPasso07()
        {
        }
    }
}
