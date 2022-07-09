using ProjectSacrifice.Messages;
using UnityEngine;

namespace ProjectSacrifice
{
    [RequireComponent(typeof(Team))]
    public class Defense : MonoBehaviour, IMessageListenerPost<Defense.MsgDefend>
    {
        [SerializeField] private Statistic m_Strength;
        /// <summary>
        /// The defensive strength.
        /// </summary>
        public ref Statistic Strength => ref m_Strength;
        
        public void OnMessageReceivedPost(ref MsgDefend message)
        {
            //Calculate damage taken and reduce health by that amount.
            float damage = Strength.Result - message.Attacker.Strength.Result;
            if (damage < 0f)
                GetComponent<Health>().Modify(damage, message.Attacker.gameObject);
        }
        
        /// <summary>
        /// The message sent when defending.
        /// </summary>
        public struct MsgDefend : IMessage
        {
            private Offense m_Attacker;

            /// <summary>
            /// The attacker.
            /// </summary>
            public Offense Attacker => m_Attacker;

            public MsgDefend(Offense attacker)
            {
                m_Attacker = attacker;
            }
        }
    }
}
