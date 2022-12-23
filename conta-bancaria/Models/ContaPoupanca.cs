﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models
{
  
   public class ContaPoupanca : Conta
   {
        //Propriedades:
        public double taxaDeSaque = 0.035;
        public double depositoMin { get; set; }


        //Construtor: obrigará o deposito antes da abertura da conta
        public ContaPoupanca(int numeroConta, Cliente cliente) : base(numeroConta, cliente)
        {
            this.depositoMin = depositoInicial();
        }


        // Método do deposito inicial 
        public double depositoInicial()
        {
            bool deposito;
            double depositoMinimo;

            Console.WriteLine("\nPara abertura de CONTA POUPANÇA é necessário um depósito inicial!\n *Valor mínimo de R$100,00*\n");
            //validação do depósito:
            do
            {
                Console.WriteLine("\nDigite o valor a ser depositado: ");
                deposito = double.TryParse(Console.ReadLine(), out depositoMinimo);
            } while (depositoMinimo < 100.00);

            //possuirá a mesma caracteristica do depósito normal (herdado da classe pai)
            base.Depositar(depositoMinimo);
            return Saldo += depositoMinimo;
        }

        // por ser poupança, neste método, apenas caso o cliente seja maior de 18 anos ele irá funcionar
        public override void Sacar(double valor)
        {
            if (Cliente.Idade >= 18)
            {
                base.Sacar(valor);
            }
            else
            {
                Console.WriteLine("Você ainda não tem idade para realizar essa operação");
            }
        }


        // Método especifico de transferência herdará as mesmas características do depósito
        public void TransferirParaPoupanca(double valor)
        {
            base.Depositar(valor);
        }


        //Método da tarifa específica (preciso verificar se o valor da taxa está correto)
        public override double CalcularValorTarifaManutencao()
        {
            double tarifa = this.taxaDeSaque * (Saldo / 100);
            return tarifa;
        }
    }

}