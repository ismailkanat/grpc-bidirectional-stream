using Grpc.Core;
using Grpc.Net.Client;
using GrpcChatService;
using System;
using System.Threading.Tasks;

namespace GrpcClient1
{
    class Program
    {
		static async Task Main(string[] args)
		{
			var customer = new Customer
			{
				FontColor = GetRandomChatColor(),
				Id = Guid.NewGuid().ToString(),
				Name = "Earth"
			};

			var channel = GrpcChannel.ForAddress("https://localhost:5001");
			var client = new ChatService.ChatServiceClient(channel);
			var joinCustomerReply = await client.JoinToChatRoomAsync(new JoinRequest
			{
				Customer = customer
			});

			using (var streaming = client.SendMessage(new Metadata { new Metadata.Entry("CustomerName", customer.Name) }))
			{
				var response = Task.Run(async () =>
				{
					while (await streaming.ResponseStream.MoveNext())
					{
						Console.ForegroundColor = Enum.Parse<ConsoleColor>(streaming.ResponseStream.Current.Color);
						Console.WriteLine($"{streaming.ResponseStream.Current.CustomerName}: {streaming.ResponseStream.Current.Message}");
						Console.ForegroundColor = Enum.Parse<ConsoleColor>(customer.FontColor);
					}
				});

				await streaming.RequestStream.WriteAsync(new ChatMessage
				{
					CustomerId = customer.Id,
					Color = customer.FontColor,
					Message = "",
					RoomId = joinCustomerReply.RoomId,
					CustomerName = customer.Name
				});
				Console.ForegroundColor = Enum.Parse<ConsoleColor>(customer.FontColor);
				Console.WriteLine($"Joined the chat as {customer.Name}");

				var line = Console.ReadLine();
				while (!string.Equals(line, "qw!", StringComparison.OrdinalIgnoreCase))
				{
					await streaming.RequestStream.WriteAsync(new ChatMessage
					{
						Color = customer.FontColor,
						CustomerId = customer.Id,
						CustomerName = customer.Name,
						Message = line,
						RoomId = joinCustomerReply.RoomId
					});
					line = Console.ReadLine();
				}
				await streaming.RequestStream.CompleteAsync();
			}
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}

		private static string GetRandomChatColor()
		{
			var colors = Enum.GetValues(typeof(ConsoleColor));
			var rnd = new Random();
			return colors.GetValue(rnd.Next(1, colors.Length - 1)).ToString();
		}

	}
}
