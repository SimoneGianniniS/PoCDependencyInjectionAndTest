using PoCDependecyInjection.BLL.Interface;
using PoCDependecyInjection.BLL.Services;
using PoCDependecyInjection.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region registrazione dei miei services
builder.Services.AddKeyedSingleton<IPrintService, PrintServiceSingleton>("PrintSingl");
builder.Services.AddScoped<IPrintService, PrintService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IDBContext, DBContext>();
//builder.Services.AddTransient<IFormatService, FormatService>(); //servizio facoltativo, non sono obbligato ad implementarlo anche se è richiesto nel costruttore
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //con .net 9 è stato rimosso Swashbuckle.AspNetCore che ci forniva l'interfaccia ui di swagger. il json viene comunque creato da openApi. installo nuget package 
    //Swashbuckle.AspNetCore.SwaggerUI solamente UI (è un visualizzatore del file.json che viene creato dalle openapi) e gli passiamo il path del json aggiungendo
    //il comando UseSwaggerUI()
    //[scalar.aspnetcore è un'altra interfaccia ui da poter usare, a questa non c'è bisogno di passargli l'url del json, la prende di default]
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", app.Environment.ApplicationName);
    });
    //poi per far aprire la pagina del browser come faceva prima devo andare nelle properties del progetto -> launchSettings.json, nella sezione https ed
    //aggiungere questio due attributi nel json
    //"launchBrowser": true,
    //"launchUrl": "swagger",
    
    
    //questo per portare internamente le funzionalità core, la creazione del file json, per non dipendere dall'esterno, poi li ci posso agganciare qualsiasi ui
    //e swshbuckle era da un po che non l'aggiornavano (circa un anno) e per questo presero questa decisione, per evitare di dipendere da un pacchetto che non venisse più aggiornato
}

app.MapGet("api/MinimalEx/{numberOfPerson}", (int numberOfPerson, IDBContext myService) =>
{
    return numberOfPerson + " " + string.Join($", {numberOfPerson} ", myService.GetPersonNames());
}).WithOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
