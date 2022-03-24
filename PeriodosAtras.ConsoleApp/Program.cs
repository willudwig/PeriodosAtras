using System;

namespace PeriodosAtras.ConsoleApp
{
    internal class Program
    {
        static DateTime hoje = DateTime.Today;
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
                    continue;
            }

            Console.ReadKey();
        }

        private static string VerificarIntervaloTempo()
        {
            TimeSpan intervalo = hoje - entrada;

            int anos = Math.Abs(Convert.ToInt32(hoje.Year - entrada.Year));
            int meses = Math.Abs(Convert.ToInt32(hoje.Month - entrada.Month));
            int dias = Math.Abs(Convert.ToInt32(intervalo.TotalDays));
            int horas = Math.Abs(Convert.ToInt32(intervalo.TotalHours));
            int minutos = Math.Abs(Convert.ToInt32(intervalo.TotalMinutes)/60);
            int segundos = Math.Abs(Convert.ToInt32(intervalo.TotalSeconds));

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
