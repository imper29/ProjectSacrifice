using ProjectSacrifice.Messages;
using UnityEngine;

namespace ProjectSacrifice
{
    [RequireComponent(typeof(Team))]
    public class Offense : MonoBehaviour, IMessageListener<Offense.MsgAttack>, IMessageListenerPost<Offense.MsgAttack>
    {
        [SerializeField] private Statistic m_Strength;
        /// <summary>
        /// The offensive strength.
        /// </summary>
        public ref Statistic Strength => ref m_Strength;

        public void OnMessageReceived(ref MsgAttack message)
        {
            //Cancel attacks if attacking team members with friendly fire off.
            Team defenderTeam = message.Defender.GetComponent<Team>();
            if (!defenderTeam.Current.FriendlyFire && defenderTeam.Current == GetComponent<Team>().Current)
                message.Cancel();
        }
        public void OnMessageReceivedPost(ref MsgAttack message)
        {
            //Notify the object that is being attacked that it is being attacked.
            message.Defender.gameObject.SendMessage(new Defense.MsgDefend(this));
        }

        /// <summary>
        /// The message sent when attacking.
        /// </summary>
        public struct MsgAttack : IMessage
        {
            private Defense m_Defender;
            private bool m_Canceled;

            /// <summary>
            /// The defender.
            /// </summary>
            public Defense Defender => m_Defender;
            public bool Canceled => m_Canceled;

            public MsgAttack(Defense defender)
            {
                m_Canceled = false;
                m_Defender = defender;
            }

            /// <summary>
            /// Cancels the message.
            /// </summary>
            public void Cancel()
            {
                m_Canceled = true;
            }
        }
    }
}
