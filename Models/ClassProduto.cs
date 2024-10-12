class Produto{
    public string? Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public string Categoria { get; set; }

    public Produto (string id, string nome, double preco, string categoria){
        Id = id;
        Nome = nome;
        Preco = preco;
        Categoria = categoria;
    }
    public Produto (string nome, double preco, string categoria){
        Nome = nome;
        Preco = preco;
        Categoria = categoria;
    }
    public Produto (){
    }
}