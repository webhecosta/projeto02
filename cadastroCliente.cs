using System;
using System.Collections.Generic; //PARA UTILIZAR LISTA

class CadastroCliente {

  string nome,
  cpf;

  List < Cliente > listCliente; //PROPRIEDADE

  public void cadastro() {

    listCliente = new List < Cliente > (); //INSTANCIAR LISTA VAZIA

    Cliente webhe = new Cliente("WEBHE", "AV. COPA", "12560800713", "04/01/1990"); //PASSANDO OS ATRIBUTOS PARA O TIPO CLIENTE 
    listCliente.Add(webhe);

    // INSTANCIAR CLASSE
    ValidaCPF valida = new ValidaCPF();

    //DECLARAÇÃO DE VARIÁVEIS
    bool cpfValidado;

    int sair = 0; //VARIÁVEL PARA CONTROLAR A EXECUÇÃO DO WHILE

    while (sair == 0) {
      Console.WriteLine("NOME DO CLIENTE");
      nome = Console.ReadLine();
      Console.WriteLine("CPF DO CLIENTE");
      cpf = Console.ReadLine();

      cpfValidado = valida.IsCpf(cpf); //PASSAR COMO PARÂMETRO O NUMERO DO CPF PARA VALIDÁ-LO ANTES DE CADASTRAR.

      while (cpfValidado != true) {
        // LER O CPF ENQUANTO O MESMO FOR INVÁLIDO 
        Console.WriteLine("DIGITE UM CPF VÁLIDO!");
        cpf = Console.ReadLine();
        cpfValidado = valida.IsCpf(cpf);

      } // FIM WHILE VERIFICAR VALIDADE CPF

      Console.WriteLine("ENDEREÇO COMPLETO DO CLIENTE");
      string endereco = (Console.ReadLine());
      Console.WriteLine("DATA DE NASCIMENTO DO CLIENTE EX. XX/XX/XXXX");
      string dataNascimento = (Console.ReadLine());

      Cliente client = new Cliente(nome, endereco, cpf, dataNascimento); //PASSANDO OS ATRIBUTOS PARA O TIPO CLIENTE 

      listCliente.Add(client); //CADASTRAR O CLIENTE NA LISTA

      //VERIFICANDO COM O USUÁRIO SE ELE DESEJA CONTINUAR OU SAIR
      Console.WriteLine("1 - PARA SAIR \n 0 - CADASTRAR NOVO CLIENTE \n");
      sair = int.Parse(Console.ReadLine());

      if (sair == 1) {

        Console.WriteLine("QUANTIDADE DE CLIENTES:  {0}", listCliente.Count); //EXIBIR QUANTIDADE DE CARROS

        foreach(Cliente c in listCliente) {
          Console.WriteLine(c.nome + " " + c.cpf);
        } //FIM foreach

      } // FIM IF SAIR  

    } // FIM WHILE SAIR

  } // FIM FUNÇÃO CADASTRO

  //FUNÇÃO PARA VERIFICAR SE EXISTE CADASTRO DO CLIENTE EM COMPRAS
  public bool verificaCadastros(string cpf) {

    for (int i = 0; i < listCliente.Count; i++) {

      if (listCliente[i].cpf == cpf) {

        Console.WriteLine("CLIENTE:{0}\n CPF: {1}", listCliente[i].nome, listCliente[i].cpf);
        return true;
      }

    }

    return false;

  }

} // FIM CLASSE
