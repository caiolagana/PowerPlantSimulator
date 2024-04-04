using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UHESSimao
{
    public class Fluxo
    {
        List<Equipamento> equipList = new List<Equipamento>();
        Dictionary<String, int> equipDict = new Dictionary<String, int>();
        static List<PontoVazado> pvazadoList = new List<PontoVazado>();
        List<Equipamento> equipVisitados = new List<Equipamento>();
        public List<Equipamento> equipsCurto = new List<Equipamento>();

        public Fluxo(List<Equipamento> _equipList, Dictionary<String, int> _equipDict, List<PontoVazado> _pvazadoList)
        {
            equipList = _equipList;
            equipDict = _equipDict;
            pvazadoList = _pvazadoList;
        }

        public void EnergizaAdjacentes(Equipamento equip)
        {
            equipVisitados.Add(equip);

            foreach (Equipamento adj in equip.adjascentes)
            {
                if (!equipVisitados.Contains(adj))
                {
                    if (adj is Disjuntor)
                    {
                        if (((Disjuntor)adj).estado == Const.F)
                        {
                            adj.V = equip.V;
                            EnergizaAdjacentes(adj);
                        }
                        else
                            adj.V = 0;
                    }
                    else
                    {
                        if (adj is Barra)
                        {
                            adj.V = equip.V * equip.Transforma;
                            adj.BackColor = (equip.V > 0 ? Const.ColorBarraOn : Const.ColorBarraOff);
                        }
                        EnergizaAdjacentes(adj);
                    }
                }
            }
        }

        public void AtualizaUnifilar()
        {
            // Reseta Ambiente
            equipVisitados.Clear();
            foreach (Equipamento equip in equipList)
            {
                if (!(equip is FonteDeTensao)) equip.V = 0;
                if (equip is Barra) equip.BackColor = Const.ColorBarraOff;
            }

            // Busca recursiva partindo das fontes
            foreach (Equipamento fonte in equipList)
            {
                if (fonte is FonteDeTensao)
                {
                    if (fonte.V > 0 && ((FonteDeTensao)fonte).Especie != "UG_parada" && ((FonteDeTensao)fonte).Especie != "UG_pronta" && ((FonteDeTensao)fonte).Especie != "UG_giro")
                    {
                        EnergizaAdjacentes(fonte);
                    }
                }
            }
        }

        public bool EstaoEmCurto(Equipamento fonte, Equipamento alvo)
        {
            bool z = false;
            bool vaza = false;

            if (EstaoSobrepostos(fonte, alvo)) return true;

            equipsCurto.Add(fonte);

            //foreach (Equipamento adj in equipList)
            foreach (Equipamento adj in fonte.adjascentes)
            {
                if (!(adj is Barra || adj is Disjuntor || adj is FonteDeTensao)) continue;

                vaza = false;
                foreach (PontoVazado pvazado in pvazadoList)
                {
                    if (EstaoSobrepostos(alvo, pvazado) && EstaoSobrepostos(adj, pvazado)) vaza = true;
                }
                if (vaza) continue;

                if (EstaoSobrepostos(fonte, adj) && !equipsCurto.Contains(adj) && adj.V > 0)
                {
                    z = !z ? EstaoEmCurto(adj, alvo) : true;
                }
            }

            return z;
        }

        public Equipamento GetEquip(String nome)
        {
            Equipamento equip = null;

            if (equipList.Contains(equipList[equipDict[nome]]))
                equip = equipList[equipDict[nome]];

            return equip;
        }

        public static bool VerificaSobreposicao(int value, int min, int max)
        {
            return (value >= min) && (value <= max);
        }

        public static bool EstaoSobrepostos(Control A, Control B)
        {
            if (A == null || B == null) return false;
            if (A.Parent != B.Parent) return false;

            bool xSobreposto = VerificaSobreposicao(A.Location.X, B.Location.X, B.Location.X + B.Size.Width) ||
                   VerificaSobreposicao(B.Location.X, A.Location.X, A.Location.X + A.Size.Width);

            bool ySobreposto = VerificaSobreposicao(A.Location.Y, B.Location.Y, B.Location.Y + B.Size.Height) ||
                               VerificaSobreposicao(B.Location.Y, A.Location.Y, A.Location.Y + A.Size.Height);

            return (xSobreposto && ySobreposto);
        }
    }
}
