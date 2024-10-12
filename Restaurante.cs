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
}