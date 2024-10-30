using Banco;

namespace BancoTestes
{
    [TestClass]
    public class ContaBancaria_Teste
    {
        [TestMethod]
        public void Debito_ComMontanteValido_AtualizandoSaldo()//testando o método de debitar o saldo da conta; void = não retorna valor;
        {
            double saldoInicial = 11.99;
            double montanteDebitado = 4.55;
            double esperado = 7.44;

            ContaBancaria conta = new("Mis Cristina",saldoInicial);

            //ação que vai disparar o teste
            conta.Debitar(montanteDebitado);

            double atual = conta.Saldo;
            Assert.AreEqual(esperado, atual,0.001, "O Debito Não ocorreu corretamente");
        }

        [TestMethod]
        public void Debito_QuandoMontantemenorQueZero_InterceptadoPorExcecao()
        {
            double saldoInicial = 11.99;
            double montanteDebitado = -100.00;

            ContaBancaria conta = new("MS Cristina",saldoInicial);

            //ação e assert(comparação)
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>conta.Debitar(montanteDebitado));
        }

        [TestMethod]
        public void Creditar_ComMontante_AtualizandoSaldo()
        {
            double saldoInicial = 10.00;
            double montanteCreditado = 4.55;
            double esperado = 14.55;

            ContaBancaria conta = new("Mis Cristina", saldoInicial);

            //ação que vai disparar o teste
            conta.Creditar(montanteCreditado);

            double atual = conta.Saldo;
            Assert.AreEqual(esperado, atual, 0.001, "O Credito Não ocorreu corretamente");
        }

        [TestMethod]
        public void Creditar_QuandoMontanteMenorQueZero_InterceptaExcecao()
        {
            double saldoInicial = 11.99;
            double montanteCreditado = -100.00;

            ContaBancaria conta = new("MS Cristina", saldoInicial);

            //ação e assert(comparação)
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => conta.Creditar(montanteCreditado));
        }

        //Método que testa a logica quando o montante maior que o saldo (Debitar)
        [TestMethod]
        public void TestarDebitar_QuandoMontanteMaiorQueSaldo()
        {
            double montante = 100.00;
            double saldoInicial = 10.00;

            ContaBancaria conta = new("Maximo", saldoInicial);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => conta.Debitar(montante));
        }
    }
}