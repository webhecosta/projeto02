using System;
using System.Collections.Generic; //PARA UTILIZAR LISTA

class Carrinho {

  //VARIAVEIS

  public string nomeProduto,cod_produto,valorProduto,Quantidade;
  bool saldoContaBanco;

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

    int result,opcao = 1,formPag, manterCompra = 0;
    string codPro, quantPro, ResultCPF;
    double totalCompra = 0,totalCompras=0; //SOMAR PRODUTOS DA COMPRA
    int qtdItem=0;
		int pyCarrinho=0;
    //VARIÁVEL DO TIPO VETOR
    string[] vetor;
		string[] cadCliente; //RETORNAR OS NOME E CPF DO CLIENTE QUE EFETUAOU A COMPRA
    
    //INSTANCIAR CLASSES
    Loja loj = new Loja();

    //CRIANDO LISTA
    List < Carrinho > listaCarrinhoCodigo; //PROPRIEDADE
    List < Carrinho > listaParametro; //LISTA QUE PASSA COMO PARÂMETRO PARA A CLASSE Loja

    while (manterCompra == 0) { //PERGUNTAR AO FINAL DA COMPRA SE O USUÁRIO VAI CONTINUAR COMPRANDO
     // loj.descricao(); // EXIBIR LISTA DE PRODUTOS A CADA COMPRA
      opcao = 1; // ESTA OPÇÃO SERÁ NECESSÁRIA ENQUANTO O USUÁRIO QUISER FAZER UMA NOVA COMPRA
      totalCompra = 0; //ZERA COMPRA ANTERIOR
      listaCarrinhoCodigo = new List < Carrinho > (); //INSTANCIAR LISTA VAZIA  
      listaParametro = new List < Carrinho > (); //INSTANCIAR LISTA VAZIA

      while (opcao != 0) {
				 loj.descricao(); // EXIBIR LISTA DE PRODUTOS A CADA COMPRA
				Console.WriteLine(" ____o");
				Console.WriteLine("(_{0}_/",qtdItem);
				Console.WriteLine(" ° °");
      //  pyCarrinho=Console.CursorTop-2;	// IR PARA A POSIÇÃO DENTRO DA CAIXA NOME
        Console.WriteLine("Digite o código do produto para adicionar no carrinho");
        codPro = (Console.ReadLine()); //Ler produto desejado

        Console.WriteLine("Digite o Quantidade que deseja para este produto");
        quantPro = (Console.ReadLine()); //Ler quantidade desejada

        result = loj.validaProduto(codPro, quantPro); // Retorno da consulta do produto

        if (result == 1) {

          Console.WriteLine("Existe o produto e Quantidade");

          Carrinho listReturn = new Carrinho(codPro, quantPro); // ADICIONANDO OS VALORES DENTRO DA LISTA
          listaParametro.Add(listReturn); // ADICIONAR OS PRODUTOS DO CARRINHO EM UMA LISTA ONDE SERÁ ENVIADA COMO PARÂMETRO PARA CASO OCORRA ESTORNO DE PRODUTOS

          loj.setQuantidade(codPro, quantPro); // ATUALIZAR LISTA DE PRODUTOS
          vetor = (loj.retornoDadosProduto(codPro)); //RECEBER OS DADOS DO PRODUTO ANTES DE ADICIONAR A LISTA.	

          Carrinho carrinho = new Carrinho(vetor[1], vetor[0], vetor[2], vetor[3]);
          totalCompra = totalCompra + (int.Parse(quantPro) * double.Parse(vetor[3])); // COMPRA = QUANTIDADE * VALOR UNITÁRIO ---- DE CADA PRODUTO
          //PASSANDO OS ATRIBUTOS PARA O TIPO CLIENTE 
          listaCarrinhoCodigo.Add(carrinho); // Adicionar o produto na lista de carrinhos
          qtdItem++;
        } else if (result == 2) {

          Console.WriteLine("Existe o produto mas não tem Quantidade disponível");

        } else {

          Console.WriteLine("Não Existe o produto");

        }

        Console.WriteLine("Adicionar mais produtos no carrinho ?\n 0 - NÃO\n 1 - SIM ");
        opcao = int.Parse(Console.ReadLine());
      }

      //EXIBIR A LISTA DE PRODUTOS DENTRO DA LISTA
      Console.WriteLine("############# LISTA DE COMPRAS #####################\n");
			int u = 0; //CONTADOR PARA PERCORRER A LISTA DE PRODUTOS QUE FORAM ADICIONADOS NO CARRINHO
      foreach(Carrinho c in listaCarrinhoCodigo) {
        Console.WriteLine("COD.PRODUTO: {0} - NOME PRODUTO {1} ",c.cod_produto,c.nomeProduto);

				Console.WriteLine("QTDE SOL. {0} - VL UN R$ {1} - VL TOTAL R$ {2}",listaParametro[u].Quantidade,c.valorProduto,int.Parse(listaParametro[u].Quantidade)*double.Parse(c.valorProduto));
				Console.WriteLine("----------------------------------------------------------------|");
				u += 1;
			}

      Console.WriteLine("\n############# TOTAL VALOR #####################");
      Console.WriteLine("TOTAL : R$ {0}", totalCompra);
			Console.WriteLine("\n###############################################\n");

      SaldoConta saldoC = new SaldoConta(); //INSTANCIAR CLASSE

      //############ TRATAMENTO DE CADASTRO DE CLIENTE COM VALIDADAÇÃO DE CPF ####################
      Console.WriteLine("DIGITE O CPF PARA CONTINUAR COM A COMPRA");
      ValidaCPF valCpf = new ValidaCPF(); //INSTANCIAR VALIDA CPF
      ResultCPF = Console.ReadLine(); // VARIAVEL QUE VAI RECEBER O CPF DIGITADO PELO USUARIO
      bool cpfCompra = valCpf.IsCpf(ResultCPF); //RECEBER UM VALOR BOLEANO, TRUE - EXISTE O CPF, FALSE - NÃO EXISTE

      if (cpfCompra == true) {
     
      
        bool existeCliente = Menu.cliente.verificaCadastros(ResultCPF); //VERIFICA SE O CLIENTE EXISTE

        if (existeCliente == true) {

          Console.WriteLine("QUAL MÉTODO DE PAGAMENTO ?\n 1 - DINHEIRO \n 2 - CARTÃO DE CRÉDITO");
          formPag = int.Parse(Console.ReadLine());
          //PAGAMENTO EM DINHEIRO

          if (formPag == 1) {

            saldoContaBanco = saldoC.Sacar(totalCompra); //RETORNO BOLEANO

            if (saldoContaBanco == true) {

              Console.WriteLine("Pagamento efetuado com sucesso!\n");
							Console.WriteLine("#########################CUPOM FISCAL#########################\n");
							cadCliente = Menu.cliente.retornoDadosCliente(ResultCPF); //VERIFICA SE O CLIENTE EXISTE
								Console.WriteLine("CLIENTE : {0}\n CPF : {1}",cadCliente[0],cadCliente[1]);	
							//EXIBIR A LISTA DE PRODUTOS DENTRO DA LISTA
							Console.WriteLine("##############################################################\n");
							int h = 0; //CONTADOR PARA PERCORRER A LISTA DE PRODUTOS QUE FORAM ADICIONADOS NO CARRINHO
							foreach(Carrinho c in listaCarrinhoCodigo) {

								Console.WriteLine("----------------------------------------------------------------|");
								Console.WriteLine("COD.PRODUTO: {0} - NOME PRODUTO {1} ",c.cod_produto,c.nomeProduto);
								Console.WriteLine("QTDE SOL. {0} - VL UN R$ {1} - VL TOTAL R$ {2}",listaParametro[h].Quantidade,c.valorProduto,int.Parse(listaParametro[h].Quantidade)*double.Parse(c.valorProduto));
								Console.WriteLine("----------------------------------------------------------------|");
								totalCompras += int.Parse(listaParametro[h].Quantidade)*double.Parse(c.valorProduto); //SOMAR VALOR 
								h += 1;
							}

								Console.WriteLine("########################## TOTAL ##############################\n");
								Console.WriteLine("TOTAL : R$ {0} \nTIPO PAGAMENTO : {1}",totalCompras,"DINHEIRO");
								Console.WriteLine("\n#############################################################\n");

            } else {

              Console.WriteLine("Saldo Indisponível!...A compra está sendo cancelada!\n");
							loj.setEstornoQuantidade(listaParametro); // ESTORNAR QUANTIDADE DO PRODUTO

            }

            //PAGAMENTO CARTÃO DE CRÉDITO
          } else if (formPag == 2) {

            saldoContaBanco = saldoC.CartaoCredito(totalCompra); //RETORNO BOLEANO

            if (saldoContaBanco == true) {

              Console.WriteLine("Pagamento efetuado com sucesso!\n");
							Console.WriteLine("#########################CUPOM FISCAL#########################\n");
							cadCliente = Menu.cliente.retornoDadosCliente(ResultCPF); //VERIFICA SE O CLIENTE EXISTE
							Console.WriteLine("CLIENTE : {0}\n CPF : {1}",cadCliente[0],cadCliente[1]);	
							//EXIBIR A LISTA DE PRODUTOS DENTRO DA LISTA
							Console.WriteLine("##############################################################\n");

								//EXIBIR A LISTA DE PRODUTOS DENTRO DA LISTA
							Console.WriteLine("############# CUPOM FISCAL #####################\n");
							int h = 0; //CONTADOR PARA PERCORRER A LISTA DE PRODUTOS QUE FORAM ADICIONADOS NO CARRINHO
							
							foreach(Carrinho c in listaCarrinhoCodigo) {

								Console.WriteLine("----------------------------------------------------------------|");
								Console.WriteLine("COD.PRODUTO: {0} - NOME PRODUTO {1} ",c.cod_produto,c.nomeProduto);
								Console.WriteLine("QTDE SOL. {0} - VL UN R$ {1} - VL TOTAL R$ {2}",listaParametro[h].Quantidade,c.valorProduto,int.Parse(listaParametro[h].Quantidade)*double.Parse(c.valorProduto));
								Console.WriteLine("----------------------------------------------------------------|");
								totalCompras += int.Parse(listaParametro[h].Quantidade)*double.Parse(c.valorProduto) ; //SOMAR VALOR TOTAL DA COMPRA
								h += 1;
							}
								Console.WriteLine("############# TOTAL #####################\n");					
								Console.WriteLine("TOTAL : R$ {0} \nTIPO PAGAMENTO : {1}",totalCompras,"CARTÃO DE CRÉDITO");
								Console.WriteLine("\n#############################################################\n");

            } else {

              Console.WriteLine("Saldo Indisponível!...A compra está sendo cancelada\n");

              loj.setEstornoQuantidade(listaParametro);// ESTORNAR QUANTIDADE DO PRODUTO

            }

          } else {

            Console.WriteLine("Opção inválida");
						Console.WriteLine("A compra está sendo cancelada");
						loj.setEstornoQuantidade(listaParametro);// ESTORNAR QUANTIDADE DO PRODUTO

          }

        } else {

          Console.WriteLine("CLIENTE NÃO CADASTRADO!...COMPRA CANCELADA");
          break;

        }

      } else {
        Console.WriteLine("CPF INVÁLIDO!...COMPRA CANCELADA");
        break;

      }

      //EXIBIR A LISTA DE PRODUTOS DENTRO DA tupla
      Console.WriteLine("Deseja efetuar uma nova compra ?\n 0 - SIM\n 1 - NÃO\n");
      manterCompra = int.Parse(Console.ReadLine());

    } // WHILE MANTER NOVA COMPRA OU FINALIZAR

  } // FIM FUNCAO COMPRAR

} //FIM CLASSE
