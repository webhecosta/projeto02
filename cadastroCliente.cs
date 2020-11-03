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
		int px=Console.CursorLeft; //PEGAR POSIÇÃO ATUAL DE X
		int py= Console.CursorTop; //PEGAR POSIÇÃO ATUAL DE Y
    int pyEdtNome=0;
    int pyEdtCpf=0;
		int pyEdtEndereco=0;
    int pyEdtDtNascimento=0;
		int qtdCliente=0;
	//	Console.WriteLine("x :{0}\n Y:{1}",px,py);
    	py++;
    while (sair == 0) {
			Console.Clear();
			qtdCliente++;			
			Console.WriteLine("<=======================================================>");
			Console.WriteLine("<|                 CADASTRO DE CLIENTE({0})              |>",qtdCliente);		
			Console.WriteLine("<=======================================================>");			
			Console.WriteLine("");
		//	Console.WriteLine("x :{0} \\ Y:{1}",Console.CursorLeft,Console.CursorTop);	
      Console.WriteLine("NOME DO CLIENTE");		
			Console.WriteLine("--------------------------------------------------------");
			Console.WriteLine("                                                       |");		
			Console.WriteLine("--------------------------------------------------------");
			pyEdtNome=Console.CursorTop-2;	// IR PARA A POSIÇÃO DENTRO DA CAIXA NOME
	//		Console.WriteLine("x :{0} \\ Y:{1}",Console.CursorLeft,pyEdtNome);				
			Console.WriteLine("");
			Console.WriteLine("CPF DO CLIENTE");
			Console.WriteLine("--------------------------------------------------------");
			Console.WriteLine("                                                       |");				
			Console.WriteLine("--------------------------------------------------------");
			pyEdtCpf=Console.CursorTop-2;		// IR PARA A POSIÇÃO DENTRO DA CAIXA CPF
			Console.WriteLine("");
      Console.WriteLine("ENDEREÇO COMPLETO DO CLIENTE");
			Console.WriteLine("--------------------------------------------------------");
			Console.WriteLine("                                                       |");					
			Console.WriteLine("--------------------------------------------------------");
			pyEdtEndereco=Console.CursorTop-2; 	// IR PARA A POSIÇÃO DENTRO DA CAIXA ENDEREÇO
			Console.WriteLine("");
			Console.WriteLine("DATA DE NASCIMENTO DO CLIENTE EX. XX/XX/XXXX");
			Console.WriteLine("--------------------------------------------------------");
			Console.WriteLine("                                                       |");					
			Console.WriteLine("--------------------------------------------------------");	
			pyEdtDtNascimento=Console.CursorTop-2;// IR PARA A POSIÇÃO DENTRO DA CAIXA DATA NASCIMENTO
			Console.WriteLine("");

			Console.SetCursorPosition(0,pyEdtNome); //SETAR POSIÇÃO DO NOME
     // Console.WriteLine("NOME DO CLIENTE");
      nome = Console.ReadLine();
			
			Console.SetCursorPosition(0,pyEdtCpf); //SETAR POSIÇÃO DO CPF
      //Console.WriteLine("CPF DO CLIENTE");
      cpf = Console.ReadLine();

      cpfValidado = valida.IsCpf(cpf); //PASSAR COMO PARÂMETRO O NUMERO DO CPF PARA VALIDÁ-LO ANTES DE CADASTRAR.

      while (cpfValidado != true) {
        // LER O CPF ENQUANTO O MESMO FOR INVÁLIDO 
				Console.SetCursorPosition(0,pyEdtCpf);
			  Console.Write("                                    ");	
				Console.SetCursorPosition(0,pyEdtCpf);
        Console.Write("DIGITE UM CPF VÁLIDO!");	
				Console.ReadKey();
				Console.SetCursorPosition(0,pyEdtCpf);
				Console.Write("                                    ");
				Console.SetCursorPosition(0,pyEdtCpf);			
        cpf = Console.ReadLine();
        cpfValidado = valida.IsCpf(cpf);

      } // FIM WHILE VERIFICAR VALIDADE CPF
      	Console.SetCursorPosition(0,pyEdtEndereco);
     // Console.WriteLine("ENDEREÇO COMPLETO DO CLIENTE");
      string endereco = (Console.ReadLine());
			
			Console.SetCursorPosition(0,pyEdtDtNascimento);
     // Console.WriteLine("DATA DE NASCIMENTO DO CLIENTE EX. XX/XX/XXXX");
      string dataNascimento = (Console.ReadLine());

      Cliente client = new Cliente(nome, endereco, cpf, dataNascimento); //PASSANDO OS ATRIBUTOS PARA O TIPO CLIENTE 

      listCliente.Add(client); //CADASTRAR O CLIENTE NA LISTA
      Console.SetCursorPosition(0,Console.CursorTop+3);
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
				 Console.WriteLine("\n");
        return true;
      }

    }

    return false;

  }

	//CONSULTAR CLIENTE ATRAVÉS DO CPF
	  public string[] retornoDadosCliente(string cpf) {

    string[] cpfMsg = new string[2]; //CRIAR VETOR DE TAMANHO 2

    for (int i = 0; i < listCliente.Count; i++) {

      if ((listCliente[i].cpf) == cpf) {

        cpfMsg[0] = listCliente[i].nome;
        cpfMsg[1] = listCliente[i].cpf;
        return cpfMsg;
        break;
      }

    }

    return cpfMsg;
  }

} // FIM CLASSE
