using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Numerics;

namespace UHESSimao
{
    public partial class Form1 : Form
    {
        // Variáveis físicas
        //=================================================================================================================
        Thread thread_loopFisico1;
        Thread thread_loopFisico2;
        Thread thread_loopFisico3;
        Thread thread_loopFisico4;
        Thread thread_loopFisico5;
        Thread thread_loopFisico6;
        public Vars[] x = new Vars[Const.nUGs + 1];
        double h = 71.3;

        // Variáveis do Gerenciador dos Processos da Maquina (GPM)
        //=================================================================================================================
        public GPM GPM1;
        public GPM GPM2;
        public GPM GPM3;
        public GPM GPM4;
        public GPM GPM5;
        public GPM GPM6;
        Thread thread_GPM1;
        Thread thread_GPM2;
        Thread thread_GPM3;
        Thread thread_GPM4;
        Thread thread_GPM5;
        Thread thread_GPM6;
        public int[] PassoAtual = new int[Const.nUGs + 1];
        public int[] UltimoPasso = new int[Const.nUGs + 1];
        public int[] EstadoAtual = new int[Const.nUGs + 1];
        public int[] EstadoAlvo = new int[Const.nUGs + 1];

        // Variáveis do fluxo de potencia
        //=================================================================================================================
        public Fluxo Fluxo;
        FluxoLogico FluxoLogico;
        Thread thread_Fluxo;
        public static AutoResetEvent ev_Fluxo = new AutoResetEvent(false);
        public static AutoResetEvent ev_dummy = new AutoResetEvent(false);
        public static AutoResetEvent ev_GPM1 = new AutoResetEvent(false);
        public static AutoResetEvent ev_GPM2 = new AutoResetEvent(false);
        public static AutoResetEvent ev_GPM3 = new AutoResetEvent(false);
        public static AutoResetEvent ev_GPM4 = new AutoResetEvent(false);
        public static AutoResetEvent ev_GPM5 = new AutoResetEvent(false);
        public static AutoResetEvent ev_GPM6 = new AutoResetEvent(false);
        public List<AutoResetEvent> ev_GPM = new List<AutoResetEvent>();
        public List<Equipamento> equipList = new List<Equipamento>();
        public List<Disjuntor> linksList = new List<Disjuntor>();
        public List<PortaLogica> portasList = new List<PortaLogica>();
        public List<PontoVazado> pvazadoList = new List<PontoVazado>();
        public List<LED> LedList = new List<LED>();
        //public List<Mostrador> mostradorList = new List<Mostrador>();
        public Dictionary<String, int> equipDict = new Dictionary<String, int>();
        //public Dictionary<String, double> vars = new Dictionary<string, double>();
        public static String DisjuntorClicado = "null";

        // Forms
        //=================================================================================================================
        public FormUGs FormUGs;
        public Form_Vao_03 Form_Vao_03;
        public FormPopUp_UG4 FormPopUp_UG4;
        public FormLogs FormLogs;
        public Form_Partida_04 Form_Partida_04;
        public Form_Parada_04 Form_Parada_04;
        public String[] PopUpClicado = new String[Const.nUGs + 1];

        // Variáveis do sistema
        //=================================================================================================================
        public bool run = true;
        public int TempoSleep = 50;
        int ciclo1 = 0;
        int ciclo2 = 0;
        int ciclo3 = 0;
        int ciclo4 = 0;
        int ciclo5 = 0;
        int ciclo6 = 0;
        private System.Windows.Forms.Timer timer4;

