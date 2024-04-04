using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UHESSimao
{
    class FluxoLogico
    {
        List<PortaLogica> portasList = new List<PortaLogica>();
        List<Equipamento> equipList = new List<Equipamento>();
        List<PontoVazado> pvazadoList = new List<PontoVazado>();
        List<Equipamento> equipVisitados = new List<Equipamento>();



        public FluxoLogico(List<Equipamento> _equipList, List<PortaLogica> _portasList, List<PontoVazado> _pvazadoList)
        {
            equipList = _equipList;
            portasList = _portasList;
            pvazadoList = _pvazadoList;
        }

        private static bool VerificaSobreposicao(int value, int min, int max)
        {
            return (value >= min) && (value <= max);
        }

        private static bool EhEntrada(Control A, Control B)
        {
            bool mesmoForm = (A.Parent == B.Parent ? true : false);

            bool xSobreposto = VerificaSobreposicao(A.Location.X + A.Size.Width, B.Location.X, B.Location.X + B.Size.Width / 2);

            bool ySobreposto = VerificaSobreposicao(A.Location.Y, B.Location.Y, B.Location.Y + B.Size.Height) ||
                               VerificaSobreposicao(B.Location.Y, A.Location.Y, A.Location.Y + A.Size.Height);

            return (xSobreposto && ySobreposto && mesmoForm);
        }

        private static bool EhSaida(Control A, Control B)
        {
            bool mesmoForm = (A.Parent == B.Parent ? true : false);

            bool xSobreposto = VerificaSobreposicao(A.Location.X, B.Location.X + B.Size.Width / 2, B.Location.X + B.Size.Width);

            bool ySobreposto = VerificaSobreposicao(A.Location.Y, B.Location.Y, B.Location.Y + B.Size.Height) ||
                               VerificaSobreposicao(B.Location.Y, A.Location.Y, A.Location.Y + A.Size.Height);

            return (xSobreposto && ySobreposto && mesmoForm);
        }

        public bool EnergizaSaida(PortaLogica A, double x)
        {
            bool HouveMudancaDeEstado = false;

            foreach (Equipamento barraOut in equipList)
            {
                if (barraOut is Barra)
                {
                    if (EhSaida((Barra)barraOut, A))
                    {
                        HouveMudancaDeEstado = (barraOut.V != x ? true : false);
                        barraOut.V = x;
                        barraOut.BackColor = (x == 0 ? Const.ColorBarraOff : Const.ColorBarraOn);
                        HouveMudancaDeEstado = HouveMudancaDeEstado | EnergizaAdjacentes((Barra)barraOut);
                    }
                }
            }

            return HouveMudancaDeEstado;
        }

        public bool EnergizaAdjacentes(Barra fonte)
        {
            bool HouveMudancaDeEstado = false;
            bool vaza = false;
            equipVisitados.Add(fonte);

            foreach (Equipamento barra in equipList)
            {
                if (barra is Barra)
                {
                    if (EstaoConectados(fonte, barra) && !equipVisitados.Contains(barra) && barra != fonte)
                    {
                        vaza = false;
                        foreach (PontoVazado pvazado in pvazadoList)
                        {
                            if (EstaoConectados(fonte, pvazado) && EstaoConectados(barra, pvazado)) vaza = true;
                        }
                        if (vaza) continue;

                        HouveMudancaDeEstado = (barra.V != fonte.V ? true : false);
                        barra.V = fonte.V;
                        barra.BackColor = (barra.V > 0 ? Const.ColorBarraOn : Const.ColorBarraOff);
                        HouveMudancaDeEstado = HouveMudancaDeEstado | EnergizaAdjacentes((Barra)barra);
                    }
                }
            }

            return HouveMudancaDeEstado;
        }

        private static bool EstaoConectados(Control A, Control B)
        {
            bool mesmoForm = (A.Parent == B.Parent ? true : false);

            bool xSobreposto = VerificaSobreposicao(A.Location.X, B.Location.X, B.Location.X + B.Size.Width) ||
                   VerificaSobreposicao(B.Location.X, A.Location.X, A.Location.X + A.Size.Width);

            bool ySobreposto = VerificaSobreposicao(A.Location.Y, B.Location.Y, B.Location.Y + B.Size.Height) ||
                               VerificaSobreposicao(B.Location.Y, A.Location.Y, A.Location.Y + A.Size.Height);

            return (xSobreposto && ySobreposto && mesmoForm);
        }

        public void AtualizaUnifilar()
        {
            bool and = true;
            bool or = false;
            bool HouveMudancaDeEstado = false;//Isso dá conta das malhas em que houver retroalimentação entre as portas

            do
            {
                equipVisitados.Clear();
                HouveMudancaDeEstado = false;

                foreach (PortaLogica porta in portasList)
                {
                    if (porta is PortaAND)
                    {
                        and = true;

                        foreach (Equipamento barraIn in equipList)
                        {
                            if (barraIn is Barra)
                            {
                                if (EhEntrada((Barra)barraIn, porta) && barraIn.V == 0)
                                {
                                    and = false;
                                    HouveMudancaDeEstado = EnergizaSaida(porta, 0);
                                    continue;
                                }
                            }
                        }

                        if (and) HouveMudancaDeEstado = EnergizaSaida(porta, 1);
                    }
                    else if (porta is PortaOR)
                    {
                        or = false;

                        foreach (Equipamento barraIn in equipList)
                        {
                            if (barraIn is Barra)
                            {
                                if (EhEntrada((Barra)barraIn, porta) && barraIn.V > 0)
                                {
                                    or = true;
                                    HouveMudancaDeEstado = EnergizaSaida(porta, 1);
                                    continue;
                                }
                            }
                        }

                        if (!or) HouveMudancaDeEstado = EnergizaSaida(porta, 0);
                    }
                    else if (porta is PortaNOT)
                    {
                        foreach (Equipamento barraIn in equipList)
                        {
                            if (barraIn is Barra)
                            {
                                if (EhEntrada((Barra)barraIn, porta))
                                {
                                    HouveMudancaDeEstado = EnergizaSaida(porta, barraIn.V > 0 ? 0 : 10);
                                }
                            }
                        }
                    }
                }
            }
            while (HouveMudancaDeEstado);
        }
    }
}
