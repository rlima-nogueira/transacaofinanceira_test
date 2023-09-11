using System;
namespace TransacaoFinanceira.Models
{
    public class ContasSaldo
    {
        public ContasSaldo(long conta, decimal valor)
        {
            this.conta = conta;
            this.saldo = valor;
        }
        public long conta { get; set; }
        public decimal saldo { get; set; }
    }
}