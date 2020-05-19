using System;
using ContaBancaria_TratErro.Exceptions;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria_TratErro
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Conta corrente");

                Console.Write("Número da conta: ");
                int numero = int.Parse(Console.ReadLine());

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Deposito: ");
                double saldo = double.Parse(Console.ReadLine());

                Console.Write("Limite diario para saque: ");
                double limiteDiario = double.Parse(Console.ReadLine());

                Console.Write("Deseja efetuar saque: (s/n): ");
                char efetivarSaque = char.Parse(Console.ReadLine());

                Conta c = new Conta(numero, nome, saldo, limiteDiario);

                if ((efetivarSaque == 's') || (efetivarSaque == 'S'))
                {
                    Console.Write("Informe o valor do saque: ");
                    double saque = double.Parse(Console.ReadLine());

                    c.SaqueDiario(saldo, saque, limiteDiario);

                    Console.WriteLine(c);
                }
                else
                {
                    Console.WriteLine(c);

                }

            }
            catch (FormatException e)
            {
                Console.WriteLine("Erro inesperado formato invalidado: " + e.Message);
            }
            catch (DomainException e)
            {
                Console.WriteLine("Alerta: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro inesperado: " + e.Message);




            }
        }
    }
}