        public Form1()
        {
            InitializeComponent();

            FormUGs = new FormUGs(this);
            FormUGs.Show();

            Form_Vao_03 = new Form_Vao_03(this);
            Form_Vao_03.Hide();

            FormPopUp_UG4 = new FormPopUp_UG4(this);
            FormPopUp_UG4.Hide();

            Form_Partida_04 = new Form_Partida_04(this);
            Form_Partida_04.Show();
            //Form_Partida_04.Hide();

            Form_Parada_04 = new Form_Parada_04(this);
            Form_Parada_04.Hide();

            FormLogs = new FormLogs();
            FormLogs.Show();

            //Unifilar do fluxo lógico
            foreach (TabPage tab in tabControl1.TabPages)
            {
                foreach (Control equip in tab.Controls)
                {
                    if (equip is Equipamento)
                    {
                        equipList.Add((Equipamento)equip);
                        equipDict.Add(equip.Name, equipList.Count - 1);
                    }

                    if (equip is PontoVazado)
                        pvazadoList.Add((PontoVazado)equip);

                    if (equip is LED)
                        LedList.Add((LED)equip);

                    if (equip is PortaLogica)
                    {
                        portasList.Add((PortaLogica)equip);
                    }

                    if (equip is Disjuntor)
                        if (((Disjuntor)equip).Link != "null")
                            linksList.Add((Disjuntor)equip);
                }
            }

            // Adiciona adjascentes aos equipamentos
            bool vaza = false;
            foreach (Equipamento equip1 in equipList)
            {
                equip1.adjascentes = new List<Equipamento>();

                foreach (Equipamento equip2 in equipList)
                {
                    if (equip1 is Barra && equip1.Name == equip2.Link)
                    {
                        equip1.adjascentes.Add(equip2);
                        continue;
                    }

                    vaza = false;
                    foreach (PontoVazado pvazado in pvazadoList)
                    {
                        if (Fluxo.EstaoSobrepostos(equip1, pvazado) && Fluxo.EstaoSobrepostos(equip2, pvazado))
                        {
                            vaza = true;
                            continue;
                        }
                    }
                    if (vaza) continue;

                    if (equip1 != equip2 && equip1 != null && equip2 != null)
                        if (Fluxo.EstaoSobrepostos(equip1, equip2))
                            equip1.adjascentes.Add(equip2);
                }
            }

            Fluxo = new Fluxo(equipList, equipDict, pvazadoList);
            FluxoLogico = new FluxoLogico(equipList, portasList, pvazadoList);

            x[1] = new Vars();
            x[2] = new Vars();
            x[3] = new Vars();
            x[4] = new Vars();
            x[5] = new Vars();
            x[6] = new Vars();

            for (int i = 0; i <= Const.nUGs; i++)
            {
                PassoAtual[i] = Const.PASSO_NULO;
                EstadoAlvo[i] = Const.MAQUINA_PARADA;
                EstadoAtual[i] = Const.MAQUINA_PARADA;
            }

            //GPM1 = new GPM(this, 1);
            //GPM2 = new GPM(this, 2);
            //GPM3 = new GPM(this, 3);
            GPM4 = new GPM(this, 4);
            //GPM5 = new GPM(this, 5);
            //GPM6 = new GPM(this, 6);

            //thread_GPM1 = new Thread(loopGPM1);
            //thread_GPM1.Start();
            //thread_GPM2 = new Thread(loopGPM2);
            //thread_GPM2.Start();
            //thread_GPM3 = new Thread(loopGPM3);
            //thread_GPM3.Start();
            thread_GPM4 = new Thread(loopGPM4);
            thread_GPM4.Start();
            //thread_GPM5 = new Thread(loopGPM5);
            //thread_GPM5.Start();
            //thread_GPM6 = new Thread(loopGPM6);
            //thread_GPM6.Start();

            ev_GPM.Add(ev_dummy);
            ev_GPM.Add(ev_GPM1);
            ev_GPM.Add(ev_GPM2);
            ev_GPM.Add(ev_GPM3);
            ev_GPM.Add(ev_GPM4);
            ev_GPM.Add(ev_GPM5);
            ev_GPM.Add(ev_GPM6);

            thread_loopFisico4 = new Thread(loopFisico4);
            thread_loopFisico4.Start();

            thread_Fluxo = new Thread(AgenteFluxo);
            thread_Fluxo.Start();

            timer4 = new System.Windows.Forms.Timer();
            timer4.Enabled = true;
            timer4.Interval = 200;
            timer4.Tick += new System.EventHandler(this.timer4_Tick);
        }

