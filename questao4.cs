using System;

class Program {
    static void Main(string[] args) {
        DateTime vencimentoOriginal, vencimentoNovo;
        decimal valorBoleto;
        decimal jurosPorDia = 0.03m;
        decimal valorMulta = 2.00m;

        Console.Write("Digite a data de vencimento original (dd/mm/aaaa): ");
        DateTime.TryParse(Console.ReadLine(), out vencimentoOriginal);

        Console.Write("Digite a data de vencimento nova (dd/mm/aaaa): ");
        DateTime.TryParse(Console.ReadLine(), out vencimentoNovo);

        Console.Write("Digite o valor do boleto: ");
        decimal.TryParse(Console.ReadLine(), out valorBoleto);

        int numDias = (int)(vencimentoNovo - vencimentoOriginal).TotalDays;
        decimal valorJuros = 0;

        for (int i = 0; i < numDias; i++) {
            DateTime dataAtual = vencimentoOriginal.AddDays(i);
            bool isFeriado = VerificaFeriado(dataAtual);
            bool isFinalDeSemana = VerificaFinalDeSemana(dataAtual);

            if ((isFinalDeSemana || isFeriado) && !VerificaDiaUtilConsecutivo(dataAtual)) {
                continue;
            }

            if (isFeriado && VerificaDiaUtilConsecutivo(dataAtual)) {
                continue;
            }

            if (isFeriado && VerificaDiaUtilConsecutivo(dataAtual.AddDays(1))) {
                continue;
            }

            if (isFeriado && VerificaDiaUtilConsecutivo(dataAtual.AddDays(2))) {
                valorJuros += (valorBoleto * jurosPorDia);
                continue;
            }

            if (VerificaDiaUtilConsecutivo(dataAtual)) {
                continue;
            }

            if (vencimentoNovo < vencimentoOriginal) {
                break;
            }

            if (VerificaDiaUtilConsecutivo(vencimentoOriginal) && VerificaDiaUtilConsecutivo(vencimentoNovo)) {
                valorJuros += (valorBoleto * jurosPorDia);
                valorJuros += valorMulta;
                break;
            }

            
            valorJuros += (valorBoleto * jurosPorDia);
        }

        decimal valorTotal = valorBoleto + valorJuros + valorMulta;
        Console.WriteLine($"Valor do boleto recalculado: R${valorTotal}");

    }
}