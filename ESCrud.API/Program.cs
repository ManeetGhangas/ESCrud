using ESCrud.API.Model;
using ESCrud.API.Service;
using Nest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionSettings = new ConnectionSettings(new Uri("http://localhost:9200"))
    .DefaultIndex("esdemo");

var elasticsclient = new ElasticClient(connectionSettings);
builder.Services.AddSingleton(elasticsclient);
//await elasticsearch.CreateIndexIfNotExists("myindex");
builder.Services.AddScoped< IElasticSearchService<MyDocument>, ElasticSearchService<MyDocument>>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
