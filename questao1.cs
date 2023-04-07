using System;

class MainClass {
  public static void Main (string[] args) {
    char continuar;
    int ano, total_ate_2000 = 0, total_geral = 0;
    double valor, valor_com_desconto;

    do {
      Console.Write("Digite o ano do veículo: ");
      ano = int.Parse(Console.ReadLine());
  
      Console.Write("Digite o valor do veículo: R$");
      valor = double.Parse(Console.ReadLine());
  
      if (ano <= 2000) {
        valor_com_desconto = valor * 0.88;
        total_ate_2000++;
      }
      else {
        valor_com_desconto = valor * 0.93;
      }
  
      Console.WriteLine("Valor do desconto: R$" + (valor - valor_com_desconto));
      Console.WriteLine("Valor a ser pago: R$" + valor_com_desconto);
      total_geral++;
  
      Console.Write("Deseja continuar calculando desconto? (S/N) ");
      continuar = char.Parse(Console.ReadLine());
    } while (continuar == 'S' || continuar == 's');

    Console.WriteLine("Total de carros com ano até 2000: " + total_ate_2000);
    Console.WriteLine("Total geral de carros: " + total_geral);
  }
}