        void timer4_Tick(object sender, EventArgs e)
        {
            Form1_labelEstadoAlvoUG4.Text  = EstadoAlvo[4].ToString();
            Form1_labelRpmUG4.Text         = (x[4].Omega * Const.RadPerSecToRpm).ToString("#0.00") + " rpm";
            Form1_labelVazaoUG4.Text       = (x[4].Z / Const.rhoAgua).ToString("#0.00") + " m3/s";
            Form1_labelAreaUG4.Text        = (x[4].A).ToString("#0.00") + " m2";
            Form1_labelAreaNominalUG4.Text = (x[4].ANominal).ToString("#0.00") + " m2";
            Form1_labelTorqueUG4.Text      = (x[4].TorqueA).ToString("#0.00") + " kg m2/s2";
            Form1_labelAtritoUG4.Text      = (x[4].beta * x[1].Omega).ToString("#0.00") + " kg m2/s2";
            Form1_labelEUG4.Text           = (x[4].E.Magnitude).ToString("#0.00") + " V";
            Form1_labelVUG4.Text           = (x[4].V.Magnitude).ToString("#0.00") + " V";
            Form1_labelIUG4.Text           = (x[4].I.Magnitude).ToString("#0.00") + " A";
            Form1_labelCosPhiUG4.Text      = (Math.Cos(x[4].phi)).ToString("#0.00") + " ";
            Form1_labelPUG4.Text           = (x[4].P/1E6).ToString("#0.00") + " MW";
            Form1_labelQUG4.Text           = (x[4].Q/1E6).ToString("#0.00") + " MW";
            Form1_labelFreqUG4.Text        = (x[4].f).ToString("#0.00") + " Hz";
            Form1_labelDeltaUG4.Text       = (x[4].delta).ToString("#0.00") + " rad";
        }

        void IluminaLEDs()
        {
            foreach (LED led in LedList)
            {
                if (led.Link == "null") continue;

                led.Estado = Fluxo.GetEquip(led.Link).V > 0 ? Const.LedON : Const.LedOFF;
            }
        }

        private void AgenteFluxo()
        {
            while (true)
            {
                if (DisjuntorClicado != "null")
                {
                    Disjuntor clicado = (Disjuntor)Fluxo.GetEquip(DisjuntorClicado);
                    if (clicado.Link != "null")//É filha
                    {
                        //Atualiza mãe
                        ((Disjuntor)Fluxo.GetEquip(clicado.Link)).e = clicado.e;
                        //Atualiza irmãos
                        AtualizaDisjuntoresLinkados(clicado.Link);
                    }
                    else//É mãe
                    {
                        //Atualiza filhas
                        AtualizaDisjuntoresLinkados(DisjuntorClicado);
                    }
                }

                Fluxo.AtualizaUnifilar();
                FluxoLogico.AtualizaUnifilar();
                IluminaLEDs();
                VerificaSincronismo();

                ev_Fluxo.WaitOne();
            }
        }

        void VerificaSincronismo()
        {
            bool UG4_SyncAA = false;
            bool UG4_SyncBB = false;

            //=================================================================================================================
            // UG-4
            //=================================================================================================================
            Fluxo.equipsCurto.Clear(); // O caráter recursivo da busca EstaoEmCurto() requer que a lista seja resertada aqui...
            UG4_SyncAA = (Fluxo.EstaoEmCurto(Fluxo.GetEquip("UG_04"), Fluxo.GetEquip("barraA"))) ? true : false;

            Fluxo.equipsCurto.Clear(); // O caráter recursivo da busca EstaoEmCurto() requer que a lista seja resertada aqui...
            UG4_SyncBB = (Fluxo.EstaoEmCurto(Fluxo.GetEquip("UG_04"), Fluxo.GetEquip("barraB"))) ? true : false;

            x[4].Sincronizado = UG4_SyncAA | UG4_SyncBB;
        }

        public void AtualizaDisjuntoresLinkados(String linkName)
        {
            Disjuntor link = (Disjuntor)Fluxo.GetEquip(linkName);

            foreach (Disjuntor linked in linksList)
            {
                if (linked.Link == link.Name)
                {
                    linked.e = link.e;
                    linked.V = link.V;
                }
            }
        }

        public void Fonte(int ug)
        {
            x[ug].v = Math.Sqrt(2 * Const.g * h);
            x[ug].Z = Const.rhoAgua * x[ug].v * x[ug].A;
        }

