using System;
using System.Collections.Generic; //PARA UTILIZAR LISTA

class Carrinho {

  //VARIAVEIS

  public string nomeProduto,
  cod_produto,
  valorProduto,
  Quantidade;
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

    int result,
    opcao = 1,
    formPag,
    manterCompra = 0;
    string codPro,
    quantPro,
    ResultCPF;
    double totalCompra = 0; //SOMAR PRODUTOS DA COMPRA

    //VARIÁVEL DO TIPO VETOR
    string[] vetor;

    //INSTANCIAR CLASSES
    Loja loj = new Loja();

    //CRIANDO LISTA
    List < Carrinho > listaCarrinhoCodigo; //PROPRIEDADE
    List < Carrinho > listaParametro; //LISTA QUE PASSA COMO PARÂMETRO PARA A CLASSE Loja

    while (manterCompra == 0) { //PERGUNTAR AO FINAL DA COMPRA SE O USUÁRIO VAI CONTINUAR COMPRANDO
      loj.descricao(); // EXIBIR LISTA DE PRODUTOS A CADA COMPRA
      opcao = 1; // ESTA OPÇÃO SERÁ NECESSÁRIA ENQUANTO O USUÁRIO QUISER FAZER UMA NOVA COMPRA
      totalCompra = 0; //ZERA COMPRA ANTERIOR
      listaCarrinhoCodigo = new List < Carrinho > (); //INSTANCIAR LISTA VAZIA  
      listaParametro = new List < Carrinho > (); //INSTANCIAR LISTA VAZIA

      while (opcao != 0) {

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

        } else if (result == 2) {

          Console.WriteLine("Existe o produto mas não tem Quantidade disponível");

        } else {

          Console.WriteLine("Não Existe o produto");

        }

        Console.WriteLine("Adicionar mais produtos no carrinho ?\n 0 - NÃO\n 1 - SIM ");
        opcao = int.Parse(Console.ReadLine());
      }

      //EXIBIR A LISTA DE PRODUTOS DENTRO DA LISTA
      Console.WriteLine("############# LISTA DE COMPRAS #####################");
      foreach(Carrinho c in listaCarrinhoCodigo) {
        Console.WriteLine(c.cod_produto + " " + c.nomeProduto + " " + c.Quantidade + " " + c.valorProduto);
      }

      Console.WriteLine("\n############# TOTAL VALOR #####################");
      Console.WriteLine("TOTAL : R$ {0}", totalCompra);

      SaldoConta saldoC = new SaldoConta(); //INSTANCIAR CLASSE

      //############ TRATAMENTO DE CADASTRO DE CLIENTE COM VALIDADAÇÃO DE CPF ####################
      Console.WriteLine("DIGITE O CPF PARA CONTINUAR COM A COMPRA");
      ValidaCPF valCpf = new ValidaCPF(); //INSTANCIAR VALIDA CPF
      ResultCPF = Console.ReadLine(); // VARIAVEL QUE VAI RECEBER O CPF DIGITADO PELO USUARIO
      bool cpfCompra = valCpf.IsCpf(ResultCPF); //RECEBER UM VALOR BOLEANO, TRUE - EXISTE O CPF, FALSE - NÃO EXISTE

      if (cpfCompra == true) {

        Console.WriteLine("CPF VÁLIDO!");

        //cadCliente.verificaCadastros();

        //bool existeCliente = cadCliente.verificaCadastros(ResultCPF);	
        bool existeCliente = Menu.cliente.verificaCadastros(ResultCPF);

        if (existeCliente == true) {

          Console.WriteLine("QUAL MÉTODO DE PAGAMENTO ?\n 1 - DINHEIRO \n 2 - CARTÃO DE CRÉDITO");
          formPag = int.Parse(Console.ReadLine());
          //PAGAMENTO EM DINHEIRO

          if (formPag == 1) {

            saldoContaBanco = saldoC.Sacar(totalCompra); //RETORNO BOLEANO

            if (saldoContaBanco == true) {

              Console.WriteLine("Pagamento efetuado com sucesso!");

            } else {

              Console.WriteLine("Saldo Indisponível!...A compra está sendo cancelada!");

            }

            //PAGAMENTO CARTÃO DE CRÉDITO
          } else if (formPag == 2) {

            saldoContaBanco = saldoC.CartaoCredito(totalCompra); //RETORNO BOLEANO

            if (saldoContaBanco == true) {

              Console.WriteLine("Pagamento efetuado com sucesso!");

            } else {

              Console.WriteLine("Saldo Indisponível!...A compra está sendo cancelada");

              loj.setEstornoQuantidade(listaParametro);

            }

          } else {

            Console.WriteLine("Opção inválida");

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
