using System;
using System.Collections.Generic; //PARA UTILIZAR LISTA

class Menu {

  //DEIXAR O ACESSO A CLASSE DE FORMA PUBLICA PARA PODER ACESSAR A LISTA DE OUTRAS CLASSES.
	
  public static CadastroCliente cliente = new CadastroCliente();

  public void opcMenu() {

    int opcao;

    Console.WriteLine("O que de fazer ? \n 1 - Comprar\n 4 - Cadastrar Cliente "); //PERGUNTAR AO USUÁRIO A OPÇÃO DESEJADA

    opcao = int.Parse(Console.ReadLine()); //RECEBER O RESULTADO DA OPÇÃO

    if (opcao > 4 && opcao < 1) {

      Console.WriteLine("Opção inválida... Execute o programa novamente!"); //MENSAGEM DE ERRO, CASO DIGITAR UMA OPÇÃO INVÁLIDA
    }
    else if (opcao == 1) {

      // INSTANCIAR CLASSE CARRINHO
      Carrinho carr = new Carrinho();
      cliente.cadastro(); // ENTRAR EM CADASTRO DE CLIENTE     
      carr.compras(); // ENTRAR EM COMPRAS

    }
    else if (opcao == 2) {

      Console.WriteLine("Erro de condição ao escolher opção!"); //MENSAGEM DE ERRO, CASO OCORRA PROBLEMAS QUE NÃO FORAM PENSADOS DURANTE A EXECUÇÃO DO PROGRAMA!

    }
    else if (opcao == 3) {

      Console.WriteLine("Erro de condição ao escolher opção!"); //MENSAGEM DE ERRO, CASO OCORRA PROBLEMAS QUE NÃO FORAM PENSADOS DURANTE A EXECUÇÃO DO PROGRAMA!

    } else if (opcao == 4) {

      //CADASTRO DE CLIENTE	
      CadastroCliente cliente = new CadastroCliente();
      cliente.cadastro();

    }
    else {

      Console.WriteLine("Erro de condição ao escolher opção!"); //MENSAGEM DE ERRO, CASO OCORRA PROBLEMAS QUE NÃO FORAM PENSADOS DURANTE A EXECUÇÃO DO PROGRAMA!

    }

  }

}