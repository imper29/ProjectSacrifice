using UnityEngine;

namespace ProjectSacrifice.Messages
{
    /// <summary>
    /// Provides utilities for messages.
    /// </summary>
    public static class MessageUtils
    {
        /// <summary>
        /// Sends a message to the components attached to the target.
        /// </summary>
        /// <typeparam name="TMessage">The message type.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="message">The message.</param>
        public static void SendMessage<TMessage>(this GameObject target, TMessage message) where TMessage : IMessage
        {
            SendMessage(target, ref message);
        }
        /// <summary>
        /// Sends a message to the components attached to the target.
        /// </summary>
        /// <typeparam name="TMessage">The message type.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="message">The message.</param>
        public static void SendMessage<TMessage>(this GameObject target, ref TMessage message) where TMessage : IMessage
        {
            //Send message to generic message listener components.
            foreach (var listener in target.GetComponents<IMessageListener>()) {
                if (message.Canceled)
                    return;
                listener.OnMessageReceived(ref message);
            }
            //Send message to specific message listener components.
            foreach (var listener in target.GetComponents<IMessageListener<TMessage>>()) {
                if (message.Canceled)
                    return;
                listener.OnMessageReceived(ref message);
            }
            //Send message to generic post message listener components.
            foreach (var listener in target.GetComponents<IMessageListenerPost>()) {
                if (message.Canceled)
                    return;
                listener.OnMessageReceivedPost(ref message);
            }
            //Send message to specific post message listener components.
            foreach (var listener in target.GetComponents<IMessageListenerPost<TMessage>>()) {
                if (message.Canceled)
                    return;
                listener.OnMessageReceivedPost(ref message);
            }
        }
    }
}
