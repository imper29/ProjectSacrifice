namespace ProjectSacrifice.Messages
{
    /// <summary>
    /// The base for all messages.
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Returns true if the message was canceled.
        /// </summary>
        bool Canceled { get => false; }
    }
}
