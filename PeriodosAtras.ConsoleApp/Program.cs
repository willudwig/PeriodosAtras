using System;

namespace PeriodosAtras.ConsoleApp
{
    internal class Program
    {
        static DateTime hoje = DateTime.Now;
        static DateTime entrada = new();

        public static void Main()
        {
            while (true)
            {
                Console.Write("Data > ");
                DateTime.TryParse(Console.ReadLine(), out entrada);

                if (ValidarEntradaData() == (Validacao)0)
                {
                    Console.WriteLine(VerificarIntervaloTempo());
                    break;
                }
                else
                {
                    Console.WriteLine("Data inválida");
                    continue;
                }
            }

            Console.ReadKey();
        }

        private static string VerificarIntervaloTempo()
        {
            TimeSpan intervalo = hoje - entrada;

            int anos = Math.Abs(Convert.ToInt32(hoje.Year - entrada.Year));
            int meses = Math.Abs(Convert.ToInt32(hoje.Month - entrada.Month));
            int dias = Math.Abs(Convert.ToInt32(intervalo.Days));
            int horas = Math.Abs(Convert.ToInt32(intervalo.Hours)); 
            int minutos = Math.Abs(Convert.ToInt32(intervalo.Minutes));
            int segundos = Math.Abs(Convert.ToInt32(intervalo.Seconds));

            string resultado = "\n" + anos + " ano(s) " + meses + " mês(es) " + dias + " dia(s) " + horas + " horas " + minutos + " minutos" + " e " + segundos + " segundos";

            return resultado;
        }

        private static Validacao ValidarEntradaData()
        {
            Validacao statusData = Validacao.Válido;

            if (entrada > DateTime.Today)
                statusData = Validacao.Inválido;

            if (string.IsNullOrEmpty(entrada.ToString()))
                statusData = Validacao.Inválido;

            if (entrada.Day < 0)
                statusData = Validacao.Inválido;

            return statusData;
        }

        private enum Validacao { Válido, Inválido}

    }
}
