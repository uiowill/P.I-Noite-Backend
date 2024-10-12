Restaurante Senac = new Restaurante();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/adicionar", AdicionarProduto);

app.Run();

IResult AdicionarProduto (Produto produto){
    var add = Senac.AdicionarProduto(produto);
    return TypedResults.Created("/adicionar", add);
}