using System;
using System.Collections.Generic; //PARA UTILIZAR LIST
  
class Loja{


    public List<int> listaCodigo = new List<int>{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50};


     private List<string> nomeProduto = new List<string>{"10 COLOUR SPACEBOY PEN","SET/10 BLUE POLKADOT PARTY CANDLES","POTTING SHED SOW \'N\' GROW SET","PAPERWEIGHT KINGS CHOICE ","WOVEN BERRIES CUSHION COVER ","WHITE/PINK MINI CRYSTALS NECKLACE","SET/3 RED GINGHAM ROSE STORAGE BOX","MAGNETS PACK OF 4 VINTAGE LABELS ","WHITE CHRYSANTHEMUMS ART FLOWER","WHITE FRANGIPANI NECKLACE","SILVER FABRIC MIRROR","PINK  HONEYCOMB PAPER FAN","PINK BOUDOIR T-LIGHT HOLDER","BLACK CHERRY LIGHTS","GLASS CAKE COVER AND PLATE","DECORATION SITTING BUNNY","ANTIQUE MID BLUE FLOWER EARRINGS","VINTAGE LEAF CHOPPING BOARD  ","SNACK TRAY I LOVE LONDON","DECROTIVEVINTAGE COFFEE GRINDER BOX","IVORY ENCHANTED FOREST PLACEMAT","ANTIQUE SILVER TEA GLASS ETCHED","BLUE FELT HANGING HEART W FLOWER","PACK OF 12 COLOURED PENCILS","CLAM SHELL SMALL ","TWO DOOR CURIO CABINET","GREEN GOOSE FEATHER CHRISTMAS TREE ","MULTICOLOUR HONEYCOMB FAN","GREEN DROP EARRINGS W BEAD CLUSTER","BOTANICAL LILY GREETING CARD","SILVER DROP EARRINGS WITH FLOWER","CANDY SPOT BUNNY","WHITE WITH BLACK CATS PLATE","VEGETABLE MAGNETIC  SHOPPING LIST","FLOWER PURPLE CLOCK WITH SUCKER","VINTAGE CHRISTMAS GIFT SACK","found box","SET 10 CARDS SNOWY SNOWDROPS  17100","JUMBO SHOPPER VINTAGE RED PAISLEY","SET OF 4 ENGLISH ROSE PLACEMATS","FELTCRAFT HAIRBAND RED AND BLUE","BLUE GIANT GARDEN THERMOMETER","VINTAGE PAISLEY STATIONERY SET","SET OF 4 NAPKIN CHARMS CUTLERY","CARAVAN SQUARE TISSUE BOX","FRENCH PAISLEY CUSHION COVER ","GOLD FISHING GNOME","PINK BABY BUNTING","DROP DIAMANTE EARRINGS CRYSTAL","RED FLOCK LOVE HEART PHOTO FRAME"};

     public List<double> preco = new List<double>{10.65,9.13,0.66,175.69,15.5,206.4,194.7,3.26,2019.05,109.19,404.49,157.08,183.2,124.87,888.42,736.38,0.84,0.07,2.4,24.96,9.72,160.0,18.62,14.75,2.82,10.2,29.74,19.96,80.46,183.09,152.19,49.13,8.0,138.46,135.08,2.41,10.82,425.14,2028.25,5.13,20.38,5.76,199.33,192.44,2.62,201.84,170.92,0.0,0.87,537.83};
  
     public List<int>quantidade = new List<int>{110,29,84,17,19,28,19,37,201,109,40,19,18,12,88,73,37,42,28,24,96,160,18,14,27,10,29,19,80,183,152,49,86,138,135,23,15,42,22,53,20,50,199,192,24,201,170,30,20,537};
	

  public void setQuantidade(string cod, string quantidade) {

    for (int i = 0; i < nomeProduto.Count; i++) {

      if ((listaCodigo[i]) == int.Parse(cod)) {

        this.quantidade[i] = (this.quantidade[i] - int.Parse(quantidade));

      }

    }

  }

