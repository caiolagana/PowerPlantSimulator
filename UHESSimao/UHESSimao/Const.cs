using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UHESSimao
{
    class Const
    {
        public const int nUGs = 6;

        public const double R = 2.8;//raio efetivo da turbina [m] diametro-rotor=7,2m
        public const double M = 1.947E6;//massa da turbina+gerador [kg] peso-estator: 437 T, peso-rotor: 280 T, peso-turbina: 1165 T, peso-mancal: (27,7  + 11,4 + 27,7) T
        public const double J = M * R * R / 2.0;//momento de inércia total (turbina + gerador), assumindo-a um cilindro homogêneo.
        //public const double eff = 0.8;//eficiência da turbina
        public const double K = R;
        public const double betaLivre = 1E4;
        public const double betaFreio = 1E8;

        public const double g = 9.8;
        public const double rhoAgua = 1.0e3;//densidade da agua [kg/m3]
        public const double rhoOleo = 850.0;//densidade do oleo [kg/m3]
        public const double CpOleo = 1800.0;//calor específico óleo [J/kg ºC]
        public const double CpAgua = 4184.0;//calor específico agua [J/kg ºC]

        public const double DegToRad = Math.PI / 180.0;
        public const double RadToDeg = 180.0 / Math.PI;
        public const double HzToRadPerSec = 2.0 * Math.PI / 360.0;
        public const double RpmToHz = 1.0 / 60.0;
        public const double RadPerSecToRpm = 9.549296596;
        public const double RpmToRadPerSec = 0.104719755;
        public const double LitersPerMinToCubicMetersPerSec = 0.0001 / (6.0);

        public const double TensaoEstatorPrescrita = 16500.0;
        public const double Xs = 0.9;
        public const double FatorEspira = TensaoBarra * Transf500To165 / (RpmNominal * RpmToRadPerSec * TensaoExcitacaoNominal);
        public const double RpmNominal = 94.7;
        public const double MechanicalTurnToChargeTurn = FrequenciaBarra / RpmNominal;//;0.633579725448785;
        public const double TensaoExcitacaoNominal = 110.0;//[Vcc]
        public const double dt = 0.5;//[s]
        public const double FrequenciaBarra = 60.0;//[Hz]
        public const double TensaoBarra = 500E3;//[V]
        public const double Transf165To500 = 500.0 / 16.5;//fator de transformação
        public const double Transf500To165 = 16.5 / 500.0;//fator de transformação
        public const int TempoEtapaMax = 3 * 60000;//3min
        public const int TempoAguardaResposta = 500;
        public const int TempoAtualizaEstadoMaquina = 2500;

        //=============================================================================================================
        //estados de componentes
        //=============================================================================================================
        public static bool A = false;
        public static bool F = true;
        public const double V0 = 0;

        //=============================================================================================================
        //cores default
        //=============================================================================================================
        public static Color ColorBarraOff = Color.Green;
        public static Color ColorBarraOn = Color.Red;
        public static Color ColorLedOn = Color.LightGreen;
        public static Color ColorLedOff = Color.Gray;
        public static Color Blink0 = Color.Gray;
        public static Color Blink1 = Color.Green;
        public static Color Blink2 = Color.Red;
        public const bool LedON = true;
        public const bool LedOFF = false;

        public const int PASSO_PARTIDA_1 = 0;
        public const int PASSO_PARTIDA_2 = 1;
        public const int PASSO_PARTIDA_3 = 2;
        public const int PASSO_PARTIDA_4 = 3;
        public const int PASSO_PARTIDA_5 = 4;
        public const int PASSO_PARTIDA_6 = 5;
        public const int PASSO_PARTIDA_7 = 6;
        public const int PASSO_PARADA_1 = 7;
        public const int PASSO_PARADA_2 = 8;
        public const int PASSO_PARADA_3 = 9;
        public const int PASSO_PARADA_4 = 10;
        public const int PASSO_PARADA_5 = 11;
        public const int PASSO_PARADA_6 = 12;
        public const int PASSO_PARADA_7 = 13;
        public const int PASSO_NULO = -999;
        public const bool OK = true;
        public const bool NOK = false;
        public const int MAQUINA_PARADA = 31;
        public const int PRONTA_GIRO_1 = 32;
        public const int PRONTA_GIRO_2 = 33;
        public const int PRONTA_GIRO_3 = 34;
        public const int GIRO_MECANICO = 35;
        public const int EXCITADA = 36;
        public const int PRE_SINCRONISMO = 37;
        public const int SINCRONIZADA = 38;
        public const int DESCONHECIDO = -39;

        public const int TempoDesenergizacaoReleParada = 5000; //5s
        public const int TempoExcitacaoPosNomSemCarga = 1000; //1s
        public const int TempoDesligResistAquecGerador = 1000; //1s
        public const int TempoFechDisjCampo = 1000; //1s
        public const int TempoLigBomba1ou2MancEscora = 1000;//1s
        public const int TempoLigBomba1ou2MancGuia = 1000;//1s
        public const int TempoAplicFreio = 1000;//1s
        public const int TempoLigBomba1ou2RV = 1000;//1s
        public const int TempoFluxoOleoMancGuiaInf = 1000;//1s
        public const int TempoFluxoPressaoMGMERV = 1000;//1s
        public const int TempoAbrValvulaTanqueRV = 1000;//1s
    }
}
