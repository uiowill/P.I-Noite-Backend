using System.Globalization;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.Authentication;

class DataBase{
    string stringConexao = "server=localhost; uid=root; pwd=1234; database=Mysql";

    public int AdicionarProduto(Produto produto){
        var preco = produto.Preco.ToString(new NumberFormatInfo(){NumberDecimalSeparator = "."});
        MySqlConnection conexao;
        string querry = $"INSERT INTO cardapiosenac.produtos(nome, valor, categoria) VALUE('{produto.Nome}', {preco}, '{produto.Categoria}');";

        try{
            conexao = new MySqlConnection(stringConexao);
            conexao.Open();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = conexao;
            comando.CommandText = querry;
            int insert = comando.ExecuteNonQuery();
            return insert; //Possiveis retornos 0 - não adicionado | > 0 - adicionado; 
        }
        catch(MySqlException ex){
            Console.WriteLine(ex);
            return -1;
        }
    }

    public int RemoverProduto(int id){
        MySqlConnection conexao;
        string querry = $"DELETE FROM cardapiosenac.produtos WHERE id = {id};";
        
        try{
            conexao = new MySqlConnection(stringConexao);
            conexao.Open();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = conexao;
            comando.CommandText = querry;
            int remover = comando.ExecuteNonQuery();
            return remover;
    } catch(MySqlException ex){
        Console.WriteLine(ex);
        return -1;
    }
}

    public int AtualizarProduto(Produto produto){
        var preco = produto.Preco.ToString(new NumberFormatInfo(){NumberDecimalSeparator = "."});
        MySqlConnection conexao;
        string querry = $"UPDATE cardapiosenac.produtos SET  nome = '{produto.Nome}', valor = {preco}, categoria = '{produto.Categoria}' WHERE id = {produto.Id};";

        try{
            conexao = new MySqlConnection(stringConexao);
            conexao.Open();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = conexao;
            comando.CommandText = querry;
            int remover = comando.ExecuteNonQuery();
            return remover;
        }catch(MySqlException ex){
            Console.WriteLine(ex);
            return -1;
        }
    }

    public List<Produto> ListaProdutos(){
        List<Produto> produtos = new List<Produto>();
        MySqlConnection conexao;
        string querry = "SELECT * FROM cardapiosenac.produtos;";
        
        try{
            conexao = new MySqlConnection(stringConexao);
            conexao.Open();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = conexao;
            comando.CommandText = querry;
            MySqlDataReader reader = comando.ExecuteReader();
        while(reader.Read()){
            int id = reader.GetInt32("id");
            string nome = reader.GetString("nome");
            double valor = reader.GetDouble("valor");
            string categoria = reader.GetString("categoria");

            Produto produto = new Produto(id,nome, valor, categoria);
            produtos.Add(produto);
        }
    }catch(MySqlException ex)
    {
        Console.WriteLine(ex);
    }
    return produtos;
    }

    public Produto BuscarProduto(int id){
        MySqlConnection conexao;
        string querry = $"SELECT * FROM cardapiosenac.produtos WHERE id = '{id}';";

        try{
             conexao = new MySqlConnection(stringConexao);
            conexao.Open();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = conexao;
            comando.CommandText = querry;
            MySqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            Produto produto = new Produto(reader.GetInt32("id"),reader.GetString("nome"),
            reader.GetDouble("valor"),reader.GetString("categoria"));

            return produto;
        }catch(MySqlException ex)
    {
        Console.WriteLine(ex);
        return null;
    }
    }
}