using Grpc.Core;
namespace GrpcServer;
public class GreeterService : Greeter.GreeterBase
{
    /// <summary>
    /// Simple Method answer HelloRequest 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns>Message with <paramref name="request"/>.Name</returns>
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {

        return Task.FromResult(new HelloReply
        {
            Message = $"Hello {request.Name}"
        });
    }
}
