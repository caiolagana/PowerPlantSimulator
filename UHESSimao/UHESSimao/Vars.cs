using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace UHESSimao
{
    public class Vars
    {
        // Variáveis da fonte
        //=================================================================================================================
        public double v;//velocidade [m/s]
        public double Z;//vazão rho*v*A [kg/s]
        //public double h = 71.3;//coluna d'agua [m]
        public double A = 0;//área da entrada de água [m2]
        public double ANominal = 0;//diametro interno: 9,5m

        // Variáveis da turbina
        //=================================================================================================================
        public double Omega = 0;
        public double OmegaAux = 0;
        public double dOmegadt;//derivada temporal de Omega [rad / s2]
        public double TorqueA;//[kg m2 / s2]
        public double TorqueP;//[kg m2 / s2]
        public double beta = Const.betaLivre;

        // Variáveis do gerador
        //=================================================================================================================
        public double TensaoExcitacao = 0;
        public double TensaoExcitacaoAux = 0;
        public double TensaoExcitacaoPrescrita = Const.TensaoExcitacaoNominal;
        public bool flag_RegulaQ = true;
        public double f = 0;
        public double delta = 0, phi = 0;
        public bool Sincronizado = false;
        public Complex E = new Complex();//força eletromotriz no induzido [V]
        public Complex I = new Complex();//corrente no induzido [A]
        public Complex V = new Complex();//tensão da barra no induzido [V]
        public double P = 0, Q = 0, Pnominal = 5E6;
    }
}
