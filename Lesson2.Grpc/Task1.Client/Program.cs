using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using Lesson2.Grpc;

var channel = GrpcChannel.ForAddress("https://localhost:7069");
var client = new WeatherService.WeatherServiceClient(channel);
using var call = client.StreamingFromServer(new WeatherStreamRequest
    { CurrentTime = Timestamp.FromDateTimeOffset(DateTimeOffset.Now) });

await foreach (var response in
               call.ResponseStream.ReadAllAsync())
    Console.WriteLine(
        $"{response.Time} = {response.WeatherValue} {response.WeatherUnits}");