using System;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers;

public class AuctionDeletedConsumer: IConsumer<AuctionDeleted>
{
    public async Task Consume(ConsumeContext<AuctionDeleted> context)
    {
        Console.WriteLine("--> Consuming AuctionDeleted event" + context.Message.Id);
        var result = await DB.DeleteAsync<Item>(context.Message.Id);
        if(!result.IsAcknowledged)
        {
            Console.WriteLine("--> Could not delete Auction with Id: " + context.Message.Id);
            throw new MessageException(typeof(AuctionDeleted),"Problem deleting action with Id: " + context.Message.Id);
        }
    }
}

