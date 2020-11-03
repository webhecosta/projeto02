public class SaldoConta
{
    public string titular;
    public int agencia;
    public int numero;
    public double saldo = 200;	//SALDO EM CONTA BANCÁRIA
		public double saldoCartao = 1000;	//SALDO CARTÃO DE CRÉDITO


		//FUNÇÃO PARA VERIFICAR SE EXISTE SALDO EM CONTA BANCÁRIA
    public bool Sacar(double valor) {
        if (this.saldo < valor)
        {
            return false;
        }

        this.saldo -= valor;
        return true;

    }

		//FUNÇÃO PARA VERIFICAR SE EXISTE SALDO NO CARTÃO DE CRÉDITO
		 public bool CartaoCredito(double valor) {
			 
        if (this.saldoCartao < valor)
        {
            return false;
        }

        this.saldoCartao -= valor;
        return true;

    }
	//FUNÇÃO PARA DEPOSITAR EM CONTA BANCÁRIA
    public void Depositar(double valor){
        this.saldo += valor;
    }

	//FUNÇÃO PARA TRANSFERENCIA DE VALOR ENTRE CONTAS
    public bool Transferir(double valor, SaldoConta contaDestino){
			
        if (this.saldo < valor)
        {
            return false;
        }
        this.saldo -= valor;
        contaDestino.Depositar(valor);
        return true;

    }
}