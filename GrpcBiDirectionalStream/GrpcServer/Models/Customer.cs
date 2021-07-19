using Grpc.Core;
using GrpcChatService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Models
{
	public class Customer
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string FontColor { get; set; }
		public IAsyncStreamWriter<ChatMessage> Stream { get; set; }
	}
}
