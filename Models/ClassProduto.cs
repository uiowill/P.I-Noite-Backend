class Produto{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Valor { get; set; }
    public string Categoria { get; set; }

    public Produto (int id, string nome, double valor, string categoria){
        Id = id;
        Nome = nome;
        Valor = valor;
        Categoria = categoria;
    }
    public Produto (string nome, double preco, string categoria){
        Nome = nome;
        Valor = preco;
        Categoria = categoria;
    }
    public Produto (){
    }
}