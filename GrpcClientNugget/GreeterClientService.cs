namespace GrpcClientNugget;
using Grpc.Net.Client;
using GrpcService;
/// <summary>
/// Service Used for comunication with the GreeterService Server
/// </summary>
public class GreeterClientService
{
    private readonly string _url;
    /// <summary>
    /// ctor to acces value of url seeded through configuration
    /// </summary>
    /// <param name="grpcClientConfiguration"></param>
    public GreeterClientService(GrpcClientConfiguration grpcClientConfiguration)
    {
        _url = grpcClientConfiguration.Url;
    }
    /// <summary>
    /// Calls the SayHello rpc with an HelloRequest with a name param.
    /// Url param is needed to buil the Channel for this rpc communication.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public async Task<string> RequestGreet(string name)
    {
        AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

        using var channel = GrpcChannel.ForAddress(_url);

        var client = new Greeter.GreeterClient(channel);

        var reply = await client.SayHelloAsync(new HelloRequest { Name = name });

        return reply.Message;
    }
}
