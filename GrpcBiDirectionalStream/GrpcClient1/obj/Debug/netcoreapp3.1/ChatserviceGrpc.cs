// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: chatservice.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcChatService {
  public static partial class ChatService
  {
    static readonly string __ServiceName = "greet.ChatService";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::GrpcChatService.JoinRequest> __Marshaller_greet_JoinRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcChatService.JoinRequest.Parser));
    static readonly grpc::Marshaller<global::GrpcChatService.JoinResponse> __Marshaller_greet_JoinResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcChatService.JoinResponse.Parser));
    static readonly grpc::Marshaller<global::GrpcChatService.ChatMessage> __Marshaller_greet_ChatMessage = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcChatService.ChatMessage.Parser));

    static readonly grpc::Method<global::GrpcChatService.JoinRequest, global::GrpcChatService.JoinResponse> __Method_JoinToChatRoom = new grpc::Method<global::GrpcChatService.JoinRequest, global::GrpcChatService.JoinResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "JoinToChatRoom",
        __Marshaller_greet_JoinRequest,
        __Marshaller_greet_JoinResponse);

    static readonly grpc::Method<global::GrpcChatService.ChatMessage, global::GrpcChatService.ChatMessage> __Method_SendMessage = new grpc::Method<global::GrpcChatService.ChatMessage, global::GrpcChatService.ChatMessage>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "SendMessage",
        __Marshaller_greet_ChatMessage,
        __Marshaller_greet_ChatMessage);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcChatService.ChatserviceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for ChatService</summary>
    public partial class ChatServiceClient : grpc::ClientBase<ChatServiceClient>
    {
      /// <summary>Creates a new client for ChatService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public ChatServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ChatService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public ChatServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected ChatServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected ChatServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::GrpcChatService.JoinResponse JoinToChatRoom(global::GrpcChatService.JoinRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return JoinToChatRoom(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::GrpcChatService.JoinResponse JoinToChatRoom(global::GrpcChatService.JoinRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_JoinToChatRoom, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::GrpcChatService.JoinResponse> JoinToChatRoomAsync(global::GrpcChatService.JoinRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return JoinToChatRoomAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::GrpcChatService.JoinResponse> JoinToChatRoomAsync(global::GrpcChatService.JoinRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_JoinToChatRoom, null, options, request);
      }
      public virtual grpc::AsyncDuplexStreamingCall<global::GrpcChatService.ChatMessage, global::GrpcChatService.ChatMessage> SendMessage(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendMessage(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncDuplexStreamingCall<global::GrpcChatService.ChatMessage, global::GrpcChatService.ChatMessage> SendMessage(grpc::CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_SendMessage, null, options);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override ChatServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ChatServiceClient(configuration);
      }
    }

  }
}
#endregion