        public void Turbina(int ug)
        {
            // Atribui valor do atrito de rotação: com ou sem freio
            //=================================================================================================================
            x[ug].beta = Const.betaFreio;
            if (Fluxo != null)
                if (Fluxo.GetEquip("barra_Freio_UG" + ug.ToString()).V == 0)
                    x[ug].beta = Const.betaLivre;

            // Calcula torque exercido sobre a turbina pela fonte de energia
            //=================================================================================================================
            x[ug].TorqueA = Const.K * eff(h) * x[ug].v * x[ug].Z;
            x[ug].TorqueP = (x[ug].Omega == 0 ? 0 : (x[ug].P + x[ug].Q) / x[ug].Omega);
            x[ug].dOmegadt = (x[ug].TorqueA - x[ug].beta * x[ug].Omega - x[ug].TorqueP) / Const.J;
            x[ug].OmegaAux = x[ug].Omega;
            x[ug].Omega += x[ug].dOmegadt * Const.dt;

            // Trunca velocidade se Rpm < 1 e o freio estiver aplicado
            //=================================================================================================================
            if (x[ug].Omega * Const.RadPerSecToRpm < 1 && x[ug].beta == Const.betaFreio) x[ug].Omega = 0;

            // Calcula o valor da abertura das palhetas
            //=================================================================================================================
            RV(ug);

            if (x[ug].OmegaAux.ToString("0.000") != x[ug].Omega.ToString("0.000"))
            {
                if (x[ug].Omega * Const.RadPerSecToRpm >= 0.5 * Const.RpmNominal && x[ug].OmegaAux * Const.RadPerSecToRpm < 0.5 * Const.RpmNominal)
                {
                    ((Disjuntor)Fluxo.GetEquip("disjuntor_Velocidade50_UG" + ug.ToString())).e = Const.F;
                    ev_Fluxo.Set();
                }

                if (x[ug].Omega * Const.RadPerSecToRpm >= 0.9 * Const.RpmNominal && x[ug].OmegaAux * Const.RadPerSecToRpm < 0.9 * Const.RpmNominal)
                {
                    ((Disjuntor)Fluxo.GetEquip("disjuntor_Velocidade90_UG" + ug.ToString())).e = Const.F;
                    ev_Fluxo.Set();
                }
            }
        }

        public void RV(int ug)
        {
            if (((Barra)(Fluxo.GetEquip("barra_BombaRV_UG" + ug.ToString()))).V == 0) return; //Sem pressão, RV não atua
            
            // Se barra_RV_UG > 0, busca RpmNominal; senão, fecha distribuidor
            if (((Barra)Fluxo.GetEquip("barra_RV_UG" + ug.ToString())).V > 0)
                x[ug].ANominal = (Const.RpmNominal * Const.RpmToRadPerSec * Const.betaLivre + x[ug].TorqueP) / (Const.K * eff(h) * Const.rhoAgua * x[ug].v * x[ug].v);
            //x[ug].ANominal = (Const.RpmNominal * Const.RpmToRadPerSec * Const.betaLivre + (x[ug].Pnominal + x[ug].Q) / x[ug].Omega) / (Const.K * eff(x[ug].Z) * Const.rhoAgua * x[ug].v * x[ug].v);
            else
                x[ug].ANominal = 0;

            //if (x[ug].Omega < 0.95 * Const.RpmNominal * Const.RpmToRadPerSec) x[ug].ANominal *= 3;

            if (x[ug].ANominal > 0)
            {
                //x[ug].A = x[ug].ANominal;
                //x[ug].A += degrau_suave(x[ug].A - x[ug].ANominal, 0.1, 0.5);
                x[ug].A = atrator((Const.RpmNominal - x[ug].Omega * Const.RadPerSecToRpm) / Const.RpmNominal, x[ug].ANominal, 3 * (1 + degrau_suave((x[ug].Omega * Const.RadPerSecToRpm - Const.RpmNominal) / Const.RpmNominal, 2, 0.1)));
                //x[ug].A = atrator((Const.RpmNominal - x[ug].Omega * Const.RadPerSecToRpm) / Const.RpmNominal, x[ug].ANominal, 3);//OK!!!
                //x[ug].A = atrator((Const.RpmNominal - x[ug].Omega * Const.RadPerSecToRpm) / Const.RpmNominal, x[ug].ANominal, 6);
                //x[ug].A = atrator((Const.RpmNominal - x[ug].Omega * Const.RadPerSecToRpm) / Const.RpmNominal, x[ug].ANominal, 1);
                //x[ug].A = degrau_suave((x[ug].Omega * Const.RadPerSecToRpm - Const.RpmNominal) / Const.RpmNominal, 1, 0.5 * degrau_suave(x[ug].Pnominal != 0 ? Math.Abs(x[ug].P - x[ug].Pnominal) / x[ug].Pnominal : x[ug].P, 1, 1), 25) * x[ug].ANominal;

                if (x[ug].Sincronizado)
                    x[ug].A += degrau_suave((x[ug].P - x[ug].Pnominal) / 1E6, 0.01, 10);
                  //x[ug].A += degrau_suave((x[ug].P - x[ug].Pnominal) / 1E6, 0.01, 5);
                  //x[ug].A += degrau_suave((x[ug].P - x[ug].Pnominal) / 1E6, 0.01, 20);
                //if (x[ug].Sincronizado)
                //    x[ug].A += degrau_suave(x[ug].Pnominal != 0 ? (x[ug].P - x[ug].Pnominal) / x[ug].Pnominal : x[ug].P, 0, 0.025, 100);
            }
            else if (x[ug].ANominal == 0)
                x[ug].A = 0;

            if (x[ug].A < 0) x[ug].A = 0;

            //works good! --old...
            //x[ug].AnguloPalheta = degrau_suave((x[ug].Omega * Const.RadPerSecToRpm - Const.RpmNominal) / Const.RpmNominal, 1, 0.5 * degrau_suave(x[ug].Pnominal != 0 ? Math.Abs(x[ug].P - x[ug].Pnominal) / x[ug].Pnominal : x[ug].P, 1, 1), 25) * x[ug].AnguloPalhetaNominal;
            //if (x[ug].Sincronizado) x[ug].AnguloPalheta += degrau_suave(x[ug].Pnominal != 0 ? (x[ug].P - x[ug].Pnominal) / x[ug].Pnominal : x[ug].P, 0, 0.025, 100);
        }

