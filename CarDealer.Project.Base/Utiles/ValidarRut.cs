
using System.Text.RegularExpressions;

namespace N5_API.Project.Base.Utiles
{
    public class ValidarRut
    {
        public static bool IsValid(string Rut)
        {
            if (string.IsNullOrWhiteSpace(Rut))
                return false;

            try
            {
                Rut = Rut.Replace(".", "");
                Rut = FuncionesUtiles.FormatearRutConGuion(Rut);
                
                string sRut = Rut.Substring(0, Rut.LastIndexOf("-"));
                string sDig = Rut.Substring(Rut.LastIndexOf("-") + 1);

                string strDV = ValidaDigitoVerificador(sRut);

                long intRut = long.Parse(sRut);

                if (sDig != strDV) return false;

                Regex re = new Regex("^(\\d{2}\\.\\d{3}\\.\\d{3}-)([a-zA-Z]{1}$|\\d{1}$)");

                Match m = re.Match(Rut);

                if (m.Captures.Count == 0)
                    return true;
                else
                    return false;

            }
            catch
            {
                return false;
            }
        }

        private static string ValidaDigitoVerificador(string rut_input)
        {
            int Digito;
            int Contador;
            int Multiplo;
            int Acumulador;
            String RutDigito;

            Contador = 2;
            Acumulador = 0;

            int rut = Convert.ToInt32(rut_input);

            while (rut != 0)
            {
                Multiplo = (rut % 10) * Contador;
                Acumulador = Acumulador + Multiplo;
                rut = rut / 10;
                Contador = Contador + 1;
                if (Contador == 8)
                {
                    Contador = 2;
                }
            }

            Digito = 11 - (Acumulador % 11);
            RutDigito = Digito.ToString().Trim();
            if (Digito == 10)
            {
                RutDigito = "K";
            }
            if (Digito == 11)
            {
                RutDigito = "0";
            }
            return (RutDigito);
        }
    }
}
