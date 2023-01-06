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
        public double taxaDeSaque { get; } = 0.35;

        //Construtor: obrigará o deposito antes da abertura da conta
        public ContaPoupanca(Cliente cliente) : base(cliente)
        {
                        
        }

        public void AbrirContaPoupanca()
        {
            Saldo = 0;
            bool deposito;
            double depositoMinimo;

            Console.WriteLine("\nPara abertura de CONTA POUPANÇA é necessário um depósito inicial!\n\n*Valor mínimo de R$100,00*\n");
            //validação do depósito:
            do
            {
                Console.WriteLine("\nDigite o valor a ser depositado: ");
                deposito = double.TryParse(Console.ReadLine(), out depositoMinimo);
            } while (depositoMinimo < 100);

            //possuirá a mesma caracteristica do depósito normal (herdado da classe pai)
            base.Depositar(depositoMinimo);
        }

        // por ser poupança, neste método, apenas caso o cliente seja maior de 18 anos ele irá funcionar
        public override void Sacar(double valor, double taxaDeSaque)
        {
            Console.WriteLine("Para concluir o Saque, digite os 3 primeiros digitos do seu CPF");
            string senhaCPF = Console.ReadLine();
            if (Cliente.Cpf.StartsWith(senhaCPF) && senhaCPF.Length == 3)
            {
                base.Sacar(valor, taxaDeSaque);
            }
            else
            {
                Console.WriteLine("Senha inválida");
            }
        }

        // Método especifico de transferência herdará as mesmas características do depósito
        public void TransferirParaPoupanca(double valor)
        {
            base.Depositar(valor);
        }

          public void OperacoesPoupanca(int inputUsuario)
        {
            switch (inputUsuario)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Digite o valor que deseja transferir para poupança:");
                    double valorTransf = double.Parse(Console.ReadLine());
                    if (valorTransf < 0)
                        valorTransf *= -1;
                    TransferirParaPoupanca(valorTransf);
                    Console.WriteLine("\nPressione ENTER para continuar!");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Digite o valor que deseja sacar: ");
                    double valorSaq = double.Parse(Console.ReadLine());
                    if (valorSaq < 0)
                        valorSaq *= -1;
                    Sacar(valorSaq, taxaDeSaque);
                    Console.WriteLine("\nPressione ENTER para continuar!");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Extrato();
                    Console.WriteLine("\nPressione ENTER para continuar!");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Cliente.VisualizarDados();
                    Console.WriteLine("\nPressione ENTER para continuar!");
                    Console.ReadKey();
                    break;
            }

        }


    }

}