        public void Gerador(int ug)
        {
            Excitacao(ug);

            // Calcula diagrama fasorial do gerador
            //=================================================================================================================
            x[ug].f = (x[ug].E.Magnitude > 0 ? x[ug].Omega * Const.RadPerSecToRpm * Const.MechanicalTurnToChargeTurn : 0);
            x[ug].E = Complex.FromPolarCoordinates(x[ug].Omega * x[ug].TensaoExcitacao * Const.FatorEspira, 0);

            // V = Tensao no estator (devido a linha externa se estiver sincronizado, igual a E se estiver girando em vazio)
            // E = Tensao induzida no estator
            // TensaoExcitacao = Tensao no rotor

            if (x[ug].Sincronizado)
            {
                // Máquina ligada a barramento infinito
                x[ug].delta += (x[ug].f > 0 ? (Const.FrequenciaBarra - x[ug].f) * Const.HzToRadPerSec * Const.dt : 0);
                x[ug].V = Complex.FromPolarCoordinates(Const.TensaoBarra * Const.Transf500To165, x[ug].E.Phase + x[ug].delta);
                x[ug].I = (x[ug].Omega > 0 ? Complex.ImaginaryOne * (x[ug].V - x[ug].E) / Const.Xs : 0);
            }
            else
            {
                // Máquina operando em vazio
                x[ug].V = x[ug].E;
                x[ug].I = Complex.Zero;
                x[ug].delta = 0;
                //x[ug].TensaoExcitacaoPrescrita = Const.TensaoExcitacaoNominal;
                //excitação nominal prescrita via IHM
            }

            x[ug].phi = (x[ug].I.Magnitude == 0 ? 0 : x[ug].I.Phase - x[ug].V.Phase);
            x[ug].P =  3 * x[ug].V.Magnitude * x[ug].I.Magnitude * Math.Cos(x[ug].phi);
            x[ug].Q = -3 * x[ug].V.Magnitude * x[ug].I.Magnitude * Math.Sin(x[ug].phi);
        }

