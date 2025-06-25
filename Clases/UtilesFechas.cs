using System;

namespace Calendario.Clases
{
    public class UtilesFechas
    {

        public static int GetDiaFindeMes(int anno, int mes)
        {
            switch (mes)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    return UtilesFechas.UltimoDiaFebrero(anno);
                default:
                    return 0;
            }

        }
        public static int UltimoDiaFebrero(decimal anno)
        {
            DateTime primerDiaDeMarzo = new DateTime(2025, 3, 1);
            DateTime ultimoDiaDeFebrero = primerDiaDeMarzo.AddDays(-1);
            return ultimoDiaDeFebrero.Day;
        }

        public static int GetDiaSemana(DateTime fecha)
        {
            int diaSemana = (int)fecha.DayOfWeek;
            if (diaSemana == 0)
                return 7;
            else
                return (int)fecha.DayOfWeek;
        }

        public static bool EsFestivo(DateTime fecha)
        {
            // 1 de enero
            if (fecha.Day == 1 && fecha.Month == 1)
                return true;
            // 6 de enero
            if (fecha.Day == 6 && fecha.Month == 1)
                return true;
            // 25 de julio del 2025
            if (fecha.Day == 25 && fecha.Month == 7 && fecha.Year == 2025)
                return true;

            return false;

        }

        public static string GetMesTexto(int mes)
        {
            switch (mes)
            {
                case 1:
                    return "Enero";
                case 2:
                    return "Febrero";
                case 3:
                    return "Marzo";
                case 4:
                    return "Abril";
                case 5:
                    return "Mayo";
                case 6:
                    return "Junio";
                case 7:
                    return "Julio";
                case 8:
                    return "Agosto";
                case 9:
                    return "Septiembre";
                case 10:
                    return "Octubre";
                case 11:
                    return "Noviembre";
                case 12:
                    return "Diciembre";
                default:
                    return "";
            }
        }

    }
}
