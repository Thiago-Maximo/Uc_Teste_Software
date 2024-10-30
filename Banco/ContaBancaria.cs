namespace Banco
{
    public class ContaBancaria
    {
        
        private readonly string m_nomeCliente;
        private double m_saldo;

        public ContaBancaria()
        {

        }

        public ContaBancaria(string m_NomeCliente,double saldo)
        {
            m_nomeCliente = m_NomeCliente;
            m_saldo = saldo;
        }

        public string NomeCliente { get { return m_nomeCliente; } }
        public double Saldo { get { return m_saldo; } }

        public void Debitar(double montante)
        {
            if(montante > m_saldo)
            {
                throw new ArgumentOutOfRangeException("montante");
            }
            if(montante < 0)
            {
                throw new ArgumentOutOfRangeException("montante");
            }
            if(montante > Saldo)
            {
                throw new ArgumentOutOfRangeException("montante");
            }

            m_saldo -= montante; //errado intencionalmente
        }

        public void Creditar(double montante)
        {
            if (montante < 0)
            {
                throw new ArgumentOutOfRangeException("montante");
            }

            m_saldo += montante;
        }

        static void Main(string[] args)
        {
            ContaBancaria conta = new ("James McCgregor",11.99);
            conta.Creditar(5.77);
            conta.Debitar(11.22);
            Console.WriteLine($"O Saldo Atual é R$: {conta.Saldo}");
        }
    }
}
