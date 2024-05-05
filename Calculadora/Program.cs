using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Operacoes> filaOperacoes = new Queue<Operacoes>();
            filaOperacoes.Enqueue(new Operacoes { valorA = 2, valorB = 3, operador = '+' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 14, valorB = 8, operador = '-' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 5, valorB = 6, operador = '*' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 2147483647, valorB = 2, operador = '+' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 18, valorB = 3, operador = '/' });

            Calculadora calculadora = new Calculadora();

            Stack resultados = new Stack();

            while (filaOperacoes.Count > 0)
            {
                Operacoes operacao = filaOperacoes.Dequeue();
                calculadora.calcular(operacao);
                resultados.Push(operacao.resultado);
                Console.WriteLine("{0} {1} {2} = {3}", operacao.valorA,operacao.operador,operacao.valorB, operacao.resultado);

                if (filaOperacoes.Count > 0)
                {

                    foreach (Operacoes op in filaOperacoes)
                    {
                        Console.WriteLine("Próxima operação: {0} {1} {2}", op.valorA, op.operador, op.valorB);
                    }

                    Console.WriteLine("\n");

                } else
                {
                    Console.WriteLine("Não restam mais operações \n");
                }

            }

            Console.WriteLine("Imprimindo resultados das operações...");

            foreach (Object res in resultados)
            {
                Console.WriteLine(res);
            }

        }
    }
}
