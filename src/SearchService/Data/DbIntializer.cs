using System.Text.Json;
using Microsoft.OpenApi.Writers;
using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;
using SearchService.Services;

namespace SearchService.Data;

public class DbIntializer
{
    public static async Task InitDb(WebApplication app)
    {
        await DB.InitAsync("SearchDb",
        MongoClientSettings.FromConnectionString(app.Configuration
        .GetConnectionString("MongoDbConnection")));

        await DB.Index<Item>()
            .Key(i => i.Make, KeyType.Text)
            .Key(i => i.Model, KeyType.Text)
            .Key(i => i.Color, KeyType.Text)
            .CreateAsync();
        var count = await DB.CountAsync<Item>();
        using var scope = app.Services.CreateScope();
        var httpClient = scope.ServiceProvider.GetRequiredService<AuctionSvcHttpClient>();
        var items = await httpClient.GetItemsForSearchDb();
        Console.WriteLine(items.Count + "returned from auction service");
        if(items.Count>0) await DB.SaveAsync(items);
    }
}
