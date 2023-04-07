using System;

class Program {
    static void Main(string[] args) {
        int codigo;
        double nota1, nota2, nota3, media;
        do {
            Console.Write("Digite o código do aluno (0 para sair): ");
            codigo = int.Parse(Console.ReadLine());
            if (codigo != 0) {
                Console.Write("Digite a primeira nota do aluno: ");
                nota1 = double.Parse(Console.ReadLine());
                Console.Write("Digite a segunda nota do aluno: ");
                nota2 = double.Parse(Console.ReadLine());
                Console.Write("Digite a terceira nota do aluno: ");
                nota3 = double.Parse(Console.ReadLine());
                media = (4 * Math.Max(nota1, Math.Max(nota2, nota3)) + 3 * (nota1 + nota2 + nota3 - Math.Max(nota1, Math.Max(nota2, nota3)))) / 9;
                Console.WriteLine($"Aluno {codigo}: notas {nota1}, {nota2}, {nota3} - média {media:F1} - {(media >= 6 ? "APROVADO" : "REPROVADO")}");
            }
        } while (codigo != 0);
    }
}