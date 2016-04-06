using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;

namespace SignalRDemo.WebHost.Hubs
{
    public class ChatHub : Hub
    {
        private static readonly List<ChatClient> _connectedClientsList = new List<ChatClient>();

        public void JoinChatroom( ChatClient newChatClient )
        {
            // Add client & broadcast new chat user message to all clients connected to this Hub.
            _connectedClientsList.Add( newChatClient );
            Clients.All.addChatMessage( newChatClient.ChatUserName + " has joined the Chatroom!" );

            // Organizing clients in groups ..
            Groups.Add( Context.ConnectionId, "ChatRoom A" );
        }

        public void LeaveChatRoom( ChatClient chatClientToRemove )
        {
            // Clean-up.
            _connectedClientsList.Remove( chatClientToRemove );
            Clients.All.addChatMessage( chatClientToRemove.ChatUserName + " has left the Chatroom!" );

            Groups.Remove( Context.ConnectionId, "ChatRoom A" );
        }

        public void PushChatMessageToClients( string message )
        {
            // Push to all connected clients.
            Clients.All.addChatMessage( message );

            // Communicate to a Group.
            // Clients.Group("ChatRoom A").addChatMessage(message);

            // Invoke a method on the calling client only.
            // Clients.Caller.addChatMessage(message);

            // Similar to above, the more verbose way.
            // Clients.Client(Context.ConnectionId).addChatMessage(message);            
        }
    }
}
