using System;
using System.Collections.Generic;
using System.Linq;

namespace Teste_C__Gustavo_Anjos
{
    internal class Program
    {
        // Cálculo da eficiência
        static double CalculateAccuracy(List<int> sample)
        {
            double grade = sample.Average();
            int AboveGrade = sample.Count(x => x > grade);
            return (AboveGrade / (double)sample.Count) * 100;
        }

        // Todas as amostras disponíveis
        static List<List<int>> samples = new List<List<int>>()
        {
            new List<int> { 50, 50, 70, 80, 100 },
            new List<int> { 100, 95, 90, 80, 70, 60, 50 },
            new List<int> { 70, 90, 80 },
            new List<int> { 70, 90, 81 },
            new List<int> { 100, 99, 98, 97, 96, 95, 94, 93, 91 }
        };

        // Escolha da amostra
        static void ChooseSample()
        {
            Console.WriteLine("Escolha uma das amostras:");
            for (int i = 0; i < samples.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {string.Join(", ", samples[i])}");
            }

            while (true)
            // Leitura do usuário e retorno do resultado da eficiência
            {
                Console.Write("Digite o número da amostra para ver a eficiência: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int number) && number >= 1 && number <= samples.Count)
                {
                    int index = number - 1;
                    double accuracy = CalculateAccuracy(samples[index]);
                    Console.WriteLine($"A eficiência da amostra escolhida é: {accuracy:F3}%");
                    break;
                }
                else
                {
                    Console.WriteLine("Número inválido. Por favor, digite o número novamente!");
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                ChooseSample();

                // Loop para o usuário quiser fazer o cálculo de outra amostra
                Console.Write("Deseja calcular a eficiência de outra amostra? (s/n): ");
                string response = Console.ReadLine().ToLower();

                if (response != "s")
                {
                    // Encerra o programa
                    Console.WriteLine("Programa encerrado.");
                    break;
                }
            }
        }
    }
}