  //FUNÇÃO ESTORNAR QUANTIDADE DE PRODUTOS
  public void setEstornoQuantidade(List < Carrinho > lista) {

    foreach(Carrinho c in lista) {

      Console.WriteLine(c.cod_produto + " " + c.Quantidade);

      for (int j = 0; j < nomeProduto.Count; j++) {

        if ((listaCodigo[j]) == int.Parse(c.cod_produto)) {

          Console.WriteLine("ESTORNO DE PRODUTOS");
          Console.WriteLine("SALDO ATUAL :{0}\n QUANTIDADE PARA ESTORNO : {1}\n SALTO ATUALIZADO : {2}", this.quantidade[j], int.Parse(c.Quantidade), (this.quantidade[j] + int.Parse(c.Quantidade)));

          this.quantidade[j] = (this.quantidade[j] + int.Parse(c.Quantidade)); // AQUI FAZ O ESTORNO DO PRODUTO

        }

      }

    }

  }

  public void descricao() {

    /*Console.WriteLine("A lista tem " + nomeProduto.Count + " itens:");
    //Imprime cada item da lista
    nomeProduto.ForEach(i => Console.WriteLine(i));


  } 

     foreach (string item in nomeProduto){
                Console.WriteLine(item);
        }//FIM foreach
*/
    int cont = 0;
    while (cont < nomeProduto.Count) {

      Console.WriteLine(" CODIGO PRODUTO : {0} - - NOME : {1}  -- PREÇO : {2} -- QUANTIDADE : {3}", listaCodigo[cont], nomeProduto[cont], preco[cont], quantidade[cont]);

      cont += 1;

    }

  } // FIM FUNÇÃO DESCRICAO

  //FUNÇÃO PARA VERIFICAR SE EXISTE O PRODUTO NA LISTA DO MERCADO
  // LISTA DE TIPO DE RETORNO:
  // 1 - EXISTE PRODUTO E EXISTE QUANTIDADE DISPONÍVEL
  // 2 - EXISTE PRODUTO, PORÉM NÃO TEM QUANTIDADE DISPONÍVEL
  // 3 - NÃO EXISTE PRODUTO E NATURALMENTE NÃO EXISTE QUANTIDADE
  public int validaProduto(string cod, string qtde) {

    int valor = 0;

    for (int i = 0; i < nomeProduto.Count; i++) {

 
      if ((listaCodigo[i]) == int.Parse(cod)) { //VERIFICAR SE EXISTE O CÓDIGO DENTRO DA LISTA DE CÓDIGOS DE PRODUTOS

        if ((quantidade[i]) > int.Parse(qtde)) {

          return 1; //EXISTE PRODUTO E EXISTE QUANTIDADE DISPONÍVEL

        } else {

          return 2; // 2 - EXISTE PRODUTO, PORÉM NÃO TEM QUANTIDADE DISPONÍVEL

        }

      } else {
        valor = 3;

      }

    } // FIM FOR VALIDA PRODUTO

    return valor;

  }

  // A CADA SELEÇÃO DE PRODUTO, ESTE RETORNO ENVIARÁ UM VETOR COM TODOS OS DADOS DO PRODUTO PARA A LISTA DE CARRINHO
  public string[] retornoDadosProduto(string cod) {

    string[] spMsg = new string[4]; //CRIAR VETOR DE TAMANHO 4

    for (int i = 0; i < nomeProduto.Count; i++) {

      if ((listaCodigo[i]) == int.Parse(cod)) {

        spMsg[0] = (listaCodigo[i]).ToString();
        spMsg[1] = nomeProduto[i];
        spMsg[2] = (quantidade[i]).ToString();
        spMsg[3] = (preco[i]).ToString();
        break;
      }

    }

    return spMsg;
  }

  // FIM FUNÇÃO VALIDAPRODUTO

} //FIM CLASSE
