using System;

class Cliente {

  //coloquei o valor dos parametros para teste
  public string nome,
  endereco,
  cpf,
  dataNascimento;

  public string getCliente() {
    return nome;
  }

  public void relatorio() {

    Console.WriteLine("NOME : {0} \n CPF : {1} \n", nome, cpf);

  }

  public void atualizaCliente(string n, string cp) {

    string novo_nome = n;
    string novo_cpf = cp;

    Console.WriteLine("NOVO CLIENTE : {0}  \n NOVO CPF: {1} \n", novo_nome, novo_cpf);

  }

  //CONSTRUTOR VAZIO
  public Cliente() {
    nome = "WEBHE ROSA DA COSTA";
    endereco = "AV. COPACABANA,739-MORADA DE LARANJEIRAS";
    cpf = "12560800713";
    dataNascimento = "01/01/1990";
  }

  //CONTRUTOR COMPLETO
  public Cliente(string n, string e, string c, string data) {

    nome = n;
    endereco = e;
    cpf = c;
    dataNascimento = data;

  }

}