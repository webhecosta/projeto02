using System;
using System.Collections.Generic; //PARA UTILIZAR LISTA

class Carrinho {

  //VARIAVEIS

  public string nomeProduto, cod_produto, valorProduto, Quantidade;

  //Construtor vazio
  public Carrinho() {

	}
  //Construtor completo
  public Carrinho(string nomePr, string cod_pr, string Quant, string vl) {

    nomeProduto = nomePr;
    cod_produto = cod_pr;
    Quantidade = Quant;
    valorProduto = vl;

  }

  public Carrinho(string cod_pr, string Quant) {

    cod_produto = cod_pr;
    Quantidade = Quant;

  }

  //FUNÇÃO PARA ESCOLHER PRODUTOS QUE SERÃO ADICIONADOS NO CARRINHO
  //NESTA FUNÇÃO O USUÁRIO SABERÁ QUAIS PRODUTOS PODERÃO SER ADICIONADOS NO CARRINHO
  public void compras() {

    int result,opcao = 1,manterCompra = 0, opcaoSeguirCom;
    string codPro,quantPro;
    double totalCompra = 0;
    int qtdItem = 0;
 
    //VARIÁVEL DO TIPO VETOR
    string[] vetor;
 
   	Loja loj = new Loja();

		  Funcompras funcaoCompra = new Funcompras(); //INSTANCIAR FUNÇÃO PARA 

    //CRIANDO LISTA
    List < Carrinho > listaCarrinhoCodigo; //PROPRIEDADE
    List < Carrinho > listaParametro; //LISTA QUE PASSA COMO PARÂMETRO PARA A CLASSE Loja

    while (manterCompra == 0) { //PERGUNTAR AO FINAL DA COMPRA SE O USUÁRIO VAI CONTINUAR COMPRANDO
      // loj.descricao(); // EXIBIR LISTA DE PRODUTOS A CADA COMPRA
      opcao = 1; // ESTA OPÇÃO SERÁ NECESSÁRIA ENQUANTO O USUÁRIO QUISER FAZER UMA NOVA COMPRA
      totalCompra = 0; //ZERA COMPRA ANTERIOR
      qtdItem = 0; //ZERA CARRINHO ANTERIOR
      listaCarrinhoCodigo = new List <Carrinho> (); //INSTANCIAR LISTA VAZIA  
      listaParametro = new List <Carrinho> (); //INSTANCIAR LISTA VAZIA

      while (opcao != 0) {
        loj.descricao(); // EXIBIR LISTA DE PRODUTOS A CADA COMPRA       
        //  pyCarrinho=Console.CursorTop-2;	// IR PARA A POSIÇÃO DENTRO DA CAIXA NOME
        Console.WriteLine("Digite o código do produto para adicionar no carrinho");
        codPro = (Console.ReadLine()); //Ler produto desejado

        Console.WriteLine("Digite o Quantidade que deseja para este produto");
        quantPro = (Console.ReadLine()); //Ler quantidade desejada

        result = loj.validaProduto(codPro, quantPro); // Retorno da consulta do produto

        if (result == 1) {

         // Console.WriteLine("Existe o produto e Quantidade");

          Carrinho listReturn = new Carrinho(codPro, quantPro); // ADICIONANDO OS VALORES DENTRO DA LISTA
          listaParametro.Add(listReturn); // ADICIONAR OS PRODUTOS DO CARRINHO EM UMA LISTA ONDE SERÁ ENVIADA COMO PARÂMETRO PARA CASO OCORRA ESTORNO DE PRODUTOS

          loj.setQuantidade(codPro, quantPro); // ATUALIZAR LISTA DE PRODUTOS
          vetor = (loj.retornoDadosProduto(codPro)); //RECEBER OS DADOS DO PRODUTO ANTES DE ADICIONAR A LISTA.	

          Carrinho carrinho = new Carrinho(vetor[1], vetor[0], quantPro, vetor[3]);
          totalCompra = totalCompra + (int.Parse(quantPro) * double.Parse(vetor[3])); // COMPRA = QUANTIDADE * VALOR UNITÁRIO ---- DE CADA PRODUTO
          //PASSANDO OS ATRIBUTOS PARA O TIPO CLIENTE 
          listaCarrinhoCodigo.Add(carrinho); // Adicionar o produto na lista de carrinhos
          qtdItem++;
					Console.WriteLine(" ____o");
        	Console.WriteLine("(_{0}_/", qtdItem);
        	Console.WriteLine(" ° °");

        } else if (result == 2) {

          Console.WriteLine("Existe o produto mas não tem Quantidade disponível");

        } else {

          Console.WriteLine("Não Existe o produto");

        }

        Console.WriteLine("Adicionar mais produtos no carrinho ?\n 0 - NÃO\n 1 - SIM ");
        opcao = int.Parse(Console.ReadLine());

      } //WHILE OPÇÃO ADICIONAR MAIS PRODUTOS

      //EXIBIR A LISTA DE PRODUTOS DENTRO DA LISTA
      Console.WriteLine("############# LISTA DE COMPRAS #####################\n");
      int u = 0; //CONTADOR PARA PERCORRER A LISTA DE PRODUTOS QUE FORAM ADICIONADOS NO CARRINHO
      foreach(Carrinho c in listaCarrinhoCodigo) {
        Console.WriteLine("COD.PRODUTO: {0} - NOME PRODUTO {1} ", c.cod_produto, c.nomeProduto);

        Console.WriteLine("QTDE SOL. {0} - VL UN R$ {1} - VL TOTAL R$ {2}", c.Quantidade, c.valorProduto, int.Parse(c.Quantidade) * double.Parse(c.valorProduto));
        Console.WriteLine("----------------------------------------------------------------|");
        u += 1;
      }

      Console.WriteLine("\n############# TOTAL VALOR #####################");
      Console.WriteLine("TOTAL : R$ {0}", totalCompra);
      Console.WriteLine("\n###############################################\n");

      Console.WriteLine("\nDIGITE:\n0-CONTINUAR COM A COMPRA\n1-CANCELAR UM ITEM\n2-CANCELAR A COMPRA"); // OPÇÃO ANTES DE CONTINUAR COM A COMPRA
      opcaoSeguirCom = int.Parse(Console.ReadLine()); // LER OPÇÃO DIGITADA

      //PROSSEGUIR COM A COMPRA
      if (opcaoSeguirCom == 0) {

      //RETORNAR RETORNAR INFORMAÇÃO DA COMPRA
			 funcaoCompra.funCarrinho(listaCarrinhoCodigo,listaParametro);

        //CANCELAR ITEM DA COMPRA
      } else if (opcaoSeguirCom == 1) { /////////////

			//RETORNAR RETORNAR INFORMAÇÃO DA COMPRA
			 funcaoCompra.cancelaEditCompras(listaCarrinhoCodigo,listaParametro);

      } else if (opcaoSeguirCom == 2) {
        Console.WriteLine("COMPRA CANCELADA!!!");
        break;

      } else {
        Console.WriteLine("OPÇÃO INVÁLIDA!!");
        break;
      }

      //EXIBIR A LISTA DE PRODUTOS DENTRO DA tupla
      Console.WriteLine("Deseja efetuar uma nova compra ?\n 0 - SIM\n 1 - NÃO\n");
      manterCompra = int.Parse(Console.ReadLine());

    } // WHILE MANTER NOVA COMPRA OU FINALIZAR

  } // FIM FUNCAO COMPRAR

} //FIM CLASSE
