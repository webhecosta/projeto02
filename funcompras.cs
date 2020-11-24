using System;
using System.Collections.Generic; //PARA UTILIZAR LISTA

class Funcompras {

  //DECLARAÇÃO DE VARIÁVEIS

  int formPag=0;
  string ResultCPF;
  double totalCompra = 0,
  totalCompras = 0; //SOMAR PRODUTOS DA COMPRA
  //VARIÁVEL DO TIPO VETOR  
  string[] cadCliente;
  bool saldoContaBanco,cpfCompra = false;

  Loja loj = new Loja(); //INSTANCIAR CLASSES
  SaldoConta saldoC = new SaldoConta(); //INSTANCIAR CLASSE	 

  public void funCarrinho(List < Carrinho > listaCarrinhoCodigo, List < Carrinho > listaParametro) {

    //############ TRATAMENTO DE CADASTRO DE CLIENTE COM VALIDADAÇÃO DE CPF ####################
  
  
		while(cpfCompra != true){
			  
				Console.WriteLine("DIGITE O CPF PARA CONTINUAR COM A COMPRA\n");
				ValidaCPF valCpf = new ValidaCPF(); //INSTANCIAR VALIDA CPF
				ResultCPF = Console.ReadLine();
			   // VARIAVEL QUE VAI RECEBER O CPF DIGITADO PELO USUARIO
    		 cpfCompra = valCpf.IsCpf(ResultCPF); //RECEBER UM VALOR BOLEANO, TRUE - EXISTE O CPF, FALSE - NÃO EXISTE

				 if (cpfCompra != true){

					 	Console.WriteLine("DIGITE UM CPF VÁLIDO!!\n");

				 }

		}


      bool existeCliente = Menu.cliente.verificaCadastros(ResultCPF); //VERIFICA SE O CLIENTE EXISTE

      if (existeCliente == true) {

        
					while ( (formPag != 1) &&  (formPag !=2) ){

						Console.WriteLine("QUAL MÉTODO DE PAGAMENTO ?\n 1 - DINHEIRO \n 2 - CARTÃO DE CRÉDITO");
          	formPag = int.Parse(Console.ReadLine());
						
						if ( (formPag != 1) &&  (formPag !=2) ){
							Console.WriteLine("DIGITE UMA OPÇÃO VÁLIDA!!\n");
						}						

					} //FIM WHILE VALIDA FORMA DE PAGAMENTO.


        if (formPag == 1) {

          saldoContaBanco = saldoC.Sacar(totalCompra); //RETORNO BOLEANO

          if (saldoContaBanco == true) {

            Console.WriteLine("Pagamento efetuado com sucesso!\n");
            Console.WriteLine("#########################CUPOM FISCAL#########################\n");
            cadCliente = Menu.cliente.retornoDadosCliente(ResultCPF); //VERIFICA SE O CLIENTE EXISTE
            Console.WriteLine("CLIENTE : {0}\nCPF : {1}", cadCliente[0], cadCliente[1]);
            //EXIBIR A LISTA DE PRODUTOS DENTRO DA LISTA

            int h = 0; //CONTADOR PARA PERCORRER A LISTA DE PRODUTOS QUE FORAM ADICIONADOS NO CARRINHO
            foreach(Carrinho c in listaCarrinhoCodigo) {

              Console.WriteLine("----------------------------------------------------------------|");
              Console.WriteLine("COD.PRODUTO: {0} - NOME PRODUTO {1} ", c.cod_produto, c.nomeProduto);
              Console.WriteLine("QTDE SOL. {0} - VL UN R$ {1} - VL TOTAL R$ {2}", c.Quantidade, c.valorProduto, int.Parse(c.Quantidade) * double.Parse(c.valorProduto));
              Console.WriteLine("----------------------------------------------------------------|");
              totalCompras += int.Parse(c.Quantidade) * double.Parse(c.valorProduto); //SOMAR VALOR 
              h += 1;
            }

            Console.WriteLine("########################## TOTAL ##############################\n");
            Console.WriteLine("TOTAL : R$ {0} \nTIPO PAGAMENTO : {1}", totalCompras, "DINHEIRO");
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
            Console.WriteLine("CLIENTE : {0}\nCPF : {1}", cadCliente[0], cadCliente[1]);
            //EXIBIR A LISTA DE PRODUTOS DENTRO DA LISTA

            //EXIBIR A LISTA DE PRODUTOS DENTRO DA LISTA
            Console.WriteLine("############# CUPOM FISCAL #####################\n");
            int h = 0; //CONTADOR PARA PERCORRER A LISTA DE PRODUTOS QUE FORAM ADICIONADOS NO CARRINHO

            foreach(Carrinho c in listaCarrinhoCodigo) {

              Console.WriteLine("----------------------------------------------------------------|");
              Console.WriteLine("COD.PRODUTO: {0} - NOME PRODUTO {1} ", c.cod_produto, c.nomeProduto);
              Console.WriteLine("QTDE SOL. {0} - VL UN R$ {1} - VL TOTAL R$ {2}", c.Quantidade, c.valorProduto, int.Parse(c.Quantidade) * double.Parse(c.valorProduto));
              Console.WriteLine("----------------------------------------------------------------|");
              totalCompras += int.Parse(c.Quantidade) * double.Parse(c.valorProduto); //SOMAR VALOR TOTAL DA COMPRA
              h += 1;
            }
            Console.WriteLine("############# TOTAL #####################\n");
            Console.WriteLine("TOTAL : R$ {0} \nTIPO PAGAMENTO : {1}", totalCompras, "CARTÃO DE CRÉDITO");
            Console.WriteLine("\n#############################################################\n");

          } else {

            Console.WriteLine("Saldo Indisponível!...A compra está sendo cancelada\n");

            loj.setEstornoQuantidade(listaParametro); // ESTORNAR QUANTIDADE DO PRODUTO

          }

        } else {

          Console.WriteLine("Opção inválida");
          Console.WriteLine("A compra está sendo cancelada");
          loj.setEstornoQuantidade(listaParametro); // ESTORNAR QUANTIDADE DO PRODUTO

        }

      } else {

        Console.WriteLine("CLIENTE NÃO CADASTRADO!...COMPRA CANCELADA");

      }

    

  } //FIM FUNÇÃO######################################################################################################################################################################################################################################################################################################

