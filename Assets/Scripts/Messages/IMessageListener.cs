namespace ProjectSacrifice.Messages
{
    /// <summary>
    /// Implement this interface to receive messages.
    /// </summary>
    public interface IMessageListener
    {
        /// <summary>
        /// This method is invoked when receiving a message.
        /// </summary>
        /// <typeparam name="TMessage">The message type.</typeparam>
        /// <param name="message">The message.</param>
        void OnMessageReceived<TMessage>(ref TMessage message) where TMessage : IMessage;
    }
    /// <summary>
    /// Implement this interface to receive messages of the specified type.
    /// </summary>
    /// <typeparam name="TMessage">The message type.</typeparam>
    public interface IMessageListener<TMessage> where TMessage : IMessage
    {
        /// <summary>
        /// This method is invoked when receiving a message of the specified type.
        /// </summary>
        /// <param name="message">The message.</param>
        void OnMessageReceived(ref TMessage message);
    }
}
