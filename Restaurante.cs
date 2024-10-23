using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

class Restaurante{
    List<Produto> produtos =new List<Produto>();

    public Restaurante (){
    } 

// --------------CRUDE----------------

//-------ADD----------
public Produto AdicionarProduto (Produto produto){
    produtos.Add(produto);
    return produtos[produtos.Count -1];
}

//-----REMOVE---------
public void RemoverProduto (int id){
    for (int i = 0; i < produtos.Count; i++)
    {
        if (produtos[i].Id == id){
            produtos.RemoveAt(i);
        }
    }
}
//-----ATUALIZAR-----
public Produto AtualizarProduto (Produto produto){
    var produtoAtualizado = new Produto();
    for (int i = 0; i < produtos.Count; i++)
    {
        if (produtos[i].Id == produto.Id){
            produtos[i].Nome = produto.Nome;
            produtos[i].Categoria = produto.Categoria;
            produtos[i].Valor = produto.Valor;
            produtoAtualizado = produtos[i];
            return produtoAtualizado;
        }
    }
    return null;
}
//-----LISTA DE PRODUTOS -------
public List<Produto> ListarProdutos (){
    return produtos;
}
//----BUSCA PRODUTO------
public Produto BuscaProduto (int id){
    for(int i = 0 ; i < produtos.Count; i++){
        if(produtos[i].Id == id){
            return produtos[i];
        }
    }
    return null;
}
}