  public void cancelaEditCompras(List < Carrinho > listaCarrinhoCodigo, List < Carrinho > listaParametro) {

    Console.WriteLine("DIGITE QUANTOS PRODUTOS DESEJA CANCELAR/EDITAR");
    int qtdeCancelProd = int.Parse(Console.ReadLine());

    for (int n = 0; n < qtdeCancelProd; n++) {
    
      Console.WriteLine("DIGITE O CÓDIGO DO PRODUTO QUE DESEJA CANCELAR/EDITAR");
      string codCancProd = Console.ReadLine();

      for (int i = 0; i < listaCarrinhoCodigo.Count; i++) {

        if (listaCarrinhoCodigo[i].cod_produto == codCancProd) {

          Console.WriteLine("0-EDITAR\n1-CANCELAR");
          int EditOpt = int.Parse(Console.ReadLine());

          if (EditOpt == 0) {

            Console.WriteLine("DIGITE A QUANTIDADE A SER EDITADA");
            string qtdeEditProd = Console.ReadLine();

            for (int q = 0; q < listaCarrinhoCodigo.Count; q++) {

              if (listaCarrinhoCodigo[q].cod_produto == codCancProd) {

                listaCarrinhoCodigo[q].Quantidade = qtdeEditProd;

              }

            }

          } else if (EditOpt == 1) {

            Console.WriteLine("CANCELANDO PRODUTO!!");
            for (int w = 0; w < listaCarrinhoCodigo.Count; w++) {

              if (listaCarrinhoCodigo[w].cod_produto == codCancProd) {

                Console.WriteLine("COD PRODUTO : {0}\n PRODUTO : {1} -------  CANCELANDO!!", listaCarrinhoCodigo[w].cod_produto, listaCarrinhoCodigo[w].nomeProduto);
                listaCarrinhoCodigo.RemoveAt(w);

              }

            }

          } else {
            Console.WriteLine("OPÇÃO INVÁLIDA");
          }

        } // FIM IF DENTRO DO FOR

      } //FOR PERCORRER LISTA

    } // FOR PERCORRE QUANTIDADE DE PRODUTOS A SEREM EXCLUIDOS/EDITADOS

    //SE NÃO EXISTE PRODUTO NO CARRINHO... VAI SOLICITAR UMA NOVA COMPRA
    if (listaCarrinhoCodigo.Count <= 0) {
      Console.WriteLine("\nSEM PRODUTOS NA LISTA.... EFETUE UMA NOVA COMPRA!!!\n");

    } else {

      //EXIBIR A LISTA DE PRODUTOS DENTRO DA LISTA
      Console.WriteLine("\n############# LISTA DE COMPRAS #####################\n");
      foreach(Carrinho c in listaCarrinhoCodigo) {
        Console.WriteLine("COD.PRODUTO: {0} - NOME PRODUTO {1} ", c.cod_produto, c.nomeProduto);

        Console.WriteLine("QTDE SOL. {0} - VL UN R$ {1} - VL TOTAL R$ {2}", c.Quantidade, c.valorProduto, int.Parse(c.Quantidade) * double.Parse(c.valorProduto));
        Console.WriteLine("----------------------------------------------------------------|");

      }

      SaldoConta saldoC = new SaldoConta(); //INSTANCIAR CLASSE

      //############ TRATAMENTO DE CADASTRO DE CLIENTE COM VALIDADAÇÃO DE CPF ####################     

			while (cpfCompra != true){

				Console.WriteLine("DIGITE O CPF PARA CONTINUAR COM A COMPRA\n");
				ValidaCPF valCpf = new ValidaCPF(); //INSTANCIAR VALIDA CPF
				ResultCPF = Console.ReadLine(); // VARIAVEL QUE VAI RECEBER O CPF DIGITADO PELO USUARIO

				 cpfCompra = valCpf.IsCpf(ResultCPF); //RECEBER UM VALOR BOLEANO, TRUE - EXISTE O CPF, FALSE - NÃO EXISTE

				
				 if (cpfCompra != true){

					 	Console.WriteLine("DIGITE UM CPF VÁLIDO!!\n");

				 }

			}
     

        bool existeCliente = Menu.cliente.verificaCadastros(ResultCPF); //VERIFICA SE O CLIENTE EXISTE

        if (existeCliente == true) {
				
					//FORÇAR QUE O USUÁRIO DIGITE UMA DAS OPÇÕES ABAIXO:
					// SE ELE CHEGOU ATÉ AQUI...NÃO PODE CANCELAR.

					while ( (formPag != 1) &&  (formPag !=2) ){

						Console.WriteLine("QUAL MÉTODO DE PAGAMENTO ?\n 1 - DINHEIRO \n 2 - CARTÃO DE CRÉDITO");
          	formPag = int.Parse(Console.ReadLine());
						
						if ( (formPag != 1) &&  (formPag !=2) ) {
							Console.WriteLine("DIGITE UMA OPÇÃO VÁLIDA!!\n");
						}	

								

					} //FIM WHILE VALIDA FORMA DE PAGAMENTO.

      
          //PAGAMENTO EM DINHEIRO

          if (formPag == 1) {

            saldoContaBanco = saldoC.Sacar(totalCompra); //RETORNO BOLEANO

            if (saldoContaBanco == true) {

              Console.WriteLine("Pagamento efetuado com sucesso!\n");
              Console.WriteLine("#########################CUPOM FISCAL#########################\n");
              cadCliente = Menu.cliente.retornoDadosCliente(ResultCPF); //VERIFICA SE O CLIENTE EXISTE
              Console.WriteLine("CLIENTE : {0}\nCPF : {1}", cadCliente[0], cadCliente[1]);
              //EXIBIR A LISTA DE PRODUTOS DENTRO DA LISTA

              int h = 0; //CONTADOR PARA PERCORRER A LISTA DE PRODUTOS QUE FORAM ADICIONADOS NO CARRINHO
              foreach(Carrinho c in listaCarrinhoCodigo) {

                Console.WriteLine("----------------------------------------------------------------|");
                Console.WriteLine("COD.PRODUTO: {0} - NOME PRODUTO {1} ", c.cod_produto, c.nomeProduto);
                Console.WriteLine("QTDE SOL. {0} - VL UN R$ {1} - VL TOTAL R$ {2}", c.Quantidade, c.valorProduto, int.Parse(c.Quantidade) * double.Parse(c.valorProduto));
                Console.WriteLine("----------------------------------------------------------------|");
                totalCompras += int.Parse(c.Quantidade) * double.Parse(c.valorProduto); //SOMAR VALOR 
                h += 1;
              }

              Console.WriteLine("########################## TOTAL ##############################\n");
              Console.WriteLine("TOTAL : R$ {0} \nTIPO PAGAMENTO : {1}", totalCompras, "DINHEIRO");
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
              Console.WriteLine("CLIENTE : {0}\nCPF : {1}", cadCliente[0], cadCliente[1]);
              //EXIBIR A LISTA DE PRODUTOS DENTRO DA LISTA

              //EXIBIR A LISTA DE PRODUTOS DENTRO DA LISTA
              Console.WriteLine("############# CUPOM FISCAL #####################\n");
              int h = 0; //CONTADOR PARA PERCORRER A LISTA DE PRODUTOS QUE FORAM ADICIONADOS NO CARRINHO

              foreach(Carrinho c in listaCarrinhoCodigo) {

                Console.WriteLine("----------------------------------------------------------------|");
                Console.WriteLine("COD.PRODUTO: {0} - NOME PRODUTO {1} ", c.cod_produto, c.nomeProduto);
                Console.WriteLine("QTDE SOL. {0} - VL UN R$ {1} - VL TOTAL R$ {2}", c.Quantidade, c.valorProduto, int.Parse(c.Quantidade) * double.Parse(c.valorProduto));
                Console.WriteLine("----------------------------------------------------------------|");
                totalCompras += int.Parse(c.Quantidade) * double.Parse(c.valorProduto); //SOMAR VALOR TOTAL DA COMPRA
                h += 1;
              }
              Console.WriteLine("############# TOTAL #####################\n");
              Console.WriteLine("TOTAL : R$ {0} \nTIPO PAGAMENTO : {1}", totalCompras, "CARTÃO DE CRÉDITO");
              Console.WriteLine("\n#############################################################\n");

            } else {

              Console.WriteLine("Saldo Indisponível!...A compra está sendo cancelada\n");

              loj.setEstornoQuantidade(listaParametro); // ESTORNAR QUANTIDADE DO PRODUTO

            }

          } else { // ELSE DE SEGURANÇA..PELA LÓGICA... NÃO VAI CAIR AQUI, PORÉM CASO OCORRA ALGUMA MUDANÇA DO CÓDIGO ESTA PARTE DO CÓGIDO PODE AJUDAR EM BUSCA DE ERROS

            Console.WriteLine("Opção inválida");
            Console.WriteLine("A compra está sendo cancelada");
            loj.setEstornoQuantidade(listaParametro); // ESTORNAR QUANTIDADE DO PRODUTO

          }

        } else {

          Console.WriteLine("CLIENTE NÃO CADASTRADO!...COMPRA CANCELADA");

        }



    }

  }

} //FIM CLASSE
