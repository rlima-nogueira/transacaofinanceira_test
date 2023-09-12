using System; 
namespace TransacaoFinanceira.Models {
    public class Transacao
    {
        public int correlation_id { get; set; }
        public string? datetime { get; set; }
        public long conta_origem { get; set; }
        public long conta_destino { get; set; }
        public int VALOR { get; set; }
    }

  
}