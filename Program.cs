Restaurante Senac = new Restaurante();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/adicionar", AdicionarProduto);
app.MapDelete("/remover/{id}", RemoverProduto);
app.MapPut("/atualizar", AtualizarProduto);
app.MapGet("/listaprodutos", ListaProdutos);
app.MapGet("/buscarproduto/{id}", BuscarProduto);

app.Run();

IResult AdicionarProduto (Produto produto){
    DataBase dataBase = new DataBase();
    var add = dataBase.AdicionarProduto(produto);
    
    if(add > 0){
        return TypedResults.Created("/adicionar", add);
    }else{
        return TypedResults.BadRequest();
    }
}

IResult RemoverProduto (int id){
    DataBase dataBase = new DataBase();
    var delete = dataBase.RemoverProduto(id);
    
    if(delete > 0){
        return TypedResults.Ok();
    }
    if(delete == 0){
        return TypedResults.NotFound();
    }else{
        return TypedResults.BadRequest();
    }
}

IResult AtualizarProduto (Produto produto){
    DataBase dataBase = new DataBase();
    var update = dataBase.AtualizarProduto(produto);

    if(update > 0){
        return TypedResults.Ok();
    }
    if(update == 0){
        return TypedResults.NotFound();
    }else{
        return TypedResults.BadRequest();
    }
}

IResult ListaProdutos (){
    DataBase dataBase = new DataBase();
    var produtos = dataBase.ListaProdutos();
    
    return TypedResults.Ok(produtos);
}

IResult BuscarProduto (int id){
     DataBase dataBase = new DataBase();
    var produto = dataBase.BuscarProduto(id);

    if (produto == null){
        return TypedResults.NotFound();
    }else{
        return TypedResults.Ok(produto);
    }
}