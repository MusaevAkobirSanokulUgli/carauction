
using Contracts;
using MassTransit;

namespace AuctionService.Consumers;

public class AuctionCreatedFaultConsumer : IConsumer<Fault<AuctionCreated>>
{
    public async Task Consume(ConsumeContext<Fault<AuctionCreated>> context)
    {
        Console.WriteLine("--> Consuming Faulted AuctionCreated event: " + context.Message.Message.Id);
        var exception = context.Message.Exceptions.First();
        if (exception.ExceptionType == "System.ArgumentException")
        {
            context.Message.Message.Model = "FooBar";
            //After changing the fault we will republis it
            await context.Publish(context.Message.Message);
        }
        else
        { 
            Console.WriteLine("--> Faulted AuctionCreated event: " + context.Message.Message.Id + " with exception: " + exception.Message);
        }
            
    }
}
