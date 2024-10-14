Restaurante Senac = new Restaurante();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/adicionar", AdicionarProduto);
app.MapDelete("/remover/{id}", RemoverProduto);
app.MapPut("/atualizar", AtualizarProduto);
app.MapGet("/listaprodutos", ListaProdutos);
app.MapGet("/buscaproduto/{id}", BuscaProduto);

app.Run();

IResult AdicionarProduto (Produto produto){
    var add = Senac.AdicionarProduto(produto);
    return TypedResults.Created("/adicionar", add);
}

IResult RemoverProduto (int id){
    Senac.RemoverProduto(id);
    return TypedResults.Ok();
}

IResult AtualizarProduto (Produto produto){
    var att = Senac.AtualizarProduto(produto);
    if (att == null){
        return TypedResults.NotFound();
    } else {
        return TypedResults.Ok(att);
    }
}

IResult ListaProdutos (){
    var lista = Senac.ListarProdutos();
    return TypedResults.Ok(lista);
}

IResult BuscaProduto (int id){
    var produto = Senac.BuscaProduto(id);
    if (produto == null){
        return TypedResults.NotFound();
    }else{
        return TypedResults.Ok(produto);
    }
}