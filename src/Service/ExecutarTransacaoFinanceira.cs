using System;
using System.Collections.Generic;
using TransacaoFinanceira.Models;
namespace TransacaoFinanceira.Service
{
    public class ExecutarTransacaoFinanceira: AcessoDados
       {
           public void Transferir(int correlation_id, long conta_origem, long conta_destino, decimal valor)
        {
            ContasSaldo conta_saldo_origem = getSaldo<ContasSaldo>(conta_origem);
            Console.WriteLine("############################################");
            Console.WriteLine($"O saldo atual da conta {conta_saldo_origem.conta} é de: {conta_saldo_origem.saldo}");
            Console.WriteLine($"O valor a ser transferido é de: {valor}");
            if (conta_saldo_origem.saldo > valor)
            {
                Console.WriteLine($"Transacao numero {correlation_id} foi cancelada por falta de saldo");
                Console.WriteLine("############################################");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadKey();
            };

            ContasSaldo conta_saldo_destino = getSaldo<ContasSaldo>(conta_destino);
            conta_saldo_origem.saldo -= valor;
            conta_saldo_destino.saldo += valor;
            Console.WriteLine($"Transacao numero {correlation_id} foi efetivada com sucesso! ");
            Console.WriteLine($"Novos saldos: Conta Origem-{conta_saldo_origem.conta}: {conta_saldo_origem.saldo} | Conta Destino-{conta_saldo_destino.conta}: {conta_saldo_destino.saldo}");
            Console.WriteLine("############################################");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadKey();

        }
    }

    public class AcessoDados
    {
        private readonly List<ContasSaldo> TABELA_SALDOS;
        public AcessoDados()
        {
            TABELA_SALDOS = new List<ContasSaldo>();
            TABELA_SALDOS.Add(new ContasSaldo(938485762, 180));
            TABELA_SALDOS.Add(new ContasSaldo(347586970, 1200));
            TABELA_SALDOS.Add(new ContasSaldo(2147483649, 0));
            TABELA_SALDOS.Add(new ContasSaldo(675869708, 4900));
            TABELA_SALDOS.Add(new ContasSaldo(238596054, 478));
            TABELA_SALDOS.Add(new ContasSaldo(573659065, 787));
            TABELA_SALDOS.Add(new ContasSaldo(210385733, 10));
            TABELA_SALDOS.Add(new ContasSaldo(674038564, 400));
            TABELA_SALDOS.Add(new ContasSaldo(563856300, 1200));
        }
        public T getSaldo<T>(long id)
        {
            return (T)Convert.ChangeType(TABELA_SALDOS.Find(x => x.conta == id), typeof(T));
        }
        public bool atualizar<T>(T dado)
        {
            try
            {
                ContasSaldo item = (dado as ContasSaldo);
                TABELA_SALDOS.RemoveAll(x => x.conta == item.conta);
                TABELA_SALDOS.Add(dado as ContasSaldo);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

    }
}