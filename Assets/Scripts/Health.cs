using ProjectSacrifice.Messages;
using UnityEngine;

namespace ProjectSacrifice
{
    public class Health : MonoBehaviour, IMessageListenerPost<Health.MsgDeath>
    {
        [SerializeField] private float m_Hp;
        [SerializeField] private Statistic m_HpMaximum;

        /// <summary>
        /// The health.
        /// </summary>
        public float Hp => m_Hp;
        /// <summary>
        /// The maximum health.
        /// </summary>
        public ref Statistic HpMaximum => ref m_HpMaximum;

        public void Modify(float amount, GameObject cause)
        {
            m_Hp += amount;
            if (m_Hp > m_HpMaximum.Result)
                m_Hp = m_HpMaximum.Result;
            else if (m_Hp <= 0f) {
                m_Hp = 0f;
                gameObject.SendMessage(new MsgDeath(cause));
            }
        }

        public void OnMessageReceivedPost(ref MsgDeath message)
        {
            Destroy(gameObject);
        }

        public struct MsgDeath : IMessage
        {
            /// <summary>
            /// The reason this message was sent.
            /// </summary>
            public GameObject cause;

            public MsgDeath(GameObject cause)
            {
                this.cause = cause;
            }
        }
    }
}