        void Excitacao(int ug)
        {
            bool SistemaExcitacaoLigado = ((Barra)Fluxo.GetEquip("barra_SistemaExcitacao_UG" + ug.ToString())).V > 0 ? true : false;

            if (SistemaExcitacaoLigado)
            {
                x[ug].TensaoExcitacao += degrau_suave(x[ug].TensaoExcitacao - x[ug].TensaoExcitacaoPrescrita, 1, 1);
                /*
                if (x[ug].flag_RegulaQ)
                {
                    x[ug].TensaoExcitacao += degrau_suave((x[ug].E.Magnitude - Const.TensaoBarra * Const.Transf500To165) / 1000, 0, 5, 1);
                }
                else
                {
                    x[ug].TensaoExcitacao += degrau_suave(x[ug].TensaoExcitacao - x[ug].TensaoExcitacaoPrescrita, 0, 5, 5);
                }
                */
            }
            else
            {
                x[ug].TensaoExcitacao += degrau_suave(x[ug].TensaoExcitacao - 0, 1, 1);
            }

            if (x[ug].TensaoExcitacao < 0) x[ug].TensaoExcitacao = 0;

            //if (x[ug].TensaoExcitacao == 0 && x[ug].TensaoExcitacaoAux > 0) Form1.ev_Fluxo.Set(); // !!!! nao atualiza direito Atualiza estado maquina: Excitada |--->> Giro Mec
            //if (x[ug].TensaoExcitacao > 0 && x[ug].TensaoExcitacaoAux == 0) Form1.ev_Fluxo.Set(); // !!!! nao atualiza direito Atualiza estado maquina: Giro Mec |--->> Excitada
            //x[ug].TensaoExcitacaoAux = x[ug].TensaoExcitacao;
        }

        bool RegulaQ(int ug)
        {
            bool z = false;

            if (Math.Abs(x[ug].Q) > 500E3 && x[ug].flag_RegulaQ)
            {
                z = true;
                x[ug].TensaoExcitacaoPrescrita += 0.01 * Math.Sign(-x[ug].Q);
            }

            return z;
        }

        double degrau_suave(double x, double C, double l = 1)
        {
            // Função degrau suave
            // f(0) = 0
            // f(-Infty) = + C
            // f(+Infty) = - C
            // largura do degrau = 1/l
            return (2.0 * C / (1.0 + Math.Exp(x / l)) - C);
        }

        double atrator(double x, double A, double k = 1)
        {
            // f(0) = A
            // f(-Infty) = 0
            // f(+Infty) = +Infty
            return (A * Math.Exp(k * x));
        }

        double eff(double h)
        {
            return (0.6 * (1.0 + 0.05 * (h - 71.0) / (78.0 - 71.0)));
        }

        public void loopFisico4()
        {
            while (true)
            {
                if (Fluxo == null) continue;

                if (run)
                {
                    ciclo4++;

                    Fonte(4);
                    do
                    {
                        Turbina(4);
                        Gerador(4);
                    }
                    while (RegulaQ(4));
                    //Temperatura(4);

                    Thread.Sleep(TempoSleep);
                }
            }
        }

        public void loopGPM1()
        {
            while (true)
            {
                if (run)
                {
                    GPM1.Set();
                }

                ev_GPM.ElementAt(1).WaitOne();
            }
        }

        public void loopGPM2()
        {
            while (true)
            {
                if (run)
                {
                    GPM2.Set();
                }

                ev_GPM.ElementAt(2).WaitOne();
            }
        }

        public void loopGPM3()
        {
            while (true)
            {
                if (run)
                {
                    GPM3.Set();
                }

                ev_GPM.ElementAt(3).WaitOne();
            }
        }

        public void loopGPM4()
        {
            while (true)
            {
                if (run)
                {
                    GPM4.Set();
                }

                ev_GPM.ElementAt(4).WaitOne();
            }
        }

        public void loopGPM5()
        {
            while (true)
            {
                if (run)
                {
                    GPM5.Set();
                }

                ev_GPM.ElementAt(5).WaitOne();
            }
        }

        public void loopGPM6()
        {
            while (true)
            {
                if (run)
                {
                    GPM6.Set();
                }

                ev_GPM.ElementAt(6).WaitOne();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dig = new DialogResult();
            dig = MessageBox.Show("Tem certezar que deseja encerrar o Simulador?", "Alerta!", MessageBoxButtons.YesNo);

            if (dig == DialogResult.Yes)
            {
                System.Environment.Exit(1);
                Application.Exit();
            }
            e.Cancel = (dig == DialogResult.No);
        }

        private void button_h_Click(object sender, EventArgs e)
        {
            h = Double.Parse(textBox_h.Text);
        }
    }
}