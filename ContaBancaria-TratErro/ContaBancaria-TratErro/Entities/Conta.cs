using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContaBancaria_TratErro.Exceptions;

namespace ContaBancaria_TratErro
{
    class Conta
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public double Saque { get; set; }
        public double LimiteDiario { get; set; }

        public Conta()
        {

        }

      
        public Conta(int numero, string nome, double saldo, double limiteDiario)
        {

            if (saldo <= 0)
            {
                throw new DomainException("Deposito não permitido, valor deve ser maior que zero");
            }

            Numero = numero;
            Nome = nome;
            Saldo = saldo;
            LimiteDiario = limiteDiario;
            
        }

        public void SaqueDiario(double saldo, double saque, double limiteDiario)
        {
            Saque = saque;

            if (saque > limiteDiario)
            {
                throw new DomainException("Saque não é permitido, valor acima do limite diario");
            }

            if (saque > saldo)
            {
                throw new DomainException("Saque não é permitido, saldo insuficiente");
            }

            Saldo -= Saque;
        }


        public override string ToString(){
            return "Conta: " + Numero
                + " - Correntista: " + Nome
                + " - Saldo: " + Saldo;

            
        }


    }
}
