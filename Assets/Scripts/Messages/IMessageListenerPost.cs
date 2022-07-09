namespace ProjectSacrifice.Messages
{
    /// <summary>
    /// Implement this interface to receive messages after <see cref="IMessageListener"/> and <see cref="IMessageListener{TMessage}"/>.
    /// </summary>
    public interface IMessageListenerPost
    {
        /// <summary>
        /// This method is invoked when receiving a message.
        /// </summary>
        /// <typeparam name="TMessage">The message type.</typeparam>
        /// <param name="message">The message.</param>
        void OnMessageReceivedPost<TMessage>(ref TMessage message) where TMessage : IMessage;
    }
    /// <summary>
    /// Implement this interface to receive messages of the specified type after <see cref="IMessageListener"/> and <see cref="IMessageListener{TMessage}"/>.
    /// </summary>
    /// <typeparam name="TMessage">The message type.</typeparam>
    public interface IMessageListenerPost<TMessage> where TMessage : IMessage
    {
        /// <summary>
        /// This method is invoked when receiving a message of the specified type.
        /// </summary>
        /// <param name="message">The message.</param>
        void OnMessageReceivedPost(ref TMessage message);
    }
}
